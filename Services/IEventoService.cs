using Models;

namespace ProtectoraAPI.Services
{
    public interface IEventoService
    {
        Task<List<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);

        Task<IEnumerable<Evento>> ObtenerPorProtectoraAsync(int idProtectora);
    }
}
