using System.Windows.Input;

namespace Proyecto_WPF__II_.Comando
{
    internal static class ComandosSalasSesiones
    {
        public static readonly RoutedUICommand InsertarSala = new RoutedUICommand(
            "Insertar Sala",
            "Insertar Sala",
            typeof(ComandosSalasSesiones),
            null
        );

        public static readonly RoutedUICommand AñadirSala = new RoutedUICommand(
           "Añadir Sala",
           "Añadir Sala",
           typeof(ComandosSalasSesiones),
           null
       );

        public static readonly RoutedUICommand ModificarSala = new RoutedUICommand(
           "Modificar Sala",
           "Modificar Sala",
           typeof(ComandosSalasSesiones),
           null
       );

        public static readonly RoutedUICommand InsertarSesion = new RoutedUICommand(
           "Insertar Sesion",
           "Insertar Sesion",
           typeof(ComandosSalasSesiones),
           null
       );

        public static readonly RoutedUICommand AñadirSesion = new RoutedUICommand(
           "Añadir Sesion",
           "Añadir Sesion",
           typeof(ComandosSalasSesiones),
           null
       );

        public static readonly RoutedUICommand ModificarSesion = new RoutedUICommand(
           "Modificar Sesion",
           "Modificar Sesion",
           typeof(ComandosSalasSesiones),
           null
       );

        public static readonly RoutedUICommand EliminarSesion = new RoutedUICommand(
           "Eliminar Sesion",
           "Eliminar Sesion",
           typeof(ComandosSalasSesiones),
           null
       );
    }
}
