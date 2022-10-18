
using System.ComponentModel.DataAnnotations;

namespace FBQ.Salud_Domain.Entities
{
    public class Habitacion
    {

        [Key]
        public int HabitacionId { get; set; }
        [Required]
        [Display(Name = "PacienteId")]
        public int PacienteId { get; set; }
        [Required]
        [Display(Name = "EnfermeraId")]
        public int EnfermeraId { get; set; }
        public bool Estado { get; set; }
        [Required]
        [Display(Name = "Número")]
        public int Numero { get; set; }
        [Required]
        [Display(Name = "Piso")]
        public int piso { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }
       
    }
}
