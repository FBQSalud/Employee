using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FBQ.Salud_Presentation.Controllers
{
    [Route("api/especialidad")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        IEspecialidadServices _especialidadServices;
        private readonly IMapper _mapper;

        public EspecialidadController(IEspecialidadServices especialidadServices, 
            IMapper mapper)
        {
            _especialidadServices = especialidadServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var especialidad = _especialidadServices.GetAll();
                var especialidadMapped = _mapper.Map<List<EspecialidadResponseDTO>>(especialidad);

                return Ok(especialidadMapped);
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
                var especialidad = _especialidadServices.GetEspecialidadById(id);
              
                if (especialidad == null)
                {
                    return NotFound("Especialidad Inexistente");
                }
                var especialidadMapped = _mapper.Map<EspecialidadResponseDTO>(especialidad);
                return Ok(especialidadMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateEspecialidad([FromForm] EspecialidadDTO especialidad)
        {
            try
            {
                var especialidadEntity = _especialidadServices.CreateEspecialidad(especialidad);

                if (especialidadEntity != null)
                {
                    var especialidadCreated = _mapper.Map<EspecialidadDTO>(especialidadEntity);
                    return Ok("Especialidad Creada");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEspecialidad(int id, EspecialidadDTO especialidad)
        {
            try
            {
                if (especialidad == null)
                {
                    return BadRequest("Completar todos los campos para realizar la actualizacion");
                }

                var especialidadUpdate = _especialidadServices.GetEspecialidadById(id);

                if (especialidadUpdate == null)
                {
                    return NotFound("Especialidad Inexistente");
                }

                _mapper.Map(especialidad, especialidadUpdate);
                _especialidadServices.Update(especialidadUpdate);

                return Ok("Especialidad actualizada");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEspecialidad(int id)
        {
            try
            {
                var especialidad = _especialidadServices.GetEspecialidadById(id);

                if (especialidad == null)
                {
                    return NotFound("Especialidad Inexistente");
                }

                _especialidadServices.Delete(especialidad);
                return Ok("Especialidad eliminada");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
