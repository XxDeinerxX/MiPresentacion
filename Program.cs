using Avalonia;
using System;

namespace MiPresentacion;

internal sealed class Program
{
    // Punto de entrada de la aplicación.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Configuración de Avalonia.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
}
