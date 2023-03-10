namespace RiceCakeSoftware.CattleBreedersNotes.App.Views;

public static class ViewsExtensions
{
    public static MauiAppBuilder ConfigureViews(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<AppShell>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<CowsPage>();
        builder.Services.AddTransient<SettingsPage>();
        return builder;
    }
}
