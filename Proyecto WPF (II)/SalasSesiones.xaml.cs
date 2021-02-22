using Microsoft.Data.Sqlite;
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
            try
            {
                _vm = new ViewModelSalasSesiones();
            }
            catch (SqliteException)
            {
                MostrarAdvertencia("Error en la base de datos");
            }

            InitializeComponent();
            DataContext = _vm;
        }

        //Salas
        private void InsertarSalaCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                _vm.InsertarSala();
            } catch (SqliteException sqle)
            {
                MostrarAdvertencia(sqle.Message);
            }
        }

        private void InsertarSalaCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm != null && _vm.PuedeInsertarSala();
        }

        private void AccionSalaCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string mensaje = null;
            if (_vm != null)
            {
                mensaje = _vm.CambiarModoSala();
            }

            if (mensaje != null)
            {
                MostrarAdvertencia(mensaje);
            }
        }

        //Sesiones
        private void InsertarSesionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                _vm.InsertarSesion();
            }
            catch (SqliteException sqle)
            {
                MostrarAdvertencia(sqle.Message);
            }
        }
        private void InsertarSesionCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm != null && _vm.PuedeInsertarSesion();
        }

        private void AccionSesionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string mensaje = null;
            if (_vm != null)
            {
                mensaje = _vm.CambiarModoSesion();
            }

            if (mensaje != null)
            {
                MostrarAdvertencia(mensaje);
            }
        }

        private void EliminarSesionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _vm.EliminarSesion();
        }

        private void EliminarSesionCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _vm != null && _vm.PuedeEliminarSesion();
        }

        private void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
