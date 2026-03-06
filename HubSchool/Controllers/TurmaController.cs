using HubSchool.Data.Dto;
using HubSchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace HubSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaServices _turmaService;
        private readonly ILogger<TurmaController> _logger;

        public TurmaController(ITurmaServices service, ILogger<TurmaController> logger)
        {
            _turmaService = service;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TurmaDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Buscando todos as turmas.");
            return Ok(_turmaService.FindAll());
        }

        [HttpGet("count")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetCount()
        {
            _logger.LogInformation("Buscando a quantidade de turmas.");
            return Ok(_turmaService.Count());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TurmaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Buscando turma de Id {id}.", id);
            var turma = _turmaService.FindById(id);
            if (turma == null)
            {
                _logger.LogWarning("Turma de Id {id} não encontrado", id);
                return NotFound();
            }
            return Ok(turma);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(TurmaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] TurmaDTO turma)
        {
            _logger.LogInformation("Cadastrando novo turma: {name}.", turma.Name);
            var navoTurma = _turmaService.Create(turma);
            if (navoTurma == null)
            {
                _logger.LogError("Falha ao cadastrar turma de nome {name}", turma.Name);
                return NotFound();
            }
            return Ok(navoTurma);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(TurmaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] TurmaDTO turma)
        {
            _logger.LogInformation("Atualizando turma de Id {id}.", turma.Id);
            var novaTurma = _turmaService.Update(turma);
            if (novaTurma == null)
            {
                _logger.LogError("Falha ao atualizar turma de Id {id}, não encontrado.", turma.Id);
                return NotFound();
            }
            _logger.LogDebug("Turma atualizada com sucesso: {name} ", novaTurma.Name);
            return Ok(novaTurma);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(TurmaDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deletando turma de Id {id}.", id);
            _turmaService.Delete(id);
            _logger.LogDebug("Turma com Id {id} deletada com sucesso. ", id);
            return NoContent();
        }
    }
}
