using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationRequest registrationRequest)
        {
            return Ok("User created");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            return Ok("User is logging");
        }

        [HttpGet("{userId:guid}")]
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
