using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class conexion
    {
        public SqlConnection dbconexion = new SqlConnection("Data Source = DESKTOP-4DQVP92; Initial Catalog = colegio; Integrated Security = True");
    }
}
