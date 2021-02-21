using Proyecto_WPF__II_.Modelo;
using Proyecto_WPF__II_.Servicio;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Proyecto_WPF__II_.ViewModel
{
    internal class ViewModelCartelera : INotifyPropertyChanged
    {
        public ObservableCollection<Pelicula> Peliculas { get; }

        public ViewModelCartelera()
        {
            SQLiteService _bd = new SQLiteService();
            Peliculas = _bd.LeerPeliculas();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
