
using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FBQ.Salud_AccessData.Queries
{
    public class EnfermeraRepository : IEnfermeraRepository
    {
        private readonly FbqSaludDbContext _context;

        public EnfermeraRepository(FbqSaludDbContext context)
        {
            _context = context;
        }
        
        public List<Enfermera> GetAll()
        {
            return _context.Enfermeras.Include(e => e.Empleado).ThenInclude(horario => horario.horario).Where(enfermera => enfermera.Estado == true).ToList();
        }

        public Enfermera GetEnfermeraById(int id)
        {
            return _context.Enfermeras.Include(e => e.Empleado).ThenInclude(horario => horario.horario).FirstOrDefault(enfermera => enfermera.EnfermeraId == id && enfermera.Estado == true);
        }

        public void Add(Enfermera enfermera)
        {
            _context.Enfermeras.Add(enfermera);
            _context.SaveChanges();
        }

        public void Update(Enfermera enfermera)
        {
            _context.Update(enfermera);
            _context.SaveChanges();
        }

        public void Delete(Enfermera enfermera)
        {
            _context.Enfermeras.Remove(enfermera);
            _context.SaveChanges();
        }

        public Enfermera GetEnfermeraByEmpleadoId(int id)
        {
            return _context.Enfermeras.Include(e => e.Empleado).ThenInclude(horario => horario.horario).FirstOrDefault(enfermera => enfermera.EmpleadoId == id && enfermera.Estado == true);
        }
    }
}
