using AppEventos.Models;

namespace AppEventos.Views;

public partial class ResumoPage : ContentPage
{
    public ResumoPage(Evento evento)
    {
        InitializeComponent();
        BindingContext = evento;
    }

    private async void EditarCadastro(object? sender, EventArgs e)
    {
        BotaoEditar.IsEnabled = false;
        try
        {
            await Navigation.PopAsync();
        }
        finally
        {
            BotaoEditar.IsEnabled = true;
        }
    }
}
