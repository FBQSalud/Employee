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

        /// <summary>
        ///  Endpoint dedicado a obtener todas las especialidades. 
        /// </summary>
        [HttpGet("todos/")]
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
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a obtener una Especialidad por Id. 
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EspecialidadResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = new ResponseDTO();
                var especialidad = _especialidadServices.GetEspecialidadById(id);
              
                if (especialidad == null)
                {
                    response = new ResponseDTO { message = "Especialidad inexistente", statuscode = "404" };
                    return NotFound(response);
                }
                var especialidadMapped = _mapper.Map<EspecialidadResponseDTO>(especialidad);
                return Ok(especialidadMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
        /// <summary>
        ///  Endpoint dedicado a la creación de Especialidades.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult CreateEspecialidad([FromForm] EspecialidadDTO especialidad)
        {
            try
            {
                var response = new ResponseDTO();
                var especialidadEntity = _especialidadServices.CreateEspecialidad(especialidad);

                if (especialidadEntity != null)
                {
                    var especialidadCreated = _mapper.Map<EspecialidadDTO>(especialidadEntity);
                    response = new ResponseDTO { message = "Especialidad Creada", statuscode = "200" };
                    return Created("Sucess", response);
                }

                throw new FormatException();
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a  la actualizacíón de una especialidad
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEspecialidad(int id, EspecialidadDTO especialidad)
        {
            var response = new ResponseDTO();
            try
            {
                if (especialidad == null)
                {
                    response = new ResponseDTO { message = "Completar todos los campos para realizar la actualizacion", statuscode = "400" };
                    return BadRequest(response);
                }

                var especialidadUpdate = _especialidadServices.GetEspecialidadById(id);

                if (especialidadUpdate == null)
                {
                    response = new ResponseDTO { message = "Especialidad inexistente", statuscode = "404" };
                    return NotFound(response);
                }

                _mapper.Map(especialidad, especialidadUpdate);
                _especialidadServices.Update(especialidadUpdate);
                response = new ResponseDTO { message = "Especialidad actualizada", statuscode = "200" };
                return Ok(response);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a  la eliminación de una especialidad
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult DeleteEspecialidad(int id)
        {
            var response = new ResponseDTO();
            try
            {

                var especialidad = _especialidadServices.GetEspecialidadById(id);

                if (especialidad == null)
                {
                    response = new ResponseDTO { message = "Especialidad inexistente", statuscode = "404" };
                    return NotFound(response);
                }

                _especialidadServices.Delete(especialidad);
                response = new ResponseDTO { message = "Especialidad eliminada", statuscode = "200" };
                return Ok(response);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
    }
}
