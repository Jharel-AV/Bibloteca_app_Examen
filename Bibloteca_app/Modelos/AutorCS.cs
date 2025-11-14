using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Bibloteca_app.Modelos
{
    internal class AutorCS
    {
        public static DataTable ObtenerAutores()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Autores order by id desc", cnn.ObtenerConexion());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable autoresTable = new DataTable();
                adapter.Fill(autoresTable);
                return autoresTable;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al obtener los autores: " + ex.Message);
                return null;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool AgregarAutor(string nombres, string apellidos,string fecha_nacimiento,string pais,string biografia)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                SqlCommand cmd = new SqlCommand("INSERT INTO Autores (nombres, apellidos, fecha_nacimiento, pais, biografia) VALUES (@nombres, @apellidos, @fecha_nacimiento, @pais, @biografia)", cnn.ObtenerConexion());
                cmd.Parameters.AddWithValue("@nombres", nombres);
                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);
                cmd.Parameters.AddWithValue("@pais", pais);
                cmd.Parameters.AddWithValue("@biografia", biografia);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el autor: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool EditarAutor(int id, string nombres, string apellidos, string fecha_nacimiento, string pais, string biografia)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                SqlCommand cmd = new SqlCommand("UPDATE Autores SET nombres = @nombres, apellidos = @apellidos, fecha_nacimiento = @fecha_nacimiento, pais = @pais, biografia = @biografia WHERE id = @id", cnn.ObtenerConexion());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombres", nombres);
                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", fecha_nacimiento);
                cmd.Parameters.AddWithValue("@pais", pais);
                cmd.Parameters.AddWithValue("@biografia", biografia);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el autor: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool EliminarAutor(int id)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                SqlCommand cmd = new SqlCommand("DELETE FROM Autores WHERE id = @id", cnn.ObtenerConexion());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el autor: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
    }
}
