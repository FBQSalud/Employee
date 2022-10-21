using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Domain.Commands
{
    public interface IEnfermeraRepository
    {
        List<Enfermera> GetAll();
        Enfermera GetEnfermeraById(int id);
        Enfermera GetEnfermeraByEmpleadoId(int id);
        void Update(Enfermera enfermera);
        void Delete(Enfermera enfermera);
        void Add(Enfermera enfermera);
    }
}
