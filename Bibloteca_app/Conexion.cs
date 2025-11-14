using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bibloteca_app
{
    internal class Conexion
    {
        SqlConnection connection = new SqlConnection("Data Source=192.168.10.2; DataBase=libros_app;User Id=sa; Password=Hyp3r10nPr0_;TrustServerCertificate=True");

        public void Conectar()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public void Desconectar()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlConnection ObtenerConexion()
        {
            return connection;
        }
    }

}
