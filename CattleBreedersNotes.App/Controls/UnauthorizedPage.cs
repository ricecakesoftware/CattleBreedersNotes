namespace RiceCakeSoftware.CattleBreedersNotes.App.Controls;

public class UnauthorizedPage : ContentPage
{
    public static readonly BindableProperty HeaderTitleProperty = BindableProperty.Create(nameof(HeaderTitle), typeof(string), typeof(UnauthorizedPage), string.Empty);
    public string HeaderTitle
    {
        get => (string)GetValue(HeaderTitleProperty);
        set => SetValue(HeaderTitleProperty, value);
    }
}
