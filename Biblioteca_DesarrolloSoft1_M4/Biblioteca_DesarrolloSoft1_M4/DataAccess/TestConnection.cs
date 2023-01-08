using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Biblioteca_DesarrolloSoft1_M4.DataAccess
{
    public class TestConnection
    {
        private readonly string connectionstring = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        public void testing()
        {

            try
            {
                var conn = new SqlConnection(connectionstring);

            }
            catch (Exception)
            {

                MessageBox.Show("Error en la conexion");
            }

            MessageBox.Show("Conexion exitosa");
        }
    }
}
