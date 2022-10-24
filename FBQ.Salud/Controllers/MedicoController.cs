using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FBQ.Salud_Presentation.Controllers
{
    [Route("api/medicos")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        IMedicoServices _medicoServices;
        IEmpleadoServices _empleadoServices;
       IHorarioTrabajoServices _horarioTrabajoServices;
        IEspecialidadServices _especialidadServices;
        IEnfermeraServices _enfermeraServices;
        private readonly IMapper _mapper;

        public MedicoController(IMedicoServices medicoServices, IEmpleadoServices empleadoServices,IHorarioTrabajoServices horarioTrabajoServices,
            IMapper mapper, IEspecialidadServices especialidadServices, IEnfermeraServices enfermeraServices)
        {
            _medicoServices = medicoServices;
            _mapper = mapper;
            _horarioTrabajoServices = horarioTrabajoServices;
            _especialidadServices = especialidadServices;
            _empleadoServices = empleadoServices;
            _enfermeraServices = enfermeraServices;
        }
        /// <summary>
        ///  Endpoint dedicado a obtener todos los medicos. 
        /// </summary>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                var medico = _medicoServices.GetAll();
                var medicoMapped = _mapper.Map<List<MedicoResponseDTO>>(medico);

                return Ok(medicoMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
        /// <summary>
        ///  Endpoint dedicado a obtener un medico por Id. 
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MedicoResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var medico = _medicoServices.GetMedicoById(id);

                if (medico == null)
                {
                    response = new ResponseDTO { message = "Medico inexistente", statuscode = "404" };
                    return NotFound(response);
                }
                var medicoMapped = _mapper.Map<MedicoResponseDTO>(medico);
                return Ok(medicoMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
        /// <summary>
        ///  Endpoint dedicado a la creación de Medicos.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult CreateMedico([FromForm] MedicoDTO medico)
        {
            var response = new ResponseDTO();
            try
            {
                var medicoCheck = _medicoServices.GetMedicoByEmpleadoId(medico.EmpleadoId);
                var EmpleadoCheck = _empleadoServices.GetEmpleadoById(medico.EmpleadoId);
                var EnfermeraCheck = _enfermeraServices.GetEnfermeraByEmpleadoId(medico.EmpleadoId);
              
                if (EmpleadoCheck == null)
                {
                    response = new ResponseDTO { message = "El id del empleado ingresado no existe", statuscode = "404" };
                    return NotFound(response);
                }
                if (EnfermeraCheck != null)
                {
                    response = new ResponseDTO { message = "El id del empleado ingresado corresponde a una enfermera.", statuscode = "409" };
                    return Conflict(response);

                }
                if (medicoCheck != null)
                {
                    response = new ResponseDTO { message = "El id del medico ingresado corresponde a uno ya existente.", statuscode = "409" };
                    return Conflict(response);
                }
                var HorarioCheck = _horarioTrabajoServices.GetHorarioTrabajoById(medico.HorarioId);
                if (HorarioCheck == null)
                {
                    response = new ResponseDTO { message = "El id del horario ingresado no existe", statuscode = "404" };
                    return Conflict(response);
                }

                var EspacialidadId = _especialidadServices.GetEspecialidadById(medico.EspecialidadId);
                if(EspacialidadId == null)
                {
                    response = new ResponseDTO { message = "El id de la especialidad ingresada no existe", statuscode = "404" };
                    return Conflict(response);
                }  
                var medicoEntity = _medicoServices.CreateMedico(medico);

                if (medicoEntity != null)
                {
                    var UserCreated = _mapper.Map<MedicoDTO>(medicoEntity);
                    response = new ResponseDTO { message = "Medico Creado", statuscode = "201" };
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
        ///  Endpoint dedicado a  la actualizacíón de un medico.
        /// </summary>
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateMedico(int id, MedicoPatchDTO medico)
        {
            var response = new ResponseDTO();
            try
            {
                if (medico == null)
                {
                   
                    response = new ResponseDTO { message = "Completar todos los campos para realizar la actualizacion", statuscode = "400" };
                    return BadRequest(response);
                }

                var medicoUpdate = _medicoServices.GetMedicoById(id);

                if (medicoUpdate == null)
                {
                    response = new ResponseDTO { message = "Médico inexistente", statuscode = "404" };
                    return NotFound(response);
                }

                _mapper.Map(medico, medicoUpdate);
                _medicoServices.Update(medicoUpdate);

                response = new ResponseDTO { message = "Médico actualizado", statuscode = "200" };
                return Ok(response);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
        /// <summary>
        ///  Endpoint dedicado a  la eliminación de un medico.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult DeleteMedico(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var medico = _medicoServices.GetMedicoById(id);

                if (medico == null)
                {
                    response = new ResponseDTO { message = "Médico inexistente", statuscode = "404" };
                    return NotFound(response);
                }

                _medicoServices.Delete(medico);
                response = new ResponseDTO { message = "Médico eliminado", statuscode = "200" };
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

