﻿using AutoMapper;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;

namespace FBQ.Salud_Presentation.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Medico, MedicoDTO>().ReverseMap();
            CreateMap<Enfermera, EnfermeraDTO>().ReverseMap();
            CreateMap<Empleado, EmpleadoDTO>().ReverseMap();
            CreateMap<TipoEmpleado, TipoEmpleadoDTO>().ReverseMap();
            CreateMap<HorarioTrabajo, HorarioTrabajoDTO>().ReverseMap();
            CreateMap<Especialidad, EspecialidadDTO>().ReverseMap();
        }
    }
}

    

