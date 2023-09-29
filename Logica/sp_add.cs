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
    public class sp_add
    {
        public string nom_user, ape_user, 
            codigo, nombre, cedula, apellido, civil, genero, estado;
        public DateTime edad;
        public long provincia;

        #region INGRESOS - ESTUDIANTE PROVINCIA CIUDAD

        // Método usando [PA] para los registros de estudiantes
        public void Reg_Studens()
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();

            SqlCommand conn = new SqlCommand("sp_add_estudiante", conectar.dbconexion);
            conn.CommandType = CommandType.StoredProcedure;
            
            #region Parametros de ingreso
            conn.Parameters.AddWithValue("@est_cod", codigo);
            conn.Parameters.AddWithValue("@est_ced", cedula);
            conn.Parameters.AddWithValue("@est_nom", nombre);
            conn.Parameters.AddWithValue("@est_ape", apellido);
            conn.Parameters.AddWithValue("@est_fec_nac", edad);
            conn.Parameters.AddWithValue("@est_est_civ", civil);
            conn.Parameters.AddWithValue("@est_gen", genero);
            conn.Parameters.AddWithValue("@pro_id", provincia);
            #endregion

            conn.ExecuteNonQuery();
            conectar.dbconexion.Close();
        }

        // Método usando [PA] para los registros de provincias
        public void Reg_Provincia()
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();

            SqlCommand conn = new SqlCommand("sp_add_provincia", conectar.dbconexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            conn.Parameters.AddWithValue("@pro_nom", nombre);
            conn.Parameters.AddWithValue("@pro_est", estado);

            conn.ExecuteNonQuery();
            conectar.dbconexion.Close();
        }

        // Método usando [PA] para los registros de ciudades
        public void Reg_Ciudad()
        {
            conexion conectar = new conexion();
            conectar.dbconexion.Open();

            SqlCommand conn = new SqlCommand("sp_add_ciudad", conectar.dbconexion);
            conn.CommandType = CommandType.StoredProcedure;

            conn.Parameters.AddWithValue("@ciu_nom", nombre);
            conn.Parameters.AddWithValue("@ciu_est", estado);
            conn.Parameters.AddWithValue("@pro_id", provincia);

            conn.ExecuteNonQuery();
            conectar.dbconexion.Close();
        }

        #endregion        
    }
}