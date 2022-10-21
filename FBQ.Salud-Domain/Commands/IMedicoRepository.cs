using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Commands
{
    public interface IMedicoRepository
    {
        List<Medico> GetAll();
        Medico GetMedicoById(int id);
        Medico GetMedicoByEmpleadoId(int id);
        void Update(Medico medico);
        void Delete(Medico medico);
        void Add(Medico medico);
    }
}
