using Models;
using ProtectoraAPI.Repositories;

namespace ProtectoraAPI.Services
{
    public class DeseadoService : IDeseadoService
    {
        private readonly IDeseadoRepository _repository;

        public DeseadoService(IDeseadoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Deseado>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Deseado?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(Deseado deseado) => _repository.AddAsync(deseado);

        public Task UpdateAsync(Deseado deseado) => _repository.UpdateAsync(deseado);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);

        public Task<IEnumerable<Deseado>> ObtenerDeseadosPorUsuarioAsync(int idUsuario)
            => _repository.ObtenerDeseadosPorUsuarioAsync(idUsuario);
    }
}
