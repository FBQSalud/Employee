using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FBQ.Salud_Presentation.Controllers
{
    [Route("api/empleados")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        IEmpleadoServices _empleadoServices;
        private readonly IMapper _mapper;

        public EmpleadoController(IEmpleadoServices empleadoServices, 
            IMapper mapper)
        {
            _empleadoServices = empleadoServices;
            _mapper = mapper;
        }
        /// <summary>
        ///  Endpoint dedicado a obtener todos los empleados. 
        /// </summary>
        [HttpGet("todos/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                var empleado = _empleadoServices.GetAll();
                var empleadoMapped = _mapper.Map<List<EmpleadoDTO>>(empleado);

                return Ok(empleadoMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a obtener un Empleado por Id. 
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmpleadoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var empleado = _empleadoServices.GetEmpleadoById(id);
                var empleadoMapped = _mapper.Map<EmpleadoDTO>(empleado);
                if (empleado == null)
                {
                     response = new ResponseDTO { message = "Empleado inexistente", statuscode = "404" };
                    return NotFound(response);
                }
                return Ok(empleadoMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
        /// <summary>
        ///  Endpoint dedicado a la creación de empleados
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult CreateEmpleado([FromForm] EmpleadoDTO empleado)
        {
            var response = new ResponseDTO();
            try
            {
                var EmpleadoExists = _empleadoServices.GetEmpleadoByDni(empleado.DNI);

                if(EmpleadoExists != null)
                {
                     response = new ResponseDTO { message ="El DNI de cliente ingresado corresponde a uno ya existente.",statuscode = "409"};
                    return Conflict(response);
                }
                if (EmpleadoExists.Usuario == empleado.Usuario)
                {
                    response = new ResponseDTO { message = "El usuario del cliente ingresado corresponde a uno ya existente.",statuscode = "409" };
                    return Conflict(response);
                }
                var empleadoEntity = _empleadoServices.CreateEmpleado(empleado);    
                if (empleadoEntity != null)
                {
                    var empleadoCreated = _mapper.Map<EmpleadoDTO>(empleadoEntity);
                    response = new ResponseDTO { message = "Empleado Creado", statuscode = "200" };
                    return Ok(response);
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
        ///  Endpoint dedicado a  la actualizacíón de un empleado
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEmpleado(int id, EmpleadoDTO empleado)
        {
            var response = new ResponseDTO();
            try
            {
                if (empleado == null)
                {
                    response = new ResponseDTO { message = "Completar todos los campos para realizar la actualizacion", statuscode = "400" };
                    return BadRequest(response);
                }

                var empleadoUpdate = _empleadoServices.GetEmpleadoById(id);

                if (empleadoUpdate == null)
                {
                    response = new ResponseDTO { message = "Empleado inexistente", statuscode = "404" };
                    return NotFound(response);
                }

                _mapper.Map(empleado, empleadoUpdate);
                _empleadoServices.Update(empleadoUpdate);
                response = new ResponseDTO { message = "Empleado actualizado", statuscode = "200" };

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
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult DeleteEmpleado(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var empleado = _empleadoServices.GetEmpleadoById(id);

                if (empleado == null)
                {
                    response = new ResponseDTO { message = "Empleado inexistente", statuscode = "404" };
                    return NotFound(response);
                }
               
                _empleadoServices.Delete(empleado);
                response = new ResponseDTO { message = "Empleado eliminado", statuscode = "200" };
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


