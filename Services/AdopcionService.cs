using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using ProtectoraAPI.Repositories; // Asegúrate de que el namespace coincide con tu IAdopcionRepository

namespace ProtectoraAPI.Services
{
    /// <summary>
    /// Implementación del servicio de Adopciones.
    /// Envuelve al repositorio y centraliza validaciones/errores.
    /// </summary>
    public class AdopcionService : IAdopcionService
    {
        private readonly IAdopcionRepository _repo;

        public AdopcionService(IAdopcionRepository repo)
        {
            _repo = repo;
        }

        // =========================
        // CRUD
        // =========================
        public async Task<IEnumerable<Adopcion>> GetAllAsync()
        {
            try
            {
                return await _repo.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error obteniendo las adopciones.", ex);
            }
        }

        public async Task<Adopcion?> GetByIdAsync(int id)
        {
            try
            {
                return await _repo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error obteniendo la adopción con id {id}.", ex);
            }
        }

        public async Task<int> CreateAsync(Adopcion dto)
        {
            try
            {
                // Validaciones mínimas (puedes ampliar)
                if (dto.Id_Gato <= 0) throw new ArgumentException("Id_Gato es obligatorio.");
                if (dto.Id_Protectora <= 0) throw new ArgumentException("Id_Protectora es obligatorio.");

                return await _repo.CreateAsync(dto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error creando la adopción.", ex);
            }
        }

        public async Task<bool> UpdateAsync(Adopcion dto)
        {
            try
            {
                if (dto.Id_Adopcion <= 0) throw new ArgumentException("Id_Adopcion inválido.");
                if (dto.Id_Gato <= 0) throw new ArgumentException("Id_Gato es obligatorio.");
                if (dto.Id_Protectora <= 0) throw new ArgumentException("Id_Protectora es obligatorio.");

                return await _repo.UpdateAsync(dto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error actualizando la adopción {dto.Id_Adopcion}.", ex);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _repo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error eliminando la adopción {id}.", ex);
            }
        }

        // =========================
        // Consultas para UI
        // =========================
        public async Task<IEnumerable<AdopcionListadoDTO>> GetListadoGeneralAsync()
        {
            try
            {
                return await _repo.GetListadoGeneralAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error obteniendo el listado de adopciones.", ex);
            }
        }

        public async Task<IEnumerable<SerieMesDTO>> GetSerieGeneralUltimos12MesesAsync()
        {
            try
            {
                return await _repo.GetSerieGeneralUltimos12MesesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error obteniendo la serie general de adopciones.", ex);
            }
        }

        public async Task<IEnumerable<SerieMesProtectoraDTO>> GetSeriePorProtectoraUltimos12MesesAsync()
        {
            try
            {
                return await _repo.GetSeriePorProtectoraUltimos12MesesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error obteniendo la serie por protectora de adopciones.", ex);
            }
        }
    }
}
