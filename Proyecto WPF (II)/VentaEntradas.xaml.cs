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
            _vm = new ViewModelVentaEntradas();
            InitializeComponent();
            DataContext = _vm;
        }

        private void LimpiarCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.LimpiarSeleccion();
        }

        private void LimpiarCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.PuedeLimpiarSeleccion();
        }

        private void VenderCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.Vender();
            _vm.LimpiarSeleccion();
        }

        private void VenderCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.PuedeVender();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm.LimpiarFormulario();
        }
    }
}
