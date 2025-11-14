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

namespace Bibloteca_app
{
    public partial class CategoriasFRM : Form
    {
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
    }
}
