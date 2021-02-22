using Microsoft.Data.Sqlite;
using Proyecto_WPF__II_.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Proyecto_WPF__II_
{
    /// <summary>
    /// Lógica de interacción para VentaEntradas.xaml
    /// </summary>
    public partial class VentaEntradas : Window
    {
        ViewModelVentaEntradas _vm;
        public VentaEntradas()
        {
            try
            {
                _vm = new ViewModelVentaEntradas();
            } catch (SqliteException)
            {
                MostrarAdvertencia("Error al acceder a la base de datos");
            }

            InitializeComponent();
            DataContext = _vm;
        }

        private void LimpiarCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.LimpiarSeleccion();
        }

        private void LimpiarCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm != null && _vm.PuedeLimpiarSeleccion();
        }

        private void VenderCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                _vm.Vender();
            }
            catch (SqliteException)
            {
                MostrarAdvertencia("Error al insertar en la base de datos");
            }

            _vm.LimpiarSeleccion();
        }

        private void VenderCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm != null && _vm.PuedeVender();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm.LimpiarFormulario();
        }

        private void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
