using RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

namespace RiceCakeSoftware.CattleBreedersNotes.App.Views;

public partial class SettingsPage
{
    public SettingsPage(SettingsPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
