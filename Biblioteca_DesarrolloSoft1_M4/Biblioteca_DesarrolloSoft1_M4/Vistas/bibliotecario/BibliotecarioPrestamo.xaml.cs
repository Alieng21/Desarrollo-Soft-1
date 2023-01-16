using Biblioteca_DesarrolloSoft1_M4.DataAccess;
using Biblioteca_DesarrolloSoft1_M4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Biblioteca_DesarrolloSoft1_M4.Vistas.bibliotecario
{
    /// <summary>
    /// Lógica de interacción para BibliotecarioPrestamo.xaml
    /// </summary>
    public partial class BibliotecarioPrestamo : Window
    {
        DataDAO data = new DataDAO();
        List<Prestamos> prestamos = new List<Prestamos>();
        Usuarios user = new Usuarios();
        public BibliotecarioPrestamo(Usuarios usuarios)
        {
            InitializeComponent();
            user = usuarios;
            lblNombre.Content = user.nombre_miembro + " " + user.apellido_miembro;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = txtid.Text;

                if (id == null)
                {
                    MessageBox.Show("Debe llenar todos los campos");
                }
                else
                {
                    prestamos = data.getPrestamosByUSer(id);
                    lvPrestamos.ItemsSource = prestamos;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            txtid.Clear();
            lvPrestamos.ItemsSource = null;
        }

        private void btnregistrar_Click(object sender, RoutedEventArgs e)
        {
            string isbn = txtisbn.Text;
            string id = txtidentificacion.Text;
            DateTime fechaprestamo = Convert.ToDateTime(dpfechaprestamo.Text);
            DateTime fechalimite = Convert.ToDateTime(dpfechalimite.Text);
            int copias = Convert.ToInt32(txtcopias.Text);
            data.registrarPrestamo(isbn, id, fechaprestamo, fechalimite, copias);
        }

        private void btnLibros_Click(object sender, RoutedEventArgs e)
        {
            MPBibliotecario mPBibliotecario = new MPBibliotecario(user);
            mPBibliotecario.Show();
            this.Close();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            BibliotecarioUsers bibliotecarioUsers = new BibliotecarioUsers(user);
            bibliotecarioUsers.Show();
            this.Close();
        }

        private void btnDevoluciones_Click(object sender, RoutedEventArgs e)
        {
            BibliotecarioDevolucion bibliotecarioDevolucion = new BibliotecarioDevolucion(user);
            bibliotecarioDevolucion.Show();
            this.Close();
        }

        private void btnCerrarsesion_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnPrestamos_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
