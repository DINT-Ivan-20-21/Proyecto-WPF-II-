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

        private void AyudaCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GestionarSalasSesionesCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SalasSesiones window = new SalasSesiones();
            window.Owner = this;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
        }

        private void VenderEntradasCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreaVentana(new VentaEntradas());
        }

        private void ConsultarOcupacionCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CreaVentana(new Ocupacion());
        }
    }
}
