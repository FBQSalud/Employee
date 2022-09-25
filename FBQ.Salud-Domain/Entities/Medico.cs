
namespace FBQ.Salud_Domain.Entities
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public int EmpeleadoId { get; set; }
        public int EspecialidadId { get; set; }
        public bool Estado { get; set; }
        public int HorarioId { get; set; }
    }
}
