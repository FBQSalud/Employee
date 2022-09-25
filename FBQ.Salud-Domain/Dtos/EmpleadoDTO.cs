
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FBQ.Salud_Domain.Dtos
{
    public class EmpleadoDTO
    {
        public int EmpleadoId { get; set; }
        [Required]
        public int TipoEmpleadoId { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Dni")]
        public string DNI { get; set; }
        public bool Estado { get; set; }
        [Required]
        [Display(Name = "Foto")]
        public string Foto { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Clave { get; set; }
        [Required]
        public int HorarioId { get; set; }
    }
}
