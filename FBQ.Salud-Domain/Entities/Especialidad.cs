
using System.ComponentModel.DataAnnotations;

namespace FBQ.Salud_Domain.Entities
{
    public class Especialidad
    {
        [Key]
        public int EspecilalidadId { get; set; }
        [Required]
        public string Descripcion { get; set; } 
    }
}
