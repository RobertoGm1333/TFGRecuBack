using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProtectoraAPI.Repositories;
using Models;
using System.Text.Json;
using ProtectoraAPI.Services;

namespace ProtectoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudAdopcionController : ControllerBase
    {
        private readonly ISolicitudAdopcionRepository _repository;
        private readonly ILogger<SolicitudAdopcionController> _logger;

        public SolicitudAdopcionController(ISolicitudAdopcionRepository repository, ILogger<SolicitudAdopcionController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SolicitudAdopcion>>> GetSolicitudes()
        {
            var solicitudes = await _repository.GetAllAsync();
            return Ok(solicitudes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitudAdopcion>> GetSolicitud(int id)
        {
            var solicitud = await _repository.GetByIdAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return Ok(solicitud);
        }

        [HttpPost]
        public async Task<ActionResult<SolicitudAdopcion>> CreateSolicitud([FromBody] SolicitudAdopcion solicitud)
        {
            try
            {
                _logger.LogInformation($"Recibida solicitud de adopción: {JsonSerializer.Serialize(solicitud)}");
                
                // Validaciones básicas
                if (solicitud == null)
                {
                    _logger.LogWarning("La solicitud recibida es nula.");
                    return BadRequest(new { message = "La solicitud no puede estar vacía" });
                }

                // Validar campos requeridos
                var validationErrors = new List<string>();

                if (string.IsNullOrWhiteSpace(solicitud.NombreCompleto))
                    validationErrors.Add("El nombre completo es requerido");
                if (string.IsNullOrWhiteSpace(solicitud.DNI))
                    validationErrors.Add("El DNI es requerido");
                if (string.IsNullOrWhiteSpace(solicitud.Email))
                    validationErrors.Add("El email es requerido");
                if (string.IsNullOrWhiteSpace(solicitud.Telefono))
                    validationErrors.Add("El teléfono es requerido");
                if (solicitud.Id_Usuario <= 0)
                    validationErrors.Add("ID de usuario inválido");
                if (solicitud.Id_Gato <= 0)
                    validationErrors.Add("ID de gato inválido");
                if (solicitud.Edad.HasValue && (solicitud.Edad.Value < 18 || solicitud.Edad.Value > 120))
                    validationErrors.Add("La edad debe estar entre 18 y 120 años");
                if (solicitud.NumeroPersonas.HasValue && solicitud.NumeroPersonas.Value <= 0)
                    validationErrors.Add("El número de personas debe ser mayor que 0");

                if (validationErrors.Any())
                {
                    _logger.LogWarning($"Errores de validación: {string.Join(", ", validationErrors)}");
                    return BadRequest(new { message = "Errores de validación", errors = validationErrors });
                }

                solicitud.Fecha_Solicitud = DateTime.Now;
                solicitud.Estado = "pendiente";

                try
                {
                    await _repository.AddAsync(solicitud);
                    _logger.LogInformation($"Solicitud de adopción creada con éxito. ID: {solicitud.Id_Solicitud}");
                    return CreatedAtAction(nameof(GetSolicitud), new { id = solicitud.Id_Solicitud }, solicitud);
                }
                catch (Exception ex) when (ex.Message.Contains("El usuario especificado no existe"))
                {
                    _logger.LogError(ex, "Error al crear solicitud: Usuario no existe");
                    return BadRequest(new { message = "El usuario especificado no existe en el sistema" });
                }
                catch (Exception ex) when (ex.Message.Contains("El gato especificado no existe"))
                {
                    _logger.LogError(ex, "Error al crear solicitud: Gato no existe");
                    return BadRequest(new { message = "El gato especificado no existe en el sistema" });
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error interno al crear la solicitud");
                    return StatusCode(500, new { message = "Error al crear la solicitud", error = ex.Message });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error no controlado al crear la solicitud");
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSolicitud(int id, SolicitudAdopcion updated)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            updated.Id_Solicitud = id;
            await _repository.UpdateAsync(updated);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud(int id)
        {
            var solicitud = await _repository.GetByIdAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("usuario/{idUsuario}")]
        public async Task<ActionResult<List<SolicitudAdopcion>>> GetSolicitudesPorUsuario(int idUsuario)
        {
            try
            {
                var solicitudes = await _repository.GetByUsuarioIdAsync(idUsuario);
                if (solicitudes == null || !solicitudes.Any())
                {
                    return NotFound(new { message = "No hay solicitudes para este usuario." });
                }
                return Ok(solicitudes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener solicitudes del usuario {idUsuario}");
                return StatusCode(500, $"Error al obtener las solicitudes: {ex.Message}");
            }
        }

        [HttpGet("gato/{idGato}")]
        public async Task<ActionResult<List<SolicitudAdopcion>>> GetSolicitudesPorGato(int idGato)
        {
            var solicitudes = await _repository.GetByGatoIdAsync(idGato);
            return Ok(solicitudes);
        }

        [HttpGet("protectora/{idProtectora}")]
        public async Task<ActionResult<List<object>>> GetSolicitudesPorProtectora(int idProtectora)
        {
            var solicitudes = await _repository.GetSolicitudesByProtectoraAsync(idProtectora);
            return Ok(solicitudes);
        }

        [HttpPut("estado/{id}")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] CambiarEstadoDTO datos)
        {
            var solicitud = await _repository.GetByIdAsync(id);
            if (solicitud == null)
                return NotFound();

            await _repository.UpdateEstadoAsync(id, datos.Estado, datos.Comentario_Protectora);
            return NoContent();
        }

        [HttpGet("usuario/{idUsuario}/gato/{idGato}")]
        public async Task<ActionResult<SolicitudAdopcion>> GetSolicitudPorUsuarioYGato(int idUsuario, int idGato)
        {
            try
            {
                _logger.LogInformation($"Buscando solicitud para usuario {idUsuario} y gato {idGato}");
                var solicitudes = await _repository.GetByUsuarioIdAsync(idUsuario);
                var solicitud = solicitudes.FirstOrDefault(s => s.Id_Gato == idGato);
                
                if (solicitud == null)
                {
                    _logger.LogInformation($"No se encontró solicitud para usuario {idUsuario} y gato {idGato}");
                    return NotFound(new { message = "No existe una solicitud para este usuario y gato." });
                }

                return Ok(solicitud);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener solicitud para usuario {idUsuario} y gato {idGato}");
                return StatusCode(500, $"Error al obtener la solicitud: {ex.Message}");
            }
        }
    }

    public class CambiarEstadoDTO
    {
        public string Estado { get; set; } = "";
        public string? Comentario_Protectora { get; set; }
    }
}
