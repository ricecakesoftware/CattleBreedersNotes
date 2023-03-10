using Microsoft.Extensions.Configuration;
using RiceCakeSoftware.CattleBreedersNotes.App.Services;
using RiceCakeSoftware.CattleBreedersNotes.Commons;

namespace RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

public partial class UnauthorizedViewModel : ViewModelBase
{
    public UnauthorizedViewModel(IAlertService alertService, INavigationService navigationService, IConfiguration configuration, Certification certification)
        : base(alertService, navigationService, configuration, certification)
    {
    }
}
