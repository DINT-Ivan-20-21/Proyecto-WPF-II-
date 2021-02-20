using Proyecto_WPF__II_.Modelo;
using Proyecto_WPF__II_.Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WPF__II_.ViewModel
{
    class ViewModelSalasSesiones : INotifyPropertyChanged
    {
        public enum Modo { Insertar, Modificar }

        public ObservableCollection<Sala> Salas { get; }
        public Sala SalaSeleccionada { get; set; }
        public Modo ModoSala { get; set; }

        public ObservableCollection<Sesion> Sesiones { get; }
        public Sesion SesionSeleccionada { get; set; }
        public Modo ModoSesion { get; set; }

        public ObservableCollection<Pelicula> Peliculas { get; set; }

        private readonly SQLiteService _bd;

        public ViewModelSalasSesiones()
        {
            _bd = new SQLiteService();
            Salas = _bd.LeerSalas();
            Sesiones = _bd.LeerSesiones();
            Peliculas = _bd.LeerPeliculas();
            SalaSeleccionada = new Sala();
            SesionSeleccionada = new Sesion();
            ModoSala = Modo.Insertar;
            ModoSesion = Modo.Insertar;
        }

        public void AceptarSala()
        {
            if (ModoSala == Modo.Insertar)
            {
                _bd.Insertar(SalaSeleccionada);
                Salas.Add(SalaSeleccionada);
            }
            else
            {
                _bd.Actualizar(SalaSeleccionada);
            }
            SalaSeleccionada = new Sala();
        }

        public void AceptarSesion()
        {
            if (ModoSesion == Modo.Insertar)
            {
                _bd.Insertar(SesionSeleccionada);
                Sesiones.Add(SesionSeleccionada);
            }
            else
            {
                _bd.Actualizar(SesionSeleccionada);
            }
            SalaSeleccionada = new Sala();
        }

        public bool PuedeAceptarSala()
        {
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
