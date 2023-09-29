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
    public partial class frmConsultas : Form
    {
        public frmConsultas()
        {
            InitializeComponent();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            add_tablas objproceso = new add_tablas();
            objproceso.Consul_studens(dataGridView1);
        }
        
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    MessageBox.Show("Por favor, ingrese el dato a buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBuscar.Focus();
                }
                else
                {
                    MostrarRegistros();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }            
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                MostrarRegistros();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        private void MostrarRegistros()
        {
            add_tablas objproceso = new add_tablas();
            dataGridView1.Refresh();
            objproceso.Select_radio(dataGridView1, radioButton1, radioButton2, txtBuscar);
        }
    }
}
