﻿
using System.ComponentModel.DataAnnotations;

namespace FBQ.Salud_Domain.Entities
{
    public class HabitacionDTO
    {

        [Display(Name = "PacienteId")]
        public int pacienteId { get; set; }
        [Display(Name = "EnfermeraId")]
        public int enfermeraId { get; set; }
        [Display(Name = "Estado")]
        public bool Estado { get; set; }
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
