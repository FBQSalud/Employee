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
        /// <summary>
        ///  Endpoint dedicado a obtener todas las habitaciónes. 
        /// </summary>
        [HttpGet("todos/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            try
            {
                var Response = new ResponseDTO();
                var Habitaciones = _habitacionServices.GetAll();          

                return Ok(Habitaciones);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

 
        /// <summary>
        ///  Endpoint dedicado a asignar enfermeras a  una habitación.
        /// </summary>
        [HttpPut("asignar/{numero}/enfermeraId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult Asignar(int numero, int enfermeraId) 
        {
            try
            {
                var Response = new ResponseDTO();
                var HabitacionFind = _habitacionServices.GetHabitacionByNumero(numero);

                var EnfermeraFind = _enfermeraServices.GetEnfermeraById(enfermeraId);
                if (EnfermeraFind == null)
                {
                    Response = new ResponseDTO { message = "La enfermera a asignar no existe.", statuscode = "404" };
                    return NotFound(Response);
                }
                if (HabitacionFind == null)
                {
                    Response = new ResponseDTO { message = "La habitación no existe.", statuscode = "404" };
                    return NotFound(Response);
                }
                if (HabitacionFind.EnfermeraId != null)
                {
                     Response = new ResponseDTO { message = "La habitación ya tiene asignada una enfermera.", statuscode = "409" };
                    return Conflict(Response);
                }
                HabitacionFind.EnfermeraId = enfermeraId;
                _habitacionServices.Update(HabitacionFind);
                 Response = new ResponseDTO { message = "Enfermera a sido asignada a habitación " + HabitacionFind.Numero + ", piso " + HabitacionFind.Piso + " correctamente.", statuscode = "200" };
                return Ok(Response);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :"+ e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a Desasignar enfermeras a  una habitación.
        /// </summary>
        [HttpPut("desasignar/numero")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult Desasignar(int numero)
        {
            try
            {
                var Response = new ResponseDTO();
                var habitacion = _habitacionServices.GetHabitacionByNumero(numero);

               
                if (habitacion == null)
                {
                    Response = new ResponseDTO { message = "La habitación no existe.", statuscode = "404" };
                    return NotFound(Response);
                }
                if (habitacion.EnfermeraId == 0)
                {
                    Response = new ResponseDTO { message = "La habitación No tiene asignada una enfermera.", statuscode = "409" };
                    return Conflict(Response);
                }
                habitacion.EnfermeraId = 0;
                _habitacionServices.Update(habitacion);
                Response = new ResponseDTO { message = "Se ha desasignado a la enfermera de la habitación " + habitacion.Numero + ", piso " + habitacion.Piso + " correctamente.", statuscode = "200" };
                return Ok(Response);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
        /// <summary>
        ///  Endpoint dedicado a ocupar una habitación con un paciente.
        /// </summary>
        [HttpPut("ocupar/{numero}/pacienteId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult Ocupar(int numero, int pacienteId) 
        {
            try
            {
                var Response = new ResponseDTO();
                var Habitacion = _habitacionServices.GetHabitacionByNumero(numero);

                // Comprobación de pacienteId conexión a otro microservicio perhaps.
                if (Habitacion == null)
                {
                    Response = new ResponseDTO { message = "La habitación no existe.", statuscode = "404" };
                    return NotFound(Response);
                }
                if (Habitacion.Estado == true)
                {
                    Response = new ResponseDTO { message = "La habitación ya se encuentra ocupada.", statuscode = "409" };
                    return Conflict(Response);
                }
                Habitacion.PacienteId = pacienteId;
                Habitacion.Estado = false;
                _habitacionServices.Update(Habitacion);
                Response = new ResponseDTO { message = "Paciente ingresado a habitación " + numero + ", piso " + Habitacion.Piso + " correctamente.", statuscode = "200" };
                return Ok();
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }

        /// <summary>
        ///  Endpoint dedicado a Desocupar una habitación de pacientes.
        /// </summary>
        [HttpPut("Desocupar/numero")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseDTO), StatusCodes.Status400BadRequest)]
        public IActionResult Desocupar(int numero) 
        {
            try
            {
                var Response = new ResponseDTO();
                var habitacion = _habitacionServices.GetHabitacionByNumero(numero);
                

                if (habitacion == null)
                {
                    Response = new ResponseDTO { message = "Habitación Inexistente", statuscode = "404" };
                    return NotFound(Response);
                }
                if(habitacion.Estado == false)
                {
                    Response = new ResponseDTO { message = "La habitación está vacía.", statuscode = "409" };
                    return Conflict(Response);
                }
                habitacion.PacienteId = 0;
                habitacion.Estado = true;
                _habitacionServices.Update(habitacion);
                Response = new ResponseDTO { message = " habitación " +  numero + ", piso " + habitacion.Piso + " desocupada correctamente.", statuscode = "200" };
                return Ok(Response);
            }
            catch (Exception e)
            {
                var ErrorResponse = new ResponseDTO { message = "Se ha ingresado los datos en un formato incorrecto, Excepcion :" + e.Message, statuscode = "400" };
                return BadRequest(ErrorResponse);
            }
        }
    }
}


