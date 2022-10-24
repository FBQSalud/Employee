
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Commands
{
    public interface IHabitacionRepository
    {
        List<Habitacion> GetAll();
        List<Habitacion> GetAllFree();
        Habitacion GetHabitacionById(int id);
        void Update(Habitacion habitacion);
        Habitacion GetHabitacionByNumero(int numero);
    }
}
