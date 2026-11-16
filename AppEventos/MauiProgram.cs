using System.Globalization;

namespace AppEventos;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var cultura = CultureInfo.GetCultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentCulture = cultura;
        CultureInfo.DefaultThreadCurrentUICulture = cultura;

        return MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(fontes =>
            {
                fontes.AddFont("OpenSans-Regular.ttf", "AppRegular");
                fontes.AddFont("OpenSans-Semibold.ttf", "AppSemibold");
            })
            .Build();
    }
}
