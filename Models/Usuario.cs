using System;

namespace Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string Contraseña { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime Fecha_Registro { get; set; } = DateTime.Now;
        public string Rol { get; set; } = "usuario";
        public bool Activo { get; set; } = true;

        public Usuario() { }

        public Usuario(string nombre, string apellido, string contraseña, string email, DateTime fecha_Registro, string rol, bool activo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Contraseña = contraseña;
            Email = email;
            Fecha_Registro = fecha_Registro;
            Rol = rol;
            Activo = activo;
        }

        public void MostrarDetalles()
        {
            Console.WriteLine($"Usuario: {Nombre} {Apellido}, Contraseña: {Contraseña}, Email: {Email}, Fecha del Registro: {Fecha_Registro}, Rol: {Rol}, Activo: {Activo}");
        }
    }
}
