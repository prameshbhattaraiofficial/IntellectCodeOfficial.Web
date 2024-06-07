using IntellectCodeofficial.API.Models;
using IntellectCodeofficial.API.Models.Sign_Up;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace IntellectCodeofficial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _Configuration;
        private readonly UserManager<IdentityRole> _UserManager;
        private readonly SignInManager<IdentityUser> _SignInManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        public AuthenticationController(IConfiguration Configuration, UserManager<IdentityRole> UserManager, SignInManager<IdentityUser> SignInManager, RoleManager<IdentityRole> RoleManager)
        {
            _Configuration = Configuration;
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _RoleManager = RoleManager;
        }

        [HttpGet]

        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {

            var userExist = await _UserManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
            {
                // User already exists
                return StatusCode(StatusCodes.Status409Conflict,
                    new Response { Status = "Error", Message = "User Already Exists" }
                );
            }

            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username
            };

            var result = await _UserManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                // User created successfully
                return StatusCode(StatusCodes.Status201Created,
                    new Response { Status = "Success", Message = "User Created Successfully" }
                );
            }
            else
            {
                // User creation failed
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User Failed to Create" }
                );
            }



            /* var userExist = await _UserManager.FindByEmailAsync(registerUser.Email);
             if (userExist != null)
             {
                 return StatusCode(StatusCodes.Status403Forbidden,
                       new Response { Status = "Error", Message = "User Already Exist" }
                     );


             }

             IdentityUser user = new()
             {
                 Email = registerUser.Email,
                 SecurityStamp = Guid.NewGuid().ToString(),
                 UserName = registerUser.Username
             };

             var result = await _UserManager.CreateAsync(user, registerUser.Password);

             if (result.Succeeded)
             {
                 return StatusCode(StatusCodes.Status403Forbidden,
                     new Response { Status = "Error", Message = "User Already Exist!" });
             }
             else
             {
                 return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Failed to Create" });
             }*/

        }

    }
}
