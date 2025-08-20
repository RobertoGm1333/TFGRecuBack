using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Models;

namespace ProtectoraAPI.Repositories
{
    public class AdopcionRepository : IAdopcionRepository
    {
        private readonly string _connectionString;

        public AdopcionRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private SqlConnection GetConn() => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Adopcion>> GetAllAsync()
        {
            const string sql = @"SELECT Id_Adopcion, Id_Protectora, Id_Gato, Fecha_Adopcion, OrigenWeb, Telefono_Adoptante, Observaciones
                                 FROM Adopcion
                                 ORDER BY Fecha_Adopcion DESC";
            using var cn = GetConn();
            await cn.OpenAsync();
            using var cmd = new SqlCommand(sql, cn);
            var list = new List<Adopcion>();
            using var rd = await cmd.ExecuteReaderAsync();
            while (await rd.ReadAsync())
            {
                list.Add(new Adopcion
                {
                    Id_Adopcion = rd.GetInt32(0),
                    Id_Protectora = rd.GetInt32(1),
                    Id_Gato = rd.GetInt32(2),
                    Fecha_Adopcion = rd.GetDateTime(3),
                    OrigenWeb = rd.GetBoolean(4),
                    Telefono_Adoptante = rd.IsDBNull(5) ? null : rd.GetString(5),
                    Observaciones = rd.IsDBNull(6) ? null : rd.GetString(6)
                });
            }
            return list;
        }

        public async Task<Adopcion?> GetByIdAsync(int id)
        {
            const string sql = @"SELECT Id_Adopcion, Id_Protectora, Id_Gato, Fecha_Adopcion, OrigenWeb, Telefono_Adoptante, Observaciones
                                 FROM Adopcion WHERE Id_Adopcion=@id";
            using var cn = GetConn();
            await cn.OpenAsync();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            using var rd = await cmd.ExecuteReaderAsync();
            if (await rd.ReadAsync())
            {
                return new Adopcion
                {
                    Id_Adopcion = rd.GetInt32(0),
                    Id_Protectora = rd.GetInt32(1),
                    Id_Gato = rd.GetInt32(2),
                    Fecha_Adopcion = rd.GetDateTime(3),
                    OrigenWeb = rd.GetBoolean(4),
                    Telefono_Adoptante = rd.IsDBNull(5) ? null : rd.GetString(5),
                    Observaciones = rd.IsDBNull(6) ? null : rd.GetString(6)
                };
            }
            return null;
        }

