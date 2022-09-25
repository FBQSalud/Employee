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
        private readonly IMapper _mapper;

        public EnfermeraController(IEnfermeraServices enfermeraServices, 
            IMapper mapper)
        {
            _enfermeraServices = enfermeraServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var enfermera = _enfermeraServices.GetAll();
                var enfermeraMapped = _mapper.Map<List<EnfermeraDTO>>(enfermera);

                return Ok(enfermeraMapped);
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
                var enfermera = _enfermeraServices.GetEnfermeraById(id);
                var enfermeraMapped = _mapper.Map<EnfermeraDTO>(enfermera);
                if (enfermera == null)
                {
                    return NotFound("Enfermera Inexistente");
                }
                return Ok(enfermeraMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateEnfermera([FromForm] EnfermeraDTO enfermera)
        {
            try
            {
                var enfermeraEntity = _enfermeraServices.CreateEnfermera(enfermera);

                if (enfermeraEntity != null)
                {
                    var enfermeraCreated = _mapper.Map<EnfermeraDTO>(enfermeraEntity);
                    return Ok("Enfermera Creada");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEnfermera(int id, EnfermeraDTO enfermera)
        {
            try
            {
                if (enfermera == null)
                {
                    return BadRequest("Completar todos los campos para realizar la actualizacion");
                }

                var enfermeraUpdate = _enfermeraServices.GetEnfermeraById(id);

                if (enfermeraUpdate == null)
                {
                    return NotFound("Enfermera Inexistente");
                }

                _mapper.Map(enfermera, enfermeraUpdate);
                _enfermeraServices.Update(enfermeraUpdate);

                return Ok("Enfermera actualizada");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEnfermera(int id)
        {
            try
            {
                var enfermera = _enfermeraServices.GetEnfermeraById(id);

                if (enfermera == null)
                {
                    return NotFound("Enfermera Inexistente");
                }

                _enfermeraServices.Delete(enfermera);
                return Ok("Enfermera eliminada");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
