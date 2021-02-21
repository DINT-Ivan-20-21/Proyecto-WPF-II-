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
            _vm = new ViewModelOcupacion();
            InitializeComponent();
            DataContext = _vm;
        }
    }
}
