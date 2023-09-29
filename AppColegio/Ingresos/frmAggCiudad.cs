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
    public partial class frmAggCiudad : Form
    {
        public frmAggCiudad()
        {
            InitializeComponent();
            CargarComboProvincias();
        }

        public string nom, est;
        public long pro;

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
                    pro = Int64.Parse(comboBox1.SelectedValue.ToString());

                    //** PROCESO **//
                    sp_add objproceso = new sp_add();

                    objproceso.nombre = nom;
                    objproceso.estado = est;
                    objproceso.provincia = pro;
                    objproceso.Reg_Ciudad();

                    MessageBox.Show("Se registró en la base de datos.");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Alerta");
                }
            }
        }

        private void CargarComboProvincias()
        {
            loading_comboBox p = new loading_comboBox();
            p.CargarProvincias(comboBox1);
        }
    }
}
