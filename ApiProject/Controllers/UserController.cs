using ApiProject.Api.Authentication.TokenGenerators;
using ApiProject.Api.Authentication.TokenValidators;
using ApiProject.Domain.DTOs.UserDTO;
using ApiProject.Domain.Entities;
using ApiProject.Infrastructure.Repository.MajorRepository;
using ApiProject.Infrastructure.Repository.RefreshTokenRepository;
using ApiProject.Infrastructure.Repository.UserRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly Authenticator _authenticator;
        private readonly ValidateRefreshToken _refreshTokenValidator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IMajorRepository _majorRepository;
        public UserController(IUserRepository userRepository, ValidateRefreshToken refreshTokenValidator,
            IRefreshTokenRepository refreshTokenRepository, Authenticator authenticator,IMajorRepository majorRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _authenticator = authenticator;

            _userRepository = userRepository;

            _refreshTokenValidator = refreshTokenValidator;
            _majorRepository = majorRepository;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var emailValidate = await _userRepository.GetByEmail(request.Email);
            if (emailValidate != null)
            {
                return Conflict();
            }
            var persoanlId = await _userRepository.GetByPersonalId(request.PersonalId);
            if (persoanlId != null)
            {
                return NotFound();
            }


            await _userRepository.Create(request);
           
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            User user = await _userRepository.GetByEmail(login.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            if (user.PeronalId != login.PersoanlId)
            {
                return Unauthorized();
            }
            AuthenticatedResponse authenticatedUser = await _authenticator.Authenticate(user);
            return Ok(authenticatedUser);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            bool isValidRefreshToken = _refreshTokenValidator.is_Valid(token);
            if (!isValidRefreshToken)
            {
                return BadRequest("Expired Token");
            }
            RefreshToken refreshTokenDTO = await _refreshTokenRepository.GetByToken(token);
            if (refreshTokenDTO == null)
            {
                return NotFound("Not found");
            }
            await _refreshTokenRepository.Delete(refreshTokenDTO.Id);
            User user = await _userRepository.GetById(refreshTokenDTO.UserId);
            AuthenticatedResponse authenticatedUser = await _authenticator.Authenticate(user);
            return Ok(authenticatedUser);
        }
        [Authorize]
        [HttpDelete("logout")]
        public async Task<IActionResult> LogOut()
        {
            string rawId = HttpContext.User.FindFirstValue("id");
            Guid.TryParse(rawId, out Guid userId);

            if (userId.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                return BadRequest("Invalid token");
            }
            await _refreshTokenRepository.DeleteAll(userId);
            return Ok("Logged Out");
        }
        [Authorize]
        [HttpPatch("set-major")]
        public async Task<IActionResult> SetMajor(string majorId)
        {
            string rawId = HttpContext.User.FindFirstValue("id");
            Guid.TryParse(rawId, out Guid userId);

            if (userId.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                return BadRequest("Invalid token");
            }
            if(await _majorRepository.GetById(majorId) == null)
            {
                return NotFound();
            }
            await _userRepository.SetMajor(userId, majorId);
            return Ok();
        }
        [Authorize]
        [HttpPost("confirm-payment")]
        public async Task<IActionResult> ConfirmPayment(IFormFile formFile)
        {
            
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rawId = HttpContext.User.FindFirstValue("id");
            Guid.TryParse(rawId, out Guid userId);
            string fileName = $"{userId}{formFile.Name}";
            string fullFileName = Path.Combine(path, fileName);
            if (userId.ToString() == "00000000-0000-0000-0000-000000000000")
            {
                return BadRequest("Invalid token");
            }
            
            await _userRepository.ConfirmPayment(userId);
            return Ok();
        }



    }
}