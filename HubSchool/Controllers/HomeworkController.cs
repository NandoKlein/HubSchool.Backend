using HubSchool.Data.Dto;
using HubSchool.Services;
using Microsoft.AspNetCore.Mvc;
using HubSchool.Model.Enums;

namespace HubSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeworkController : ControllerBase
    {
        private readonly IHomeworkServices _homeworkServices;
        private readonly ILogger<HomeworkController> _logger;
        private readonly IWebHostEnvironment _env;


        public HomeworkController(IHomeworkServices services, ILogger<HomeworkController> logger, IWebHostEnvironment env)
        {
            _homeworkServices = services;
            _logger = logger;
            _env = env;
        }

        [HttpGet("buscaPorProfessor")]
        [ProducesResponseType(200, Type = typeof(List<HomeworkDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long idProfessor)
        {
            _logger.LogInformation("Buscando homeworks do professor {id}.", idProfessor);
            var Homeworks = _homeworkServices.BuscaHomeworksPorProfessor(idProfessor);
            if (Homeworks == null)
            {
                _logger.LogWarning("Homework de Id {id} não encontrado", idProfessor);
                return NotFound();
            }
            return Ok(Homeworks);
        }

        [HttpGet("buscaPorAluno")]
        [ProducesResponseType(200, Type = typeof(List<HomeworkDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long idAluno, int status)
        {
            _logger.LogInformation("Buscando homeworks do aluno {id}.", idAluno);
            var Homeworks = _homeworkServices.BuscaHomeworksPorAluno( idAluno, status);
            if (Homeworks == null)
            {
                _logger.LogWarning("Homework de Id {id} não encontrado", idAluno);
                return NotFound();
            }
            return Ok(Homeworks);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(HomeworkDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] HomeworkDTO homeworkDTO)
        {
            _logger.LogInformation("Atualizando homework de Id.");
            var homework = _homeworkServices.Atualizar(homeworkDTO);
            if (homework == null)
            {
                _logger.LogError("Falha ao atualizar homework, não encontrado.");
                return NotFound();
            }
            _logger.LogDebug("Homework atualizada com sucesso.");
            return Ok(homework);
        }

        [HttpPost("{idAula}/{idAluno}/arquivo")]
        public async Task<IActionResult> UploadHomework(long idAula,long idAluno, IFormFile arquivo)
        {
            if (arquivo == null || arquivo.Length == 0)
                return BadRequest("Nenhum arquivo enviado.");
            var extensao = Path.GetExtension(arquivo.FileName);
            var nomeArquivo = $"{idAula}{idAluno}{extensao}";
            var webRoot = _env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var caminho = Path.Combine(webRoot, "uploads", "homeworks", nomeArquivo);

            Directory.CreateDirectory(Path.GetDirectoryName(caminho));
            using (var stream = new FileStream(caminho, FileMode.Create))
                await arquivo.CopyToAsync(stream);

            var url = $"/uploads/homeworks/{nomeArquivo}";

            var homeworkDTO =  _homeworkServices.BuscaHomeworkPorAulaEAluno(idAula, idAluno);
            homeworkDTO.Arquivo = url;
            homeworkDTO.StatusHomework = StatusHomework.PendenteDeCorreção;
            _homeworkServices.Atualizar(homeworkDTO);

            return Ok(new { url });
        }

    }
}
