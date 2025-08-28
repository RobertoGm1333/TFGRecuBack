using Microsoft.Data.SqlClient;
using System.Data;
using Models;

namespace ProtectoraAPI.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly string _connectionString;
        private const string Table = "[dbo].[Eventos]"; // <- usa el nombre real de tu tabla

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

            var query = $"SELECT * FROM {Table} WHERE IdEvento = @Id";
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
    (IdProtectora, NombreEvento, Lugar, Direccion, Fecha, Hora, Descripcion, EnlaceMaps, Visible)
OUTPUT INSERTED.IdEvento
VALUES
    (@IdProtectora, @NombreEvento, @Lugar, @Direccion, @Fecha, @Hora, @Descripcion, @EnlaceMaps, @Visible);";

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IdProtectora", evento.Id_Protectora);
            command.Parameters.AddWithValue("@NombreEvento", evento.Nombre_Evento);
            command.Parameters.AddWithValue("@Lugar", evento.Lugar);
            command.Parameters.AddWithValue("@Direccion", (object?)evento.Direccion ?? DBNull.Value);
            command.Parameters.AddWithValue("@Fecha", evento.Fecha.Date);
            command.Parameters.Add("@Hora", SqlDbType.Time).Value = evento.Hora;
            command.Parameters.AddWithValue("@Descripcion", (object?)evento.Descripcion ?? DBNull.Value);
            command.Parameters.AddWithValue("@EnlaceMaps", (object?)evento.Enlace_Maps ?? DBNull.Value);
            command.Parameters.AddWithValue("@Visible", evento.Visible);

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
    IdProtectora = @IdProtectora,
    NombreEvento = @NombreEvento,
    Lugar = @Lugar,
    Direccion = @Direccion,
    Fecha = @Fecha,
    Hora = @Hora,
    Descripcion = @Descripcion,
    EnlaceMaps = @EnlaceMaps,
    Visible = @Visible
WHERE IdEvento = @IdEvento;";

            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IdEvento", evento.Id_Evento);
            command.Parameters.AddWithValue("@IdProtectora", evento.Id_Protectora);
            command.Parameters.AddWithValue("@NombreEvento", evento.Nombre_Evento);
            command.Parameters.AddWithValue("@Lugar", evento.Lugar);
            command.Parameters.AddWithValue("@Direccion", (object?)evento.Direccion ?? DBNull.Value);
            command.Parameters.AddWithValue("@Fecha", evento.Fecha.Date);
            command.Parameters.Add("@Hora", SqlDbType.Time).Value = evento.Hora;
            command.Parameters.AddWithValue("@Descripcion", (object?)evento.Descripcion ?? DBNull.Value);
            command.Parameters.AddWithValue("@EnlaceMaps", (object?)evento.Enlace_Maps ?? DBNull.Value);
            command.Parameters.AddWithValue("@Visible", evento.Visible);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = $"DELETE FROM {Table} WHERE IdEvento = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<Evento>> ObtenerPorProtectoraAsync(int idProtectora)
        {
            var eventos = new List<Evento>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var query = $"SELECT * FROM {Table} WHERE IdProtectora = @IdProtectora";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdProtectora", idProtectora);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
                eventos.Add(Map(reader));

            return eventos;
        }

        private static Evento Map(SqlDataReader rd)
        {
            // columnas esperadas en la tabla: IdEvento, IdProtectora, NombreEvento, Lugar,
            // Direccion, Fecha, Hora, Descripcion, EnlaceMaps, Visible
            int ord(string n) => rd.GetOrdinal(n);

            return new Evento
            {
                Id_Evento     = rd.GetInt32(ord("IdEvento")),
                Id_Protectora = rd.GetInt32(ord("IdProtectora")),
                Nombre_Evento = rd.GetString(ord("NombreEvento")),
                Lugar         = rd.GetString(ord("Lugar")),
                Direccion     = rd.IsDBNull(ord("Direccion")) ? null : rd.GetString(ord("Direccion")),
                Fecha         = rd.GetDateTime(ord("Fecha")),
                Hora          = (TimeSpan)rd.GetValue(ord("Hora")),
                Descripcion   = rd.IsDBNull(ord("Descripcion")) ? null : rd.GetString(ord("Descripcion")),
                Enlace_Maps   = rd.IsDBNull(ord("EnlaceMaps")) ? null : rd.GetString(ord("EnlaceMaps")),
                Visible       = rd.GetBoolean(ord("Visible"))
            };
        }
    }
}
