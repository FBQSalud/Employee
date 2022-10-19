
using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;

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
            return _context.Habitaciones.ToList();
        }

        public Habitacion GetHabitacionById(int id)
        {
            return _context.Habitaciones.FirstOrDefault(habita => habita.HabitacionId == id);
        }

        public void Update(Habitacion habitacion)
        {
            _context.Update(habitacion);
            _context.SaveChanges();
        }
    }
}
