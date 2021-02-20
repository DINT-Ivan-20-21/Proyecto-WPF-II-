using System;
using System.ComponentModel;

namespace Proyecto_WPF__II_.Modelo
{
    class Sesion : INotifyPropertyChanged
    {
        public int Id { get; }
        public Pelicula Pelicula { get; set; }
        public Sala Sala { get; set; }
        public DateTime Hora { get; set; }

        public Sesion()
        {
        }

        public Sesion(int id, Pelicula pelicula, Sala sala, DateTime hora)
        {
            Id = id;
            Pelicula = pelicula;
            Sala = sala;
            Hora = hora;
        }

        public Sesion(Sesion sesion)
        {
            Id = sesion.Id;
            Pelicula = new Pelicula(sesion.Pelicula);
            Sala = new Sala(sesion.Sala);
            Hora = sesion.Hora;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
