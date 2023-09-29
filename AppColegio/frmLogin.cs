using Datos;
using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppColegio
{
    public partial class frmLogin : Form
    {
        public string use, con;

        public frmLogin()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Enter_Press(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Registrar();
            }
        }

        private void Registrar()
        {
            if (string.IsNullOrWhiteSpace(txtuser.Text) || string.IsNullOrWhiteSpace(txtpass.Text))
            {
                MessageBox.Show("Por favor, no dejes vacío ningun campo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtuser.Focus();
            }
            else
            {
                try
                {
                    frmMDI mdi = new frmMDI();
                    sp_login login = new sp_login();

                    use = txtuser.Text;
                    con = txtpass.Text;

                    login.user = use;
                    login.pass = con;

                    login.Logearte(this, mdi, txtuser, txtpass, mdi.nom_user);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Error");
                }
            }
        }        
    }
}
