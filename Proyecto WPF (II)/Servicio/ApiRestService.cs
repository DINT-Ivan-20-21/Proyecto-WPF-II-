using Newtonsoft.Json;
using Proyecto_WPF__II_.Modelo;
using RestSharp;
using System.Collections.ObjectModel;

namespace Proyecto_WPF__II_.Servicio
{
    public static class ApiRestService
    {
        private static RestClient client = new RestClient(Properties.Settings.Default.endPoint);

        internal static ObservableCollection<Pelicula> GetCartelera()
        {
            var request = new RestRequest("peliculas", Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(response.Content);
        }
    }
}
