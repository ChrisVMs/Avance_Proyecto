using System.ComponentModel.DataAnnotations;


namespace Avance_Proyecto.Models
{
    public class ContactModel
    {
        public int IdContacto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
