
using FBQ.Salud_AccessData.Commands;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FBQ.Salud_AccessData.Queries
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly FbqSaludDbContext _context;

        public EmpleadoRepository(FbqSaludDbContext context)
        {
            _context = context; 
        }
       
        public List<Empleado> GetAll()
        {
            return _context.Empleados.Include(a => a.horario ).ToList();
        }

        public Empleado GetEmpleadoById(int id)
        {
            return _context.Empleados.Include(a => a.horario).FirstOrDefault(empleado => empleado.EmpleadoId == id);
        }

        public void Add(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Update(Empleado empleado)
        {
            _context.Update(empleado);
            _context.SaveChanges();
        }
        
        public void Delete(Empleado empleado)
        {
            _context.Remove(empleado);
            _context.SaveChanges();
        }

        public Empleado GetEmpleadoByDni(string dni)
        {
            return _context.Empleados.Include(a => a.horario).FirstOrDefault(empleado => empleado.DNI == dni );
        }

        public Empleado GetEmpleadoByUser(string user)
        {
            return _context.Empleados.Include(a => a.horario).FirstOrDefault(empleado => empleado.Usuario == user);
        }
    }
}
