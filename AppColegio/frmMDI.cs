using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppColegio
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
            this.Size = new Size(1000,800);
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            frmRegistros frm = new frmRegistros();
            frm.ShowDialog();
            this.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        
        private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultas con = new frmConsultas();
            con.ShowDialog();
            this.Show();
        }

        private void provinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAggProvincia frm = new frmAggProvincia();
            frm.ShowDialog();
            this.Show();
        }

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAggCiudad frm = new frmAggCiudad();
            frm.ShowDialog();
            this.Show();
        }

        private void matriculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMatriculaEstudiante frm = new frmMatriculaEstudiante();
            frm.ShowDialog();
            this.Show();
        }

        private void printPreviewToolStripButton_Click(object sender, EventArgs e)
        {
            frmConsultas con = new frmConsultas();
            con.ShowDialog();
            this.Show();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultas con = new frmConsultas();
            con.ShowDialog();
            this.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MantenerCentrado(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.CenterToScreen();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ssss");
            string dayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            string formattedDate = char.ToUpper(dayOfWeek[0]) + dayOfWeek.Substring(1) + DateTime.Now.ToString(", dd 'de' MMMM 'de' yyyy");
            label2.Text = formattedDate;
        }

        private void provinciasToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ciudadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void matrículasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tablas.VerMatriculas ve = new Tablas.VerMatriculas();
            ve.ShowDialog();
            Show();
        }
    }
}
