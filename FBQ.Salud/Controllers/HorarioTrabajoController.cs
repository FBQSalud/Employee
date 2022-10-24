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
        /// <summary>
        ///  Endpoint dedicado a obtener todos los horarios de trabajo. 
        /// </summary>
        [HttpGet("todos/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                var horarioTrabajo = _horarioTrabajoServices.GetAll();
                var horarioTrabajoMapped = _mapper.Map<List<HorarioTrabajoResponseDTO>>(horarioTrabajo);

                return Ok(horarioTrabajoMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a obtener un Horario de trabajo por Id. 
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HorarioTrabajoResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var horarioTrabajo = _horarioTrabajoServices.GetHorarioTrabajoById(id);       
                if (horarioTrabajo == null)
                {
                    response = new ResponseDTO { message = "Horario de trabajo inexistente", statuscode = "404" };
                    return NotFound(response);
                }
                var horarioTrabajoMapped = _mapper.Map<HorarioTrabajoResponseDTO>(horarioTrabajo);
                return Ok(horarioTrabajoMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a la creación de Horarios de Trabajo.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult CreateHorarioTrabajo([FromForm] HorarioTrabajoDTO horarioTrabajo)
        {
            var response = new ResponseDTO();
            try
            {
                var horarioTrabajoEntity = _horarioTrabajoServices.CreateHorarioTrabajo(horarioTrabajo);

                if (horarioTrabajoEntity != null)
                {
                    var horarioTrabajoCreated = _mapper.Map<HorarioTrabajoDTO>(horarioTrabajoEntity);
                    response = new ResponseDTO { message = "Horario de Trabajo Creado", statuscode = "200" };
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
        ///  Endpoint dedicado a  la actualizacíón de un horario de trabajo.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateHorarioTrabajo(int id, HorarioTrabajoDTO horarioTrabajo)
        {
            var response = new ResponseDTO();
            try
            {
                if (horarioTrabajo == null)
                {
                    response = new ResponseDTO { message = "Completar todos los campos para realizar la actualizacion", statuscode = "400" };
                    return BadRequest(response);
                }

                var horarioTrabajoUpdate = _horarioTrabajoServices.GetHorarioTrabajoById(id);

                if (horarioTrabajo == null)
                {
                    response = new ResponseDTO { message = "Horario de Trabajo inexistente", statuscode = "404" };
                    return NotFound(response);
                }

                _mapper.Map(horarioTrabajo, horarioTrabajoUpdate);
                _horarioTrabajoServices.Update(horarioTrabajoUpdate);
                response = new ResponseDTO { message = "Horario De Trabajo actualizado", statuscode = "200" };
                return Ok(response);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a  la eliminación de un empleado
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult DeleteHorarioTrabajo(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var horarioTrabajo = _horarioTrabajoServices.GetHorarioTrabajoById(id);

                if (horarioTrabajo == null)
                {
                    response = new ResponseDTO { message = "Horario de Trabajo inexistente", statuscode = "404" };
                    return NotFound(response);
                }

                _horarioTrabajoServices.Delete(horarioTrabajo);
                response = new ResponseDTO { message = "Horario de Trabajo eliminado", statuscode = "200" };
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

