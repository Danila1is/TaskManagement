using Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contracts.Users;

namespace Presenters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequest registrationRequest)
        {
            try
            {
                Guid id = await _usersService.RegistrationAsync(registrationRequest);
                return Ok($"{id}");
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                string token = await _usersService.LoginAsync(loginRequest);

                Response.Cookies.Append("jwt-token", token);

                return Ok("Успешный вход");
            }
            catch(ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{userId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] Guid userId)
        {
            return Ok("User is find");
        }

        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid userId, [FromBody] UpdateRequest updateRequest)
        {
            return Ok("User is updated");
        }

        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid userId)
        {
            return Ok("User is deleted");
        }
    }
}
