using Models;

namespace ProtectoraAPI.Services
{
    public interface ICatherineService
    {
        Task<Catherine> ProcesarAsync(string mensaje);
    }
}
