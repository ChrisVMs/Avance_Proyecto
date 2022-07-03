using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPROYECTO.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }
    }
}
