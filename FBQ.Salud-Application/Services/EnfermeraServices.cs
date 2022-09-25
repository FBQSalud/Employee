using AutoMapper;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;


namespace FBQ.Salud_Application.Services
{
    public interface IEnfermeraServices
    {
        List<Enfermera> GetAll();
        Enfermera GetEnfermeraById(int id);
        void Update(Enfermera enfermera);
        void Delete(Enfermera enfermera);
        Enfermera CreateEnfermera(EnfermeraDTO enfermera);
    }
    public class EnfermeraServices : IEnfermeraServices
    {
        IEnfermeraRepository _enfermeraRepository;
        private readonly IMapper _mapper;

        public EnfermeraServices(IEnfermeraRepository enfermeraRepository, 
            IMapper mapper)
        {
            _enfermeraRepository = enfermeraRepository;
            _mapper = mapper;
        }

        public List<Enfermera> GetAll()
        {
            return _enfermeraRepository.GetAll();
        }

        public Enfermera GetEnfermeraById(int id)
        {
            return _enfermeraRepository.GetEnfermeraById(id);
        }
        public Enfermera CreateEnfermera(EnfermeraDTO enfermera)
        {
            var enfermeraMapped = _mapper.Map<Enfermera>(enfermera);
            _enfermeraRepository.Add(enfermeraMapped);

            return enfermeraMapped;
        }

        public void Update(Enfermera enfermera)
        {
            _enfermeraRepository.Update(enfermera);
        }

        public void Delete(Enfermera enfermera)
        {
            _enfermeraRepository.Delete(enfermera);
        }
    }
}
