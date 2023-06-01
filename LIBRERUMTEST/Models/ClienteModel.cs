using System.ComponentModel.DataAnnotations;

namespace LIBRERUMTEST.Models
{
    public class ClienteModel
    {
        [Required(ErrorMessage = "El campo Cedula es obligatorio")]
        public string? Cedula { get; set; }
        [Required(ErrorMessage = "El campo Nombres es obligatorio")]
        public string? Nombres { get; set; }
        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        public string? Direccion { get; set; }



    }
}
