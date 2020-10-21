using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Projeto.Model;
using Projeto.Service;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var response = await _service.Login(model);
            Response.Headers.TryGetValue("Set-Cookie", out StringValues value);
            var token = Helpers.Helpers.GetToken(value);
            Response.Headers.Add("X-Access-Token", JsonSerializer.Serialize(token));
            return Ok(response);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _service.Logout();
            return Ok();
        }

        
        [HttpGet]
        [Route("permissao")]
        [Authorize(Roles="Admin")]
        public IActionResult HasPermissao(){
            return Ok();
        }
    }
}