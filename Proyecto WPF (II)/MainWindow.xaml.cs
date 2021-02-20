using System;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_WPF__II_
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreaVentana(Window window)
        {
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }

        private void VerCarteleraCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreaVentana(new Cartelera());
        }


        private void GestionarSalasSesionesCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreaVentana(new SalasSesiones());
        }

        private void VenderEntradasCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreaVentana(new VentaEntradas());
        }

        private void ConsultarOcupacionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreaVentana(new Ocupacion());
        }

        private void AyudaCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
