using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCourseWork.Authentication;


namespace WebApplicationCourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthModel model) // action method essentially just registers user
        {

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                return Ok(new { message = "Successful Registration" });

            }

            return BadRequest(result.Errors);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //var user = new IdentityUser { UserName = model.Email};
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                return Ok("Login has succeeded");
            }
            return Unauthorized("Wrong username or password Try again!");

        }

    }
}