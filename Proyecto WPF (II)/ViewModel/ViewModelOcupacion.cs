using Proyecto_WPF__II_.Modelo;
using Proyecto_WPF__II_.Servicio;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Proyecto_WPF__II_.ViewModel
{
    class ViewModelOcupacion : INotifyPropertyChanged
    {
        public List<object> Datos { get; set; }

        public ViewModelOcupacion()
        {
            Datos = new List<object>();

            SQLiteService _bd = new SQLiteService();
            ObservableCollection<Sesion> sesiones = _bd.LeerSesiones();
            foreach (Sesion sesion in sesiones)
            {
                if (sesion.Sala.Disponible)
                {
                    Datos.Add(
                        new
                        {
                            Sala = sesion.Sala.Numero,
                            Titulo = sesion.Pelicula.Titulo,
                            Hora = sesion.Hora.TimeOfDay,
                            Disponibles = sesion.Sala.Capacidad - _bd.CantidadEntradasVendidas(sesion.Id)
                        }
                    );
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
