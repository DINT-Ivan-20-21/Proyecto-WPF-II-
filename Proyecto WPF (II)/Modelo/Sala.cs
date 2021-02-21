using System.Collections.Generic;
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

        public override bool Equals(object obj)
        {
            return obj is Sala sala &&
                   Id == sala.Id &&
                   Numero == sala.Numero &&
                   Capacidad == sala.Capacidad &&
                   Disponible == sala.Disponible;

        }

        public override int GetHashCode()
        {
            int hashCode = -188733676;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Numero);
            hashCode = hashCode * -1521134295 + Capacidad.GetHashCode();
            hashCode = hashCode * -1521134295 + Disponible.GetHashCode();
            return hashCode;
        }
    }
}
