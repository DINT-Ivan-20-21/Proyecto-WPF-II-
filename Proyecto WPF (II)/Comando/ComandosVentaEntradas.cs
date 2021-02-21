using System.Windows.Input;

namespace Proyecto_WPF__II_.Comando
{
    internal static class ComandosVentaEntradas
    {
        public static readonly RoutedUICommand Limpiar = new RoutedUICommand(
           "Limpiar",
           "Limpiar",
           typeof(ComandosVentaEntradas),
           null
       );

        public static readonly RoutedUICommand Vender = new RoutedUICommand(
           "Vender",
           "Vender",
           typeof(ComandosVentaEntradas),
           null
       );
    }
}
