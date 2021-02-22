using Microsoft.Data.Sqlite;
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
        public int Disponibles
        {
            get
            {
                try
                {
                    return SesionSeleccionada != null ? SesionSeleccionada.Sala.Capacidad - _bd.CantidadEntradasVendidas(SesionSeleccionada.Id) : 0;
                }
                catch (SqliteException)
                {
                    return 0;
                }
            }
        }
        public List<string> FormasPago { get; set; } = new List<string>(new string[] { "Efectivo", "Tarjeta", "Bizum" });

        //Sesiones
        public ObservableCollection<Sesion> Sesiones {
            get
            {
                try
                {
                    return PeliculaSeleccionada != null ? _bd.BuscaSesionesPorPelicula(PeliculaSeleccionada.Id) : new ObservableCollection<Sesion>();
                }
                catch (SqliteException)
                {
                    return new ObservableCollection<Sesion>();
                }
            }
        }
        public Sesion SesionSeleccionada { get; set; }

        //Peliculas
        public ObservableCollection<Pelicula> Peliculas { get; set; }
        public Pelicula PeliculaSeleccionada { get; set; }

        private readonly SQLiteService _bd;

        public ViewModelVentaEntradas()
        {
            _bd = new SQLiteService();
            Peliculas = _bd.LeerPeliculas();
            VentaFormulario = new Venta();
        }

        public void Vender()
        {
            VentaFormulario.Sesion = SesionSeleccionada;
            _bd.Insertar(VentaFormulario);
        }
        public bool PuedeVender()
        {
            return VentaFormulario.Cantidad <= Disponibles && VentaFormulario.Cantidad > 0 && VentaFormulario.Pago != null;
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

        public bool PuedeLimpiarSeleccion()
        {
            return PeliculaSeleccionada != null;
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
