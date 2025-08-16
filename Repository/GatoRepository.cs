using Microsoft.Data.SqlClient;
using Models;

namespace ProtectoraAPI.Repositories
{
    public class GatoRepository : IGatoRepository
    {
        private readonly string _connectionString;

        public GatoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Gato>> GetAllAsync()
        {
            var gatos = new List<Gato>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Gato";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var gato = new Gato
                            {
                                Id_Gato = reader.GetInt32(0),
                                Id_Protectora = reader.GetInt32(1),
                                Nombre_Gato = reader.GetString(2),
                                Raza = reader.GetString(3),
                                Edad = reader.GetInt32(4),
                                Esterilizado = reader.GetBoolean(5),
                                Sexo = reader.GetString(6),
                                Descripcion_Gato = reader.GetString(7),
                                Descripcion_Gato_En = reader.GetString(8),
                                Imagen_Gato = reader.GetString(9),
                                Visible = reader.GetBoolean(10)
                            };

                            gatos.Add(gato);
                        }
                    }
                }
            }
            return gatos;
        }

        public async Task<Gato?> GetByIdAsync(int id)
        {
            Gato? gato = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Gato WHERE Id_Gato = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            gato = new Gato
                            {
                                Id_Gato = reader.GetInt32(0),
                                Id_Protectora = reader.GetInt32(1),
                                Nombre_Gato = reader.GetString(2),
                                Raza = reader.GetString(3),
                                Edad = reader.GetInt32(4),
                                Esterilizado = reader.GetBoolean(5),
                                Sexo = reader.GetString(6),
                                Descripcion_Gato = reader.GetString(7),
                                Descripcion_Gato_En = reader.GetString(8),
                                Imagen_Gato = reader.GetString(9),
                                Visible = reader.GetBoolean(10)
                            };
                        }
                    }
                }
            }
            return gato;
        }

        public async Task AddAsync(Gato gato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    INSERT INTO Gato (Id_Protectora, Nombre_Gato, Raza, Edad, Esterilizado, Sexo, Descripcion_Gato, Descripcion_Gato_En, Imagen_Gato, Visible)
                    OUTPUT INSERTED.Id_Gato
                    VALUES (@Id_Protectora, @Nombre_Gato, @Raza, @Edad, @Esterilizado, @Sexo, @Descripcion_Gato, @Descripcion_Gato_En, @Imagen_Gato, @Visible)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Protectora", gato.Id_Protectora);
                    command.Parameters.AddWithValue("@Nombre_Gato", gato.Nombre_Gato);
                    command.Parameters.AddWithValue("@Raza", gato.Raza);
                    command.Parameters.AddWithValue("@Edad", gato.Edad);
                    command.Parameters.AddWithValue("@Esterilizado", gato.Esterilizado);
                    command.Parameters.AddWithValue("@Sexo", gato.Sexo);
                    command.Parameters.AddWithValue("@Descripcion_Gato", gato.Descripcion_Gato);
                    command.Parameters.AddWithValue("@Descripcion_Gato_En", gato.Descripcion_Gato_En);
                    command.Parameters.AddWithValue("@Imagen_Gato", gato.Imagen_Gato);
                    command.Parameters.AddWithValue("@Visible", gato.Visible);

                    // Recupera el ID generado automáticamente
                    var idGenerado = await command.ExecuteScalarAsync();
                    if (idGenerado != null)
                    {
                        gato.Id_Gato = Convert.ToInt32(idGenerado);
                    }
                }
            }
        }

        public async Task UpdateAsync(Gato gato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Gato SET Id_Protectora = @Id_Protectora, Nombre_Gato = @Nombre_Gato, Raza = @Raza, Edad = @Edad, Esterilizado = @Esterilizado, Sexo = @Sexo, Descripcion_Gato = @Descripcion_Gato, Descripcion_Gato_En = @Descripcion_Gato_En, Imagen_Gato = @Imagen_Gato, Visible = @Visible WHERE Id_Gato = @Id_Gato";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Gato", gato.Id_Gato);
                    command.Parameters.AddWithValue("@Id_Protectora", gato.Id_Protectora);
                    command.Parameters.AddWithValue("@Nombre_Gato", gato.Nombre_Gato);
                    command.Parameters.AddWithValue("@Raza", gato.Raza);
                    command.Parameters.AddWithValue("@Edad", gato.Edad);
                    command.Parameters.AddWithValue("@Esterilizado", gato.Esterilizado);
                    command.Parameters.AddWithValue("@Sexo", gato.Sexo);
                    command.Parameters.AddWithValue("@Descripcion_Gato", gato.Descripcion_Gato);
                    command.Parameters.AddWithValue("@Descripcion_Gato_En", gato.Descripcion_Gato_En);
                    command.Parameters.AddWithValue("@Imagen_Gato", gato.Imagen_Gato);
                    command.Parameters.AddWithValue("@Visible", gato.Visible);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Gato WHERE Id_Gato = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<Gato>> ObtenerPorProtectoraAsync(int idProtectora)
        {
            var gatos = new List<Gato>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Gato WHERE Id_Protectora = @IdProtectora";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdProtectora", idProtectora);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var gato = new Gato
                            {
                                Id_Gato = reader.GetInt32(0),
                                Id_Protectora = reader.GetInt32(1),
                                Nombre_Gato = reader.GetString(2),
                                Raza = reader.GetString(3),
                                Edad = reader.GetInt32(4),
                                Esterilizado = reader.GetBoolean(5),
                                Sexo = reader.GetString(6),
                                Descripcion_Gato = reader.GetString(7),
                                Descripcion_Gato_En = reader.GetString(8),
                                Imagen_Gato = reader.GetString(9),
                                Visible = reader.GetBoolean(10)
                            };

                            gatos.Add(gato);
                        }
                    }
                }
            }

            return gatos;
        }
    }
}
