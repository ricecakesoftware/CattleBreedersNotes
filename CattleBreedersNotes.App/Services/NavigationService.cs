using RiceCakeSoftware.CattleBreedersNotes.App.Views;

namespace RiceCakeSoftware.CattleBreedersNotes.App.Services;

public class NavigationService : INavigationService
{
    public void GoToLoginPage() => Shell.Current.GoToAsync($"//{nameof(LoginPage)}");

    public void GoToDashboardPage() => Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
}
