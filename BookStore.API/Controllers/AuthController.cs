using BookStore.API.Data.DTOs;
using BookStore.API.Data.Models;
using BookStore.API.Static;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, UserManager<ApiUser> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            _logger.LogInformation($"Registration for {userDTO.Email}");

            try
            {
                if (userDTO == null)
                {
                    return BadRequest(ModelState);
                }

                var newUser = new ApiUser
                {
                    UserName = userDTO.UserName,
                    Email = userDTO.Email,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName
                };

                var createUserResult = await _userManager.CreateAsync(newUser, userDTO.Password);
                if (createUserResult.Succeeded == false)
                {
                    foreach (var error in createUserResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                var createUserRoleResult = await _userManager.AddToRoleAsync(newUser, "User");
                if (createUserRoleResult.Succeeded == false)
                {
                    foreach (var error in createUserRoleResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured while creating user - {userDTO.Email}");
                return Problem($"Something went wrong in {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginUserDTO userDTO)
        {
            _logger.LogInformation($"Login for {userDTO.Email}");

            try
            {
                var user = await _userManager.FindByEmailAsync(userDTO.Email);
                var passsordValid = await _userManager.CheckPasswordAsync(user, userDTO.Password);

                if (user == null || passsordValid == false)
                {
                    return Unauthorized(userDTO);
                }

                string tokenString = await GenerateToken(user);

                var response = new AuthResponse
                {
                    Email = user.Email,
                    Token = tokenString,
                    UserId = user.Id,
                    UserName = user.UserName
                };

                return Accepted(response);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occured while creating user - {userDTO.Email}");
                return Problem($"Something went wrong in {nameof(Register)}", statusCode: 500);
            }
        }

        private async Task<string> GenerateToken(ApiUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JwtSettings:Duration"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
