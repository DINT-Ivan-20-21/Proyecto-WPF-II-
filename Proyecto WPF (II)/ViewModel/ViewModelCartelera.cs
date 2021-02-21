using Proyecto_WPF__II_.Modelo;
using Proyecto_WPF__II_.Servicio;
using System.Collections.ObjectModel;

namespace Proyecto_WPF__II_.ViewModel
{
    internal class ViewModelCartelera
    {
        public ObservableCollection<Pelicula> Peliculas { get; }

        public ViewModelCartelera()
        {
            SQLiteService _bd = new SQLiteService();
            Peliculas = _bd.LeerPeliculas();
        }
    }
}
