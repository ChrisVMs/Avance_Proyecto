using Avance_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avance_Proyecto.Servicios
{
    public interface IServicioApi
    {
        Task<List<Producto>> Lista();

        Task<Producto> Obtener(int IdProducto);
    }
}
