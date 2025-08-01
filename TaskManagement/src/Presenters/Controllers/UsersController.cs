﻿using Application.Users;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contracts.Users;
using TaskManagement.Presenters.ResponseExtensions;

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

            Result<Guid, Failure> result = await _usersService.RegistrationAsync(registrationRequest);

            if (result.IsFailure)
            {
                return result.Error.ToResponse();
            }

            return Ok($"{result.Value}");

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            Result<string, Failure> result = await _usersService.LoginAsync(loginRequest);

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
