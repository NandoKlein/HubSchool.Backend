using HubSchool.Data.Dto;
using HubSchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace HubSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AulaController : ControllerBase
    {
        private readonly IAulaServices _aulaServices;
        private readonly ILogger<AulaController> _logger;

        public AulaController(IAulaServices services, ILogger<AulaController> logger)
        {
            _aulaServices = services;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AulaDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Buscando todas as aulas.");
            return Ok(_aulaServices.FindAll());
        }

        [HttpGet("count")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetCount()
        {
            _logger.LogInformation("Buscando a quantidade de aulas.");
            return Ok(_aulaServices.Count());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AulaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Buscando aula de Id {id}.", id);
            var aula = _aulaServices.FindById(id);
            if (aula == null)
            {
                _logger.LogWarning("Aula de Id {id} não encontrado", id);
                return NotFound();
            }
            return Ok(aula);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AulaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] AulaDTO aula)
        {
            _logger.LogInformation("Cadastrando uma nova aula.");
            var novaAula = _aulaServices.Create(aula);
            if (novaAula == null)
            {
                _logger.LogError("Falha ao cadastrar aula.");
                return NotFound();
            }
            return Ok(novaAula);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(AulaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] AulaDTO aula)
        {
            _logger.LogInformation("Atualizando aula de Id {id}.", aula.Id);
            var novaAula = _aulaServices.Update(aula);
            if (novaAula == null)
            {
                _logger.LogError("Falha ao atualizar aula de Id {id}, não encontrado.", aula.Id);
                return NotFound();
            }
            _logger.LogDebug("Aula atualizada com sucesso.");
            return Ok(novaAula);
        }

        [HttpPut("updateFrequencias")]
        [ProducesResponseType(200, Type = typeof(AulaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult PutFrequencias([FromBody] AulaDTO aula)
        {
            _logger.LogInformation("Atualizando frequencias da aula Id {id}.", aula.Id);
            var novaAula = _aulaServices.UpdateFrequencias(aula);
            if (novaAula == null)
            {
                _logger.LogError("Falha ao atualizar aula de Id {id}, não encontrado.", aula.Id);
                return NotFound();
            }
            _logger.LogDebug("Frequencias atualizadas com sucesso.");
            return Ok(novaAula);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(AulaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deletando aula de Id {id}.", id);
            _aulaServices.Delete(id);
            _logger.LogDebug("Aula com Id {id} deletada com sucesso. ", id);
            return NoContent();
        }


    }
}
