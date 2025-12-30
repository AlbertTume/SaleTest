using Microsoft.AspNetCore.Mvc;
using SaliTest.Application.DTOs;
using SaliTest.Application.Services;

namespace SaliTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(AuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto loginRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new LoginResponseDto
                    {
                        IsSuccess = false,
                        Message = "Invalid login request."
                    });
                }

                var response = await _authService.LoginAsync(loginRequest);

                if (!response.IsSuccess)
                {
                    return Unauthorized(response);
                }

                return Ok(response);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the login request.");
                return StatusCode(500, new LoginResponseDto {
                    IsSuccess = false,
                    Message = "An internal server error occurred."
                });
            }
        }
    }
}