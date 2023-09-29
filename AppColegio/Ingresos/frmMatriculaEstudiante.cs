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
    public partial class frmMatriculaEstudiante : Form
    {
        public string
            codigo, tipo_mat, observa, estado;
        public int student, curso, periodo;
        public DateTime fecha;

        public frmMatriculaEstudiante()
        {
            InitializeComponent();
            CargarPeriodos();
            CargarCusos();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            loading_comboBox objproceso = new loading_comboBox();
            objproceso.CargarMatriculas(txtBuscar, textBox3, textBox4, textBox5);
        }

        private void CargarPeriodos()
        {
            loading_comboBox p = new loading_comboBox();
            p.CargarPeriodos(comboBox1);
        }

        private void CargarCusos()
        {
            loading_comboBox p = new loading_comboBox();
            p.CargarCursos(comboBox2);
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                codigo = textBox2.Text;
                if (!int.TryParse(textBox3.Text, out student))
                {
                    MessageBox.Show("El valor del estudiante no es válido.", "Error");
                    return;
                }
                observa = textBox4.Text;
                tipo_mat = textBox5.Text;
                if (!int.TryParse(comboBox2.Text, out curso))
                {
                    MessageBox.Show("El valor del curso no es válido.", "Error");
                    return;
                }
                if (!int.TryParse(comboBox1.Text, out periodo))
                {
                    MessageBox.Show("El valor del periodo no es válido.", "Error");
                    return;
                }
                fecha = DateTime.Now;

                //** PROCESO **//
                tabla_matricula objproceso = new tabla_matricula
                {
                    codigo = codigo,
                    student = student,
                    observa = observa,
                    tipo_mat = tipo_mat,
                    curso = curso,
                    periodo = periodo,
                    fecha = fecha,
                };
                objproceso.Reg_Matricula();
                MessageBox.Show("Matriculado.", "Proceso realizado");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
