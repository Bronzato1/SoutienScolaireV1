using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace SoutienScolaireV1.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            #region Add configuration file

            // Below code will list all the (fully qualified) names of all resources embedded in the assembly your code is written in.
            var checkOnly = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var myAssembly = Assembly.GetExecutingAssembly();
            using var stream = myAssembly.GetManifestResourceStream("SoutienScolaireV1.Maui.appsettings.json") ?? new MemoryStream();
            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);

            #endregion

            return builder.Build();
        }
    }
}
