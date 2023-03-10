using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RiceCakeSoftware.CattleBreedersNotes.App.Services;
using RiceCakeSoftware.CattleBreedersNotes.App.ViewModels;
using RiceCakeSoftware.CattleBreedersNotes.App.Views;
using RiceCakeSoftware.CattleBreedersNotes.Commons;
using System.Reflection;

namespace RiceCakeSoftware.CattleBreedersNotes.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();
        builder.UseMauiCommunityToolkit();
        builder.ConfigureServices();
        builder.ConfigureViewModels();
        builder.ConfigureViews();
        builder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("Kosugi-Regular.ttf", "Kosugi");
        });
        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<Certification>();
        builder.Configuration.AddConfiguration(new ConfigurationBuilder().AddJsonStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("RiceCakeSoftware.CattleBreedersNotes.App.appsettings.json")).Build());
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
