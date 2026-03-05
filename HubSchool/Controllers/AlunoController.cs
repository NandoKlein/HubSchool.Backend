using HubSchool.Data.Dto;
using HubSchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace HubSchool.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoServices _alunoService;
        private readonly ILogger<AlunoController> _logger;
        public AlunoController(IAlunoServices sevice, ILogger<AlunoController> logger)
        {
            _alunoService = sevice;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AlunoDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all people.");
            return Ok(_alunoService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AlunoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching person with Id {id}.", id);
            var aluno = _alunoService.FindById(id);
            if (aluno == null)
            {
                _logger.LogWarning("Person with Id {id} not found", id);
                return NotFound();
            }
            return Ok(aluno);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AlunoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] AlunoDTO aluno)
        {
            _logger.LogInformation("Creating new person: {firstName}.", aluno.Name);
            var createdAluno = _alunoService.Create(aluno);
            if (createdAluno == null)
            {
                _logger.LogError("Failed to create person with name {firstName}", aluno.Name);
                return NotFound();
            }
            return Ok(createdAluno);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(AlunoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] AlunoDTO aluno)
        {
            _logger.LogInformation("Updating person with Id {id}.", aluno.Id);
            var createdAluno = _alunoService.Update(aluno);
            if (createdAluno == null)
            {
                _logger.LogError("Failed to update person with Id {id} not found", aluno.Id);
                return NotFound();
            }
            _logger.LogDebug("Person updated successfully: {firstName} ", createdAluno.Name);
            return Ok(createdAluno);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(AlunoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting person with Id {id}.", id);
            _alunoService.Delete(id);
            _logger.LogDebug("Person with Id {id} deleted successfully ", id);
            return NoContent();
        }
    
    }
}
