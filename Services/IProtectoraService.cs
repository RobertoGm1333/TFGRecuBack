using Models;

namespace ProtectoraAPI.Services
{
    public interface IProtectoraService
    {
        Task<List<Protectora>> GetAllAsync();
        Task<Protectora?> GetByIdAsync(int id);
        Task AddAsync(Protectora protectora);
        Task UpdateAsync(Protectora protectora);
        Task DeleteAsync(int id);
    }
}
