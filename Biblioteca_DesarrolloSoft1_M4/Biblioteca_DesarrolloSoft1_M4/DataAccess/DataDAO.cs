using Biblioteca_DesarrolloSoft1_M4.Models;
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
    public class DataDAO
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
        
        public List<Libros> getAllLibros()
        {
            try
            {
                List<Libros> libros = new List<Libros>();

                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Mostrar_TblLibros",conn);

                SqlDataReader rd = cmd.ExecuteReader();

                while(rd.Read())
                {
                    libros.Add(new Libros
                    {
                        nombre_libro = rd.GetString(0),
                        categoria_libro = rd.GetString(1),
                        autor_libro = rd.GetString(2),
                        editorial_libro= rd.GetString(3),
                        copias_libro = rd.GetInt32(4),
                        ISBN = rd.GetString(5)
                    });
                }

                conn.Close();

                return libros;

            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong!");
                throw;
            }
        }

        public List<Libros> getLibrosBy(string filtro, string dato) 
        {
            try
            {
                List<Libros> libros = new List<Libros>();
                conn.Open();

                SqlCommand cmd = new SqlCommand("select * from Mostrar_TblLibros where "+filtro+" LIKE %@dato%",conn);
                //cmd.Parameters.AddWithValue("@filtro", filtro);
                cmd.Parameters.AddWithValue("@dato", dato);

                SqlDataReader rd = cmd.ExecuteReader();

                while(rd.Read())
                {
                    libros.Add(new Libros
                    {
                        nombre_libro = rd.GetString(0),
                        categoria_libro = rd.GetString(1),
                        autor_libro = rd.GetString(2),
                        editorial_libro = rd.GetString(3),
                        copias_libro = rd.GetInt32(4),
                        ISBN = rd.GetString(5)
                    });
                }

                return libros;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
