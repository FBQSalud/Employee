
using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_AccessData.Queries
{
    public class TipoEmpleadoRepository : ITipoEmpleadoRepository
    {
        private readonly FbqSaludDbContext _context;

        public TipoEmpleadoRepository(FbqSaludDbContext context)
        {
            _context = context;
        }

        public List<TipoEmpleado> GetAll()
        {
            return _context.TipoEmpleados.Where(tipo => tipo.Estado == true).ToList();
        }

        public TipoEmpleado GetTipoEmpleadoById(int id)
        {
            return _context.TipoEmpleados.FirstOrDefault(tipoEmpleado => tipoEmpleado.TipoEmpleadoId == id && tipoEmpleado.Estado == true);
        }

        public void Add(TipoEmpleado tipoEmpleado)
        {
            _context.Add(tipoEmpleado);
            _context.SaveChanges();
        }

        public void Update(TipoEmpleado tipoEmpleado)
        {
            _context.Update(tipoEmpleado);
            _context.SaveChanges();
        }

        public void Delete(TipoEmpleado tipoEmpleado)
        {
            _context.Remove(tipoEmpleado);
            _context.SaveChanges();
        }
    }
}
