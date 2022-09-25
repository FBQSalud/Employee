
using AutoMapper;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Application.Services
{
    public interface IHorarioTrabajoServices
    {
        List<HorarioTrabajo> GetAll();
        HorarioTrabajo GetHorarioTrabajoById(int id);
        void Update(HorarioTrabajo horarioTrabajo);
        void Delete(HorarioTrabajo horarioTrabajo);
        HorarioTrabajo CreateHorarioTrabajo(HorarioTrabajoDTO horarioTrabajo);
    }
    public class HorarioTrabajoServices : IHorarioTrabajoServices
    {
        IHorarioTrabajoRepository _horarioTrabajoRepository;
        private readonly IMapper _mapper;

        public HorarioTrabajoServices(IHorarioTrabajoRepository horarioTrabajoRepository, 
            IMapper mapper)
        {
            _horarioTrabajoRepository = horarioTrabajoRepository;
            _mapper = mapper;
        }

        public List<HorarioTrabajo> GetAll()
        {
            return _horarioTrabajoRepository.GetAll();
        }

        public HorarioTrabajo GetHorarioTrabajoById(int id)
        {
            return _horarioTrabajoRepository.GetHorarioTrabajoById(id);
        }

        public HorarioTrabajo CreateHorarioTrabajo(HorarioTrabajoDTO horarioTrabajo)
        {
            var horarioTrabajoMapped = _mapper.Map<HorarioTrabajo>(horarioTrabajo);
            _horarioTrabajoRepository.Add(horarioTrabajoMapped);

            return horarioTrabajoMapped;
        }

        public void Update(HorarioTrabajo horarioTrabajo)
        {
            _horarioTrabajoRepository.Update(horarioTrabajo);
        }

        public void Delete(HorarioTrabajo horarioTrabajo)
        {
            _horarioTrabajoRepository.Delete(horarioTrabajo);
        }
    }
}
