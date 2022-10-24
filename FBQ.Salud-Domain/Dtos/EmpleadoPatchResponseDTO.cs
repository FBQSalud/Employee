
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FBQ.Salud_Domain.Dtos
{
    public class EmpleadoPatchResponseDTO
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Foto")]
        public string Foto { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        public int HorarioId { get; set; }


    }
}
