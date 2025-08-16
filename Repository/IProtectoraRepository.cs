using Models;

namespace ProtectoraAPI.Repositories
{
    public interface IProtectoraRepository
    {
        Task<List<Protectora>> GetAllAsync();
        Task<Protectora?> GetByIdAsync(int id);
        Task AddAsync(Protectora protectora);
        Task UpdateAsync(Protectora protectora);
        Task DeleteAsync(int id);
        Task<Protectora?> GetByUsuarioIdAsync(int idUsuario);
    }
}
