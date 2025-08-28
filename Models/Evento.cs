using System;

namespace Models
{
    public class Evento
    {
        public int Id_Evento { get; set; }
        public int Id_Protectora { get; set; }

        public string Nombre_Evento { get; set; } = "";
        public string Lugar { get; set; } = "";
        public string? Direccion { get; set; }

        public DateTime Fecha { get; set; }   
        public TimeSpan Hora { get; set; }    
        public string? Descripcion { get; set; }
        public string? Enlace_Maps { get; set; }

        public bool Visible { get; set; } = true;
    }
}
