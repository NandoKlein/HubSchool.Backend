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
        private readonly IWebHostEnvironment _env;

        public AlunoController(IAlunoServices sevice, ILogger<AlunoController> logger, IWebHostEnvironment env)
        {
            _alunoService = sevice;
            _logger = logger;
            _env = env;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AlunoDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Buscando todos os alunos.");
            return Ok(_alunoService.FindAll());
        }

        [HttpGet("count")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetCount()
        {
            _logger.LogInformation("Buscando a quantidade de alunos.");
            return Ok(_alunoService.Count());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(AlunoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Buscando aluno de Id {id}.", id);
            var aluno = _alunoService.FindById(id);
            if (aluno == null)
            {
                _logger.LogWarning("Aluno de Id {id} não encontrado", id);
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
            _logger.LogInformation("Cadastrando novo aluno: {name}.", aluno.Name);
            var novoAluno = _alunoService.Create(aluno);
            if (novoAluno == null)
            {
                _logger.LogError("Falha ao cadastrar aluno de nome {name}", aluno.Name);
                return NotFound();
            }
            return Ok(novoAluno);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(AlunoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] AlunoDTO aluno)
        {
            _logger.LogInformation("Atualizando aluno de Id {id}.", aluno.Id);
            var novoAluno = _alunoService.Update(aluno);
            if (novoAluno == null)
            {
                _logger.LogError("Falha ao atualizar aluno de Id {id}, não encontrado.", aluno.Id);
                return NotFound();
            }
            _logger.LogDebug("Aluno atualizado com sucesso: {name} ", novoAluno.Name);
            return Ok(novoAluno);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(AlunoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deletando aluno de Id {id}.", id);
            _alunoService.Delete(id);
            _logger.LogDebug("Aluno com Id {id} deletado com sucesso. ", id);
            return NoContent();
        }

        [HttpPost("{id}/foto")]
        public async Task<IActionResult> UploadFoto(long id, IFormFile foto)
        {
            if (foto == null || foto.Length == 0)
                return BadRequest("Nenhum arquivo enviado.");
            var extensao = Path.GetExtension(foto.FileName);
            var nomeArquivo = $"{id}{extensao}";
            var webRoot = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var caminho = Path.Combine(webRoot, "uploads", "alunos", nomeArquivo);

            Directory.CreateDirectory(Path.GetDirectoryName(caminho));
            using (var stream = new FileStream(caminho, FileMode.Create))
                await foto.CopyToAsync(stream);

            var url = $"/uploads/alunos/{nomeArquivo}";
            _alunoService.AtualizarFoto(id, url);

            return Ok(new { url });
        }
    
    }
}
