namespace RiceCakeSoftware.CattleBreedersNotes.App.Services;

public class AlertService : IAlertService
{
    public Task DisplayAlertAsync(string title, string message, string cancel)
    {
        return Shell.Current.DisplayAlert(title, message, cancel);
    }

    public Task DisplayAlertAsync(string title, string message, string accept, string cancel)
    {
        return Shell.Current.DisplayAlert(title, message, accept, cancel);
    }

    public void DisplayAlert(string title, string message, string cancel)
    {
        Shell.Current.Dispatcher.Dispatch(async () => await DisplayAlertAsync(title, message, cancel));
    }

    public void DisplayAlert(string title, string message, string accept, string cancel)
    {
        Shell.Current.Dispatcher.Dispatch(async () => await DisplayAlertAsync(title, message, accept, cancel));
    }
}
