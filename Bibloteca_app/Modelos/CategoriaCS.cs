using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Bibloteca_app.Modelos
{
    internal class CategoriaCS
    {
        public static DataTable LlenarTabla()
        {
            Conexion conexion = new Conexion();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM categorias", conexion.ObtenerConexion());
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

    }
}
