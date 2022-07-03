using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avance_Proyecto.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public string Marca { get; set; }

        public int Stock { get; set; }
    }
}
