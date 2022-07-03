using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIPROYECTO.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;

namespace APIPROYECTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly string cadenaSQL;

        public ProductoController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("cadenaSQL");

        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_Listar_Productos", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(rd["IdProducto"]),
                                Nombre = rd["Nombre"].ToString(),
                                Descripcion = rd["Descripcion"].ToString(),
                                Stock = Convert.ToInt32(rd["Stock"])
                            });
                        }
                    }
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = e.Message, response = lista });
            }
        }
    }
}
