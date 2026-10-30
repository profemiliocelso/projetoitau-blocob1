using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Site_EmilioCelso.Treinamento.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { mensagem = "Bem vinda (o) ao bloco B1" });
        }
    }
}
