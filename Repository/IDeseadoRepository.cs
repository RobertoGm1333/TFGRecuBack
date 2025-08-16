using Models;

namespace ProtectoraAPI.Repositories
{
    public interface IDeseadoRepository
    {
        Task<List<Deseado>> GetAllAsync();
        Task<Deseado?> GetByIdAsync(int id);
        Task<Deseado> AddAsync(Deseado deseado);
        Task UpdateAsync(Deseado deseado);
        Task DeleteAsync(int id);
        Task<IEnumerable<Deseado>> ObtenerDeseadosPorUsuarioAsync(int Id_Usuario);
    }
}
