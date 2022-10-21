
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
            return _context.Habitaciones.Where(Habitacion => Habitacion.Estado == true).ToList();
        }

        public Habitacion GetHabitacionById(int id)
        {
            return _context.Habitaciones.FirstOrDefault(habita => habita.HabitacionId == id && habita.Estado == true);
        }

        public Habitacion GetHabitacionByNumero(int numero)
        {
            return _context.Habitaciones.FirstOrDefault(habita => habita.Numero == numero && habita.Estado == true);
        }

        public void Update(Habitacion habitacion)
        {
            _context.Update(habitacion);
            _context.SaveChanges();
        }
    }
}
