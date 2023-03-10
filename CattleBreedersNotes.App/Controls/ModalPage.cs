using System.Windows.Input;

namespace RiceCakeSoftware.CattleBreedersNotes.App.Controls;

public class ModalPage : ContentPage
{
    public static readonly BindableProperty HeaderTitleProperty = BindableProperty.Create(nameof(HeaderTitle), typeof(string), typeof(ModalPage), string.Empty);
    public string HeaderTitle
    {
        get => (string)GetValue(HeaderTitleProperty);
        set => SetValue(HeaderTitleProperty, value);
    }

    public static readonly BindableProperty BackCommandProperty = BindableProperty.Create(nameof(BackCommand), typeof(ICommand), typeof(ModalPage), null);
    public ICommand BackCommand
    {
        get => (ICommand)GetValue(BackCommandProperty);
        set => SetValue(BackCommandProperty, value);
    }
}
