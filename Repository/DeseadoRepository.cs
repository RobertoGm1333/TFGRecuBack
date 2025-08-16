using Microsoft.Data.SqlClient;
using Models;

namespace ProtectoraAPI.Repositories
{
    public class DeseadoRepository : IDeseadoRepository
    {
        private readonly string _connectionString;

        public DeseadoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Deseado>> GetAllAsync()
        {
            var deseados = new List<Deseado>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Deseados";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var deseado = new Deseado
                            {
                                Id_Deseado = reader.GetInt32(0),
                                Id_Usuario = reader.GetInt32(1),
                                Id_Gato = reader.GetInt32(2),
                                Fecha_Deseado = reader.GetDateTime(3)
                            };

                            deseados.Add(deseado);
                        }
                    }
                }
            }
            return deseados;
        }

        public async Task<Deseado?> GetByIdAsync(int id)
        {
            Deseado? deseado = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Deseados WHERE Id_Deseado = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            deseado = new Deseado
                            {
                                Id_Deseado = reader.GetInt32(0),
                                Id_Usuario = reader.GetInt32(1),
                                Id_Gato = reader.GetInt32(2),
                                Fecha_Deseado = reader.GetDateTime(3)
                            };
                        }
                    }
                }
            }
            return deseado;
        }

        public async Task<IEnumerable<Deseado>> ObtenerDeseadosPorUsuarioAsync(int Id_Usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Deseados WHERE Id_Usuario = @Id_Usuario";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        List<Deseado> listaDeseados = new List<Deseado>();
                        while (await reader.ReadAsync())
                        {
                            listaDeseados.Add(new Deseado
                            {
                                Id_Deseado = reader.GetInt32(0),
                                Id_Usuario = reader.GetInt32(1),
                                Id_Gato = reader.GetInt32(2),
                                Fecha_Deseado = reader.GetDateTime(3)
                            });
                        }
                        return listaDeseados;
                    }
                }
            }
        }

        public async Task<Deseado> AddAsync(Deseado deseado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                    INSERT INTO Deseados (Id_Usuario, Id_Gato, Fecha_Deseado)
                    VALUES (@Id_Usuario, @Id_Gato, @Fecha_Deseado);
                    SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Usuario", deseado.Id_Usuario);
                    command.Parameters.AddWithValue("@Id_Gato", deseado.Id_Gato);
                    command.Parameters.AddWithValue("@Fecha_Deseado", deseado.Fecha_Deseado);

                    // Obtenemos el ID generado
                    var result = await command.ExecuteScalarAsync();
                    deseado.Id_Deseado = Convert.ToInt32(result);
                }
            }

            return deseado;
        }

        public async Task UpdateAsync(Deseado deseado)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Deseados SET Id_Usuario = @Id_Usuario, Id_Gato = @Id_Gato, Fecha_Deseado = @Fecha_Deseado WHERE Id_Deseado = @Id_Deseado";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Deseado", deseado.Id_Deseado);
                    command.Parameters.AddWithValue("@Id_Usuario", deseado.Id_Usuario);
                    command.Parameters.AddWithValue("@Id_Gato", deseado.Id_Gato);
                    command.Parameters.AddWithValue("@Fecha_Deseado", deseado.Fecha_Deseado);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Deseados WHERE Id_Deseado = @Id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
