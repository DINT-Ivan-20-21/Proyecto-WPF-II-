using System.ComponentModel;

namespace Proyecto_WPF__II_.Modelo
{
    class Sala : INotifyPropertyChanged
    {
        public int Id { get; }
        public string Numero { get; set; }
        public int Capacidad { get; set; }
        public bool Disponible { get; set; }

        public Sala()
        {
        }

        public Sala(int id, string numero, int capacidad, bool disponible)
        {
            Id = id;
            Numero = numero;
            Capacidad = capacidad;
            Disponible = disponible;
        }

        public Sala(Sala sala)
        {
            Id = sala.Id;
            Numero = sala.Numero;
            Capacidad = sala.Capacidad;
            Disponible = sala.Disponible;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
