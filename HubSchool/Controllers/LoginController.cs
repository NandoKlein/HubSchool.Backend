using HubSchool.Data.Dto;
using HubSchool.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HubSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAlunoServices _alunoService;
        private readonly IProfessorServices _professorService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IAlunoServices alunoService, IProfessorServices professorService, ILogger<LoginController> logger)
        {
            _alunoService = alunoService;
            _professorService = professorService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public IActionResult Login([FromBody] LoginDTO credentials)
        {
            _logger.LogInformation("Fazendo login");
            var loginValido = _alunoService.Login(credentials.Login, credentials.Senha) 
                || _professorService.Login(credentials.Login, credentials.Senha);
            if (!loginValido)
            {
                _logger.LogWarning("Email ou senha inválidos.");
                return Unauthorized();
            }
            _logger.LogInformation("Login efetuado com sucesso.");
            return Ok();
        }
    }
}
