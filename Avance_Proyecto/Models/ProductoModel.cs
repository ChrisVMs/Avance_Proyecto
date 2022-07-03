using System.ComponentModel.DataAnnotations;

namespace Avance_Proyecto.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
