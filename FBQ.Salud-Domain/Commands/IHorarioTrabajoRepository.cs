
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Commands
{
    public interface IHorarioTrabajoRepository
    {
        List<HorarioTrabajo> GetAll();
        HorarioTrabajo GetHorarioTrabajoById(int id);
        void Update(HorarioTrabajo horarioTrabajo);
        void Delete(HorarioTrabajo horarioTrabajo);
        void Add(HorarioTrabajo horarioTrabajo);
    }
}
