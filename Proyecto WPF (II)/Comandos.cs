using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_WPF__II_
{
    internal static class Comandos
    {
        public static readonly RoutedUICommand VerCartelera = new RoutedUICommand(
            "_Ver cartelera...",
            "Ver Cartelera",
            typeof(Comandos),
            new InputGestureCollection
            {
                new KeyGesture(Key.V, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand GestionarSalasSesiones = new RoutedUICommand(
            "_Gestionar salas y sesiones...",
            "Gestionar salas",
            typeof(Comandos),
            new InputGestureCollection
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand VenderEntradas = new RoutedUICommand(
            "Vender _entradas",
            "Vender entradas",
            typeof(Comandos),
            new InputGestureCollection
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand ConsultarOcupacion = new RoutedUICommand(
            "Gestionar _ocupación",
            "Gestionar ocupacion",
            typeof(Comandos),
            new InputGestureCollection
            {
                new KeyGesture(Key.O, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand Ayuda = new RoutedUICommand(
            "_Ayuda",
            "Ayuda",
            typeof(Comandos),
            new InputGestureCollection
            {
                new KeyGesture(Key.A, ModifierKeys.Control)
            }
        );
    }
}
