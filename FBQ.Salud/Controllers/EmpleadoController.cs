using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
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

        [HttpGet]
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
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var empleado = _empleadoServices.GetEmpleadoById(id);
                var empleadoMapped = _mapper.Map<EmpleadoDTO>(empleado);
                if (empleado == null)
                {
                    return NotFound("Empleado Inexistente");
                }
                return Ok(empleadoMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateEmpleado([FromForm] EmpleadoDTO empleado)
        {
            try
            {
                var empleadoEntity = _empleadoServices.CreateEmpleado(empleado);    

                if (empleadoEntity != null)
                {
                    var empleadoCreated = _mapper.Map<EmpleadoDTO>(empleadoEntity);
                    return Ok("Empleado Creado");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmpleado(int id, EmpleadoDTO empleado)
        {
            try
            {
                if (empleado == null)
                {
                    return BadRequest("Completar todos los campos para realizar la actualizacion");
                }

                var empleadoUpdate = _empleadoServices.GetEmpleadoById(id);

                if (empleadoUpdate == null)
                {
                    return NotFound("Empleado Inexistente");
                }

                _mapper.Map(empleado, empleadoUpdate);
                _empleadoServices.Update(empleadoUpdate);

                return Ok("Empleado actualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmpleado(int id)
        {
            try
            {
                var empleado = _empleadoServices.GetEmpleadoById(id);

                if (empleado == null)
                {
                    return NotFound("Empleado Inexistente");
                }

                _empleadoServices.Delete(empleado);
                return Ok("Empleado eliminado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}


