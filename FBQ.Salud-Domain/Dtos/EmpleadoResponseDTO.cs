
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FBQ.Salud_Domain.Dtos
{
    public class EmpleadoResponseDTO
    {
        public int EmpleadoId { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Dni")]
        public string DNI { get; set; }
        [Required]
        [Display(Name = "Foto")]
        public string Foto { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Required]
        public HorarioTrabajoResponseDTO horario { get; set; }


    }
}
