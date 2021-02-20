﻿using Proyecto_WPF__II_.ViewModel;
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
using System.Windows.Shapes;

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
    }
}
