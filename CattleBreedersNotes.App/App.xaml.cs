using RiceCakeSoftware.CattleBreedersNotes.App.Views;

namespace RiceCakeSoftware.CattleBreedersNotes.App;

public partial class App : Application
{
    public App(AppShell shell)
    {
        InitializeComponent();
        MainPage = shell;
    }
}
