using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avance_Proyecto.Datos;
using Avance_Proyecto.Models;

namespace Avance_Proyecto.Controllers
{
    public class ProductosController : Controller
    {
        ProductoDatos _ProductoDatos = new ProductoDatos();

        public IActionResult ListarProductos()
        {
            var oListaProductos = _ProductoDatos.Listar();
            return View(oListaProductos);
        }

        public IActionResult GuardarProductos()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarProductos(ProductoModel oProducto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ProductoDatos.Guardar(oProducto);

            if (respuesta)
                return RedirectToAction("ListarProductos");
            else
                return View();
        }

        public IActionResult EditarProductos(int IdProducto)
        {
            var oproducto = _ProductoDatos.Obtener(IdProducto);
            return View(oproducto);
        }

        [HttpPost]
        public IActionResult EditarProductos(ProductoModel oProducto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ProductoDatos.Editar(oProducto);

            if (respuesta)
                return RedirectToAction("ListarProductos");
            else
                return View();
        }

        public IActionResult EliminarProductos(int IdProducto)
        {
            var oproducto = _ProductoDatos.Obtener(IdProducto);

            return View(oproducto);
        }

        [HttpPost]
        public IActionResult EliminarProductos(ProductoModel oProducto)
        {
            var respuesta = _ProductoDatos.Eliminar(oProducto.IdProducto);

            if (respuesta)
                return RedirectToAction("ListarProductos");
            else
                return View();
        }
    }
}
