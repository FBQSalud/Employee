using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FBQ.Salud_Presentation.Controllers
{
    [Route("api/enfermeras")]
    [ApiController]
    public class EnfermeraController : ControllerBase
    {
        IEnfermeraServices _enfermeraServices;
        IEmpleadoServices _empleadoServices;
        IHorarioTrabajoServices _horarioTrabajoServices;
        IMedicoServices _medicoServices;
        private readonly IMapper _mapper;

        public EnfermeraController(IEnfermeraServices enfermeraServices, IEmpleadoServices empleadoServices, IHorarioTrabajoServices horarioTrabajoServices, IMedicoServices medicoServices,
            IMapper mapper)
        {
            _enfermeraServices = enfermeraServices;
            _mapper = mapper;
            _empleadoServices = empleadoServices;
            _horarioTrabajoServices = horarioTrabajoServices;
            _medicoServices = medicoServices;
        }
        /// <summary>
        ///  Endpoint dedicado a obtener todas las enfermeras. 
        /// </summary>
        [HttpGet("todos/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                var enfermera = _enfermeraServices.GetAll();
                var enfermeraMapped = _mapper.Map<List<EnfermeraResponseDTO>>(enfermera);

                return Ok(enfermeraMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a obtener una enfermera por Id. 
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EnfermeraResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var enfermera = _enfermeraServices.GetEnfermeraById(id);
                if (enfermera == null)
                {
                    response = new ResponseDTO { message = "Enfermera inexistente", statuscode = "404" };
                    return NotFound(response); 
                }
                var enfermeraMapped = _mapper.Map<EnfermeraResponseDTO>(enfermera);
                return Ok(enfermeraMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
        /// <summary>
        ///  Endpoint dedicado a la creación de enfermeras.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult CreateEnfermera([FromForm] EnfermeraDTO enfermera)
        {
            var response = new ResponseDTO();
            try
            {

                var EmpleadoCheck = _empleadoServices.GetEmpleadoById(enfermera.EmpleadoId);
                var EnfermeraCheck = _enfermeraServices.GetEnfermeraByEmpleadoId(enfermera.EmpleadoId);
                var MedicoCheck = _medicoServices.GetMedicoByEmpleadoId(enfermera.EmpleadoId);
               
                if (EmpleadoCheck == null)
                {
                    response = new ResponseDTO { message = "El id del empleado ingresado no existe", statuscode = "404" };
                    return NotFound(response);
                }
                if (MedicoCheck != null)
                {
                    response = new ResponseDTO { message = "El id del empleado ingresado corresponde a un medico.", statuscode = "409" };
                    return Conflict(response);

                }
                if (EnfermeraCheck != null) 
                {
                    response = new ResponseDTO { message = "El id de la enfermera ingresada corresponde a una ya existente.", statuscode = "409" };
                    return Conflict(response);

                }
                var HorarioCheck = _horarioTrabajoServices.GetHorarioTrabajoById(enfermera.HorarioId);
                if (HorarioCheck == null)
                {
                    response = new ResponseDTO { message = "El id del horario ingresado no existe", statuscode = "404" };
                    return Conflict(response);
                }
                var enfermeraEntity = _enfermeraServices.CreateEnfermera(enfermera);
                if (enfermeraEntity != null)
                {
                    var enfermeraCreated = _mapper.Map<EnfermeraResponseDTO>(enfermeraEntity);
                    response = new ResponseDTO { message = "Enfermera Creada", statuscode = "200" };
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
        ///  Endpoint dedicado a  la actualizacíón de un enfermera
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEnfermera(int id, EnfermeraDTO enfermera)
        {
            var response = new ResponseDTO();
            try
            {
                if (enfermera == null)
                {
                    response = new ResponseDTO { message = "Completar todos los campos para realizar la actualizacion", statuscode = "400" };
                    return BadRequest(response);
                }

                var enfermeraUpdate = _enfermeraServices.GetEnfermeraById(id);

                if (enfermeraUpdate == null)
                {
                    response = new ResponseDTO { message = "Enfermera inexistente", statuscode = "404" };
                    return NotFound(response);
                }
                _mapper.Map(enfermera, enfermeraUpdate);
                _enfermeraServices.Update(enfermeraUpdate);
                response = new ResponseDTO { message = "Enfermera actualizada", statuscode = "200" };
                return Ok(response);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
        /// <summary>
        ///  Endpoint dedicado a  la eliminación de un enfermera
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult DeleteEnfermera(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var enfermera = _enfermeraServices.GetEnfermeraById(id);

                if (enfermera == null)
                {
                    response = new ResponseDTO { message = "Enfemera inexistente", statuscode = "404" };
                    return NotFound(response);
                }

                _enfermeraServices.Delete(enfermera);
                response = new ResponseDTO { message = "Enfermera eliminado", statuscode = "200" };
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
