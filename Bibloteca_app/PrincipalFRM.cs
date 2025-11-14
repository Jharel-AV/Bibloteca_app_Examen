using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bibloteca_app
{
    public partial class Principal_Biblioteca : Form
    {
        public Principal_Biblioteca()
        {
            InitializeComponent();
        }

        private void CategoriasBtn_clic(object sender, EventArgs e)
        {
            CategoriasFRM frm = new CategoriasFRM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void EditorialBtn_clic(object sender, EventArgs e)
        {
            EditorialesFRM frm = new EditorialesFRM();
            frm.MdiParent = this;
            frm.Show();
        }

        private void AutoresButton_Click(object sender, EventArgs e)
        {
            AutoresFRM fRM = new AutoresFRM();
            fRM.MdiParent = this;
            fRM.Show();
        }
    }
}
