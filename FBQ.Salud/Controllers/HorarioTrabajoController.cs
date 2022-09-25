using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FBQ.Salud_Presentation.Controllers
{
    [Route("api/horarioTrabajo")]
    [ApiController]
    public class HorarioTrabajoController : ControllerBase
    {
        IHorarioTrabajoServices _horarioTrabajoServices;
        private readonly IMapper _mapper;

        public HorarioTrabajoController(IHorarioTrabajoServices horarioTrabajoServices, 
            IMapper mapper)
        {
            _horarioTrabajoServices = horarioTrabajoServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var horarioTrabajo = _horarioTrabajoServices.GetAll();
                var horarioTrabajoMapped = _mapper.Map<List<HorarioTrabajoDTO>>(horarioTrabajo);

                return Ok(horarioTrabajoMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var horarioTrabajo = _horarioTrabajoServices.GetHorarioTrabajoById(id);
                var horarioTrabajoMapped = _mapper.Map<HorarioTrabajoDTO>(horarioTrabajo);
                if (horarioTrabajo == null)
                {
                    return NotFound("Horario de Trabajo Inexistente");
                }
                return Ok(horarioTrabajoMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateHorarioTrabajo([FromForm] HorarioTrabajoDTO horarioTrabajo)
        {
            try
            {
                var horarioTrabajoEntity = _horarioTrabajoServices.CreateHorarioTrabajo(horarioTrabajo);

                if (horarioTrabajoEntity != null)
                {
                    var horarioTrabajoCreated = _mapper.Map<HorarioTrabajoDTO>(horarioTrabajoEntity);
                    return Ok("Horario de Trabajo Creado");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHorarioTrabajo(int id, HorarioTrabajoDTO horarioTrabajo)
        {
            try
            {
                if (horarioTrabajo == null)
                {
                    return BadRequest("Completar todos los campos para realizar la actualizacion");
                }

                var horarioTrabajoUpdate = _horarioTrabajoServices.GetHorarioTrabajoById(id);

                if (horarioTrabajo == null)
                {
                    return NotFound("Horario de Trabajo Inexistente");
                }

                _mapper.Map(horarioTrabajo, horarioTrabajoUpdate);
                _horarioTrabajoServices.Update(horarioTrabajoUpdate);

                return Ok("Horario de Trabajo actualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHorarioTrabajo(int id)
        {
            try
            {
                var horarioTrabajo = _horarioTrabajoServices.GetHorarioTrabajoById(id);

                if (horarioTrabajo == null)
                {
                    return NotFound("Horario de Trabajo Inexistente");
                }

                _horarioTrabajoServices.Delete(horarioTrabajo);
                return Ok("Horario de Trabajo eliminado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

