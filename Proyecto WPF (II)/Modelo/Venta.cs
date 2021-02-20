using System.ComponentModel;

namespace Proyecto_WPF__II_.Modelo
{
    class Venta : INotifyPropertyChanged
    {
        public int Id { get; }
        public Sesion Sesion { get; set; }
        public int Cantidad { get; set; }
        public string Pago { get; set; }

        public Venta()
        {
        }

        public Venta(int id, Sesion sesion, int cantidad, string pago)
        {
            Id = id;
            Sesion = sesion;
            Cantidad = cantidad;
            Pago = pago;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
