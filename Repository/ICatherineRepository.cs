using Models;

namespace ProtectoraAPI.Repositories
{
    public interface ICatherineRepository
    {
        // 100% sin filtros: lee TODOS los gatos de tu API, aplica reglas, y redacta con Ollama
        Task<Catherine> ProcesarAsync(string mensaje);
    }
}
