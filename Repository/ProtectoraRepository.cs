using Microsoft.Data.SqlClient;
using Models;

namespace ProtectoraAPI.Repositories
{
    public class ProtectoraRepository : IProtectoraRepository
    {
        private readonly string _connectionString;

        public ProtectoraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Protectora>> GetAllAsync()
        {
            var protectoras = new List<Protectora>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Protectora";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var protectora = new Protectora
                            {
                                Id_Protectora = reader.GetInt32(0),
                                Nombre_Protectora = reader.GetString(1),
                                Direccion = reader.GetString(2),
                                Ubicacion = reader.GetString(3),
                                Correo_Protectora = reader.GetString(4),
                                Telefono_Protectora = reader.GetString(5),
                                Pagina_Web = reader.GetString(6),
                                Imagen_Protectora = reader.GetString(7),
                                Descripcion_Protectora = reader.GetString(8),
                                Descripcion_Protectora_En = reader.IsDBNull(9) ? null : reader.GetString(9),
                                Id_Usuario = reader.GetInt32(10)
                            };

                            protectoras.Add(protectora);
                        }
                    }
                }
            }
            return protectoras;
        }

        public async Task<Protectora?> GetByIdAsync(int id)
        {
            Protectora? protectora = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Protectora WHERE Id_Protectora = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            protectora = new Protectora
                            {
                                Id_Protectora = reader.GetInt32(0),
                                Nombre_Protectora = reader.GetString(1),
                                Direccion = reader.GetString(2),
                                Ubicacion = reader.GetString(3),
                                Correo_Protectora = reader.GetString(4),
                                Telefono_Protectora = reader.GetString(5),
                                Pagina_Web = reader.GetString(6),
                                Imagen_Protectora = reader.GetString(7),
                                Descripcion_Protectora = reader.GetString(8),
                                Descripcion_Protectora_En = reader.IsDBNull(9) ? null : reader.GetString(9),
                                Id_Usuario = reader.GetInt32(10)
                            };
                        }
                    }
                }
            }
            return protectora;
        }

        public async Task AddAsync(Protectora protectora)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    INSERT INTO Protectora (Nombre_Protectora, Direccion, Correo_Protectora, Telefono_Protectora, Pagina_Web, Imagen_Protectora, Ubicacion, Descripcion_Protectora, Descripcion_Protectora_En, Id_Usuario)
                    OUTPUT INSERTED.Id_Protectora
                    VALUES (@Nombre_Protectora, @Direccion, @Correo_Protectora, @Telefono_Protectora, @Pagina_Web, @Imagen_Protectora, @Ubicacion, @Descripcion_Protectora, @Descripcion_Protectora_En, @Id_Usuario)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre_Protectora", protectora.Nombre_Protectora);
                    command.Parameters.AddWithValue("@Direccion", protectora.Direccion);
                    command.Parameters.AddWithValue("@Correo_Protectora", protectora.Correo_Protectora);
                    command.Parameters.AddWithValue("@Telefono_Protectora", protectora.Telefono_Protectora);
                    command.Parameters.AddWithValue("@Pagina_Web", protectora.Pagina_Web);
                    command.Parameters.AddWithValue("@Imagen_Protectora", protectora.Imagen_Protectora);
                    command.Parameters.AddWithValue("@Ubicacion", protectora.Ubicacion);
                    command.Parameters.AddWithValue("@Descripcion_Protectora", protectora.Descripcion_Protectora);
                    command.Parameters.AddWithValue("@Descripcion_Protectora_En", protectora.Descripcion_Protectora_En);
                    command.Parameters.AddWithValue("@Id_Usuario", protectora.Id_Usuario);

                    var idGenerado = await command.ExecuteScalarAsync();
                    if (idGenerado != null)
                    {
                        protectora.Id_Protectora = Convert.ToInt32(idGenerado);
                    }
                }
            }
        }

        public async Task UpdateAsync(Protectora protectora)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Protectora SET Nombre_Protectora = @Nombre_Protectora, Direccion = @Direccion, Correo_Protectora = @Correo_Protectora, Telefono_Protectora = @Telefono_Protectora, Pagina_Web = @Pagina_Web, Imagen_Protectora = @Imagen_Protectora, Ubicacion = @Ubicacion, Descripcion_Protectora = @Descripcion_Protectora, Descripcion_Protectora_En = @Descripcion_Protectora_En, Id_Usuario = @Id_Usuario WHERE Id_Protectora = @Id_Protectora";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Protectora", protectora.Id_Protectora);
                    command.Parameters.AddWithValue("@Nombre_Protectora", protectora.Nombre_Protectora);
                    command.Parameters.AddWithValue("@Direccion", protectora.Direccion);
                    command.Parameters.AddWithValue("@Correo_Protectora", protectora.Correo_Protectora);
                    command.Parameters.AddWithValue("@Telefono_Protectora", protectora.Telefono_Protectora);
                    command.Parameters.AddWithValue("@Pagina_Web", protectora.Pagina_Web);
                    command.Parameters.AddWithValue("@Imagen_Protectora", protectora.Imagen_Protectora);
                    command.Parameters.AddWithValue("@Ubicacion", protectora.Ubicacion);
                    command.Parameters.AddWithValue("@Descripcion_Protectora", protectora.Descripcion_Protectora);
                    command.Parameters.AddWithValue("@Descripcion_Protectora_En", protectora.Descripcion_Protectora_En);
                    command.Parameters.AddWithValue("@Id_Usuario", protectora.Id_Usuario);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Protectora WHERE Id_Protectora = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Protectora?> GetByUsuarioIdAsync(int idUsuario)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            string query = "SELECT * FROM Protectora WHERE Id_Usuario = @idUsuario";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@idUsuario", idUsuario);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Protectora
                {
                    Id_Protectora = reader.GetInt32(0),
                    Nombre_Protectora = reader.GetString(1),
                    Direccion = reader.GetString(2),
                    Ubicacion = reader.GetString(3),
                    Correo_Protectora = reader.GetString(4),
                    Telefono_Protectora = reader.GetString(5),
                    Pagina_Web = reader.GetString(6),
                    Imagen_Protectora = reader.GetString(7),
                    Descripcion_Protectora = reader.GetString(8),
                    Descripcion_Protectora_En = reader.IsDBNull(9) ? null : reader.GetString(9),
                    Id_Usuario = reader.GetInt32(10)
                };
            }

            return null;
        }
    }
}
