using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace ProtectoraAPI.Services
{
    public interface IAdopcionService
    {
        Task<IEnumerable<Adopcion>> GetAllAsync();
        Task<Adopcion?> GetByIdAsync(int id);
        Task<int> CreateAsync(Adopcion item);
        Task<bool> UpdateAsync(Adopcion item);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<AdopcionListadoDTO>> GetListadoGeneralAsync();
        Task<IEnumerable<SerieMesDTO>> GetSerieGeneralUltimos12MesesAsync();
        Task<IEnumerable<SerieMesProtectoraDTO>> GetSeriePorProtectoraUltimos12MesesAsync();
    }
}
