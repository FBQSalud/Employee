
using System.ComponentModel.DataAnnotations;

namespace FBQ.Salud_Domain.Entities
{
    public class HabitacionResponseDTO
    {
        [Display(Name = "PacienteId")]
        public int pacienteId { get; set; }
        [Display(Name = "EnfermeraId")]
        public int enfermeraId { get; set; }
        [Required]
        [Display(Name = "Piso")]
        public int Piso { get; set; }
        [Required]
        [Display(Name = "Número")]
        public int Numero { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
       
    }
}
