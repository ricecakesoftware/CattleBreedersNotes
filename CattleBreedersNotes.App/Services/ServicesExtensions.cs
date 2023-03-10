namespace RiceCakeSoftware.CattleBreedersNotes.App.Services;

public static class ServicesExtensions
{
    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IAlertService, AlertService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        return builder;
    }
}
