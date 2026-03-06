using HubSchool.Data.Dto;
using HubSchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace HubSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorServices _professorServices;
        private readonly ILogger<ProfessorController> _logger;

        public ProfessorController(ILogger<ProfessorController> logger, IProfessorServices services)
        {
            _logger = logger;
            _professorServices = services;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<ProfessorDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Buscando todos os professores.");
            return Ok(_professorServices.FindAll());
        }

        [HttpGet("count")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetCount()
        {
            _logger.LogInformation("Buscando a quantidade de professores.");
            return Ok(_professorServices.Count());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProfessorDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Buscando professor de Id {id}.", id);
            var professor = _professorServices.FindById(id);
            if (professor == null)
            {
                _logger.LogWarning("Professor de Id {id} não encontrado", id);
                return NotFound();
            }
            return Ok(professor);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProfessorDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] ProfessorDTO professor)
        {
            _logger.LogInformation("Cadastrando novo professor: {name}.", professor.Name);
            var novoProfessor = _professorServices.Create(professor);
            if (novoProfessor == null)
            {
                _logger.LogError("Falha ao cadastrar professor de nome {name}", professor.Name);
                return NotFound();
            }
            return Ok(novoProfessor);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(ProfessorDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] ProfessorDTO professor)
        {
            _logger.LogInformation("Atualizando professor de Id {id}.", professor.Id);
            var novoProfessor = _professorServices.Update(professor);
            if (novoProfessor == null)
            {
                _logger.LogError("Falha ao atualizar professor de Id {id}, não encontrado.", professor.Id);
                return NotFound();
            }
            _logger.LogDebug("Professor atualizado com sucesso: {name} ", novoProfessor.Name);
            return Ok(novoProfessor);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(ProfessorDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deletando professor de Id {id}.", id);
            _professorServices.Delete(id);
            _logger.LogDebug("professor com Id {id} deletado com sucesso. ", id);
            return NoContent();
        }


    }
}
