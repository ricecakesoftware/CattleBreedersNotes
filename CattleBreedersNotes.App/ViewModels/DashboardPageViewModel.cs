using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using RiceCakeSoftware.CattleBreedersNotes.App.Services;
using RiceCakeSoftware.CattleBreedersNotes.Commons;

namespace RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

public partial class DashboardPageViewModel : AuthorizedViewModel
{
    public DashboardPageViewModel(IAlertService alertService, INavigationService navigationService, IConfiguration configuration, Certification certification)
        : base(alertService, navigationService, configuration, certification)
    {
        HeaderTitle = "ダッシュボード";
    }

    [RelayCommand]
    private void Appearing()
    {
        IsBusy = true;
    }

    [RelayCommand]
    private async void Refresh()
    {
        IsBusy = true;
        await Task.Delay(1000);
        IsBusy = false;
    }
}
