
namespace FBQ.Salud_Domain.Dtos
{
    public class HorarioTrabajoDTO
    {
        public int HorarioId { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Fecha { get; set; }
        public string DiaSemana { get; set; }
        public bool Estado { get; set; }
    }
}
