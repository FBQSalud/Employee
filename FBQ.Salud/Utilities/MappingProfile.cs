using AutoMapper;
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
            CreateMap<Habitacion, HabitacionDTO>().ReverseMap();

            CreateMap<MedicoResponseDTO, Medico>().ReverseMap();
            CreateMap<EnfermeraResponseDTO, Enfermera>().ReverseMap();
            CreateMap<MedicoPatchDTO, Medico>().ReverseMap();
            CreateMap<EnfermeraPatchResponseDTO, Enfermera>().ReverseMap();
            CreateMap<EmpleadoResponseDTO, Empleado>().ReverseMap();
            CreateMap<EmpleadoPatchResponseDTO, Empleado>().ReverseMap();
            CreateMap<TipoEmpleadoResponseDTO, TipoEmpleado>().ReverseMap();
            CreateMap<HorarioTrabajoResponseDTO, HorarioTrabajo>().ReverseMap();
            CreateMap<EspecialidadResponseDTO, Especialidad>().ReverseMap();
            CreateMap<HabitacionResponseDTO, Habitacion>().ReverseMap();
            CreateMap<HabitacionResponseDTO, HabitacionDTO>().ReverseMap();
        }
    }
}

    

