using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProtectoraAPI.Repositories;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace ProtectoraAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class GatoController : ControllerBase
   {
       private readonly IGatoRepository _repository;
       private readonly IWebHostEnvironment _env;

       public GatoController(IGatoRepository repository, IWebHostEnvironment env)
       {
           _repository = repository;
           _env = env;
       }

       [HttpGet]
       public async Task<ActionResult<List<Gato>>> GetGatos()
       {
           var gatos = await _repository.GetAllAsync();
           return Ok(gatos);
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<Gato>> GetGato(int id)
       {
           var gato = await _repository.GetByIdAsync(id);
           if (gato == null)
           {
               return NotFound();
           }
           return Ok(gato);
       }

       // ===== POST: crear gato con imagen (multipart/form-data) =====
       [HttpPost]
       [DisableRequestSizeLimit]
       [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
       public async Task<ActionResult<Gato>> CreateGato([FromForm] CrearGatoRequest req)
       {
           if (req == null) return BadRequest("Formulario vacío.");
           if (string.IsNullOrWhiteSpace(req.Nombre_Gato)) return BadRequest("Nombre_Gato es obligatorio.");

           string? imagenUrl = null;

           if (req.Imagen != null && req.Imagen.Length > 0)
           {
               // Guardar SIEMPRE en wwwroot/uploads/gatos del proyecto que está corriendo
               var contentRoot = _env.ContentRootPath;
               var webRoot = _env.WebRootPath ?? Path.Combine(contentRoot, "wwwroot");
               var uploads = Path.Combine(webRoot, "uploads", "gatos");
               Directory.CreateDirectory(uploads);

               var extension = Path.GetExtension(req.Imagen.FileName);
               var fileName = $"{Guid.NewGuid():N}{extension}";
               var fullPath = Path.Combine(uploads, fileName);

               using (var stream = System.IO.File.Create(fullPath))
               {
                   await req.Imagen.CopyToAsync(stream);
               }

               // URL ABSOLUTA para que el front la use directamente
               var scheme = Request.Scheme;      // http o https
               var host = Request.Host.Value;    // p.ej. localhost:5167
               imagenUrl = $"{scheme}://{host}/uploads/gatos/{fileName}";
           }

           var gato = new Gato
           {
               Nombre_Gato = req.Nombre_Gato,
               Raza = req.Raza,
               Edad = req.Edad,
               Sexo = req.Sexo,
               Esterilizado = req.Esterilizado,
               Descripcion_Gato = req.Descripcion_Gato,
               Id_Protectora = req.Id_Protectora,
               Visible = req.Visible,
               Imagen_Gato = imagenUrl
           };

           await _repository.AddAsync(gato);
           return CreatedAtAction(nameof(GetGato), new { id = gato.Id_Gato }, gato);
       }

       [HttpPut("{id}")]
       public async Task<IActionResult> UpdateGato(int id, [FromBody] Gato updatedGato)
       {
           var existingGato = await _repository.GetByIdAsync(id);
           if (existingGato == null)
           {
               return NotFound();
           }

           existingGato.Nombre_Gato = updatedGato.Nombre_Gato;
           existingGato.Raza = updatedGato.Raza;
           existingGato.Edad = updatedGato.Edad;
           existingGato.Esterilizado = updatedGato.Esterilizado;
           existingGato.Sexo = updatedGato.Sexo;
           existingGato.Descripcion_Gato = updatedGato.Descripcion_Gato;
           existingGato.Descripcion_Gato_En = updatedGato.Descripcion_Gato_En;
           existingGato.Imagen_Gato = updatedGato.Imagen_Gato;
           existingGato.Id_Protectora = updatedGato.Id_Protectora;
           existingGato.Visible = updatedGato.Visible;

           await _repository.UpdateAsync(existingGato);
           return NoContent();
       }

       [HttpDelete("{id}")]
       public async Task<IActionResult> DeleteGato(int id)
       {
           var gato = await _repository.GetByIdAsync(id);
           if (gato == null)
           {
               return NotFound();
           }
           await _repository.DeleteAsync(id);
           return NoContent();
       }

       [HttpGet("protectora/{idProtectora}")]
       public async Task<IActionResult> GetGatosPorProtectora(int idProtectora)
       {
           var gatos = await _repository.ObtenerPorProtectoraAsync(idProtectora);

           if (gatos == null || !gatos.Any())
               return NotFound("No se encontraron gatos para esta protectora.");

           return Ok(gatos);
       }
   }

   // DTO exclusivo para crear (multipart/form-data)
   public class CrearGatoRequest
   {
       public string Nombre_Gato { get; set; }
       public string Raza { get; set; }
       public int Edad { get; set; }
       public string Sexo { get; set; }
       public bool Esterilizado { get; set; }
       public string? Descripcion_Gato { get; set; }
       public int Id_Protectora { get; set; }
       public bool Visible { get; set; }
       public IFormFile? Imagen { get; set; }
   }
}
