using BEWalks.API.Models.DTO;
using BEWalks.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BEWalks.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager,
            ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var identityUser = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, request.Password);

            if (identityResult.Succeeded)
            {
                // Add roles to this user
                if (request.Roles != null && request.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, request.Roles);

                    if (identityResult.Succeeded)
                    {
                        //return Ok("User registered successfully!");
                        return Ok(new
                        {
                            Message = "User registered successfully!",
                            Username = identityUser.UserName,
                            Roles = request.Roles
                        });
                    }
                }
                
            }

            //return BadRequest("User registration failed");
            return BadRequest(new
            {
                Message = "User registration failed.",
                Errors = identityResult.Errors.Select(e => e.Description)
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        { 
            var user = await userManager.FindByEmailAsync(request.Username);

            if (user != null) 
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, request.Password);

                if (checkPasswordResult)
                {
                    // Get roles for this user
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        // Create Token
                        var jwtToken = tokenRepository.CreateToken(user, roles.ToList());
                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(response);
                    }

                    return Ok();
                }
            }

            return BadRequest("Username or password incorrect");

        }
    }
}
