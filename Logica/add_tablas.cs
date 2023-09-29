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
    public class add_tablas
    {
        public string nom_user, ape_user,
            codigo, nombre, cedula, apellido, civil, genero, estado;
        public DateTime edad;
        public long provincia;

        #region VER - MOSTRAR REGISTRO DE LA TABLA               

        // Método para mostrar los registros de la tabla
        public void Consul_studens(DataGridView tabla)
        {
            tabla.DataSource = Consul_table_studens();
            Hearder_Table(tabla);
        }

        // Método privado para obtener los registros de la tabla
        private DataTable Consul_table_studens()
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();
            string sql = "SELECT * FROM estudiante";
            SqlCommand conexion = new SqlCommand(sql, conectar.dbconexion);
            SqlDataAdapter datos = new SqlDataAdapter(conexion);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            conectar.dbconexion.Close();
            return tabla;
        }

        // Cabecera de las columnas para la tabla
        private void Hearder_Table(DataGridView tabla)
        {
            tabla.Columns[0].HeaderText = "N°";
            tabla.Columns[1].HeaderText = "Código";
            tabla.Columns[2].HeaderText = "Cédula";
            tabla.Columns[3].HeaderText = "Nombre";
            tabla.Columns[4].HeaderText = "Apellido";
            tabla.Columns[5].HeaderText = "F Nacimiento";
            tabla.Columns[6].HeaderText = "Estado Civil";
            tabla.Columns[7].HeaderText = "Genero";
            tabla.Columns[8].HeaderText = "Provincia";
        }

        // Método para usar los radiosbutton en las consultas
        public void Select_radio(DataGridView tablegrid, RadioButton radio1, RadioButton radio2, TextBox text)
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();

            // busqueda por apellido
            if (radio1.Checked)
            {
                Search_ape(tablegrid, text);
            }

            // busqueda por cedula
            else if (radio2.Checked)
            {
                Search_ced(tablegrid, text);
            }
            else
            {
                MessageBox.Show("Por favor, marca una opción de busqueda", "Error");
            }

            Hearder_Table(tablegrid);
            conectar.dbconexion.Close();
        }

        // Método para buscar por cedula
        private void Search_ced(DataGridView tablegrid, TextBox text)
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();

            string sql = "SELECT * FROM estudiante WHERE est_ced LIKE '%" + text.Text.Trim() + "%'";

            SqlCommand conexion = new SqlCommand(sql, conectar.dbconexion);
            SqlDataAdapter datos = new SqlDataAdapter(conexion);
            DataTable tabla = new DataTable();

            datos.Fill(tabla);
            conectar.dbconexion.Close();
            tablegrid.DataSource = tabla;
        }

        // Método para buscar por apellido
        private void Search_ape(DataGridView tablegrid, TextBox text)
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();

            string sql = "SELECT * FROM estudiante WHERE est_ape LIKE '%" + text.Text.Trim() + "%'";

            SqlCommand conexion = new SqlCommand(sql, conectar.dbconexion);
            SqlDataAdapter datos = new SqlDataAdapter(conexion);
            DataTable tabla = new DataTable();

            datos.Fill(tabla);
            conectar.dbconexion.Close();
            tablegrid.DataSource = tabla;
        }

        #endregion
    }
}
