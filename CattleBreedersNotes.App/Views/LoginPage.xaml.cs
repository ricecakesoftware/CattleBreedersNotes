using RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

namespace RiceCakeSoftware.CattleBreedersNotes.App.Views;

public partial class LoginPage
{
    public LoginPage(LoginPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
