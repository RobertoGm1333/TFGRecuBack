using Models;

namespace ProtectoraAPI.Services
{
    public interface ISolicitudAdopcionService
    {
        Task<List<SolicitudAdopcion>> GetAllAsync();
        Task<SolicitudAdopcion?> GetByIdAsync(int id);
        Task<List<SolicitudAdopcion>> GetByUsuarioIdAsync(int idUsuario);
        Task<List<SolicitudAdopcion>> GetByGatoIdAsync(int idGato);
        Task AddAsync(SolicitudAdopcion solicitud);
        Task UpdateAsync(SolicitudAdopcion solicitud);
        Task DeleteAsync(int id);
        Task UpdateEstadoAsync(int id, string nuevoEstado, string? comentarioProtectora);
        Task<List<SolicitudAdopcion>> GetByProtectoraIdAsync(int idProtectora);
        Task<List<object>> GetSolicitudesByProtectoraAsync(int idProtectora);
        Task<SolicitudAdopcion?> GetByUsuarioAndGatoIdAsync(int idUsuario, int idGato);
    }
}
