
using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FBQ.Salud_AccessData.Queries
{
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly FbqSaludDbContext _context;

        public HabitacionRepository(FbqSaludDbContext context)
        {
            _context = context; 
        }

        public List<Habitacion> GetAll()
        {
            return _context.Habitaciones.Where(habita => habita.PacienteId != 0).Include(enfermera => enfermera.Enfermera).ThenInclude(empl => empl.Empleado).ThenInclude(horario => horario.horario).ToList();
        }

        public List<Habitacion> GetAllFree()
        {
            return _context.Habitaciones.Where(habita => habita.PacienteId == 0).Include(enfermera => enfermera.Enfermera).ThenInclude(empl => empl.Empleado).ThenInclude(horario => horario.horario).ToList();
        }

        public Habitacion GetHabitacionById(int id)
        {
            return _context.Habitaciones.Include(enfermera => enfermera.Enfermera).ThenInclude(empl => empl.Empleado).ThenInclude(horario => horario.horario).FirstOrDefault(habita => habita.HabitacionId == id );
        }

        public Habitacion GetHabitacionByNumero(int numero)
        {
            return _context.Habitaciones.Include(enfermera => enfermera.Enfermera).ThenInclude(empl => empl.Empleado).ThenInclude(horario => horario.horario).FirstOrDefault(habita => habita.Numero == numero);
        }

        public void Update(Habitacion habitacion)
        {
            _context.Update(habitacion);
            _context.SaveChanges();
        }
    }
}
