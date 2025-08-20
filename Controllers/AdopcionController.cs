using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using ProtectoraAPI.Services;

namespace ProtectoraAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdopcionController : ControllerBase
    {
        private readonly IAdopcionService _svc;

        public AdopcionController(IAdopcionService svc)
        {
            _svc = svc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adopcion>>> GetAll()
        {
            var data = await _svc.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Adopcion>> Get(int id)
        {
            var item = await _svc.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Adopcion dto)
        {
            var id = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Adopcion dto)
        {
            if (id != dto.Id_Adopcion) return BadRequest("Id mismatch");
            var ok = await _svc.UpdateAsync(dto);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _svc.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }

        // Listado admin con imagen del gato vía JOIN
        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<AdopcionListadoDTO>>> ListadoGeneral()
        {
            var data = await _svc.GetListadoGeneralAsync();
            return Ok(data);
        }

        // Serie general (últimos 12 meses)
        [HttpGet("grafica/general")]
        public async Task<ActionResult<IEnumerable<SerieMesDTO>>> SerieGeneral()
        {
            var data = await _svc.GetSerieGeneralUltimos12MesesAsync();
            return Ok(data);
        }

        // Serie por protectora (últimos 12 meses)
        [HttpGet("grafica/por-protectora")]
        public async Task<ActionResult<IEnumerable<SerieMesProtectoraDTO>>> SeriePorProtectora()
        {
            var data = await _svc.GetSeriePorProtectoraUltimos12MesesAsync();
            return Ok(data);
        }
    }
}
