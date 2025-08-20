using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using ProtectoraAPI.Repositories;

namespace ProtectoraAPI.Services
{
    public class AdopcionService : IAdopcionService
    {
        private readonly IAdopcionRepository _repo;

        public AdopcionService(IAdopcionRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Adopcion>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Adopcion?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<int> CreateAsync(Adopcion item) => _repo.CreateAsync(item);
        public Task<bool> UpdateAsync(Adopcion item) => _repo.UpdateAsync(item);
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);

        public Task<IEnumerable<AdopcionListadoDTO>> GetListadoGeneralAsync() => _repo.GetListadoGeneralAsync();
        public Task<IEnumerable<SerieMesDTO>> GetSerieGeneralUltimos12MesesAsync() => _repo.GetSerieGeneralUltimos12MesesAsync();
        public Task<IEnumerable<SerieMesProtectoraDTO>> GetSeriePorProtectoraUltimos12MesesAsync() => _repo.GetSeriePorProtectoraUltimos12MesesAsync();
    }
}
