using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Biblioteca_DesarrolloSoft1_M4.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Biblioteca_DesarrolloSoft1_M4.DataAccess
{
    public class Usuario
    {
        private readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

		//Login para el final
   //     public int GetUser(string username,string password)
   //     {
			//try
			//{
			//	int rol = 0;
			//	Usuarios user = new Usuarios();
				

			//	conn.Open();
			//	SqlCommand cmd = new SqlCommand("select * from TblUsuarios where nombre_usuario = @username and clave_usuario = @password");
			//	cmd.Parameters.AddWithValue("@username", username);
			//	cmd.Parameters.AddWithValue("@password", password);

			//	SqlDataReader rd = cmd.ExecuteReader();

			//	if (rd.Read())
			//	{
			//		user.id_rol = rd.GetInt32(0);
			//		user.id_miembro = rd.GetInt32(1);
			//		user.id_rol = rd.GetInt32(2);
			//		user.nombre_usuario = rd.GetString(3);
			//		user.clave_usuario = rd.GetString(4);
			//	}

			//	rol = user.id_rol;
					
			//	return rol;
			//}
			//catch (Exception e)
			//{
			//	throw;
			//}
   //     }


    }
}
