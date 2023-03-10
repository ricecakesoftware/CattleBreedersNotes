namespace RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;

public static class ViewModelsExtensions
{
    public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<AppShellViewModel>();
        builder.Services.AddTransient<LoginPageViewModel>();
        builder.Services.AddTransient<DashboardPageViewModel>();
        builder.Services.AddTransient<CowsPageViewModel>();
        builder.Services.AddTransient<SettingsPageViewModel>();
        return builder;
    }
}