        public async Task<int> CreateAsync(Adopcion item)
        {
            const string sql = @"INSERT INTO Adopcion
                                 (Id_Protectora, Id_Gato, Fecha_Adopcion, OrigenWeb, Telefono_Adoptante, Observaciones)
                                 OUTPUT INSERTED.Id_Adopcion
                                 VALUES (@p, @g, @f, @o, @t, @obs)";
            using var cn = GetConn();
            await cn.OpenAsync();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@p", SqlDbType.Int){ Value = item.Id_Protectora },
                new SqlParameter("@g", SqlDbType.Int){ Value = item.Id_Gato },
                new SqlParameter("@f", SqlDbType.DateTime){ Value = item.Fecha_Adopcion == default ? DateTime.Now : item.Fecha_Adopcion },
                new SqlParameter("@o", SqlDbType.Bit){ Value = item.OrigenWeb },
                new SqlParameter("@t", SqlDbType.VarChar, 20){ Value = (object?)item.Telefono_Adoptante ?? DBNull.Value },
                new SqlParameter("@obs", SqlDbType.VarChar, 1000){ Value = (object?)item.Observaciones ?? DBNull.Value },
            });
            return (int)await cmd.ExecuteScalarAsync();
        }

        public async Task<bool> UpdateAsync(Adopcion item)
        {
            const string sql = @"UPDATE Adopcion
                                 SET Id_Protectora=@p, Id_Gato=@g, Fecha_Adopcion=@f, OrigenWeb=@o, Telefono_Adoptante=@t, Observaciones=@obs
                                 WHERE Id_Adopcion=@id";
            using var cn = GetConn();
            await cn.OpenAsync();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@p", SqlDbType.Int){ Value = item.Id_Protectora },
                new SqlParameter("@g", SqlDbType.Int){ Value = item.Id_Gato },
                new SqlParameter("@f", SqlDbType.DateTime){ Value = item.Fecha_Adopcion },
                new SqlParameter("@o", SqlDbType.Bit){ Value = item.OrigenWeb },
                new SqlParameter("@t", SqlDbType.VarChar, 20){ Value = (object?)item.Telefono_Adoptante ?? DBNull.Value },
                new SqlParameter("@obs", SqlDbType.VarChar, 1000){ Value = (object?)item.Observaciones ?? DBNull.Value },
                new SqlParameter("@id", SqlDbType.Int){ Value = item.Id_Adopcion },
            });
            return (await cmd.ExecuteNonQueryAsync()) > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = @"DELETE FROM Adopcion WHERE Id_Adopcion=@id";
            using var cn = GetConn();
            await cn.OpenAsync();
            using var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
            return (await cmd.ExecuteNonQueryAsync()) > 0;
        }

        public async Task<IEnumerable<AdopcionListadoDTO>> GetListadoGeneralAsync()
        {
            const string sql = @"
                SELECT 
                    a.Id_Gato,
                    a.Id_Protectora,
                    a.Fecha_Adopcion AS Fecha,
                    a.OrigenWeb,
                    g.Imagen_Gato,
                    a.Telefono_Adoptante
                FROM Adopcion a
                INNER JOIN Gato g ON g.Id_Gato = a.Id_Gato
                ORDER BY a.Fecha_Adopcion DESC;";
            using var cn = GetConn();
            await cn.OpenAsync();
            using var cmd = new SqlCommand(sql, cn);
            var list = new List<AdopcionListadoDTO>();
            using var rd = await cmd.ExecuteReaderAsync();
            while (await rd.ReadAsync())
            {
                list.Add(new AdopcionListadoDTO
                {
                    Id_Gato = rd.GetInt32(0),
                    Id_Protectora = rd.GetInt32(1),
                    Fecha = rd.GetDateTime(2),
                    OrigenWeb = rd.GetBoolean(3),
                    Imagen_Gato = rd.IsDBNull(4) ? null : rd.GetString(4),
                    Telefono_Adoptante = rd.IsDBNull(5) ? null : rd.GetString(5)
                });
            }
            return list;
        }

        public async Task<IEnumerable<SerieMesDTO>> GetSerieGeneralUltimos12MesesAsync()
        {
            const string sql = @"
DECLARE @Hoy DATE = CAST(GETDATE() AS DATE);
WITH Meses AS (
    SELECT DATEFROMPARTS(YEAR(@Hoy), MONTH(@Hoy), 1) AS Mes
    UNION ALL
    SELECT DATEADD(MONTH, -1, Mes)
    FROM Meses WHERE Mes > DATEADD(MONTH, -11, DATEFROMPARTS(YEAR(@Hoy), MONTH(@Hoy), 1))
)
SELECT CONVERT(varchar(7), m.Mes, 23) AS MesYYYYMM,
       ISNULL(v.Total, 0) AS Total
FROM Meses m
LEFT JOIN (
    SELECT DATEFROMPARTS(YEAR(Fecha_Adopcion), MONTH(Fecha_Adopcion), 1) AS Mes, COUNT(*) AS Total
    FROM Adopcion
    GROUP BY DATEFROMPARTS(YEAR(Fecha_Adopcion), MONTH(Fecha_Adopcion), 1)
) v ON v.Mes = m.Mes
ORDER BY m.Mes OPTION (MAXRECURSION 100);";
            using var cn = GetConn();
            await cn.OpenAsync();
            using var cmd = new SqlCommand(sql, cn);
            var list = new List<SerieMesDTO>();
            using var rd = await cmd.ExecuteReaderAsync();
            while (await rd.ReadAsync())
            {
                list.Add(new SerieMesDTO
                {
                    MesYYYYMM = rd.GetString(0),
                    Total = rd.GetInt32(1)
                });
            }
            return list;
        }

        public async Task<IEnumerable<SerieMesProtectoraDTO>> GetSeriePorProtectoraUltimos12MesesAsync()
        {
            const string sql = @"
DECLARE @Hoy DATE = CAST(GETDATE() AS DATE);
WITH Meses AS (
    SELECT DATEFROMPARTS(YEAR(@Hoy), MONTH(@Hoy), 1) AS Mes
    UNION ALL
    SELECT DATEADD(MONTH, -1, Mes)
    FROM Meses WHERE Mes > DATEADD(MONTH, -11, DATEFROMPARTS(YEAR(@Hoy), MONTH(@Hoy), 1))
)
SELECT 
    CONVERT(varchar(7), m.Mes, 23) AS MesYYYYMM,
    p.Id_Protectora,
    p.Nombre_Protectora,
    ISNULL(v.Total, 0) AS Total
FROM Meses m
CROSS JOIN Protectora p
LEFT JOIN (
    SELECT DATEFROMPARTS(YEAR(a.Fecha_Adopcion), MONTH(a.Fecha_Adopcion), 1) AS Mes,
           a.Id_Protectora, COUNT(*) AS Total
    FROM Adopcion a
    GROUP BY DATEFROMPARTS(YEAR(a.Fecha_Adopcion), MONTH(a.Fecha_Adopcion), 1), a.Id_Protectora
) v ON v.Mes = m.Mes AND v.Id_Protectora = p.Id_Protectora
ORDER BY p.Id_Protectora, m.Mes OPTION (MAXRECURSION 100);";
            using var cn = GetConn();
            await cn.OpenAsync();
            using var cmd = new SqlCommand(sql, cn);
            var list = new List<SerieMesProtectoraDTO>();
            using var rd = await cmd.ExecuteReaderAsync();
            while (await rd.ReadAsync())
            {
                list.Add(new SerieMesProtectoraDTO
                {
                    MesYYYYMM = rd.GetString(0),
                    Id_Protectora = rd.GetInt32(1),
                    Nombre_Protectora = rd.GetString(2),
                    Total = rd.GetInt32(3)
                });
            }
            return list;
        }
    }
}
