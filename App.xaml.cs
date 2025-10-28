namespace Semana2.MAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Usar navegación jerárquica y arrancar en el Login
        MainPage = new NavigationPage(new Views.LoginPage());
    }
}
