using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Proyecto_WPF__II_.Modelo
{
    class Pelicula : INotifyPropertyChanged, IEquatable<Pelicula>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Cartel { get; set; }
        public int Año { get; set; }
        public string Genero { get; set; }
        public string Calificacion { get; set; }

        public Pelicula()
        {

        }

        public Pelicula(int id, string titulo, string cartel, int año, string genero, string calificacion)
        {
            Id = id;
            Titulo = titulo;
            Cartel = cartel;
            Año = año;
            Genero = genero;
            Calificacion = calificacion;
        }

        public Pelicula(Pelicula pelicula)
        {
            Id = pelicula.Id;
            Titulo = pelicula.Titulo;
            Cartel = pelicula.Cartel;
            Año = pelicula.Año;
            Genero = pelicula.Genero;
            Calificacion = pelicula.Calificacion;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Equals(object obj)
        {
            return Equals(obj as Pelicula);
        }

        public bool Equals(Pelicula other)
        {
            return other != null &&
                   Id == other.Id &&
                   Titulo == other.Titulo &&
                   Cartel == other.Cartel &&
                   Año == other.Año &&
                   Genero == other.Genero &&
                   Calificacion == other.Calificacion;
        }

        public override int GetHashCode()
        {
            int hashCode = -951304565;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Titulo);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cartel);
            hashCode = hashCode * -1521134295 + Año.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Genero);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Calificacion);
            return hashCode;
        }
    }
}
