using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Configuration;
using RiceCakeSoftware.CattleBreedersNotes.App.Models;
using RiceCakeSoftware.CattleBreedersNotes.App.Services;
using RiceCakeSoftware.CattleBreedersNotes.Commons;

namespace RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    protected IAlertService AlertService { get; private set; }
    protected INavigationService NavigationService { get; private set; }
    protected AppSettings AppSettings { get; private set; }
    protected Certification Certification { get; private set; }

    [ObservableProperty]
    private string _headerTitle = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    public bool IsNotBusy => !_isBusy;

    public ViewModelBase(IAlertService alertService, INavigationService navigationService, IConfiguration configuration, Certification certification)
    {
        AlertService = alertService;
        NavigationService = navigationService;
        AppSettings = configuration.Get<AppSettings>();
        Certification = certification;
    }
}
