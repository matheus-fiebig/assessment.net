using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Model;
using Projeto.Service;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("{id?}")]
        public IActionResult GetCliente(string id="")
        {
            return Ok(_service.GetCliente(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente(ClienteForCreationModel model)
        {
            await _service.CreateCliente(model);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditCliente(ClienteForUpdateModel model, string id)
        {
            await _service.UpdateCliente(model,id);
            return NoContent();
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            await _service.DeleteCliente(id);
            return NoContent();
        }

    }
}