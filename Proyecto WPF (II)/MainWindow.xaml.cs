using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
