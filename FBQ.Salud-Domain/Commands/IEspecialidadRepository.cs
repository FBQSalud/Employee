using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Commands
{
    public interface IEspecialidadRepository
    {
        List<Especialidad> GetAll();
        Especialidad GetEspecialidadById(int id);
        void Update(Especialidad especialidad);
        void Delete(Especialidad especialidad);
        void Add(Especialidad especialidad);
    }
}
