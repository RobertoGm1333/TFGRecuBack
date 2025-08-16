using Models;

namespace ProtectoraAPI.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
        Task<Usuario?> GetByEmailAndPasswordAsync(string email, string password);
        Task<bool> ActualizarContraseñaAsync(int idUsuario, string nuevaContraseña);
    }
}
