using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_AccessData.Queries
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly FbqSaludDbContext _context;

        public MedicoRepository(FbqSaludDbContext context)
        {
            _context = context;
        }
            
        public List<Medico> GetAll()
        {
            return _context.Medicos.ToList();
        }

        public Medico GetMedicoById(int id)
        {
            return _context.Medicos.FirstOrDefault(medico => medico.MedicoId == id);
        }

        public void Add(Medico medico)
        {
            _context.Medicos.Add(medico);
            _context.SaveChanges();
        }

        public void Update(Medico medico)
        {
            _context.Update(medico);
            _context.SaveChanges();
        }

        public void Delete(Medico medico)
        {
            _context.Medicos.Remove(medico);
            _context.SaveChanges();
        }
    }
}
