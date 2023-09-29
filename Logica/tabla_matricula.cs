using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace Logica
{
    public class tabla_matricula
    {
        public string
            codigo, tipo_mat, observa, estado;
        public int student, periodo, curso;
        public DateTime fecha;


        // Método usando [PA] para los registros de estudiantes
        public void Reg_Matricula()
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();

            SqlCommand conn = new SqlCommand("sp_matricular_estudiante", conectar.dbconexion);
            conn.CommandType = CommandType.StoredProcedure;

            #region Parametros de ingreso
            conn.Parameters.AddWithValue("@mat_cod", codigo);
            conn.Parameters.AddWithValue("@est_int", student);
            conn.Parameters.AddWithValue("@cur_int", curso);
            conn.Parameters.AddWithValue("@per_int", periodo);
            conn.Parameters.AddWithValue("@mat_obs", observa);
            conn.Parameters.AddWithValue("@mat_tipo", tipo_mat);
            conn.Parameters.AddWithValue("@mat_fech", fecha);
            #endregion

            conn.ExecuteNonQuery();
            conectar.dbconexion.Close();
        }

        public void Consul_studens_matriculas(DataGridView tabla)
        {
            tabla.DataSource = Consul_table_matriculas();
            Hearder_Table(tabla);
        }

        private DataTable Consul_table_matriculas()
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();
            string sql = "SELECT * FROM matriculas";
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
            tabla.Columns[1].HeaderText = "Materia";
            tabla.Columns[2].HeaderText = "Estudiante";
            tabla.Columns[3].HeaderText = "Curso";
            tabla.Columns[4].HeaderText = "Periodo";
            tabla.Columns[5].HeaderText = "Periodo";
            tabla.Columns[6].HeaderText = "Tipo";
            tabla.Columns[7].HeaderText = "Fecha";
        }
    }
}