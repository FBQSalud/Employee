
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Commands
{
    public interface IEmpleadoRepository
    {
        List<Empleado> GetAll();
        Empleado GetEmpleadoById(int id);
        Empleado GetEmpleadoByDni(string dni);
        void Update(Empleado empleado);
        void Delete(Empleado empleado);
        void Add(Empleado empleado);
    }
}
