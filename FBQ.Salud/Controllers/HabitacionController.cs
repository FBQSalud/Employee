using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FBQ.Salud_Presentation.Controllers
{
    [Route("api/habitaciones")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        IHabitacionServices _habitacionServices;
        private readonly IMapper _mapper;

        public HabitacionController(IHabitacionServices habitacionServices, 
            IMapper mapper)
        {
            _habitacionServices = habitacionServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var Habitaciones = _habitacionServices.GetAll();          

                return Ok(Habitaciones);
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
                var Habitacion = _habitacionServices.GetHabitacionById(id);
                var HabitacionMap = _mapper.Map<HabitacionDTO>(Habitacion);
                if (Habitacion == null)
                {
                    return NotFound("Empleado Inexistente");
                }
                return Ok(HabitacionMap);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

       

        [HttpPut("{id}")]
        public IActionResult Ocupar(int id, HabitacionDTO habitacion) // Debería ser con número de habitación, debe chequear si estado = true
        {
            try
            {
                if (habitacion == null)
                {
                    return BadRequest("Completar todos los campos para realizar la actualizacion");
                }

                var empleadoUpdate = _habitacionServices.GetHabitacionById(id);

                if (empleadoUpdate == null)
                {
                    return NotFound("Empleado Inexistente");
                }

                _mapper.Map(habitacion, empleadoUpdate);
                _habitacionServices.Update(empleadoUpdate);

                return Ok("Empleado actualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Desocupar(int id) // Debería ser con número de habitación, debe chequear si estado = true
        {
            try
            {
                var habitacion = _habitacionServices.GetHabitacionById(id);

                if (habitacion == null)
                {
                    return NotFound("Habitación Inexistente");
                }

                _habitacionServices.Update(habitacion);
                return Ok("Habitación Desocupada. ");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}


