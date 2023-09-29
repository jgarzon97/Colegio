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

namespace AppColegio.Tablas
{
    public partial class VerMatriculas : Form
    {
        public VerMatriculas()
        {
            InitializeComponent();
        }

        private void VerMatriculas_Load(object sender, EventArgs e)
        {
            tabla_matricula objproceso = new tabla_matricula();
            objproceso.Consul_studens_matriculas(dataGridView1);
        }
    }
}
