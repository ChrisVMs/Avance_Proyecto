using Avance_Proyecto.Datos;
using Avance_Proyecto.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avance_Proyecto.Controllers
{
    public class UsuariosController : Controller
    {
        UsuarioDatos _ContactoDatos = new UsuarioDatos();

        public IActionResult Usuario()
        {
            return View();
        }



        [HttpPost]

        public IActionResult Guardar(UsuarioModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContactoDatos.Guardar(oContacto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
