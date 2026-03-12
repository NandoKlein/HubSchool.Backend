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
        private readonly IAtendenteServices _atendenteService;
        
        private readonly ILogger<LoginController> _logger;

        public LoginController(IAlunoServices alunoService, IProfessorServices professorService, ILogger<LoginController> logger, IAtendenteServices atendenteServices)
        {
            _alunoService = alunoService;
            _professorService = professorService;
            _logger = logger;
            _atendenteService = atendenteServices;
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
            var atendenteDTO = _atendenteService.Login(credentials.Login, credentials.Senha);                
            if (atendenteDTO != null)
            {
                return Ok(new LoginResponseDTO
                {
                    ID = atendenteDTO.Id,
                    Name = atendenteDTO.Name,
                    Role = "atendente",
                    Email = atendenteDTO.Email
                });
              
            }
            _logger.LogWarning("Email ou senha inválidos.");
            return Unauthorized();
        }
    }
}
