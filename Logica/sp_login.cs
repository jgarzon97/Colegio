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
    public class sp_login
    {
        #region LOGIN - ACCESO AL SISTEMA

        public string user, pass;

        /// <summary>
        /// Valida las credenciales del usuario e inicia sesión si las credenciales son correctas.
        /// </summary>
        /// <param name="form1">El formulario de inicio de sesión.</param>
        /// <param name="form2">El formulario MDI.</param>
        /// <param name="text1">Nombre de usuario.</param>
        /// <param name="text2">Contraseña.</param>
        /// <param name="label">Muestrar el nombre y apellido del usuario.</param>
        /// 
        public void Logearte(Form form1, Form form2, TextBox text1, TextBox text2, Label label)
        {
            // User and password control
            try
            {
                conexion conectar = new conexion();
                conectar.dbconexion.Open();

                SqlCommand conn = new SqlCommand("sp_login", conectar.dbconexion);
                conn.CommandType = CommandType.StoredProcedure;

                conn.Parameters.AddWithValue("@log_user", user);
                conn.Parameters.AddWithValue("@log_pass", pass);

                SqlParameter log_name = new SqlParameter("@log_name", SqlDbType.VarChar, 30);
                log_name.Direction = ParameterDirection.Output;
                conn.Parameters.Add(log_name);

                SqlParameter log_last_name = new SqlParameter("@log_last_name", SqlDbType.VarChar, 30);
                log_last_name.Direction = ParameterDirection.Output;
                conn.Parameters.Add(log_last_name);

                conn.ExecuteNonQuery();

                // value sends
                string name = log_name.Value.ToString();
                string last_name = log_last_name.Value.ToString();

                // validation
                if (name == "Acceso denegado")
                {
                    MessageBox.Show("Error de usuario / contraseña", "Acceso denegado");
                    Limpiar(text1, text2);
                }
                else
                {
                    
                    try
                    {
                        // login successful
                        conectar.dbconexion.Close();
                        // event form
                        form1.Hide();
                        label.Text = "Bienvenido, " + name + " " + last_name;
                        form2.ShowDialog();
                        form1.Close();
                        form1.Show();
                        Limpiar(text1, text2);
                    }
                    catch (Exception ex)
                    {
                        // Controla la Excepción producida cuando se intenta acceder a form1.
                        MessageBox.Show(ex.Source);
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error:");
            }
        }

        // Clear for Login
        private void Limpiar(TextBox text1, TextBox text2)
        {
            text1.Text = "";
            text2.Text = "";
            text1.Focus();
        }

        #endregion
    }
}
