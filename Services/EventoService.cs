using Models;
using ProtectoraAPI.Repositories;

namespace ProtectoraAPI.Services
{
    public class EventoService : IEventoService
    {
        private readonly IEventoRepository _repository;

        public EventoService(IEventoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Evento>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Evento?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task AddAsync(Evento evento) => _repository.AddAsync(evento);

        public Task UpdateAsync(Evento evento) => _repository.UpdateAsync(evento);

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);

        public Task<IEnumerable<Evento>> ObtenerPorProtectoraAsync(int idProtectora) =>
            _repository.ObtenerPorProtectoraAsync(idProtectora);
    }
}
