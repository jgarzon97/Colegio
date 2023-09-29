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
    public partial class frmRegistros : Form
    {
        public string cod, ced, nom, ape, civ, gen;
        public DateTime eda;
        public Int64 pro;

        public frmRegistros()
        {
            InitializeComponent();
            CargarComboEstadoCivil();
            CargarComboProvincias();
        }

        #region BOTONES

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Registrar();
        }

        private void btnVerRes_Click(object sender, EventArgs e)
        {
            frmConsultas con = new frmConsultas();
            con.ShowDialog();
            this.Show();
        }

        private void btnProvincia_Click(object sender, EventArgs e)
        {
            frmAggProvincia con = new frmAggProvincia();
            con.ShowDialog();
            this.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex.ToString() != null)
            {
                loading_comboBox p = new loading_comboBox();
                string id = comboBox2.SelectedValue.ToString();
                p.CargarCiudades(comboBox3, id);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region ALGORITMOS

        public void Registrar()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Por favor, no dejes vacío ningun campo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                try
                {
                    cod = textBox1.Text;
                    ced = textBox2.Text;
                    nom = textBox3.Text;
                    ape = textBox4.Text;
                    eda = dateTimePicker1.Value.Date;
                    civ = comboBox1.Text;
                    gen = Radio(radioButton1, radioButton2);
                    pro = Int64.Parse(comboBox2.SelectedValue.ToString());

                    //** PROCESO **//
                    sp_add objproceso = new sp_add
                    {
                        codigo = cod,
                        cedula = ced,
                        nombre = nom,
                        apellido = ape,
                        edad = eda,
                        civil = civ,
                        genero = gen,
                        provincia = pro
                    };
                    objproceso.Reg_Studens();

                    MessageBox.Show("Se registró en la base de datos.");
                    Limpiar();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Alerta");
                }
            }
        }
        
        private String Radio(RadioButton opcion1, RadioButton opcion2)
        {
            string res = "";

            if (opcion1.Checked)
            {
                res = "Masculino";
            }
            else if (opcion2.Checked)
            {
                res = "Femenino";
            }
            return res;
        }

        private void CargarComboEstadoCivil()
        {
            loading_comboBox p = new loading_comboBox();
            p.CargarEstadoCivil(comboBox1);
        }

        private void CargarComboProvincias()
        {
            loading_comboBox p = new loading_comboBox();
            p.CargarProvincias(comboBox2);
        }

        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
        }
        #endregion
    }
}
