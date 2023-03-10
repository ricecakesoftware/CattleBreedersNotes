using Microsoft.Extensions.Configuration;
using RiceCakeSoftware.CattleBreedersNotes.App.Services;
using RiceCakeSoftware.CattleBreedersNotes.Commons;

namespace RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

public partial class SettingsPageViewModel : AuthorizedViewModel
{
    public SettingsPageViewModel(IAlertService alertService, INavigationService navigationService, IConfiguration configuration, Certification certification)
        : base(alertService, navigationService, configuration, certification)
    {
        HeaderTitle = "設定";
    }
}
