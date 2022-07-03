using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avance_Proyecto.Models
{
    public class ResultadoAPI
    {
        public string Mensaje { get; set; }

        public List<Producto> Lista { get; set; }

        public Producto Objeto { get; set; }
    }
}
