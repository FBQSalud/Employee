
using AutoMapper;
using FBQ.Salud_AccessData.Queries;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FBQ.Salud_Application.Services
{
    public interface IHabitacionServices
    {
        List<HabitacionResponseDTO> GetAll();
        List<HabitacionResponseDTO> GetAllFree();
        Habitacion GetHabitacionById(int id);
        void Update(Habitacion habitacion);
        Habitacion GetHabitacionByNumero(int numero);
    }
    public class HabitacionServices : IHabitacionServices
    {
        IHabitacionRepository _habitacionRepository;
        private readonly IMapper _mapper;

        public HabitacionServices(IHabitacionRepository habitacionRepository, 
            IMapper mapper)
        {
            _habitacionRepository = habitacionRepository;
            _mapper = mapper;
        }

        public List<HabitacionResponseDTO> GetAll()
        {
            List<Habitacion> list = _habitacionRepository.GetAll();
               return  _mapper.Map<List<HabitacionResponseDTO>>(list);
            
            
        }

        public Habitacion GetHabitacionById(int id)
        {
            return _habitacionRepository.GetHabitacionById(id);
        }

        public void Update(Habitacion habitacion)
        {
             _habitacionRepository.Update(habitacion);
        }

        public Habitacion GetHabitacionByNumero(int numero)
        {
            return _habitacionRepository.GetHabitacionByNumero(numero);
        }

        public List<HabitacionResponseDTO> GetAllFree()
        {
            List<Habitacion> list = _habitacionRepository.GetAllFree();
            return _mapper.Map<List<HabitacionResponseDTO>>(list);
        }
    }
}
