using System.ComponentModel.DataAnnotations;

namespace PruebaAPI.Modelos
{
    public class Producto
    {
        [Required (ErrorMessage = "El Id es obligatorio")]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Range(0,50)]
        public decimal Precio { get; set; }

        [Required]
        [Range(0,100)]
        public int Existencia { get; set; }
        public bool Disponible { get; set; }
    }
}
