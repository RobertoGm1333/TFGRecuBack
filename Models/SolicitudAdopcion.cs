using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Models
{
    public class SolicitudAdopcion
    {
        public int Id_Solicitud { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Gato { get; set; }
        public DateTime Fecha_Solicitud { get; set; }
        public string Estado { get; set; } = "";
        public string? NombreCompleto { get; set; }
        public int? Edad { get; set; }
        public string? Direccion { get; set; }
        public string? DNI { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? TipoVivienda { get; set; }
        public string? PropiedadAlquiler { get; set; }
        public bool? PermiteAnimales { get; set; }
        public int? NumeroPersonas { get; set; }
        public bool? HayNinos { get; set; }
        public string? EdadesNinos { get; set; }
        public bool? ExperienciaGatos { get; set; }
        public bool? TieneOtrosAnimales { get; set; }
        public bool? CortarUnas { get; set; }
        public bool? AnimalesVacunadosEsterilizados { get; set; }
        public string? HistorialMascotas { get; set; }
        public string? MotivacionAdopcion { get; set; }
        public string? ProblemasComportamiento { get; set; }
        public string? EnfermedadesCostosas { get; set; }
        public string? Vacaciones { get; set; }
        public bool? SeguimientoPostAdopcion { get; set; }
        public bool? VisitaHogar { get; set; }
        public string? Comentario_Protectora { get; set; }
        public int? Id_Protectora { get; set; }

        // Estos campos no están en la base de datos pero pueden venir en solicitudes JSON
        [JsonIgnore]
        public string? Fotos_Hogar { get; set; }
        [JsonIgnore]
        public string? Fotos_DNI { get; set; }

        public SolicitudAdopcion() { }

        public SolicitudAdopcion(int id_Usuario, int id_Gato, string comentario_Protectora)
        {
            Id_Usuario = id_Usuario;
            Id_Gato = id_Gato;
            Comentario_Protectora = comentario_Protectora;
        }

        public void ValidarDatos()
        {
            var errores = new List<string>();

            if (Id_Usuario <= 0)
                errores.Add("ID de usuario inválido");
            if (Id_Gato <= 0)
                errores.Add("ID de gato inválido");
            if (string.IsNullOrWhiteSpace(NombreCompleto))
                errores.Add("El nombre completo es requerido");
            if (string.IsNullOrWhiteSpace(DNI))
                errores.Add("El DNI es requerido");
            if (string.IsNullOrWhiteSpace(Email))
                errores.Add("El email es requerido");
            if (string.IsNullOrWhiteSpace(Telefono))
                errores.Add("El teléfono es requerido");
            if (Edad.HasValue && (Edad.Value < 18 || Edad.Value > 120))
                errores.Add("La edad debe estar entre 18 y 120 años");
            if (NumeroPersonas.HasValue && NumeroPersonas.Value <= 0)
                errores.Add("El número de personas debe ser mayor que 0");
            if (!TipoVivienda?.Trim().Any() ?? true)
                errores.Add("El tipo de vivienda es requerido");
            if (!PropiedadAlquiler?.Trim().Any() ?? true)
                errores.Add("Debe especificar si la vivienda es propia o alquilada");
            if (!PermiteAnimales.HasValue)
                errores.Add("Debe especificar si se permiten animales");
            if (!NumeroPersonas.HasValue)
                errores.Add("El número de personas es requerido");
            if (!ExperienciaGatos.HasValue)
                errores.Add("Debe especificar si tiene experiencia con gatos");
            if (!TieneOtrosAnimales.HasValue)
                errores.Add("Debe especificar si tiene otros animales");
            if (!CortarUnas.HasValue)
                errores.Add("Debe especificar si sabe cortar uñas");
            if (!AnimalesVacunadosEsterilizados.HasValue)
                errores.Add("Debe especificar si los animales están vacunados/esterilizados");
            if (string.IsNullOrWhiteSpace(HistorialMascotas))
                errores.Add("El historial de mascotas es requerido");
            if (string.IsNullOrWhiteSpace(MotivacionAdopcion))
                errores.Add("La motivación para adoptar es requerida");
            if (string.IsNullOrWhiteSpace(ProblemasComportamiento))
                errores.Add("La respuesta sobre problemas de comportamiento es requerida");
            if (string.IsNullOrWhiteSpace(EnfermedadesCostosas))
                errores.Add("La respuesta sobre enfermedades costosas es requerida");
            if (string.IsNullOrWhiteSpace(Vacaciones))
                errores.Add("El plan para vacaciones es requerido");
            if (!SeguimientoPostAdopcion.HasValue)
                errores.Add("Debe aceptar el seguimiento post-adopción");
            if (!VisitaHogar.HasValue)
                errores.Add("Debe aceptar la visita al hogar");

            if (errores.Any())
                throw new ArgumentException(string.Join("\n", errores));
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Solicitud #{Id_Solicitud} - Usuario {Id_Usuario} quiere adoptar al gato {Id_Gato}. Estado: {Estado}");
        }
    }
}
