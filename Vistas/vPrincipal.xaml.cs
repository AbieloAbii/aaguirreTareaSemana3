using System;
using Microsoft.Maui.Controls;

namespace aaguirreTareaSemana2.Vistas
{
    public partial class vPrincipal : ContentPage
    {
        public vPrincipal(string usuario)
        {
            InitializeComponent();
            lblUsuario.Text = "Iniciaste seción con:" + usuario;
            // Agregar manejadores de eventos para el cambio de texto en los Entry del Primer Parcial
            entryNotaSeguimiento1.TextChanged += EntryNotaSeguimiento1_TextChanged;
            entryExamen.TextChanged += EntryExamen_TextChanged;

            // Agregar manejadores de eventos para el cambio de texto en los Entry del Segundo Parcial
            entryNotaSeguimiento2.TextChanged += EntryNotaSeguimiento2_TextChanged;
            entryExamen2.TextChanged += EntryExamen2_TextChanged;

            // Agregar manejador de evento para el botón
            btnCalcularNotaFinal.Clicked += btnCalcular_Clicked;
        }

        // Manejar el cambio de texto en el Entry de Nota de Seguimiento 1
        private void EntryNotaSeguimiento1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsValidNumber(e.NewTextValue))
            {
                RecalculateAndDisplayNotaParcial1();
            }
            else
            {
                DisplayAlert("Error", "Ingrese un número válido entre 0 y 10.", "Aceptar");
                entryNotaSeguimiento1.Text = null;
            }
        }

        // Manejar el cambio de texto en el Entry de Examen 1
        private void EntryExamen_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsValidNumber(e.NewTextValue))
            {
                RecalculateAndDisplayNotaParcial1();
            }
            else
            {
                DisplayAlert("Error", "Ingrese un número válido entre 0 y 10.", "Aceptar");
                entryExamen.Text = null;
            }
        }

        // Manejar el cambio de texto en el Entry de Nota de Seguimiento 2
        private void EntryNotaSeguimiento2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsValidNumber(e.NewTextValue))
            {
                RecalculateAndDisplayNotaParcial2();
            }
            else
            {
                DisplayAlert("Error", "Ingrese un número válido entre 0 y 10.", "Aceptar");
                entryNotaSeguimiento2.Text = null;
            }
        }

        // Manejar el cambio de texto en el Entry de Examen 2
        private void EntryExamen2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsValidNumber(e.NewTextValue))
            {
                RecalculateAndDisplayNotaParcial2();
            }
            else
            {
                DisplayAlert("Error", "Ingrese un número válido entre 0 y 10.", "Aceptar");
                entryExamen2.Text = null;
            }
        }

        // Método para validar que el texto sea un número entre 1 y 10
        private bool IsValidNumber(string text)
        {
            return double.TryParse(text, out double number) && number >= 0 && number <= 10;
        }

        // Método para recalcular y mostrar la nota del Parcial 1
        private void RecalculateAndDisplayNotaParcial1()
        {
            // Obtener el valor de la nota de seguimiento 1 desde la entrada de texto y convertirlo a un número decimal
            double notaSeguimiento = Convert.ToDouble(entryNotaSeguimiento1.Text);

            // Obtener el valor de la nota del examen desde la entrada de texto y convertirlo a un número decimal
            double examen = Convert.ToDouble(entryExamen.Text);

            // Calcular la nota parcial 1 usando la fórmula proporcionada
            double notaParcial1 = 0.3 * notaSeguimiento + 0.2 * examen;

            // Convertir la nota parcial 1 a una cadena de texto con formato (dos decimales) y asignarla al texto de la entrada de texto
            entryNotaParcial1.Text = notaParcial1.ToString("");

        }

        // Método para recalcular y mostrar la nota del Parcial 2
        private void RecalculateAndDisplayNotaParcial2()
        {
            double notaSeguimiento = Convert.ToDouble(entryNotaSeguimiento2.Text);
            double examen = Convert.ToDouble(entryExamen2.Text);
            double notaParcial2 = 0.3 * notaSeguimiento + 0.2 * examen;
            entryNotaParcial2.Text = notaParcial2.ToString("");
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Obtener las notas de los dos parciales
                double notaParcial1 = Convert.ToDouble(entryNotaParcial1.Text);
                double notaParcial2 = Convert.ToDouble(entryNotaParcial2.Text);

                // Calcular la nota final sobre 10
                double notaFinal = (notaParcial1 + notaParcial2) * 1.0;

                // Mostrar la nota final en el label correspondiente
                NotaFinal.Text = notaFinal.ToString("N2");

                // Obtener el estudiante seleccionado en el Picker
                string estudiante = pkNombres.SelectedItem?.ToString();

                // Obtener la fecha seleccionada en el DatePicker
                DateTime fechaCalificacion = dpFecha.Date;

                // Construir el mensaje con el estado del estudiante
                string estadoEstudiante = "";
                if (notaFinal >= 7)
                {
                    estadoEstudiante = "Aprobado";
                }
                else if (notaFinal >= 5 && notaFinal <= 6.9)
                {
                    estadoEstudiante = "Complementario";
                }
                else
                {
                    estadoEstudiante = "Reprobado";
                }

                // Construir el mensaje completo
                string mensaje = $"Estudiante: {estudiante}\n" +
                                 $"Estado: {estadoEstudiante}\n" +
                                 $"Fecha de calificación: {fechaCalificacion.ToString("MM/dd/yyyy")}";

                // Mostrar el mensaje en el último Label
                // Puedes cambiar el nombre del Label según sea necesario
                lblEstadoEstudiante.Text = mensaje;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"Se produjo un error: {ex.Message}", "Aceptar");
            }
        }
    }
}
