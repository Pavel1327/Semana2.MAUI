namespace Semana2.MAUI.Views;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();

        // Llenar el Picker con estudiantes
        pickerEstudiantes.ItemsSource = new List<string>
        {
            "Juan Pérez",
            "María López",
            "Carlos Andrade",
            "Ana Torres",
            "Luis Gómez"
        };
    }

    private async void CalcularNotas_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pickerEstudiantes.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Seleccione un estudiante", "OK");
                return;
            }

            // Leer valores ingresados
            double seg1 = double.Parse(entrySeguimiento1.Text);
            double ex1 = double.Parse(entryExamen1.Text);
            double seg2 = double.Parse(entrySeguimiento2.Text);
            double ex2 = double.Parse(entryExamen2.Text);

            // Validar rangos 0 a 10
            if (seg1 < 0 || seg1 > 10 || ex1 < 0 || ex1 > 10 ||
                seg2 < 0 || seg2 > 10 || ex2 < 0 || ex2 > 10)
            {
                await DisplayAlert("Error", "Las notas deben estar entre 0 y 10", "OK");
                return;
            }

            // Calcular parciales y nota final
            double parcial1 = (seg1 * 0.3) + (ex1 * 0.2);
            double parcial2 = (seg2 * 0.3) + (ex2 * 0.2);
            double notaFinal = parcial1 + parcial2;

            // Determinar estado
            string estado;
            if (notaFinal >= 7)
                estado = "Aprobado";
            else if (notaFinal >= 5 && notaFinal <= 6.9)
                estado = "Complementario";
            else
                estado = "Reprobado";

            // Mostrar resultado
            string mensaje =
                $"Nombre: {pickerEstudiantes.SelectedItem}\n" +
                $"Fecha: {datePickerFecha.Date:dd/MM/yyyy}\n\n" +
                $"Nota Parcial 1: {parcial1:F2}\n" +
                $"Nota Parcial 2: {parcial2:F2}\n" +
                $"Nota Final: {notaFinal:F2}\n" +
                $"Estado: {estado}";

            await DisplayAlert("Resultado del Estudiante", mensaje, "Cerrar");
        }
        catch
        {
            await DisplayAlert("Error", "Ingrese solo números válidos", "OK");
        }
    }
}