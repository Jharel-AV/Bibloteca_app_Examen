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

namespace Bibloteca_app
{
    public partial class AutoresFRM : Form
    { 
        int id = 0;

        public AutoresFRM()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void CargarAutores()
        {
            dtAutores.DataSource = AutorCS.ObtenerAutores();
            dtAutores.Columns[0].Visible = false;
        }
        public void LimpiarCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtPais.Clear();
            txtBiografia.Clear();
            id = 0;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            string dateAutores = txtFecha.Value.ToString("yyyy-MM-dd");
            string fecha_nacimiento = dateAutores;
            string pais = txtPais.Text;
            string biografia = txtBiografia.Text;
            bool resultado = false;
            if (id == 0)
            {
                resultado = AutorCS.AgregarAutor(nombres, apellidos, fecha_nacimiento, pais, biografia);
            }
            else 
            { 
                resultado = AutorCS.EditarAutor(id, nombres, apellidos, fecha_nacimiento, pais, biografia);
            }
            if (resultado)
            {
                MessageBox.Show("Operación realizada con éxito");
                CargarAutores();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al realizar la operación");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtApellidos.Text = dtAutores.CurrentRow.Cells[2].Value.ToString();
            txtNombres.Text = dtAutores.CurrentRow.Cells[1].Value.ToString();
            txtFecha.Text = dtAutores.CurrentRow.Cells[3].Value.ToString();
            txtPais.Text = dtAutores.CurrentRow.Cells[4].Value.ToString();
            txtBiografia.Text = dtAutores.CurrentRow.Cells[5].Value.ToString();
            id = Convert.ToInt32(dtAutores.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = Convert.ToInt32(dtAutores.CurrentRow.Cells[0].Value.ToString());
            bool resultado = AutorCS.EliminarAutor(idEliminar);
        }

        private void AutoresFRM_Load(object sender, EventArgs e)
        {
            dtAutores.DataSource = AutorCS.ObtenerAutores();
            dtAutores.Columns[0].Visible = false;
        }
    }
}
