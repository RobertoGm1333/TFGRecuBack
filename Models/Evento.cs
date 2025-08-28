using System;

namespace Models
{
    public class Evento
    {
        public int Id_Evento { get; set; }
        public int Id_Protectora { get; set; }

        public string Nombre_Evento { get; set; } = "";
        public string Lugar { get; set; } = "";
        public DateTime Fecha_Evento { get; set; }   
        public TimeSpan Hora_Evento { get; set; }    

        public string Descripcion_Evento { get; set; } = "";
        public string? EnclaceMaps { get; set; }    
        public string? Foto_Evento { get; set; }     
    }
}
