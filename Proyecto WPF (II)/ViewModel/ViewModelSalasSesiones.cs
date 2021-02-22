using Microsoft.Data.Sqlite;
using Proyecto_WPF__II_.Modelo;
using Proyecto_WPF__II_.Servicio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Proyecto_WPF__II_.ViewModel
{
    class ViewModelSalasSesiones : INotifyPropertyChanged
    {
        public enum Modo { Añadir, Modificar }

        public ObservableCollection<Pelicula> Peliculas { get; set; }

        private readonly SQLiteService _bd;

        //Salas
        public ObservableCollection<Sala> Salas { get; set; }
        private Sala _salaSeleccionada;
        public Sala SalaSeleccionada
        {
            get => _salaSeleccionada;
            set
            {
                _salaSeleccionada = value;
                ActualizaSesiones();
            }
        }
        public Sala SalaFormulario { get; set; }
        public Modo ModoSala { get; set; }

        //Sesiones
        public ObservableCollection<Sesion> Sesiones { get; set; }
        public Sesion SesionSeleccionada { get; set; }
        public Sesion SesionFormulario { get; set; }

        public Modo ModoSesion { get; set; }

        public bool Maximo { get => Sesiones != null && Sesiones.Count >= 3; }

        public ViewModelSalasSesiones()
        {
            _bd = new SQLiteService();
            Salas = _bd.LeerSalas();
            Peliculas = _bd.LeerPeliculas();
            ModoSala = Modo.Añadir;
            ModoSesion = Modo.Añadir;
            SalaFormulario = new Sala();
            SesionFormulario = new Sesion();
        }

        //Métodos salas
        public void InsertarSala()
        {
            if (ModoSala == Modo.Añadir)
            {
                _bd.Insertar(SalaFormulario);
                Salas.Add(SalaFormulario);
            }
            else
            {
                _bd.Actualizar(SalaFormulario);
            }

            ModoSala = Modo.Añadir;
            Salas = _bd.LeerSalas();
            SalaSeleccionada = null;
        }

        public string CambiarModoSala()
        {
            if (SalaSeleccionada == null && ModoSala == Modo.Añadir)
            {
                return "Necesita seleccionar una sala para poder modificarla";
            }

            ModoSala = ModoSala == Modo.Añadir ? Modo.Modificar : Modo.Añadir;

            SalaFormulario = (ModoSala == Modo.Añadir) ? new Sala() : new Sala(SalaSeleccionada);
            return null;
        }

        public bool PuedeInsertarSala()
        {
            return SalaFormulario.Capacidad != 0 && (!_bd.ExisteNumeroSala(SalaFormulario.Numero) || ModoSala == Modo.Modificar);
        }

        //Métodos sesiones
        public void InsertarSesion()
        {
            if (ModoSesion == Modo.Añadir)
            {
                SesionFormulario.Sala = SalaSeleccionada;
                _bd.Insertar(SesionFormulario);
                Sesiones.Add(SesionFormulario);
            }
            else
            {
                _bd.Actualizar(SesionFormulario);
            }

            ModoSesion = Modo.Añadir;
            SesionSeleccionada = null;
            ActualizaSesiones();
        }

        public string CambiarModoSesion()
        {
            if (SesionSeleccionada == null && ModoSesion == Modo.Añadir)
            {
                return "Necesita seleccionar una sesion para poder modificarla";
            }

            ModoSesion = ModoSesion == Modo.Añadir ? Modo.Modificar : Modo.Añadir;
            SesionFormulario = (ModoSesion == Modo.Añadir) ? new Sesion(SalaSeleccionada) : new Sesion(SesionSeleccionada);
            return null;
        }

        public void EliminarSesion()
        {
            _bd.Eliminar(SesionSeleccionada);
            ActualizaSesiones();
        }

        public bool PuedeInsertarSesion()
        {
            return SalaSeleccionada != null && SalaSeleccionada.Disponible && (!Maximo || ModoSesion == Modo.Modificar) && SesionFormulario.Pelicula != null;
        }

        public bool PuedeEliminarSesion()
        {
            return SesionSeleccionada != null;
        }

        private void ActualizaSesiones()
        {
            try
            {
                Sesiones = SalaSeleccionada != null ? _bd.BuscaSesionesPorSala(SalaSeleccionada.Id) : new ObservableCollection<Sesion>();
            }
            catch (SqliteException)
            {
                Sesiones = new ObservableCollection<Sesion>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
