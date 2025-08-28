using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;
using ProtectoraAPI.Services;

namespace ProtectoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _service;
        private readonly IWebHostEnvironment _env;

        public EventoController(IEventoService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
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

        [HttpGet("protectora/{idProtectora}")]
        public async Task<IActionResult> GetEventosPorProtectora(int idProtectora)
        {
            var eventos = await _service.ObtenerPorProtectoraAsync(idProtectora);
            return Ok(eventos);
        }

        // CREATE con subida de foto (multipart/form-data)
        [HttpPost]
        [RequestSizeLimit(104_857_600)] // 100 MB
        public async Task<ActionResult<Evento>> CreateEvento(
            [FromForm] int Id_Protectora,
            [FromForm] string Nombre_Evento,
            [FromForm] string Lugar,
            [FromForm] DateTime Fecha_Evento,
            [FromForm] TimeSpan Hora_Evento,
            [FromForm] string Descripcion_Evento,
            [FromForm] string? EnclaceMaps,
            [FromForm] IFormFile? Foto // ← archivo opcional
        )
        {
            var ev = new Evento
            {
                Id_Protectora = Id_Protectora,
                Nombre_Evento = Nombre_Evento,
                Lugar = Lugar,
                Fecha_Evento = Fecha_Evento.Date,
                Hora_Evento = new TimeSpan(Hora_Evento.Hours, Hora_Evento.Minutes, 0),
                Descripcion_Evento = Descripcion_Evento,
                EnclaceMaps = EnclaceMaps
            };

            if (Foto is not null && Foto.Length > 0)
                ev.Foto_Evento = await GuardarFotoAsync(Foto);

            await _service.AddAsync(ev);
            return CreatedAtAction(nameof(GetEvento), new { id = ev.Id_Evento }, ev);
        }

        // UPDATE con opción de nueva foto (multipart/form-data)
        [HttpPut("{id}")]
        [RequestSizeLimit(104_857_600)] // 100 MB
        public async Task<IActionResult> UpdateEvento(
            int id,
            [FromForm] int Id_Protectora,
            [FromForm] string Nombre_Evento,
            [FromForm] string Lugar,
            [FromForm] DateTime Fecha_Evento,
            [FromForm] TimeSpan Hora_Evento,
            [FromForm] string Descripcion_Evento,
            [FromForm] string? EnclaceMaps,
            [FromForm] IFormFile? Foto // ← si llega, se reemplaza
        )
        {
            var existente = await _service.GetByIdAsync(id);
            if (existente is null) return NotFound();

            existente.Id_Protectora = Id_Protectora;
            existente.Nombre_Evento = Nombre_Evento;
            existente.Lugar = Lugar;
            existente.Fecha_Evento = Fecha_Evento.Date;
            existente.Hora_Evento = new TimeSpan(Hora_Evento.Hours, Hora_Evento.Minutes, 0);
            existente.Descripcion_Evento = Descripcion_Evento;
            existente.EnclaceMaps = EnclaceMaps;

            if (Foto is not null && Foto.Length > 0)
            {
                // opcional: borrar la foto previa si existe en disco
                if (!string.IsNullOrWhiteSpace(existente.Foto_Evento))
                {
                    var absOld = Path.Combine(_env.WebRootPath, existente.Foto_Evento.Replace('/', Path.DirectorySeparatorChar));
                    if (System.IO.File.Exists(absOld)) System.IO.File.Delete(absOld);
                }

                existente.Foto_Evento = await GuardarFotoAsync(Foto);
            }

            await _service.UpdateAsync(existente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            var existente = await _service.GetByIdAsync(id);
            if (existente is null) return NotFound();

            // opcional: borrar la imagen en disco
            if (!string.IsNullOrWhiteSpace(existente.Foto_Evento))
            {
                var absOld = Path.Combine(_env.WebRootPath, existente.Foto_Evento.Replace('/', Path.DirectorySeparatorChar));
                if (System.IO.File.Exists(absOld)) System.IO.File.Delete(absOld);
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }

        // ===== Helpers =====
        private async Task<string> GuardarFotoAsync(IFormFile file)
        {
            var folderRel = Path.Combine("Images", "Eventos"); // ruta relativa que servirá StaticFiles
            var folderAbs = Path.Combine(_env.WebRootPath, folderRel);

            if (!Directory.Exists(folderAbs))
                Directory.CreateDirectory(folderAbs);

            var ext = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid():N}{ext}";
            var absPath = Path.Combine(folderAbs, fileName);

            using (var stream = new FileStream(absPath, FileMode.Create))
                await file.CopyToAsync(stream);

            // devolver ruta relativa con separador web
            return Path.Combine(folderRel, fileName).Replace("\\", "/");
        }
    }
}
