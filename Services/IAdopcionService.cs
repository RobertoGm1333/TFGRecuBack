using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace ProtectoraAPI.Services
{
    /// <summary>
    /// Contrato del servicio de Adopciones. 
    /// Debe cubrir CRUD + consultas para listado admin y series de la gráfica.
    /// </summary>
    public interface IAdopcionService
    {
        // CRUD básico
        Task<IEnumerable<Adopcion>> GetAllAsync();
        Task<Adopcion?> GetByIdAsync(int id);
        Task<int> CreateAsync(Adopcion dto);
        Task<bool> UpdateAsync(Adopcion dto);
        Task<bool> DeleteAsync(int id);

        // Consultas de UI (admin/listado) y gráfica
        Task<IEnumerable<AdopcionListadoDTO>> GetListadoGeneralAsync();
        Task<IEnumerable<SerieMesDTO>> GetSerieGeneralUltimos12MesesAsync();
        Task<IEnumerable<SerieMesProtectoraDTO>> GetSeriePorProtectoraUltimos12MesesAsync();
    }
}
