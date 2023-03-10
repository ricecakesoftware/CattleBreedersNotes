using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using RiceCakeSoftware.CattleBreedersNotes.App.Services;
using RiceCakeSoftware.CattleBreedersNotes.Commons;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

public partial class LoginPageViewModel : UnauthorizedViewModel
{
    private readonly HttpClient _client;
    private string _xsrfToken = string.Empty;

    [ObservableProperty]
    private string _email = string.Empty;
    [ObservableProperty]
    private string _password = string.Empty;

    public LoginPageViewModel(IAlertService alertService, INavigationService navigationService, IConfiguration configuration, Certification certification, HttpClient client)
        : base(alertService, navigationService, configuration, certification)
    {
        _client = client;
        HeaderTitle = "ログイン";
    }

    [RelayCommand]
    private async void Appearing()
    {
        try
        {
            IsBusy = true;
            Email = Preferences.Get("Email", string.Empty);
            Password = Preferences.Get("Password", string.Empty);
            _xsrfToken = string.Empty;
            HttpRequestMessage request = new(HttpMethod.Get, $"{AppSettings.ApiUrl}/sessions");
            request.Headers.Add("access_token", AppSettings.AccessToken);
            HttpResponseMessage response = await _client.SendAsync(request);
            _xsrfToken = response.Headers.SingleOrDefault((header) => header.Key == "Set-Cookie").Value.FirstOrDefault((value) => value.StartsWith("XSRF-TOKEN="))?.Split("=")[1]?.Split("; ")[0] ?? string.Empty;
        }
        catch (Exception ex)
        {
            await AlertService.DisplayAlertAsync("エラー", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async void Login()
    {
        try
        {
            IsBusy = true;
            string password = string.Join(string.Empty, SHA256.HashData(Encoding.UTF8.GetBytes(Password)).Select(x => $"{x:x2}"));
            HttpRequestMessage request = new(HttpMethod.Post, $"{AppSettings.ApiUrl}/sessions");
            request.Headers.Add("X-XSRF-TOKEN", _xsrfToken);
            request.Content = new StringContent($"{{\"Email\": \"{Email}\", \"Password\": \"{password}\"}}", Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jwt = (JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync()) ?? new())["token"];
                Certification.Jwt = jwt;
                NavigationService.GoToDashboardPage();
            }
            else
            {
                await AlertService.DisplayAlertAsync("エラー", "認証に失敗しました。", "OK");
                IsBusy = false;
            }
        }
        catch (Exception ex)
        {
            await AlertService.DisplayAlertAsync("エラー", ex.Message, "OK");
            IsBusy = false;
        }
        finally
        {
            Preferences.Set("Email", Email);
            Preferences.Set("Password", Password);
        }
    }
}
