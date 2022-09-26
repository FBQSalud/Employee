
using System.ComponentModel.DataAnnotations;

namespace FBQ.Salud_Domain.Entities
{
    public class HorarioTrabajo
    {
        [Key]
        public int HorarioId { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Fecha { get; set; }
        public string DiaSemana { get; set; }
        public bool Estado { get; set; }
    }
}
