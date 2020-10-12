using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using SeguimientoApi.Models;
using SeguimientoApi.Service;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeguimientoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager AuthManager;
        public AuthController(IAuthManager authManager)
        {
            AuthManager = authManager;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value_1", "value_2" };
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] Usuario user)
        {
            var Token = AuthManager.Authenticate(user.NombreUsuario, user.Contrasena);

            if (Token == null)
                return Unauthorized();

            return Ok(Token);
        }
    }
}
