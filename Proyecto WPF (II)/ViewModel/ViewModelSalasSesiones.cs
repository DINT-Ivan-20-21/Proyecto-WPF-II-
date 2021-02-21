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

        //Salas
        public ObservableCollection<Sala> Salas { get; set; }

        private Sala _salaSeleccionada;
        public Sala SalaSeleccionada
        {
            get => _salaSeleccionada;
            set
            {
                if (_salaSeleccionada == null)
                {
                    _salaSeleccionada = value;
                }
                else if (value != null && !_salaSeleccionada.Equals(value))
                {
                    _salaSeleccionada = value;
                    Sesiones = _bd.BuscaSesionesPorSala(_salaSeleccionada.Id);
                    Maximo = Sesiones.Count >= 3;
                    SesionSeleccionada = new Sesion(SalaSeleccionada);
                }
            }
        }
        public Sala SalaFormulario { get; set; }

        private Modo _modoSala;
        public Modo ModoSala
        {
            get => _modoSala;
            set
            {
                _modoSala = value;
                SalaFormulario = (ModoSala == Modo.Añadir) ? new Sala() : new Sala(SalaSeleccionada);
            }
        }


        //Sesiones
        public ObservableCollection<Sesion> Sesiones { get; set; }
        public Sesion SesionSeleccionada { get; set; }
        public Sesion SesionFormulario { get; set; }

        private Modo _modoSesion;
        public Modo ModoSesion
        {
            get => _modoSesion;
            set
            {
                _modoSesion = value;
                SesionFormulario = (ModoSesion == Modo.Añadir) ? new Sesion(SalaSeleccionada) : new Sesion(SesionSeleccionada);
            }
        }

        public bool Maximo { get; set; }

        public ObservableCollection<Pelicula> Peliculas { get; set; }

        private readonly SQLiteService _bd;

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
            SalaSeleccionada = new Sala();
        }

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
            Sesiones = _bd.LeerSesiones();
            SesionSeleccionada = new Sesion();
        }

        public void EliminarSesion()
        {
            _bd.Eliminar(SesionSeleccionada);
            Sesiones = _bd.LeerSesiones();
        }

        public bool PuedeInsertarSala()
        {
            return SalaFormulario.Capacidad != 0 && (!_bd.ExisteNumeroSala(SalaFormulario.Numero) || ModoSala == Modo.Modificar);
        }

        public bool PuedeInsertarSesion()
        {
            return SalaSeleccionada != null && SalaSeleccionada.Disponible && !Maximo && SesionFormulario.Pelicula != null;
        }

        public bool PuedeUsarSala()
        {
            return SalaSeleccionada != null && !SalaSeleccionada.Equals(new Sala());
        }

        public bool PuedeUsarSesion()
        {
            return SesionSeleccionada != null && SalaSeleccionada.Disponible && !SesionSeleccionada.Equals(new Sesion()) && PuedeUsarSala();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
