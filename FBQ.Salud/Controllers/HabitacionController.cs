using AutoMapper;
using FBQ.Salud_Application.Services;
using FBQ.Salud_Domain.Dtos;
using FBQ.Salud_Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace FBQ.Salud_Presentation.Controllers
{
    [Route("api/habitaciones")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        IHabitacionServices _habitacionServices;
        IEnfermeraServices _enfermeraServices;
        IMedicoServices _medicoServices; 
        private readonly IMapper _mapper;

        public HabitacionController(IHabitacionServices habitacionServices, 
            IMapper mapper,
            IEnfermeraServices enfermeraServices,
            IMedicoServices medicoServices)
        {
            _habitacionServices = habitacionServices;
            _mapper = mapper;
            _enfermeraServices = enfermeraServices;
            _medicoServices = medicoServices;
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

       
        /// <summary>
        ///  Endpoint dedicado a asignar enfermeras a  una habitación.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="EnfermeraId"></param>
        [HttpPut("{id}/{EnfermeraId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public IActionResult Asignar(int id, int EnfermeraId) // debería ser con numero de habitación para hacerlo más dinamico..
        {
            try
            {
                var Response = new ErrorDTO();
                var HabitacionFind = _habitacionServices.GetHabitacionById(id);

                var EnfermeraFind = _enfermeraServices.GetEnfermeraById(EnfermeraId);
                if (EnfermeraFind == null)
                {
                    Response = new ErrorDTO { message = "La Enfermera a asignar no existe.", statuscode = "404" };
                    return NotFound(Response);
                }
                if (HabitacionFind == null)
                {
                    Response = new ErrorDTO { message = "La Habitación no existe.", statuscode = "404" };
                    return NotFound(Response);
                }
                if (HabitacionFind.EnfermeraId != null)
                {
                     Response = new ErrorDTO { message = "La Habitación ya tiene asignada una enfermera.", statuscode = "409" };
                    return Conflict(Response);
                }
                HabitacionFind.EnfermeraId = EnfermeraId;
                _habitacionServices.Update(HabitacionFind);
                 Response = new ErrorDTO { message = "Enfermera a sido asignada a Habitación " + HabitacionFind.Numero + ", Piso " + HabitacionFind.Piso + " correctamente.", statuscode = "200" };
                return Ok();
            }
            catch (Exception e)
            {
                var ErrorResponse = new ErrorDTO { message = "se ha ingresado los datos en un formato incorrecto, Excepcion :"+ e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
        /// <summary>
        ///  Endpoint dedicado a ocupar una habitación con un paciente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pacienteId"></param>
        [HttpPut("{id}/{pacienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
        public IActionResult Ocupar(int id, int pacienteId) // Debería ser con número de habitación, Id de paciente, debe chequear si estado = true
        {
            try
            {
                var Response = new ErrorDTO();
                var HabitacionFind = _habitacionServices.GetHabitacionById(id);

                // Comprobación de pacienteId conexión a otro microservicio perhaps.
                if (HabitacionFind == null)
                {
                    Response = new ErrorDTO { message = "La Habitación no existe.", statuscode = "404" };
                    return NotFound(Response);
                }
                if (HabitacionFind.Estado == true)
                {
                    Response = new ErrorDTO { message = "La Habitación ya se encuentra ocupada.", statuscode = "409" };
                    return Conflict(Response);
                }
                HabitacionFind.PacienteId = pacienteId;
                _habitacionServices.Update(HabitacionFind);
                Response = new ErrorDTO { message = "Paciente Ingresado a Habitación " + HabitacionFind.Numero + ", Piso " + HabitacionFind.Piso + " correctamente.", statuscode = "200" };
                return Ok();
            }
            catch (Exception e)
            {
                var ErrorResponse = new ErrorDTO { message = "se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
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


