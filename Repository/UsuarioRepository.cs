using Microsoft.Data.SqlClient;
using Models;
using BCrypt.Net; // Añadido para hasheo

namespace ProtectoraAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            var usuarios = new List<Usuario>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Usuario";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var usuario = new Usuario
                            {
                                Id_Usuario = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Contraseña = reader.GetString(3),
                                Email = reader.GetString(4),
                                Fecha_Registro = reader.GetDateTime(5),
                                Rol = reader.GetString(6),
                                Activo = reader.GetBoolean(7)
                            };

                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            Usuario? usuario = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Usuario WHERE Id_Usuario = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            usuario = new Usuario
                            {
                                Id_Usuario = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Contraseña = reader.GetString(3),
                                Email = reader.GetString(4),
                                Fecha_Registro = reader.GetDateTime(5),
                                Rol = reader.GetString(6),
                                Activo = reader.GetBoolean(7)
                            };
                        }
                    }
                }
            }
            return usuario;
        }

        public async Task AddAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Hashear la contraseña antes de guardar
                usuario.Contraseña = BCrypt.Net.BCrypt.HashPassword(usuario.Contraseña);

                string query = "INSERT INTO Usuario (Nombre, Apellido, Contraseña, Email, Fecha_Registro, Rol, Activo) VALUES (@Nombre, @Apellido, @Contraseña, @Email, @Fecha_Registro, @Rol, @Activo)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.Parameters.AddWithValue("@Fecha_Registro", usuario.Fecha_Registro);
                    command.Parameters.AddWithValue("@Rol", usuario.Rol);
                    command.Parameters.AddWithValue("@Activo", usuario.Activo);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Usuario WHERE Id_Usuario = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"UPDATE Usuario SET 
                                Nombre = @Nombre,
                                Apellido = @Apellido,
                                Contraseña = @Contraseña,
                                Email = @Email,
                                Fecha_Registro = @Fecha_Registro,
                                Rol = @Rol,
                                Activo = @Activo
                                WHERE Id_Usuario = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    command.Parameters.AddWithValue("@Email", usuario.Email);
                    command.Parameters.AddWithValue("@Fecha_Registro", usuario.Fecha_Registro);
                    command.Parameters.AddWithValue("@Rol", usuario.Rol);
                    command.Parameters.AddWithValue("@Activo", usuario.Activo);
                    command.Parameters.AddWithValue("@Id", usuario.Id_Usuario);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Usuario?> GetByEmailAndPasswordAsync(string email, string password)
        {
            Usuario? usuario = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Usuario WHERE Email = @Email";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            usuario = new Usuario
                            {
                                Id_Usuario = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Apellido = reader.GetString(2),
                                Contraseña = reader.GetString(3),
                                Email = reader.GetString(4),
                                Fecha_Registro = reader.GetDateTime(5),
                                Rol = reader.GetString(6),
                                Activo = reader.GetBoolean(7)
                            };
                        }
                    }
                }
            }

            if (usuario != null)
            {
                bool esValida = false;

                try
                {
                    // Intentamos verificar como hash
                    esValida = BCrypt.Net.BCrypt.Verify(password, usuario.Contraseña);
                }
                catch
                {
                    // Si falla (por no ser un hash), comparamos directamente
                    esValida = usuario.Contraseña == password;
                }

                if (esValida)
                {
                    usuario.Contraseña = ""; // Ocultamos por seguridad
                    return usuario;
                }
            }
            return null;
        }

        public async Task<bool> ActualizarContraseñaAsync(int idUsuario, string nuevaContraseña)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Hashear la nueva contraseña
                string hash = BCrypt.Net.BCrypt.HashPassword(nuevaContraseña);

                string query = "UPDATE Usuario SET Contraseña = @NuevaContraseña WHERE Id_Usuario = @IdUsuario";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NuevaContraseña", hash);
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
