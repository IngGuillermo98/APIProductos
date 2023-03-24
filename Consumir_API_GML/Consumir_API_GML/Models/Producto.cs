using System.ComponentModel.DataAnnotations;

namespace Consumir_API_GML.Models
{
    public class Producto
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio.")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Por favor, ingrese un número válido con dos decimales")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio.")]
        public int? CodigoFabricante { get; set; }
    }
}
