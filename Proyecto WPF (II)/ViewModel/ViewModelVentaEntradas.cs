using Proyecto_WPF__II_.Modelo;
using Proyecto_WPF__II_.Servicio;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Proyecto_WPF__II_.ViewModel
{
    class ViewModelVentaEntradas : INotifyPropertyChanged
    {
        //Venta
        public Venta VentaFormulario { get; set; }
        public int Disponibles { get; set; }
        public List<string> FormasPago { get; set; }

        //Sesiones
        public ObservableCollection<Sesion> Sesiones { get; set; }

        private Sesion _sesionSeleccionada;
        public Sesion SesionSeleccionada
        {
            get => _sesionSeleccionada;
            set
            {
                _sesionSeleccionada = value;
                Disponibles = _sesionSeleccionada != null ? _sesionSeleccionada.Sala.Capacidad - _bd.CantidadEntradasVendidas(_sesionSeleccionada.Id) : 0;
            }
        }

        //Peliculas
        public ObservableCollection<Pelicula> Peliculas { get; set; }

        private Pelicula _peliculaSeleccionada;

        public Pelicula PeliculaSeleccionada
        {
            get => _peliculaSeleccionada;
            set
            {
                _peliculaSeleccionada = value;
                Sesiones = _peliculaSeleccionada != null ? _bd.BuscaSesionesPorPelicula(_peliculaSeleccionada.Id) : null;
            }
        }

        private readonly SQLiteService _bd;

        public ViewModelVentaEntradas()
        {
            _bd = new SQLiteService();
            FormasPago = new List<string>(new string[] { "Efectivo", "Tarjeta", "Bizum" });
            Peliculas = _bd.LeerPeliculas();
            VentaFormulario = new Venta();
        }

        public bool PuedeLimpiarSeleccion()
        {
            return PeliculaSeleccionada != null;
        }

        public bool PuedeVender()
        {
            return VentaFormulario.Cantidad <= Disponibles && VentaFormulario.Cantidad > 0 && VentaFormulario.Pago != null;
        }

        public void Vender()
        {
            VentaFormulario.Sesion = SesionSeleccionada;
            _bd.Insertar(VentaFormulario);
        }

        public void LimpiarSeleccion()
        {
            PeliculaSeleccionada = null;
            VentaFormulario = new Venta();
        }

        internal void LimpiarFormulario()
        {
            VentaFormulario = new Venta();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
