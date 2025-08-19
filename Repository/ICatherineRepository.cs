using Models;

namespace ProtectoraAPI.Repositories
{
    public interface ICatherineRepository
    {
        // 100% sin filtros: lee TODOS los gatos y TODAS las protectoras de tu API,
        // aplica reglas, fuzzy y contexto, y redacta la respuesta (con o sin Ollama).
        Task<Catherine> ProcesarAsync(string mensaje);
    }
}
