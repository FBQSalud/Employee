using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FBQ.Salud_Presentation.Controllers
{
    [Route("api/tipoEmpleados")]
    [ApiController]
    public class TipoEmpleadoController : ControllerBase
    {
        ITipoEmpleadoServices _tipoEmpleadoServices;
        private readonly IMapper _mapper;

        public TipoEmpleadoController(ITipoEmpleadoServices tipoEmpleadoServices, 
            IMapper mapper)
        {
            _tipoEmpleadoServices = tipoEmpleadoServices;
            _mapper = mapper;
        }

        /// <summary>
        ///  Endpoint dedicado a obtener todas las enfermeras. 
        /// </summary>
        [HttpGet("todos/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            var response = new ResponseDTO();
            try
            {
                var tipoEmpleado = _tipoEmpleadoServices.GetAll();
                var tipoEmpleadoMapped = _mapper.Map<List<TipoEmpleadoDTO>>(tipoEmpleado);

                return Ok(tipoEmpleadoMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a obtener un tipo de empleado por Id. 
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
                var tipoEmpleado = _tipoEmpleadoServices.GetTipoEmpleadoById(id);
                if (tipoEmpleado == null)
                {
                    response = new ResponseDTO { message = "Tipo de Empleado inexistente", statuscode = "404" };
                    return NotFound(response);
                }
                var tipoEmpleadoMapped = _mapper.Map<TipoEmpleadoDTO>(tipoEmpleado);
                return Ok(tipoEmpleadoMapped);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
        /// <summary>
        ///  Endpoint dedicado a la creación de Tipo de Empleado.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult CreateTipoEmpleado([FromForm] TipoEmpleadoDTO tipoEmpleado)
        {
            var response = new ResponseDTO();
            try
            {
                var tipoEmpleadoEntity = _tipoEmpleadoServices.CreateTipoEmpleado(tipoEmpleado);

                if (tipoEmpleadoEntity != null)
                {
                    var tipoEmpleadoCreated = _mapper.Map<TipoEmpleadoDTO>(tipoEmpleadoEntity);
                    response = new ResponseDTO { message = "Tipo de Empleado Creado.", statuscode = "200" };
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
        ///  Endpoint dedicado a  la actualizacíón de un tipo de Empleado.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateTipoEmpleado(int id, TipoEmpleadoDTO tipoEmpleado)
        {
            var response = new ResponseDTO();
            try
            {
                if (tipoEmpleado == null)
                {
                    response = new ResponseDTO { message = "Completar todos los campos para realizar la actualizacion", statuscode = "400" };
                    return BadRequest(response);
                }

                var tipoEmpleadoUpdate = _tipoEmpleadoServices.GetTipoEmpleadoById(id);

                if (tipoEmpleadoUpdate == null)
                {
                    response = new ResponseDTO { message = "Tipo De Empleado inexistente", statuscode = "404" };
                    return NotFound(response);
                }
                _mapper.Map(tipoEmpleado, tipoEmpleadoUpdate);
                _tipoEmpleadoServices.Update(tipoEmpleadoUpdate);
                response = new ResponseDTO { message = "Tipo De Empleado actualizada", statuscode = "200" };
                return Ok(response);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a  la eliminación de un tipo de empleado.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult DeleteTipoEmpleado(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var tipoEmpleado = _tipoEmpleadoServices.GetTipoEmpleadoById(id);

                if (tipoEmpleado == null)
                {
                    response = new ResponseDTO { message = "Tipo de Empleado inexistente ", statuscode = "404" };
                    return NotFound(response);
                }

                _tipoEmpleadoServices.Delete(tipoEmpleado);
                response = new ResponseDTO { message = "Tipo de Empleado eliminado", statuscode = "200" };
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
