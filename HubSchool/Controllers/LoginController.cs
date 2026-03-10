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
            var professorDTO = _professorService.Login(credentials.Login, credentials.Senha);
            if (professorDTO != null)
            {
                return Ok(new LoginResponseDTO
                {
                    ID = professorDTO.Id,
                    Name = professorDTO.Name,
                    Role = "professor",
                    Email = professorDTO.Email
                });
            }
            var alunoDTO = _alunoService.Login(credentials.Login, credentials.Senha);                
            if (alunoDTO != null)
            {
                return Ok(new LoginResponseDTO
                {
                    ID = alunoDTO.Id,
                    Name = alunoDTO.Name,
                    Role = "aluno",
                    Email = alunoDTO.Email
                });
              
            }
            _logger.LogWarning("Email ou senha inválidos.");
            return Unauthorized();
        }
    }
}
