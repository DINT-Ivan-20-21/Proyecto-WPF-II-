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

        public static readonly RoutedUICommand AccionSala = new RoutedUICommand(
           "Accion Sala",
           "Accion Sala",
           typeof(ComandosSalasSesiones),
           null
       );

        public static readonly RoutedUICommand InsertarSesion = new RoutedUICommand(
           "Insertar Sesion",
           "Insertar Sesion",
           typeof(ComandosSalasSesiones),
           null
       );

        public static readonly RoutedUICommand AccionSesion = new RoutedUICommand(
           "Accion Sesion",
           "Accion Sesion",
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
