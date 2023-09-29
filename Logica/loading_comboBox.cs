using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class loading_comboBox
    {
        public string nom_user, ape_user,
            codigo, nombre, cedula, apellido, civil, genero, estado;
        public DateTime edad;
        public long provincia;

        #region DATOS - CARGA DE LOS COMBOBOX

        public void CargarEstadoCivil(ComboBox box)
        {
            box.DropDownStyle = ComboBoxStyle.DropDownList;
            box.Items.Add("Soltero");
            box.Items.Add("Casado");
            box.Items.Add("Divorsiado");
            box.Items.Add("Viudo");
            box.Items.Add("Unión Libre");
        }

        public void CargarProvincias(ComboBox box)
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();
            string sql = "SELECT pro_id, pro_nom FROM provincia";
            SqlCommand conexion = new SqlCommand(sql, conectar.dbconexion);
            SqlDataAdapter datos = new SqlDataAdapter(conexion);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conectar.dbconexion.Close();

            box.ValueMember = "pro_id";
            box.DisplayMember = "pro_nom";
            box.DataSource = tabla;
            box.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarCiudades(ComboBox box, string pro_id)
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();
            SqlCommand conn = new SqlCommand("SELECT ciu_id, ciu_nom FROM ciudad WHERE pro_id = @pro_id", conectar.dbconexion);
            conn.Parameters.AddWithValue("@pro_id", pro_id);
            SqlDataAdapter datos = new SqlDataAdapter(conn);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conectar.dbconexion.Close();

            box.ValueMember = "pro_id";
            box.DisplayMember = "ciu_nom";
            box.DataSource = tabla;
            box.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarMatriculas(TextBox text1, TextBox text2, TextBox text3, TextBox text4)
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();

            string sql = "SELECT est_int, est_nom, est_ape FROM estudiante WHERE est_ced LIKE '%" + text1.Text.Trim() + "%'";

            SqlCommand conexion = new SqlCommand(sql, conectar.dbconexion);
            SqlDataReader reader = conexion.ExecuteReader();
            if (reader.Read())
            {
                // Mostrar los detalles en el textbox
                text2.Text = reader["est_int"].ToString();
                text3.Text = reader["est_nom"].ToString();
                text4.Text = reader["est_ape"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontró el registro");
            }
        }

        public void CargarPeriodos(ComboBox box)
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();
            string sql = "SELECT per_int,per_cod FROM periodos";
            SqlCommand conexion = new SqlCommand(sql, conectar.dbconexion);
            SqlDataAdapter datos = new SqlDataAdapter(conexion);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conectar.dbconexion.Close();

            box.ValueMember = "per_cod";
            box.DisplayMember = "per_int";
            box.DataSource = tabla;
            box.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void CargarCursos(ComboBox box)
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();
            string sql = "SELECT cur_int, cur_nom FROM cursos";
            SqlCommand conexion = new SqlCommand(sql, conectar.dbconexion);
            SqlDataAdapter datos = new SqlDataAdapter(conexion);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conectar.dbconexion.Close();

            box.ValueMember = "cur_nom";
            box.DisplayMember = "cur_int";
            box.DataSource = tabla;
            box.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        #endregion
    }
}
