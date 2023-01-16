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
    /// Lógica de interacción para BibliotecarioDevolucion.xaml
    /// </summary>
    public partial class BibliotecarioDevolucion : Window
    {
        DataDAO data = new DataDAO();
        List<Devoluciones> devoluciones = new List<Devoluciones>();
        public BibliotecarioDevolucion()
        {
            InitializeComponent();
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
                    devoluciones = data.GetDevolucionesByUSer(id);
                    lvDevoluciones.ItemsSource = devoluciones;
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
            lvDevoluciones.Items.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int idprestamos = Convert.ToInt32(txtidprestamos.Text);
            DateTime dpfecha = Convert.ToDateTime(dpFechadevolucion.Text);
            int copias = Convert.ToInt32(txtcopias.Text);
            data.registrarDevolucion(idprestamos, dpfecha, copias);

            
        }

        private void btnLibros_Click(object sender, RoutedEventArgs e)
        {
            MPBibliotecario mPBibliotecario = new MPBibliotecario();
            mPBibliotecario.Show();
            this.Close();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            BibliotecarioUsers bibliotecarioUsers = new BibliotecarioUsers();
            bibliotecarioUsers.Show();
            this.Close();
        }

        private void btnPrestamos_Click(object sender, RoutedEventArgs e)
        {
            BibliotecarioPrestamo bibliotecarioPrestamo = new BibliotecarioPrestamo();
            bibliotecarioPrestamo.Show();
            this.Close();
        }

        private void btnCerrarsesion_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
