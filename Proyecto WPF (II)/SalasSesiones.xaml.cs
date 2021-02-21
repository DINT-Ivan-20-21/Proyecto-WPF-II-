using Proyecto_WPF__II_.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_WPF__II_
{
    /// <summary>
    /// Lógica de interacción para SalasSesiones.xaml
    /// </summary>
    public partial class SalasSesiones : Window
    {
        private ViewModelSalasSesiones _vm;
        public SalasSesiones()
        {
            _vm = new ViewModelSalasSesiones();
            InitializeComponent();
            DataContext = _vm;
        }

        private void InsertarSalaCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.InsertarSala();
        }
        private void AñadirSalaCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.ModoSala = ViewModelSalasSesiones.Modo.Añadir;
        }
        private void ModificarSalaCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.ModoSala = ViewModelSalasSesiones.Modo.Modificar;
        }

        private void InsertarSesionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.InsertarSesion();
        }
        private void AñadirSesionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.ModoSesion = ViewModelSalasSesiones.Modo.Añadir;
        }
        private void ModificarSesionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.ModoSesion = ViewModelSalasSesiones.Modo.Modificar;
        }
        private void EliminarSesionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.EliminarSesion();
        }

        private void InsertarSalaCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.PuedeInsertarSala();
        }

        private void InsertarSesionCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.PuedeInsertarSesion();
        }

        private void UsarSesionCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.PuedeUsarSesion();
        }

        private void UsarSalaCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm.PuedeUsarSala();
        }
    }
}
