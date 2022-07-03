using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avance_Proyecto.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Avance_Proyecto.Controllers
{
    public class ApiListarController : Controller
    {
        public async Task<IActionResult> ListarApi()
        {

            List<Producto> lista = new List<Producto>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:36950/api/EntidadProducto/");
                HttpResponseMessage response = await httpClient.GetAsync("GetProductos");
                string apiResponse = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<Producto>>(apiResponse).Select(
                    s => new Producto
                    {
                        IdProducto = s.IdProducto,
                        Nombre = s.Nombre,
                        Marca = s.Marca,
                        Stock = s.Stock
                    }
                    ).ToList();
             }

             return View(lista);
        }
    }
}
