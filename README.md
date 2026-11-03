# MiPresentacion

Aplicación de escritorio desarrollada con **Avalonia UI 11** y **C# (.NET 8)**. Permite registrar nombre, apellido y edad de una persona y mostrar una presentación personalizada al presionar un botón, validando los datos antes de mostrarla.

## Controles utilizados

| Control | x:Name | Función |
|---|---|---|
| `TextBlock` | — | Título «Mi primera aplicación gráfica» |
| `TextBox` | `TxtNombre` | Entrada del nombre |
| `TextBox` | `TxtApellido` | Entrada del apellido |
| `TextBox` | `TxtEdad` | Entrada de la edad |
| `Button` | `BtnPresentarme` | Valida y muestra la presentación |
| `Button` | `BtnLimpiar` | Vacía el formulario y restaura el mensaje inicial |
| `Button` | `BtnCambiarSaludo` | Reto: alterna entre dos saludos |
| `TextBlock` | `TxtResultado` | Muestra el resultado o las advertencias |
| `StackPanel` | — | Organiza los controles con `Margin` y `Spacing` |

## Funcionamiento de los eventos

- **Presentarme (`Click`)**: lee los tres campos, comprueba que nombre y apellido no estén vacíos ni solo con espacios (`string.IsNullOrWhiteSpace`), verifica que la edad sea un entero positivo con `int.TryParse()` y muestra el mensaje (verde) o una advertencia (roja).
- **Limpiar (`Click`)**: vacía los tres `TextBox`, restaura el mensaje inicial y devuelve el cursor al nombre con `Focus()`.
- **Cambiar saludo (`Click`)**: cambia una variable booleana que decide cuál de los dos mensajes se usa; si ya había una presentación visible, se actualiza al instante sin reiniciar la app.

## Casos de prueba

| Caso | Datos | Resultado esperado |
|---|---|---|
| 1 | Nombre, apellido y edad válidos | Muestra la presentación |
| 2 | Nombre vacío | Advertencia |
| 3 | Apellido vacío | Advertencia |
| 4 | Edad con letras | Solicita una edad numérica |
| 5 | Edad negativa o 0 | Rechaza la edad |
| 6 | Presionar Limpiar | Restablece el formulario |

## Cómo ejecutar

Requisitos: [.NET 8 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/XxDeinerxX/MiPresentacion.git
cd MiPresentacion
dotnet run
```

## Capturas de pantalla

- Formulario: `capturas/formulario.png`
- Presentación correcta: `capturas/presentacion.png`
- Mensaje de validación: `capturas/validacion.png`

## Pregunta de reflexión

**¿Cuál es la función de MainWindow.axaml y MainWindow.axaml.cs, y cómo se relacionan mediante x:Name y los eventos Click?**

`MainWindow.axaml` describe *cómo se ve* la ventana: allí declaro los controles (títulos, cajas de texto, botones) y cómo se acomodan dentro del `StackPanel`. `MainWindow.axaml.cs` define *qué hace* la ventana: contiene el código C# que reacciona cuando el usuario interactúa.

Ambos archivos forman la misma clase `MainWindow` (es una clase `partial`), y se conectan de dos formas. Primero, con `x:Name`: cuando le pongo `x:Name="TxtNombre"` a un `TextBox`, en C# puedo usar `TxtNombre` como una variable para leer su `.Text`, cambiarlo o llamar a `Focus()`. Segundo, con los eventos: en el XAML escribo `Click="BtnPresentarme_Click"` y eso le dice a Avalonia que, al presionar ese botón, ejecute el método con ese nombre en el `.cs`. Así el usuario escribe en el formulario, presiona un botón, se ejecuta el método, este lee los controles por su `x:Name`, valida los datos y escribe el resultado en `TxtResultado`, que se ve de inmediato en pantalla.
