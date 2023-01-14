using Biblioteca_DesarrolloSoft1_M4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
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

                SqlCommand cmd = new SqlCommand("select * from Mostrar_TblLibros where "+filtro+" = @dato",conn);

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

<<<<<<< Updated upstream
        public List<Usuarios> getAllUsuarios()
        {

            try
            {

                List<Usuarios> usuarios = new List<Usuarios>();
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Mostrar_TblUsuario", conn);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    usuarios.Add(new Usuarios
                    {
                        nombre_miembro = rd.GetString(0),
                        apellido_miembro = rd.GetString(1),
                        nombre_usuario = rd.GetString(2),
                        rol = rd.GetString(3),
                        identificacion_miembro = rd.GetString(4),
                        email_miembro = rd.GetString(5),
                        telefono_miembro = rd.GetString(6),
                        direccion_miembro = rd.GetString(7)

                    });
                }

                conn.Close();

                return usuarios;

            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong!");
                throw;
            }



        }

        public List<Usuarios> getUsuariosBy(string filtro, string dato)
        {
            try
            {
                List<Usuarios> usuarios = new List<Usuarios>();
                conn.Open();

                SqlCommand cmd = new SqlCommand("select * from Mostrar_TblUsuario where " + filtro + " LIKE %@dato%", conn);
                //cmd.Parameters.AddWithValue("@filtro", filtro);
                cmd.Parameters.AddWithValue("@dato", dato);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    usuarios.Add(new Usuarios
                    {
                        nombre_miembro = rd.GetString(0),
                        apellido_miembro = rd.GetString(1),
                        nombre_usuario = rd.GetString(2),
                        rol = rd.GetString(3),
                        identificacion_miembro = rd.GetString(4),
                        email_miembro = rd.GetString(5),
                        telefono_miembro = rd.GetString(6),
                        direccion_miembro = rd.GetString(7)
                    });
                }

                return usuarios;
=======
        public void RegistrarPrestamo(string isbn,string identificacion,DateTime fecha_prestamo,DateTime fecha_limite,int copias)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select Id from Mostrar_TblLibros where ISBN = @isbn",conn);
                cmd.Parameters.AddWithValue("@isbn", isbn);
                int idlibro = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("select IdUsuario from Mostrar_TblUsuario where ID = @identificacion",conn);
                cmd.Parameters.AddWithValue("@identificacion", identificacion);
                int idusuario = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("Insertar_TblPrestamos",conn);
                cmd.CommandType =CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_libro", idlibro);
                cmd.Parameters.AddWithValue("@id_usuario", idusuario);
                cmd.Parameters.AddWithValue("@id_estado", 1);
                cmd.Parameters.AddWithValue("@fecha_prestamo", fecha_prestamo);
                cmd.Parameters.AddWithValue("@fecha_limite", fecha_limite);
                cmd.Parameters.AddWithValue("@copias_libro", copias);

                int x = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (x = 2)
                {
                    MessageBox.Show("Se ejecuto correctamente!");
                }
                else
                {
                    MessageBox.Show("Hubo un error!");

                }



                conn.Close();
>>>>>>> Stashed changes
            }
            catch (Exception)
            {

<<<<<<< Updated upstream
                throw;
            }
        }



=======
                MessageBox.Show("Hubo un error!");
            }
        }
>>>>>>> Stashed changes
    }


    }

