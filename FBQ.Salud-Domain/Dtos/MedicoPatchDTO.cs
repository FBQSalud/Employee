
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Dtos
{
    public class MedicoPatchDTO
    {
        public int EspecialidadId { get; set; }
        public bool Estado { get; set; }
        public int HorarioId { get; set; }

        
    }
}
