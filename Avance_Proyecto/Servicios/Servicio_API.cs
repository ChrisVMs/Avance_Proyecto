using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

using System.Text;
using Avance_Proyecto.Models;
using System.Net.Http;

namespace Avance_Proyecto.Servicios
{
    public class Servicio_API:IServicioApi
    {
        private static string _baseurl;

        public Servicio_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseurl = builder.GetSection("ApiSettings:baseURL").Value;
        }

        public async Task<List<Producto>> Lista()
        {
            List<Producto> lista = new List<Producto>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var response = await cliente.GetAsync("​/api​/Producto​/Lista");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<ResultadoAPI>(json_respuesta);
                lista = resultado.Lista;
            }

            return lista;
        }

        public Task<Producto> Obtener(int IdProducto)
        {
            throw new NotImplementedException();
        }
    }

}
