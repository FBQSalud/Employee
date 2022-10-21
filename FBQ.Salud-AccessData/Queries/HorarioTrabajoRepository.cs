
using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_AccessData.Queries
{
    public class HorarioTrabajoRepository : IHorarioTrabajoRepository
    {
        private readonly FbqSaludDbContext _context;

        public HorarioTrabajoRepository(FbqSaludDbContext context)
        {
            _context = context; 
        }
            
        public List<HorarioTrabajo> GetAll()
        {
            return _context.HorariosTrabajo.Where(HorarioTrabajo => HorarioTrabajo.Estado == true).ToList();
        }

        public HorarioTrabajo GetHorarioTrabajoById(int id)
        {
            return _context.HorariosTrabajo.FirstOrDefault(horarioTrabajo => horarioTrabajo.HorarioId == id && horarioTrabajo.Estado == true);
        }

        public void Add(HorarioTrabajo horarioTrabajo)
        {
            _context.Add(horarioTrabajo);
            _context.SaveChanges();
        }

        public void Update(HorarioTrabajo horarioTrabajo)
        {
            _context.Update(horarioTrabajo);
            _context.SaveChanges();
        }
        public void Delete(HorarioTrabajo horarioTrabajo)
        {
            _context.Remove(horarioTrabajo);
            _context.SaveChanges();
        }
    }
}
