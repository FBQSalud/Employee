
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Commands
{
    public interface ITipoEmpleadoRepository
    {
        List<TipoEmpleado> GetAll();
        TipoEmpleado GetTipoEmpleadoById(int id);
        void Update(TipoEmpleado tipoEmpleado);
        void Delete(TipoEmpleado tipoEmpleado);
        void Add(TipoEmpleado tipoEmpleado);
    }
}
