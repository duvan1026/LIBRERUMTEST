using System.ComponentModel.DataAnnotations;

namespace LIBRERUMTEST.Models
{
    public class VentaModel
    {
        [Required(ErrorMessage = "El campo CodigoVenta es obligatorio")]
        public string? CodigoVenta { get; set; }
        [Required(ErrorMessage = "El campo CodigoProducto es obligatorio")]
        public string? CodigoProducto { get; set; }
        [Required(ErrorMessage = "El campo FechaVenta es obligatorio")]
        public string? FechaVenta { get; set; }
        [Required(ErrorMessage = "El campo PuntoVenta es obligatorio")]
        public string? PuntoVenta { get; set; }
        [Required(ErrorMessage = "El campo Total es obligatorio")]
        public decimal Total { get; set; }

        public ClienteModel? ClienteModel { get; set; }
    }
}
