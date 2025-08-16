using Models;
using ProtectoraAPI.Repositories;

namespace ProtectoraAPI.Services
{
    public class ProtectoraService : IProtectoraService
    {
        private readonly IProtectoraRepository _repository;

        public ProtectoraService(IProtectoraRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Protectora>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Protectora?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(Protectora protectora) => _repository.AddAsync(protectora);

        public Task UpdateAsync(Protectora protectora) => _repository.UpdateAsync(protectora);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
