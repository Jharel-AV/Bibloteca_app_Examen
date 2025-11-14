using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibloteca_app
{
    public partial class EditorialesFRM : Form
    {
        int id = 0;
        public EditorialesFRM()
        {
            InitializeComponent();
        }

        private void txtPais_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPais.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPais, "El país no puede estar vacío.");
                txtPais.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPais, "");
            }
            // adicionalmente el pais solo se puede escribir en 2 letras
            if (txtPais.Text.Length != 2)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPais, "El país debe tener exactamente 2 letras.");
                txtPais.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPais, "");
            }
        }

        private void EditorialesFRM_Load(object sender, EventArgs e)
        {
            dtEditoriales.DataSource = Modelos.EditorialCS.LlenarDatoE();
            dtEditoriales.Columns[0].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                string nombreEditorial = txtNombre.Text;
                string pais = txtPais.Text;
                string sitioWeb = txtWeb.Text;
                bool resultado = false;
                if (id == 0)
                {
                    resultado = Modelos.EditorialCS.AgregarEditorial(nombreEditorial, pais, sitioWeb);
                }
                else
                {
                    resultado = Modelos.EditorialCS.EditarEditorial(id, nombreEditorial, pais, sitioWeb);
                }
                if (resultado)
                {
                    MessageBox.Show("Operación realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtEditoriales.DataSource = Modelos.EditorialCS.LlenarDatoE();
                    dtEditoriales.Columns[0].Visible = false;
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al realizar la operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void limpiar()
        {
            txtNombre.Clear();
            txtPais.Clear();
            txtWeb.Clear();
            id = 0;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = dtEditoriales.CurrentRow.Cells["nombre"].Value.ToString();
            txtPais.Text = dtEditoriales.CurrentRow.Cells["pais"].Value.ToString();
            txtWeb.Text = dtEditoriales.CurrentRow.Cells["sitio_web"].Value.ToString();
            id = Convert.ToInt32(dtEditoriales.CurrentRow.Cells["id"].Value);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idEliminar = Convert.ToInt32(dtEditoriales.CurrentRow.Cells["id"].Value);
            bool resultado = Modelos.EditorialCS.EliminarEditorial(idEliminar);
            if (resultado)
            {
                MessageBox.Show("Editorial eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtEditoriales.DataSource = Modelos.EditorialCS.LlenarDatoE();
                dtEditoriales.Columns[0].Visible = false;
                limpiar();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar la editorial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
