using Models;                         // Catherine vive en Models
using ProtectoraAPI.Repositories;

namespace ProtectoraAPI.Services
{
    public class CatherineService : ICatherineService
    {
        private readonly ICatherineRepository _repo;

        public CatherineService(ICatherineRepository repo)
        {
            _repo = repo;
        }

        public Task<Catherine> ProcesarAsync(string mensaje)
            => _repo.ProcesarAsync(mensaje);
    }
}
