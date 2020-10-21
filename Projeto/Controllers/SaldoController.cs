using Microsoft.AspNetCore.Mvc;
using Projeto.Model;
using Projeto.Service;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaldoController : ControllerBase
    {
        private readonly ISaldoService _service;

        public SaldoController(ISaldoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public  IActionResult GetSaldo(string id)
        {
            
            return Ok( _service.VerSaldo(id));
        }

        [HttpPost]
        [Route("adicionarSaldo")]
        public IActionResult AddSaldo(SaldoModel model)
        {
            return Ok(_service.MudarSaldo(model));
        }

        [HttpPost]
        [Route("sacar")]
        public IActionResult RemoveSaldo(SaldoModel model)
        {
            return Ok(_service.SacarSaldo(model));
        }

    }
}