using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;
using WebApplication8.Repositories;

namespace WebApplication8.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class AccountController : ControllerBase
        {
            private readonly IAccountRepositories _accountRepositories;
            public AccountController(IAccountRepositories accountRepositories)
            {
                _accountRepositories = accountRepositories;
            }

            [HttpPost("signup")]
            public async Task<IActionResult> SignUpAsync(SignUpModel model)
            {
                var result = await _accountRepositories.SignUpAsync(model);
                if (result.Succeeded)
                {
                    return Ok(result.Succeeded);
                }
                return BadRequest(result.Errors);
            }

            [HttpPost("signin")]
            public async Task<IActionResult> SignInAsync(SignInModel model)
            {
                var token = await _accountRepositories.SignInAsync(model);
                if (token is null)
                {
                    return Unauthorized();
                }
                return Ok(new
                {
                    data = new
                    {
                        success = true,
                        Token = token,
                    }
                });
            }
        }
    }

