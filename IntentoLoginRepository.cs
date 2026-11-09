using MySql.Data.MySqlClient;
using Parcial_3_Actividad_2.Models;

namespace Parcial_3_Actividad_2.Data
{
    /// <summary>Acceso a datos de la tabla IntentosLogin para MySQL.</summary>
    public class IntentoLoginRepository
    {
        public void Registrar(IntentoLogin intento)
        {
            using var con = ConexionDB.ObtenerConexion();
            con.Open();
            const string sql = @"INSERT INTO IntentosLogin (UsuarioId, NombreUsuario, Exitoso)
                                 VALUES (@id, @u, @e)";
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", (object?)intento.UsuarioId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@u", intento.NombreUsuario);
            cmd.Parameters.AddWithValue("@e", intento.Exitoso);
            cmd.ExecuteNonQuery();
        }

        public List<IntentoLogin> ListarTodos()
        {
            var lista = new List<IntentoLogin>();
            using var con = ConexionDB.ObtenerConexion();
            con.Open();
            const string sql = @"SELECT Id, UsuarioId, NombreUsuario, Exitoso, FechaIntento
                                 FROM IntentosLogin ORDER BY FechaIntento DESC";
            using var cmd = new MySqlCommand(sql, con);
            using var rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                lista.Add(new IntentoLogin
                {
                    Id = rd.GetInt32(0),
                    UsuarioId = rd.IsDBNull(1) ? null : rd.GetInt32(1),
                    NombreUsuario = rd.GetString(2),
                    Exitoso = rd.GetBoolean(3),
                    FechaIntento = rd.GetDateTime(4)
                });
            }
            return lista;
        }
    }
}