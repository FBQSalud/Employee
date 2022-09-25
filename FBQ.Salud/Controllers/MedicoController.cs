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
        private readonly IMapper _mapper;

        public MedicoController(IMedicoServices medicoServices, 
            IMapper mapper)
        {
            _medicoServices = medicoServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var medico = _medicoServices.GetAll();
                var medicoMapped = _mapper.Map<List<MedicoDTO>>(medico);

                return Ok(medicoMapped);
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
                var medico = _medicoServices.GetMedicoById(id);
                var medicoMapped = _mapper.Map<MedicoDTO>(medico);
                if (medico == null)
                {
                    return NotFound("Medico Inexistente");
                }
                return Ok(medicoMapped);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateMedico([FromForm] MedicoDTO medico)
        {
            try
            {
                var medicoEntity = _medicoServices.CreateMedico(medico);

                if (medicoEntity != null)
                {
                    var UserCreated = _mapper.Map<MedicoDTO>(medicoEntity);
                    return Ok("Medico Creado");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMedico(int id, MedicoDTO medico)
        {
            try
            {
                if (medico == null)
                {
                    return BadRequest("Completar todos los campos para realizar la actualizacion");
                }

                var medicoUpdate = _medicoServices.GetMedicoById(id);

                if (medicoUpdate == null)
                {
                    return NotFound("Medico Inexistente");
                }

                _mapper.Map(medico, medicoUpdate);
                _medicoServices.Update(medicoUpdate);

                return Ok("Medico actualizado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMedico(int id)
        {
            try
            {
                var medico = _medicoServices.GetMedicoById(id);

                if (medico == null)
                {
                    return NotFound("Medico Inexistente");
                }

                _medicoServices.Delete(medico);
                return Ok("Medico eliminado");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}   

