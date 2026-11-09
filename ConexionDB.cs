using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Parcial_3_Actividad_2.Data
{
    /// <summary>Centraliza la cadena de conexión y la creación de conexiones MySQL.</summary>
    public static class ConexionDB
    {
        private const string CadenaConexion = "Server=localhost;Database=LoginDB;Uid=root;Pwd=Isayalejo1.;";

        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(CadenaConexion);
        }
    }
}