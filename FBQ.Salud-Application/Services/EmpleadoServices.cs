
using AutoMapper;
using FBQ.Salud_AccessData.Queries;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FBQ.Salud_Application.Services
{
    public interface IEmpleadoServices
    {
        List<Empleado> GetAll();
        Empleado GetEmpleadoById(int id);
        void Update(Empleado empleado);
        void Delete(Empleado empleado);
        Empleado CreateEmpleado(EmpleadoDTO empleado);
    }
    public class EmpleadoServices : IEmpleadoServices
    {
        IEmpleadoRepository _empleadoRepository;
        private readonly IMapper _mapper;

        public EmpleadoServices(IEmpleadoRepository empleadoRepository, 
            IMapper mapper)
        {
            _empleadoRepository = empleadoRepository;
            _mapper = mapper;
        }

        public List<Empleado> GetAll()
        {
            return _empleadoRepository.GetAll();
        }

        public Empleado GetEmpleadoById(int id)
        {
            return _empleadoRepository.GetEmpleadoById(id);
        }

        public Empleado CreateEmpleado(EmpleadoDTO empleado)
        {
            var empleadoMapped = _mapper.Map<Empleado>(empleado);
            _empleadoRepository.Add(empleadoMapped);

            return empleadoMapped;
        }
      
        public void Update(Empleado empleado)
        {
            _empleadoRepository.Update(empleado);
        }

        public void Delete(Empleado empleado)
        {
            _empleadoRepository.Delete(empleado);
        }
    }
}
