using Application.Users;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions;
using TaskManagement.Application.Users.Login;
using TaskManagement.Application.Users.Registration;
using TaskManagement.Contracts.Users;
using TaskManagement.Presenters.ResponseExtensions;

namespace Presenters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {

        public UsersController()
        {
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration(
            [FromBody] RegistrationRequest registrationRequest,
            [FromServices] ICommandHandler<Guid, RegistrationCommand> handler)
        {
            var command = new RegistrationCommand(registrationRequest);

            Result<Guid, Failure> result = await handler.Handle(command);

            return result.IsFailure ? result.Error.ToResponse() : Ok(result.Value);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest loginRequest,
            [FromServices] ICommandHandler<string, LoginCommand> handler)
        {
            LoginCommand command = new LoginCommand(loginRequest);

            Result<string, Failure> result = await handler.Handle(command);

            if (result.IsFailure)
            {
                return result.Error.ToResponse();
            }

            string token = result.Value;

            Response.Cookies.Append("jwt-token", token);

            return Ok("Успешный вход");
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
