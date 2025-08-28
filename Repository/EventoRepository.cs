using Microsoft.Data.SqlClient;
using System.Data;
using Models;

namespace ProtectoraAPI.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly string _connectionString;
        private const string Table = "[dbo].[Eventos]";

        public EventoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Evento>> GetAllAsync()
        {
            var eventos = new List<Evento>();
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = $"SELECT * FROM {Table}";
            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                eventos.Add(Map(reader));

            return eventos;
        }

        public async Task<Evento?> GetByIdAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = $"SELECT * FROM {Table} WHERE Id_Evento = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow);
            if (!await reader.ReadAsync()) return null;

            return Map(reader);
        }

        public async Task AddAsync(Evento evento)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = $@"
INSERT INTO {Table}
    (Id_Protectora, Nombre_Evento, Lugar, Fecha_Evento, Hora_Evento, Descripcion_Evento, EnclaceMaps, Foto_Evento)
OUTPUT INSERTED.Id_Evento
VALUES
    (@Id_Protectora, @Nombre_Evento, @Lugar, @Fecha_Evento, @Hora_Evento, @Descripcion_Evento, @EnclaceMaps, @Foto_Evento);";

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id_Protectora", evento.Id_Protectora);
            command.Parameters.AddWithValue("@Nombre_Evento", evento.Nombre_Evento);
            command.Parameters.AddWithValue("@Lugar", evento.Lugar);
            command.Parameters.AddWithValue("@Fecha_Evento", evento.Fecha_Evento.Date);
            command.Parameters.Add("@Hora_Evento", SqlDbType.Time).Value = evento.Hora_Evento;
            command.Parameters.AddWithValue("@Descripcion_Evento", evento.Descripcion_Evento);
            command.Parameters.AddWithValue("@EnclaceMaps", (object?)evento.EnclaceMaps ?? DBNull.Value);
            command.Parameters.AddWithValue("@Foto_Evento", (object?)evento.Foto_Evento ?? DBNull.Value);

            var idGenerado = await command.ExecuteScalarAsync();
            if (idGenerado != null)
                evento.Id_Evento = Convert.ToInt32(idGenerado);
        }

        public async Task UpdateAsync(Evento evento)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = $@"
UPDATE {Table} SET
    Id_Protectora = @Id_Protectora,
    Nombre_Evento = @Nombre_Evento,
    Lugar = @Lugar,
    Fecha_Evento = @Fecha_Evento,
    Hora_Evento = @Hora_Evento,
    Descripcion_Evento = @Descripcion_Evento,
    EnclaceMaps = @EnclaceMaps,
    Foto_Evento = @Foto_Evento
WHERE Id_Evento = @Id_Evento;";

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id_Evento", evento.Id_Evento);
            command.Parameters.AddWithValue("@Id_Protectora", evento.Id_Protectora);
            command.Parameters.AddWithValue("@Nombre_Evento", evento.Nombre_Evento);
            command.Parameters.AddWithValue("@Lugar", evento.Lugar);
            command.Parameters.AddWithValue("@Fecha_Evento", evento.Fecha_Evento.Date);
            command.Parameters.Add("@Hora_Evento", SqlDbType.Time).Value = evento.Hora_Evento;
            command.Parameters.AddWithValue("@Descripcion_Evento", evento.Descripcion_Evento);
            command.Parameters.AddWithValue("@EnclaceMaps", (object?)evento.EnclaceMaps ?? DBNull.Value);
            command.Parameters.AddWithValue("@Foto_Evento", (object?)evento.Foto_Evento ?? DBNull.Value);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = $"DELETE FROM {Table} WHERE Id_Evento = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<Evento>> ObtenerPorProtectoraAsync(int idProtectora)
        {
            var eventos = new List<Evento>();
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = $"SELECT * FROM {Table} WHERE Id_Protectora = @IdProtectora";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdProtectora", idProtectora);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                eventos.Add(Map(reader));

            return eventos;
        }

        private static Evento Map(SqlDataReader rd)
        {
            int o(string n) => rd.GetOrdinal(n);

            return new Evento
            {
                Id_Evento          = rd.GetInt32(o("Id_Evento")),
                Id_Protectora      = rd.GetInt32(o("Id_Protectora")),
                Nombre_Evento      = rd.GetString(o("Nombre_Evento")),
                Lugar              = rd.GetString(o("Lugar")),
                Fecha_Evento       = rd.GetDateTime(o("Fecha_Evento")),
                Hora_Evento        = (TimeSpan)rd.GetValue(o("Hora_Evento")),
                Descripcion_Evento = rd.GetString(o("Descripcion_Evento")),
                EnclaceMaps        = rd.IsDBNull(o("EnclaceMaps")) ? null : rd.GetString(o("EnclaceMaps")),
                Foto_Evento        = rd.IsDBNull(o("Foto_Evento")) ? null : rd.GetString(o("Foto_Evento")),
            };
        }
    }
}
