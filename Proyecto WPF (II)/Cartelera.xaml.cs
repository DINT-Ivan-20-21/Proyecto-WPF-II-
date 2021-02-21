using Proyecto_WPF__II_.ViewModel;
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
            _vm = new ViewModelCartelera();
            InitializeComponent();
            DataContext = _vm;
        }
    }
}
