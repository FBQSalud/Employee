﻿using AutoMapper;
using FBQ.Salud_Domain.Commands;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;
using Microsoft.Extensions.Logging;

namespace FBQ.Salud_Application.Services
{
    public interface IMedicoServices
    {
        List<MedicoResponseDTO> GetAll();
        Medico GetMedicoById(int id);
        Medico GetMedicoByEmpleadoId(int id);
        void Update(Medico medico);
        void Delete(Medico medico);
        Medico CreateMedico(MedicoDTO medico);
    }
    public class MedicoServices : IMedicoServices
    {
        IMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;

        public MedicoServices(IMedicoRepository medicoRepository, 
            IMapper mapper)
        {
            _medicoRepository = medicoRepository;   
            _mapper = mapper;
        }

        public List<MedicoResponseDTO> GetAll()
        {
            var test = _mapper.Map<List<MedicoResponseDTO>>(_medicoRepository.GetAll());
            return test;
        }

        public Medico GetMedicoById(int id)
        {
            return _medicoRepository.GetMedicoById(id);
        }

        public Medico CreateMedico(MedicoDTO medico)
        {
            var medicoMapped = _mapper.Map<Medico>(medico); 
            _medicoRepository.Add(medicoMapped);

            return medicoMapped;
        }

        public void Update(Medico medico)
        {
            _medicoRepository.Update(medico);
        }

        public void Delete(Medico medico)
        {
            _medicoRepository.Delete(medico);
        }

        public Medico GetMedicoByEmpleadoId(int id)
        {
            return _medicoRepository.GetMedicoByEmpleadoId(id);
        }
    }
}
