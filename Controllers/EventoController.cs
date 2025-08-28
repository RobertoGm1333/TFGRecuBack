using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProtectoraAPI.Services;
using Models;

namespace ProtectoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _service;

        public EventoController(IEventoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Evento>>> GetEventos()
        {
            var eventos = await _service.GetAllAsync();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var ev = await _service.GetByIdAsync(id);
            if (ev == null) return NotFound();
            return Ok(ev);
        }

        [HttpPost]
        public async Task<ActionResult<Evento>> CreateEvento([FromBody] Evento ev)
        {
            if (ev == null) return BadRequest("Datos vacíos.");

            // Normalización ligera
            ev.Fecha = ev.Fecha.Date;
            ev.Hora  = new System.TimeSpan(ev.Hora.Hours, ev.Hora.Minutes, 0);

            await _service.AddAsync(ev);
            return CreatedAtAction(nameof(GetEvento), new { id = ev.Id_Evento }, ev);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvento(int id, [FromBody] Evento ev)
        {
            var existente = await _service.GetByIdAsync(id);
            if (existente == null) return NotFound();

            // Mantener Id
            ev.Id_Evento = id;

            ev.Fecha = ev.Fecha.Date;
            ev.Hora  = new System.TimeSpan(ev.Hora.Hours, ev.Hora.Minutes, 0);

            await _service.UpdateAsync(ev);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var existente = await _service.GetByIdAsync(id);
            if (existente == null) return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("protectora/{idProtectora}")]
        public async Task<IActionResult> GetEventosPorProtectora(int idProtectora)
        {
            var eventos = await _service.ObtenerPorProtectoraAsync(idProtectora);
            if (eventos == null || !eventos.Any())
                return NotFound("No se encontraron eventos para esta protectora.");

            return Ok(eventos);
        }
    }
}
