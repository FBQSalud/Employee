
using AutoMapper;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Application.Services
{
    public interface ITipoEmpleadoServices
    {
        List<TipoEmpleado> GetAll();
        TipoEmpleado GetTipoEmpleadoById(int id);
        void Update(TipoEmpleado tipoEmpleado);
        void Delete(TipoEmpleado tipoEmpleado);
        TipoEmpleado CreateTipoEmpleado(TipoEmpleadoDTO tipoEmpleado);
    }
    public class TipoEmpleadoServices : ITipoEmpleadoServices
    {
        ITipoEmpleadoRepository _tipoEmpleadoRepository;
        private readonly IMapper _mapper;

        public TipoEmpleadoServices(ITipoEmpleadoRepository tipoEmpleadoRepository, 
            IMapper mapper)
        {
            _tipoEmpleadoRepository = tipoEmpleadoRepository;
            _mapper = mapper;
        }

        public List<TipoEmpleado> GetAll()
        {
            return _tipoEmpleadoRepository.GetAll();
        }

        public TipoEmpleado GetTipoEmpleadoById(int id)
        {
            return _tipoEmpleadoRepository.GetTipoEmpleadoById(id);
        }

        public TipoEmpleado CreateTipoEmpleado(TipoEmpleadoDTO tipoEmpleado)
        {
            var tipoEmpleadoMapped = _mapper.Map<TipoEmpleado>(tipoEmpleado);
            _tipoEmpleadoRepository.Add(tipoEmpleadoMapped);

            return tipoEmpleadoMapped;
        }

        public void Update(TipoEmpleado tipoEmpleado)
        {
            _tipoEmpleadoRepository.Update(tipoEmpleado);
        }

        public void Delete(TipoEmpleado tipoEmpleado)
        {
            _tipoEmpleadoRepository.Delete(tipoEmpleado);
        }       
    }
}
