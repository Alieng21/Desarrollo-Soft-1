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
using System.Threading.Channels;

namespace Biblioteca_DesarrolloSoft1_M4.DataAccess
{
    public class DataDAO
    {
        private readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);

        
        public Usuarios GetUser(string username, string password)
        {
            Usuarios user = new Usuarios();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from TblUsuarios where nombre_usuario = @username and clave_usuario = @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    rd.Close();
                    cmd = new SqlCommand("select * from Mostrar_TblUsuario where usuario = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader rd2 = cmd.ExecuteReader();
                    if (rd2.Read())
                    {
                        user.nombre_miembro = rd2.GetString(1);
                        user.apellido_miembro = rd2.GetString(2);
                        user.nombre_usuario = rd2.GetString(3);
                        user.rol = rd2.GetString(4);
                        user.identificacion_miembro = rd2.GetString(5);
                        user.email_miembro = rd2.GetString(6);
                        user.telefono_miembro = rd2.GetString(7);
                        user.direccion_miembro = rd2.GetString(8);
                    }

                }
                else
                {
                    MessageBox.Show("Nombre de usuario o Contraseña incorrecta!");
                }
                conn.Close();

                return user;
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error" + e.ToString());
                return user;
            }
        }

        public List<Libros> getAllLibros()
        {
            try
            {
                List<Libros> libros = new List<Libros>();

                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Mostrar_TblLibros", conn);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    libros.Add(new Libros
                    {
                        nombre_libro = rd.GetString(1),
                        categoria_libro = rd.GetString(2),
                        autor_libro = rd.GetString(3),
                        editorial_libro = rd.GetString(4),
                        copias_libro = rd.GetInt32(5),
                        ISBN = rd.GetString(6)
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

                SqlCommand cmd = new SqlCommand("select * from Mostrar_TblLibros where " + filtro + " = @dato", conn);

                cmd.Parameters.AddWithValue("@dato", dato);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    libros.Add(new Libros
                    {
                        nombre_libro = rd.GetString(1),
                        categoria_libro = rd.GetString(2),
                        autor_libro = rd.GetString(3),
                        editorial_libro = rd.GetString(4),
                        copias_libro = rd.GetInt32(5),
                        ISBN = rd.GetString(6)
                    });
                }
                conn.Close();
                return libros;
            }
            catch (Exception)
            {

                throw;
            }
        }

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
                        nombre_miembro = rd.GetString(1),
                        apellido_miembro = rd.GetString(2),
                        nombre_usuario = rd.GetString(3),
                        rol = rd.GetString(4),
                        identificacion_miembro = rd.GetString(5),
                        email_miembro = rd.GetString(6),
                        telefono_miembro = rd.GetString(7),
                        direccion_miembro = rd.GetString(8)

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

                SqlCommand cmd = new SqlCommand("select * from Mostrar_TblUsuario where " + filtro + " = @dato", conn);
                cmd.Parameters.AddWithValue("@dato", dato);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    usuarios.Add(new Usuarios
                    {
                        nombre_miembro = rd.GetString(1),
                        apellido_miembro = rd.GetString(2),
                        nombre_usuario = rd.GetString(3),
                        rol = rd.GetString(4),
                        identificacion_miembro = rd.GetString(5),
                        email_miembro = rd.GetString(6),
                        telefono_miembro = rd.GetString(7),
                        direccion_miembro = rd.GetString(8)
                    });
                }
                conn.Close();
                return usuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void registrarPrestamo(string isbn, string identificacion, DateTime fecha_prestamo, DateTime fecha_limite, int copias)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Insertar_TblPrestamos", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@isbn", isbn);
                cmd.Parameters.AddWithValue("@identificacion", identificacion);
                cmd.Parameters.AddWithValue("@id_estado", 1);
                cmd.Parameters.AddWithValue("@fecha_prestamo", fecha_prestamo);
                cmd.Parameters.AddWithValue("@fecha_limite", fecha_limite);
                cmd.Parameters.AddWithValue("@copias_libro", copias);

                int x = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (x == 2)
                {
                    MessageBox.Show("Se ejecuto correctamente!");
                }
                else
                {
                    MessageBox.Show("Hubo un error!");

                }

                conn.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error!");
            }
        }

        public void registrarDevolucion(int id_prestamo, DateTime fecha_devolucion, int copias)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Insertar_TblDevoluciones", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_prestamo", id_prestamo);
                cmd.Parameters.AddWithValue("@fecha_devolucion", fecha_devolucion);
                cmd.Parameters.AddWithValue("@copias_libro", copias);

                int x = Convert.ToInt32(cmd.ExecuteNonQuery());

                if (x == 3)
                {
                    MessageBox.Show("Se ejecuto correctamente!");
                }
                else
                {
                    MessageBox.Show("Hubo un error!");

                }

                conn.Close();

            }
            catch (Exception e)
            {

                MessageBox.Show("Hubo un error!" + e.ToString());

            }
        }

        public List<Prestamos> getPrestamosByUSer(string identificacion)
        {
            List<Prestamos> prestamos = new List<Prestamos>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Mostrar_TblPrestamos where Identificacion = @id", conn);
                cmd.Parameters.AddWithValue("@id", identificacion);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    prestamos.Add(new Prestamos
                    {
                        id = rd.GetInt32(0),
                        libro = rd.GetString(1),
                        ISBN = rd.GetString(2),
                        prestatario = rd.GetString(3),
                        identificacion = rd.GetString(4),
                        copias = rd.GetInt32(5),
                        fecha_prestamo = rd.GetDateTime(6),
                        fecha_limite = rd.GetDateTime(7),
                        estado = rd.GetString(8)
                    });
                }
                conn.Close();

                return prestamos;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
                return prestamos;
            }
        }

        public List<Devoluciones> GetDevolucionesByUSer(string identificacion)
        {
            List<Devoluciones> devoluciones = new List<Devoluciones>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Mostrar_TblDevoluciones where Identificacion = @id", conn);
                cmd.Parameters.AddWithValue("@id", identificacion);

                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    devoluciones.Add(new Devoluciones
                    {
                        libro = rd.GetString(0),
                        ISBN = rd.GetString(1),
                        prestatario = rd.GetString(2),
                        identificacion = rd.GetString(3),
                        copias = rd.GetInt32(4),
                        fecha_devolucion = rd.GetDateTime(5)
                    });
                }

                return devoluciones;
                
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong!");
                return devoluciones;
            }
        }
        public void registrarUsuarios(Miembros miembro, int rol, string username, string password)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Insertar_TblMiembros", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre_miembro", miembro.nombre_miembro);
                cmd.Parameters.AddWithValue("@apellido_miembro", miembro.apellido_miembro);
                cmd.Parameters.AddWithValue("@identificacion_miembro", miembro.identificacion_miembro);
                cmd.Parameters.AddWithValue("@email_miembro", miembro.email_miembro);
                cmd.Parameters.AddWithValue("@telefono_miembro", miembro.telefono_miembro);
                cmd.Parameters.AddWithValue("@direccion_miembro", miembro.direccion_miembro);

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("select * from TblMiembros order by id_miembro desc", conn);
                int id_miembro = Convert.ToInt32(cmd.ExecuteScalar());

                cmd = new SqlCommand("Insertar_TblUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_miembro", id_miembro);
                cmd.Parameters.AddWithValue("@id_rol", rol);
                cmd.Parameters.AddWithValue("@nombre_usuario", username);
                cmd.Parameters.AddWithValue("@clave_usuario", password);

                int x = cmd.ExecuteNonQuery();

                conn.Close();

                if (x == 1)
                {
                    MessageBox.Show("Se registro correctamente!");
                }
                else
                {
                    MessageBox.Show("Algo salio mal!");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Something went wrong!");
            }
        }
    }
}
             