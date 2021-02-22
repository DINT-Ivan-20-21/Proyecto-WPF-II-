using Microsoft.Data.Sqlite;
using Proyecto_WPF__II_.ViewModel;
using System.Windows;

namespace Proyecto_WPF__II_
{
    /// <summary>
    /// Lógica de interacción para Ocupacion.xaml
    /// </summary>
    public partial class Ocupacion : Window
    {
        ViewModelOcupacion _vm;
        public Ocupacion()
        {
            try
            {
            _vm = new ViewModelOcupacion();
            }
            catch (SqliteException)
            {
                MessageBox.Show("No se pudo acceder a la base de datos", "advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            InitializeComponent();
            DataContext = _vm;
        }
    }
}
