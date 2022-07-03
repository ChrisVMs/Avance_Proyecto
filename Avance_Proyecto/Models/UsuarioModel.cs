using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Avance_Proyecto.Models
{
    public class UsuarioModel
    {
        [Required]
        public string usuario { get; set; }
        [Required]
        public string pass { get; set; }
    }
}
