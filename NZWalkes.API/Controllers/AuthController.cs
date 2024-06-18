using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NZWalkes.API.Models.DTOs;
using NZWalkes.API.Repositers;

namespace NZWalkes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepositery _tokenRepositery;


        public AuthController(UserManager<IdentityUser> userManager, ITokenRepositery tokenRepositery)
        {
            _userManager = userManager;
            _tokenRepositery = tokenRepositery;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var identityuser = new IdentityUser

            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                PhoneNumber = registerDto.Mobile.ToString()

            };
            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(identityuser, registerDto.Password);

                if (result.Succeeded)
                {

                    return Ok("User Registered");

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }

            return BadRequest("SomeThing Wrong");

        }




        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            // Check if user is authenticated
            // Check username and password
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user != null  )
            {
                var roles = await _userManager.GetRolesAsync(user);
                var jwttoken = _tokenRepositery.CreatedJWTToken(user, roles.ToList());
                return Ok(jwttoken);
            }

            return BadRequest("Username or Password is incorrect.");
        }
    }
}
