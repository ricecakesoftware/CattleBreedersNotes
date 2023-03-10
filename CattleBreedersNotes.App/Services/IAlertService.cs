namespace RiceCakeSoftware.CattleBreedersNotes.App.Services;

public interface IAlertService
{
    public Task DisplayAlertAsync(string title, string message, string cancel);
    public Task DisplayAlertAsync(string title, string message, string accept, string cancel);
    public void DisplayAlert(string title, string message, string cancel);
    public void DisplayAlert(string title, string message, string accept, string cancel);
}
