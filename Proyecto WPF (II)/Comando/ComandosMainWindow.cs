using System.Windows.Input;

namespace Proyecto_WPF__II_.Comando
{
    internal static class ComandosMainWindow
    {
        public static readonly RoutedUICommand VerCartelera = new RoutedUICommand(
            "_Ver cartelera...",
            "Ver Cartelera",
            typeof(ComandosMainWindow),
            new InputGestureCollection
            {
                new KeyGesture(Key.V, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand GestionarSalasSesiones = new RoutedUICommand(
            "_Gestionar salas y sesiones...",
            "Gestionar salas",
            typeof(ComandosMainWindow),
            new InputGestureCollection
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand VenderEntradas = new RoutedUICommand(
            "Vender _entradas",
            "Vender entradas",
            typeof(ComandosMainWindow),
            new InputGestureCollection
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand ConsultarOcupacion = new RoutedUICommand(
            "Gestionar _ocupación",
            "Gestionar ocupacion",
            typeof(ComandosMainWindow),
            new InputGestureCollection
            {
                new KeyGesture(Key.O, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Ayuda = new RoutedUICommand(
            "_Ayuda",
            "Ayuda",
            typeof(ComandosMainWindow),
            new InputGestureCollection
            {
                new KeyGesture(Key.A, ModifierKeys.Control)
            }
        );
    }
}
