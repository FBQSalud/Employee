
namespace FBQ.Salud_Domain.Entities
{
    public class Medico
    {
        public int MedicoId { get; set; }
        public int EmpleadoId { get; set; }
        public int EspecialidadId { get; set; }
        public bool Estado { get; set; }
        public int HorarioId { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual Especialidad Especialidad { get; set; }
    }
}
