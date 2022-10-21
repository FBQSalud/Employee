
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Dtos
{
    public class MedicoResponseDTO
    {
        public EmpleadoResponseDTO empleado { get; set; }
        public EspecialidadResponseDTO especialidad { get; set; }
       
    }
}
