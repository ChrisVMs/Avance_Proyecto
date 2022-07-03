using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avance_Proyecto.Datos;
using Avance_Proyecto.Models;

namespace Avance_Proyecto.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Guardar(ContactModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Guardar(oContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdContacto)
        {
            var ocontacto = _ContactoDatos.Obtener(IdContacto);

            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Editar(oContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdContacto)
        {
            var ocontacto = _ContactoDatos.Obtener(IdContacto);

            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactModel oContacto)
        {
            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
