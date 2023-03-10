using RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

namespace RiceCakeSoftware.CattleBreedersNotes.App.Views;

public partial class CowsPage
{
    public CowsPage(CowsPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
