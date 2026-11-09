using MySql.Data.MySqlClient;
using Parcial_3_Actividad_2.Models;

namespace Parcial_3_Actividad_2.Data
{
    /// <summary>Acceso a datos de la tabla Usuarios para MySQL.</summary>
    public class UsuarioRepository
    {
        public bool ExisteUsuario(string nombreUsuario)
        {
            using var con = ConexionDB.ObtenerConexion();
            con.Open();
            const string sql = "SELECT COUNT(1) FROM Usuarios WHERE NombreUsuario = @u";
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@u", nombreUsuario);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public void Insertar(Usuario usuario)
        {
            using var con = ConexionDB.ObtenerConexion();
            con.Open();
            const string sql = @"INSERT INTO Usuarios (NombreUsuario, NombreCompleto, PasswordHash)
                                 VALUES (@u, @n, @h)";
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@u", usuario.NombreUsuario);
            cmd.Parameters.AddWithValue("@n", usuario.NombreCompleto);
            cmd.Parameters.AddWithValue("@h", usuario.PasswordHash);
            cmd.ExecuteNonQuery();
        }

        public Usuario? ObtenerPorNombreUsuario(string nombreUsuario)
        {
            using var con = ConexionDB.ObtenerConexion();
            con.Open();
            const string sql = @"SELECT Id, NombreUsuario, NombreCompleto, PasswordHash, FechaCreacion
                                 FROM Usuarios WHERE NombreUsuario = @u";
            using var cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@u", nombreUsuario);
            using var rd = cmd.ExecuteReader();

            if (!rd.Read()) return null;

            return new Usuario
            {
                Id = rd.GetInt32(0),
                NombreUsuario = rd.GetString(1),
                NombreCompleto = rd.GetString(2),
                PasswordHash = rd.GetString(3),
                FechaCreacion = rd.GetDateTime(4)
            };
        }
    }
}