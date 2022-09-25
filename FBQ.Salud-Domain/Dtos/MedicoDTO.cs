
namespace FBQ.Salud_Domain.Dtos
{
    public class MedicoDTO
    {
        public int MedicoId { get; set; }
        public int EmpeleadoId { get; set; }
        public int EspecialidadId { get; set; }
        public bool Estado { get; set; }
        public int HorarioId { get; set; }
    }
}
