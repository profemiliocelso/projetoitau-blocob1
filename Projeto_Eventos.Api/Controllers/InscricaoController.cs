using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Eventos.Api.Entities;
using Projeto_Eventos.Api.Services;

namespace Projeto_Eventos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly InscricaoService inscricaoService;

        public InscricaoController(InscricaoService service)
        {
            this.inscricaoService = service;
        }

        [HttpPost]
        public IActionResult EfetuarInscricao([FromBody] Inscricao inscricao)
        {
            inscricaoService.Incluir(inscricao);
            return Created("/api/inscricao", inscricao);
        } 

        [HttpGet]
        public IActionResult ListarInscricoes()
        {
            return Ok(inscricaoService.ListarInscricoes());
        }       
    }
}
