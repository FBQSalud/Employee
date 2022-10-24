
using FBQ.Salud_Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace FBQ.Salud_Domain.Entities
{
    public class HabitacionResponseDTO
    {
        [Display(Name = "PacienteId")]
        public int pacienteId { get; set; }
        public virtual EnfermeraResponseDTO? Enfermera { get; set; }
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
