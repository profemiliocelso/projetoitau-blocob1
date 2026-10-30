using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Eventos.Api.Entities;
using Projeto_Eventos.Api.Services;

namespace Projeto_Eventos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvidadoController : ControllerBase
    {
        private readonly ConvidadoService convidadoService;
        public ConvidadoController(ConvidadoService service)
        {
            this.convidadoService = service;
        }

        [HttpPost]
        public IActionResult IncluirConvidado([FromBody] Convidado convidado)
        {
            convidadoService.Incluir(convidado);
            return Created("/api/convidado", convidado);
        }
    }
}
