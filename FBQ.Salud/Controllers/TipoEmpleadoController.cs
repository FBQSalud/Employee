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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var tipoEmpleado = _tipoEmpleadoServices.GetAll();
                var tipoEmpleadoMapped = _mapper.Map<List<TipoEmpleadoDTO>>(tipoEmpleado);

                return Ok(tipoEmpleadoMapped);
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
                var tipoEmpleado = _tipoEmpleadoServices.GetTipoEmpleadoById(id);
                if (tipoEmpleado == null)
                {
                    return NotFound("Tipo de Empleado Inexistente");
                }
                var tipoEmpleadoMapped = _mapper.Map<TipoEmpleadoDTO>(tipoEmpleado);
                return Ok(tipoEmpleadoMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateTipoEmpleado([FromForm] TipoEmpleadoDTO tipoEmpleado)
        {
            try
            {
                var tipoEmpleadoEntity = _tipoEmpleadoServices.CreateTipoEmpleado(tipoEmpleado);

                if (tipoEmpleadoEntity != null)
                {
                    var tipoEmpleadoCreated = _mapper.Map<TipoEmpleadoDTO>(tipoEmpleadoEntity);
                    return Ok("Tipo de Empleado Creado");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTipoEmpleado(int id, TipoEmpleadoDTO tipoEmpleado)
        {
            try
            {
                if (tipoEmpleado == null)
                {
                    return BadRequest("Completar todos los campos para realizar la actualizacion");
                }

                var tipoEmpleadoUpdate = _tipoEmpleadoServices.GetTipoEmpleadoById(id);

                if (tipoEmpleadoUpdate == null)
                {
                    return NotFound("Tipo de Empleado Inexistente");
                }

                _mapper.Map(tipoEmpleado, tipoEmpleadoUpdate);
                _tipoEmpleadoServices.Update(tipoEmpleadoUpdate);

                return Ok("Tipo de Empleado actualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTipoEmpleado(int id)
        {
            try
            {
                var tipoEmpleado = _tipoEmpleadoServices.GetTipoEmpleadoById(id);

                if (tipoEmpleado == null)
                {
                    return NotFound("Tipo de Empleado Inexistente");
                }

                _tipoEmpleadoServices.Delete(tipoEmpleado);
                return Ok("Tipo de Empleado eliminado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
