using Microsoft.Data.Sqlite;
using Proyecto_WPF__II_.ViewModel;
using System;
using System.Windows;

namespace Proyecto_WPF__II_
{
    /// <summary>
    /// Lógica de interacción para Cartelera.xaml
    /// </summary>
    public partial class Cartelera : Window
    {
        private ViewModelCartelera _vm;
        public Cartelera()
        {
            try
            {
                _vm = new ViewModelCartelera();
            }
            catch (SqliteException)
            {
                MessageBox.Show("No se pudo acceder a la base de datos", "advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo acceder a la cartelera", "advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            InitializeComponent();
            DataContext = _vm;
        }
    }
}
