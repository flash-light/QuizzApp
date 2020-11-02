using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quizzes.Common.Models;
using QuizzesApp.Auth.Models;

namespace QuizzesApp.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(
            ILogger<AuthController> logger,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
            )
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }



        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResult<string>>> LogInAsync([FromBody] AuthModel authModel)
        {
            var user = await _userManager.FindByNameAsync(authModel.username);

            if(user != null)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user, authModel.password, false, false);
                if(signInResult.Succeeded)
                {
                    return new ServiceResult<string> { Success = true, Data = "token" };
                }
            }

            return new ServiceResult<string> { Success = true, Data = "Index" };
        }


        [HttpPost("Logout")]
        public ActionResult<ServiceResult<string>> LogOut([FromBody] AuthModel authModel)
        {

            return new ServiceResult<string> { Success = true, Data = "Index" };
        }


        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResult<string>>> Register([FromBody] AuthModel authModel)
        {
            var user = new IdentityUser
            {
                UserName = authModel.username,
                Email = ""
            };
            var result = await _userManager.CreateAsync(user, authModel.password);

            if(result.Succeeded)
            {

            }
            return new ServiceResult<string> { Success = true, Data = "Index" };
        }
    }
}
