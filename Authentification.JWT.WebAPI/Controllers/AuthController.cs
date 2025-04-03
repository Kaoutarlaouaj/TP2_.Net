using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Authentification.JWT.Service;
using Authentification.JWT.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly JwtService _jwtService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(UserService userService, JwtService jwtService, ILogger<AuthController> logger)
    {
        _userService = userService;
        _jwtService = jwtService;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        _logger.LogInformation("Tentative d'enregistrement pour l'utilisateur : {Username}", model.Username);
        var user = await _userService.RegisterUserAsync(model.Username, model.Email, model.Password);
        _logger.LogInformation("Utilisateur {Username} enregistré avec succès", model.Username);
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        _logger.LogInformation("Tentative de connexion pour l'utilisateur : {Username}", model.Username);
        var user = await _userService.GetUserByUsernameAsync(model.Username);
        if (user == null || !_userService.VerifyPassword(user, model.Password))
        {
            _logger.LogWarning("Échec de connexion pour l'utilisateur : {Username}", model.Username);
            return Unauthorized("Invalid credentials");
        }

        var token = _jwtService.GenerateToken(user.Id);
        _logger.LogInformation("Connexion réussie pour l'utilisateur : {Username}", model.Username);
        return Ok(new { Token = token });
    }

    [Authorize]
    [HttpGet("protected")]
    public IActionResult ProtectedEndpoint()
    {
        _logger.LogInformation("Accès à un endpoint protégé");
        return Ok("You have accessed a protected endpoint!");
    }
}
