using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Bibloteca_app.Modelos
{
    internal class EditorialCS
    {
        public static DataTable LlenarDatoE()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                DataTable dt = new DataTable();
                string consulta = "SELECT * FROM editoriales order by id desc";
                SqlDataAdapter da = new SqlDataAdapter(consulta, cnn.ObtenerConexion());
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al llenar los datos de Editorial: " + ex.Message);
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool AgregarEditorial(string nombre, string pais, string sitio_web)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "INSERT INTO editoriales (nombre, pais, sitio_web) VALUES (@nombre, @pais, @sitio_web)";
                SqlCommand cmd = new SqlCommand(consulta, cnn.ObtenerConexion());
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@pais", pais);
                cmd.Parameters.AddWithValue("@sitio_web", sitio_web);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la editorial: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool EditarEditorial(int id, string nombre, string pais, string sitio_web)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "UPDATE editoriales SET nombre = @nombre, pais = @pais, sitio_web = @sitio_web WHERE id = @id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.ObtenerConexion());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@pais", pais);
                cmd.Parameters.AddWithValue("@sitio_web", sitio_web);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la editorial: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool EliminarEditorial(int id)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                string consulta = "DELETE FROM editoriales WHERE id = @id";
                SqlCommand cmd = new SqlCommand(consulta, cnn.ObtenerConexion());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la editorial: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
    }
}
