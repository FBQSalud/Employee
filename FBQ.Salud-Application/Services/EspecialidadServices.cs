
using AutoMapper;
using FBQ.Salud_AccessData.Queries;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Application.Services
{
    public interface IEspecialidadServices
    {
        List<Especialidad> GetAll();
        Especialidad GetEspecialidadById(int id);
        void Update(Especialidad especialidad);
        void Delete(Especialidad especialidad);
        Especialidad CreateEspecialidad(EspecialidadDTO especialidad);
    }
    public class EspecialidadServices : IEspecialidadServices
    {
        IEspecialidadRepository _especialidadRepository;
        private readonly IMapper _mapper;

        public EspecialidadServices(IEspecialidadRepository especialidadRepository, 
            IMapper mapper)
        {
            _especialidadRepository = especialidadRepository;
            _mapper = mapper;
        }

        public List<Especialidad> GetAll()
        {
            return _especialidadRepository.GetAll();
        }

        public Especialidad GetEspecialidadById(int id)
        {
            return _especialidadRepository.GetEspecialidadById(id);
        }
        public Especialidad CreateEspecialidad(EspecialidadDTO especialidad)
        {
            var especialidadMapped = _mapper.Map<Especialidad>(especialidad);
            _especialidadRepository.Add(especialidadMapped);

            return especialidadMapped;
        }
       
        public void Update(Especialidad especialidad)
        {
            _especialidadRepository.Update(especialidad);
        }

        public void Delete(Especialidad especialidad)
        {
            _especialidadRepository.Delete(especialidad);
        }
    }
}
