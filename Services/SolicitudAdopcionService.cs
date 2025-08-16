using Models;
using ProtectoraAPI.Repositories;
using System.Linq;

namespace ProtectoraAPI.Services
{
    public class SolicitudAdopcionService : ISolicitudAdopcionService
    {
        private readonly ISolicitudAdopcionRepository _repository;

        public SolicitudAdopcionService(ISolicitudAdopcionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SolicitudAdopcion>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SolicitudAdopcion?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<SolicitudAdopcion>> GetByUsuarioIdAsync(int idUsuario)
        {
            return await _repository.GetByUsuarioIdAsync(idUsuario);
        }

        public async Task<List<SolicitudAdopcion>> GetByGatoIdAsync(int idGato)
        {
            return await _repository.GetByGatoIdAsync(idGato);
        }

        public async Task AddAsync(SolicitudAdopcion solicitud)
        {
            await _repository.AddAsync(solicitud);
        }

        public async Task UpdateAsync(SolicitudAdopcion solicitud)
        {
            await _repository.UpdateAsync(solicitud);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task UpdateEstadoAsync(int id, string nuevoEstado, string? comentarioProtectora)
        {
            await _repository.UpdateEstadoAsync(id, nuevoEstado, comentarioProtectora);
        }

        public async Task<List<SolicitudAdopcion>> GetByProtectoraIdAsync(int idProtectora)
        {
            return await _repository.GetByProtectoraIdAsync(idProtectora);
        }

        public async Task<List<object>> GetSolicitudesByProtectoraAsync(int idProtectora)
        {
            return await _repository.GetSolicitudesByProtectoraAsync(idProtectora);
        }

        public async Task<SolicitudAdopcion?> GetByUsuarioAndGatoIdAsync(int idUsuario, int idGato)
        {
            var solicitudes = await _repository.GetByUsuarioIdAsync(idUsuario);
            return solicitudes.FirstOrDefault(s => s.Id_Gato == idGato);
        }
    }
}
