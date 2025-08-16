using Models;

namespace ProtectoraAPI.Repositories
{
    public interface IGatoRepository
    {
        Task<List<Gato>> GetAllAsync();
        Task<Gato?> GetByIdAsync(int id);
        Task AddAsync(Gato gato);
        Task UpdateAsync(Gato gato);
        Task DeleteAsync(int id);
        Task<IEnumerable<Gato>> ObtenerPorProtectoraAsync(int idProtectora);
    }
}
