using System.Windows.Input;

namespace RiceCakeSoftware.CattleBreedersNotes.App.Controls;

public class AuthorizedPage : ContentPage
{
    public static readonly BindableProperty HeaderTitleProperty = BindableProperty.Create(nameof(HeaderTitle), typeof(string), typeof(AuthorizedPage), string.Empty);
    public string HeaderTitle
    {
        get => (string)GetValue(HeaderTitleProperty);
        set => SetValue(HeaderTitleProperty, value);
    }

    public static readonly BindableProperty LogoutCommandProperty = BindableProperty.Create(nameof(LogoutCommand), typeof(ICommand), typeof(AuthorizedPage), null);
    public ICommand LogoutCommand
    {
        get => (ICommand)GetValue(LogoutCommandProperty);
        set => SetValue(LogoutCommandProperty, value);
    }
}
