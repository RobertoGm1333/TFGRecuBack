using System.Collections.Generic;

namespace Models
{
    public class Catherine
    {
        public string Pregunta { get; set; } = string.Empty;
        public string Respuesta { get; set; } = string.Empty;
        public List<Gato> Resultados { get; set; } = new();
    }
}
