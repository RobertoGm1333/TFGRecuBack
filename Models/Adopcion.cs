using System;

namespace Models
{
    public class Adopcion
    {
        public int Id_Adopcion { get; set; }
        public int Id_Protectora { get; set; }
        public int Id_Gato { get; set; }
        public DateTime Fecha_Adopcion { get; set; }
        public bool OrigenWeb { get; set; }
        public string? Telefono_Adoptante { get; set; }
        public string? Observaciones { get; set; }
    }

    public class AdopcionListadoDTO
    {
        public int Id_Gato { get; set; }
        public int Id_Protectora { get; set; }
        public DateTime Fecha { get; set; }
        public bool OrigenWeb { get; set; }
        public string? Imagen_Gato { get; set; }
        public string? Telefono_Adoptante { get; set; }
    }

    public class SerieMesDTO
    {
        public string MesYYYYMM { get; set; } = "";
        public int Total { get; set; }
    }

    public class SerieMesProtectoraDTO
    {
        public string MesYYYYMM { get; set; } = "";
        public int Id_Protectora { get; set; }
        public string Nombre_Protectora { get; set; } = "";
        public int Total { get; set; }
    }
}
