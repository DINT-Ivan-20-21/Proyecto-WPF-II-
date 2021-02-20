using System.ComponentModel;

namespace Proyecto_WPF__II_.Modelo
{
    class Pelicula : INotifyPropertyChanged
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
    }
}
