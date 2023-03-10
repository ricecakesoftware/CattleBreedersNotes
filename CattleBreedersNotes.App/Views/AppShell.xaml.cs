using RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

namespace RiceCakeSoftware.CattleBreedersNotes.App.Views;

public partial class AppShell
{
    public AppShell(AppShellViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
