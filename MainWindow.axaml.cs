using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace MiPresentacion;

public partial class MainWindow : Window
{
    private const string MensajeInicial = "Completa el formulario y presiona «Presentarme».";

    // Reto adicional: indica qué saludo se usa (false = saludo 1, true = saludo 2).
    private bool _saludoAlterno = false;

    // Indica si actualmente se está mostrando una presentación válida.
    private bool _presentacionVisible = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    // ---------- Botón Presentarme ----------
    private void BtnPresentarme_Click(object? sender, RoutedEventArgs e)
    {
        MostrarPresentacion();
    }

    private void MostrarPresentacion()
    {
        // 1. Obtener los datos (Trim elimina espacios sobrantes).
        string nombre = TxtNombre.Text?.Trim() ?? "";
        string apellido = TxtApellido.Text?.Trim() ?? "";
        string edadTexto = TxtEdad.Text?.Trim() ?? "";

        // 2. Validar nombre y apellido.
        if (string.IsNullOrWhiteSpace(nombre))
        {
            MostrarAdvertencia("⚠ El nombre no puede estar vacío.");
            return;
        }

        if (string.IsNullOrWhiteSpace(apellido))
        {
            MostrarAdvertencia("⚠ El apellido no puede estar vacío.");
            return;
        }

        // 3. Validar edad: entero y positivo.
        if (!int.TryParse(edadTexto, out int edad))
        {
            MostrarAdvertencia("⚠ Ingresa una edad numérica (solo números enteros).");
            return;
        }

        if (edad <= 0)
        {
            MostrarAdvertencia("⚠ La edad debe ser un número entero mayor que cero.");
            return;
        }

        // 4. Datos válidos: mostrar mensaje personalizado.
        string mensaje = _saludoAlterno
            ? $"¡Bienvenido/a! Soy {nombre} {apellido},\nmi edad es {edad} años y me encanta\ncrear aplicaciones de escritorio con Avalonia."
            : $"¡Hola! Mi nombre es {nombre} {apellido},\ntengo {edad} años y estoy aprendiendo\na desarrollar interfaces gráficas con C#.";

        TxtResultado.Foreground = Brushes.ForestGreen;
        TxtResultado.Text = mensaje;
        _presentacionVisible = true;
    }

    private void MostrarAdvertencia(string texto)
    {
        TxtResultado.Foreground = Brushes.Firebrick;
        TxtResultado.Text = texto;
        _presentacionVisible = false;
    }

    // ---------- Botón Limpiar ----------
    private void BtnLimpiar_Click(object? sender, RoutedEventArgs e)
    {
        TxtNombre.Text = "";
        TxtApellido.Text = "";
        TxtEdad.Text = "";

        TxtResultado.Foreground = null; // color por defecto del tema
        TxtResultado.Text = MensajeInicial;
        _presentacionVisible = false;

        TxtNombre.Focus();
    }

    // ---------- Reto: Cambiar saludo ----------
    private void BtnCambiarSaludo_Click(object? sender, RoutedEventArgs e)
    {
        _saludoAlterno = !_saludoAlterno;

        // Si ya había una presentación en pantalla, se actualiza al nuevo saludo
        // sin cerrar ni reiniciar la aplicación.
        if (_presentacionVisible)
        {
            MostrarPresentacion();
        }
        else
        {
            TxtResultado.Foreground = null;
            TxtResultado.Text = _saludoAlterno
                ? "Saludo 2 activado. Presiona «Presentarme» para verlo."
                : "Saludo 1 activado. Presiona «Presentarme» para verlo.";
        }
    }
}
