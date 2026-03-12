using HubSchool.Data.Dto;
using HubSchool.Model;
using HubSchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace HubSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtendenteController : ControllerBase
    {
        private readonly IAtendenteServices _atendenteServices;
        private readonly ILogger<AtendenteController> _logger;
        private readonly IWebHostEnvironment _env;

        public AtendenteController(IAtendenteServices atendenteServices, ILogger<AtendenteController> logger,IWebHostEnvironment env)
        {
            _atendenteServices = atendenteServices;
            _logger = logger;
            _env = env;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AtendenteDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Buscando todos os atendentes.");
            return Ok(_atendenteServices.FindAll());
        }

        [HttpGet("cont")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult GetCont()
        {
            _logger.LogInformation("Buscando a quantidade de atendentes.");
            return Ok(_atendenteServices.Count());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Buscando atendente de Id {id}.", id);
            var atendente = _atendenteServices.FindById(id);
            if (atendente == null)
            {
                _logger.LogWarning("Atendente de Id {id} não encontrado", id);
                return NotFound();
            }
            return Ok(atendente);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(AtendenteDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] AtendenteDTO atendente)
        {
            _logger.LogInformation("Cadastrando novo atendente: {name}.", atendente.Name);
            var novoAtendente = _atendenteServices.Create(atendente);
            if (novoAtendente == null)
            {
                _logger.LogError("Falha ao cadastrar atendente de nome {name}", atendente.Name);
                return NotFound();
            }
            return Ok(novoAtendente);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(AtendenteDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] AtendenteDTO atendente)
        {
            _logger.LogInformation("Atualizando atendente de Id {id}.", atendente.Id);
            var novoAtendente = _atendenteServices.Update(atendente);
            if (novoAtendente == null)
            {
                _logger.LogError("Falha ao atualizar atendente de Id {id}, não encontrado.", atendente.Id);
                return NotFound();
            }
            _logger.LogDebug("Atendente atualizado com sucesso: {name} ", novoAtendente.Name);
            return Ok(novoAtendente);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(AtendenteDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deletando atendente de Id {id}.", id);
            _atendenteServices.Delete(id);
            _logger.LogDebug("Atendente com Id {id} deletado com sucesso. ", id);
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
            var caminho = Path.Combine(webRoot, "uploads", "atendentes", nomeArquivo);

            Directory.CreateDirectory(Path.GetDirectoryName(caminho));
            using (var stream = new FileStream(caminho, FileMode.Create))
                await foto.CopyToAsync(stream);

            var url = $"/uploads/atendentes/{nomeArquivo}";
            _atendenteServices.AtualizarFoto(id, url);

            return Ok(new { url });
        }
    }
}
