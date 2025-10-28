namespace Semana2.MAUI.Views;

public partial class PrincipalPage : ContentPage
{
    private readonly string _usuario;

    public PrincipalPage(string usuario)
    {
        InitializeComponent();
        _usuario = usuario;

        lblBienvenida.Text = $"Bienvenido, {_usuario}";

        // Mensaje emergente de bienvenida
        Dispatcher.Dispatch(async () =>
        {
            await DisplayAlert("Bienvenido", $"Hola {_usuario}, has iniciado sesión.", "OK");
        });
    }

    private async void BtnIrCalificaciones_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Inicio()); // tu pantalla S2 existente
    }
}
