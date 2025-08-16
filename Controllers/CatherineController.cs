using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProtectoraAPI.Services;

namespace ProtectoraAPI.Controllers
{
    // DTOs locales (Swagger friendly, sin carpeta DTOs en el back)
    public class CatherineChatRequest
    {
        public string Mensaje { get; set; } = "";
    }

    public class CatherineChatResponse
    {
        public string Pregunta { get; set; } = "";
        public string Respuesta { get; set; } = "";
        public object? Resultados { get; set; } // lista de gatos devueltos (hasta N)
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CatherineController : ControllerBase
    {
        private readonly ICatherineService _svc;

        public CatherineController(ICatherineService svc)
        {
            _svc = svc;
        }

        [HttpPost("chat")]
        public async Task<ActionResult<CatherineChatResponse>> Chat([FromBody] CatherineChatRequest req)
        {
            if (req is null || string.IsNullOrWhiteSpace(req.Mensaje))
                return BadRequest("El campo 'Mensaje' es obligatorio.");

            var cat = await _svc.ProcesarAsync(req.Mensaje);

            return Ok(new CatherineChatResponse
            {
                Pregunta = cat.Pregunta,
                Respuesta = cat.Respuesta,
                Resultados = cat.Resultados.Select(g => new
                {
                    g.Id_Gato,
                    g.Nombre_Gato,
                    g.Raza,
                    g.Edad,
                    g.Sexo,
                    g.Imagen_Gato
                }).ToList()
            });
        }
    }
}
