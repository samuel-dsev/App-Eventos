namespace AppEventos;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        UserAppTheme = AppTheme.Light;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var janela = new Window(new NavigationPage(new MainPage())) { Title = "App Eventos" };
#if WINDOWS
        var tela = DeviceDisplay.Current.MainDisplayInfo;
        janela.Width = Math.Min(740, tela.Width / tela.Density - 24);
        janela.Height = Math.Min(580, tela.Height / tela.Density - 72);
#endif
        return janela;
    }
}
