using Models;

namespace ProtectoraAPI.Services
{
    public interface IGatoService
    {
        Task<List<Gato>> GetAllAsync();
        Task<Gato?> GetByIdAsync(int id);
        Task AddAsync(Gato gato);
        Task UpdateAsync(Gato gato);
        Task DeleteAsync(int id);
    }
}
