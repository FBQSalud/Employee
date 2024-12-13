
using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_AccessData.Queries
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        private readonly FbqSaludDbContext _context;

        public EspecialidadRepository(FbqSaludDbContext context)
        {
            _context = context;
        }

        public List<Especialidad> GetAll()
        {
            return _context.Especialidades.ToList();
        }

        public Especialidad GetEspecialidadById(int id)
        {
            return _context.Especialidades.FirstOrDefault(especialidad => especialidad.EspecialidadId == id);
        }

        public void Add(Especialidad especialidad)
        {
            _context.Especialidades.Add(especialidad);
            _context.SaveChanges();
        }

        public void Update(Especialidad especialidad)
        {
            _context.Especialidades.Update(especialidad);
            _context.SaveChanges();
        }

        public void Delete(Especialidad especialidad)
        {
            _context.Especialidades.Remove(especialidad);
            _context.SaveChanges();
        }
    }
}
