
using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;

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
            return _context.Enfermeras.ToList();
        }

        public Enfermera GetEnfermeraById(int id)
        {
            return _context.Enfermeras.FirstOrDefault(enfermera => enfermera.EnfermeraId == id);
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
    }
}
