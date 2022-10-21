
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Dtos
{
    public class MedicoDTO
    {
        public int EmpleadoId { get; set; }
        public int EspecialidadId { get; set; }
        public bool Estado { get; set; }
        public int HorarioId { get; set; }

        
    }
}
