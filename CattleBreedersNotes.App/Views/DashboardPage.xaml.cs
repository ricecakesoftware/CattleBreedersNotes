using RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

namespace RiceCakeSoftware.CattleBreedersNotes.App.Views;

public partial class DashboardPage
{
    public DashboardPage(DashboardPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
