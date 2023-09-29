using Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppColegio
{
    public partial class frmAggProvincia : Form
    {
        public frmAggProvincia()
        {
            InitializeComponent();
        }
        public string nom, est;

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        public void Registrar()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor, no dejes vacío ningun campo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                try
                {
                    nom = textBox1.Text;
                    est = textBox2.Text;

                    //** PROCESO **//
                    sp_add objproceso = new sp_add();

                    objproceso.nombre = nom;
                    objproceso.estado = est;
                    objproceso.Reg_Provincia();

                    MessageBox.Show("Se registró en la base de datos.");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Alerta");
                }
            }
        }
    }
}
