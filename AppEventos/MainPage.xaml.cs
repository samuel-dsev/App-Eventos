using AppEventos.Models;
using AppEventos.Views;

namespace AppEventos;

public partial class MainPage : ContentPage
{
    private readonly Evento evento = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = evento;
    }

    private async void VerResumo(object? sender, EventArgs e)
    {
        string? mensagem = evento.Validar();
        Erro.Text = mensagem;
        Erro.IsVisible = mensagem is not null;

        if (mensagem is not null)
        {
            SemanticScreenReader.Default.Announce(mensagem);
            return;
        }

        BotaoResumo.IsEnabled = false;
        try
        {
            await Navigation.PushAsync(new ResumoPage(evento));
        }
        finally
        {
            BotaoResumo.IsEnabled = true;
        }
    }
}
