using Models;
using ProtectoraAPI.Repositories;

namespace ProtectoraAPI.Services
{
    public class GatoService : IGatoService
    {
        private readonly IGatoRepository _repository;

        public GatoService(IGatoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Gato>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Gato?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(Gato gato) => _repository.AddAsync(gato);

        public Task UpdateAsync(Gato gato) => _repository.UpdateAsync(gato);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
