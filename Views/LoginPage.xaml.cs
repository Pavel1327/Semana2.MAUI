using System;
using System.Collections.Generic;

namespace Semana2.MAUI.Views;

public partial class LoginPage : ContentPage
{
    // Vectores requeridos por la consigna
    private readonly string[] users = { "Carlos", "Ana", "Jose" };
    private readonly string[] pass = { "carlos123", "ana123", "jose123" };

    // Diccionario usuario -> contraseña (para validar fácil)
    private readonly Dictionary<string, string> credenciales;

    public LoginPage()
    {
        InitializeComponent();

        credenciales = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < users.Length; i++)
            credenciales[users[i]] = pass[i];
    }

    private async void BtnIngresar_Clicked(object sender, EventArgs e)
    {
        var usuario = txtUsuario.Text?.Trim() ?? "";
        var clave = txtPassword.Text ?? "";

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(clave))
        {
            await DisplayAlert("Alerta", "Ingrese usuario y contraseña", "Cerrar");
            return;
        }

        if (credenciales.TryGetValue(usuario, out var claveOk) && claveOk == clave)
        {
            await DisplayAlert("Alerta", "Usuario registrado", "ok");
            await Navigation.PushAsync(new PrincipalPage(usuario));
        }
        else
        {
            await DisplayAlert("Alerta", "Usuario/Contraseña incorrectos", "Cerrar");
        }
    }

    private void BtnLimpiar_Clicked(object sender, EventArgs e)
    {
        txtUsuario.Text = "";
        txtPassword.Text = "";
        txtUsuario.Focus();
    }
}
