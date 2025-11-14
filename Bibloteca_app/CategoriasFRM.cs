using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bibloteca_app.Modelos;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Bibloteca_app
{
    public partial class CategoriasFRM : Form
    {
        int id = 0;
        public CategoriasFRM()
        {
            InitializeComponent();
        }

        private void CategoriasFRM_Load(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();
            try
            {
                conexion.Conectar();
                dtCat.DataSource = CategoriaCS.LlenarTabla();
                dtCat.Columns["id"].Visible = false;
                dtCat.Columns["nombre"].HeaderText = "Categoría";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Desconectar();
            }

        }

        public void limpiar()
        {
            txtCat.Clear();
            id = 0;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreCat = txtCat.Text;
            bool resultado = false;
            if (id == 0)
            {
                resultado = CategoriaCS.CrearCat(nombreCat);
            }
            else
            {
                resultado = CategoriaCS.editarCategoria(id, nombreCat);
            }
            if (resultado)
            {
                MessageBox.Show("Categoría guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtCat.DataSource = CategoriaCS.LlenarTabla();
                limpiar();
                txtCat.Focus();
            }
            else
            {
                MessageBox.Show("Error al guardar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtCat.Text = dtCat.CurrentRow.Cells["nombre"].Value.ToString();
            id = Convert.ToInt32(dtCat.CurrentRow.Cells["id"].Value);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = Convert.ToInt32(dtCat.CurrentRow.Cells["id"].Value);
            bool resultado = CategoriaCS.eliminarCategoria(idEliminar);
            if (resultado)
            {
                MessageBox.Show("Categoría eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtCat.DataSource = CategoriaCS.LlenarTabla();
                limpiar();
                txtCat.Focus();
            }
            else
            {
                MessageBox.Show("Error al eliminar la categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
