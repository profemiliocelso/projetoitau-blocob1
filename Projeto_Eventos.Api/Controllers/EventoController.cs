using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Eventos.Api.Entities;
using Projeto_Eventos.Api.Services;

namespace Projeto_Eventos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly EventoService eventoService;
        public EventoController(EventoService service)
        {
            this.eventoService = service;
        }

        [HttpGet]
        public IActionResult ListarEventos()
        {
            return Ok(eventoService.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarEvento([FromRoute] int id)
        {
            return Ok(eventoService.Buscar(id));
        }

        [HttpPost]
        public IActionResult IncluirEvento([FromBody] Evento evento)
        {
            eventoService.Incluir(evento);
            return Created("/api/evento", evento);
        }

        [HttpPut("{id}")]
        public IActionResult AlterarEvento([FromRoute] int id, [FromBody] Evento evento)
        {
            eventoService.Alterar(id, evento);
            return NoContent();
        }
    }
}
