using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Bibloteca_app.Modelos
{
    internal class CategoriaCS
    {
        public static DataTable LlenarTabla()
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM categorias order by id desc", cnn.ObtenerConexion());
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al llenar la tabla de categorías: " + ex.Message);
                return null;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool crearCategoria(string nombre)
        {
            try
            {
                Conexion conexion = new Conexion();
                SqlCommand comando = new SqlCommand("INSERT INTO categorias (nombre) VALUES (@nombre)", conexion.ObtenerConexion());
                comando.Parameters.AddWithValue("@nombre", nombre);
                conexion.ObtenerConexion().Open();
                comando.ExecuteNonQuery();
                conexion.ObtenerConexion().Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool CrearCat(string nombre)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                SqlCommand cmd = new SqlCommand("INSERT INTO categorias (nombre) VALUES (@nombre)", cnn.ObtenerConexion());
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la categoría: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool editarCategoria(int id, string nombre)
        {
          Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                SqlCommand cmd = new SqlCommand("UPDATE categorias SET nombre = @nombre WHERE id = @id", cnn.ObtenerConexion());
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }catch (Exception ex)
            {
                MessageBox.Show("Error al editar la categoría: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }
        public static bool eliminarCategoria(int id)
        {
            Conexion cnn = new Conexion();
            try
            {
                cnn.Conectar();
                SqlCommand cmd = new SqlCommand("DELETE FROM categorias WHERE id = @id", cnn.ObtenerConexion());
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la categoría: " + ex.Message);
                return false;
            }
            finally
            {
                cnn.Desconectar();
            }
        }

    }
}
