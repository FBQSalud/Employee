
using System.ComponentModel.DataAnnotations;

namespace FBQ.Salud_Domain.Entities
{
    public class Habitacion
    {
        [Key]
        public int HabitacionId { get; set; }
        [Display(Name = "PacienteId")]
        public int PacienteId { get; set; }
        [Display(Name = "EnfermeraId")]
        public int EnfermeraId { get; set; }
        [Display(Name = "Estado")]
        public bool Estado { get; set; }
        [Required]
        [Display(Name = "Piso")]
        public int Piso { get; set; }
        [Required]
        [Display(Name = "Número")]
        public int Numero { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }


    }
}
