using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;
using RiceCakeSoftware.CattleBreedersNotes.App.Services;
using RiceCakeSoftware.CattleBreedersNotes.Commons;

namespace RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

public partial class AuthorizedViewModel : ViewModelBase
{
    public AuthorizedViewModel(IAlertService alertService, INavigationService navigationService, IConfiguration configuration, Certification certification)
        : base(alertService, navigationService, configuration, certification)
    {
    }

    [RelayCommand]
    public void Logout()
    {
        NavigationService.GoToLoginPage();
    }
}
