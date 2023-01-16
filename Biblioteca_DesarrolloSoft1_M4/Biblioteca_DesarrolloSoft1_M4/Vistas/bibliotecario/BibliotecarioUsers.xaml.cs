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
    /// Lógica de interacción para BibliotecarioUsers.xaml
    /// </summary>
    public partial class BibliotecarioUsers : Window
    {
        DataDAO data = new DataDAO();
        private List<Usuarios> usuarios = new List<Usuarios>();
        public BibliotecarioUsers()
        {
            InitializeComponent();
            bindData();
        }

        private void bindData()
        {
            usuarios = data.getAllUsuarios();
            lvUsers.ItemsSource = usuarios;
        }

        private void btnLibros_Click(object sender, RoutedEventArgs e)
        {
            MPBibliotecario mPBibliotecario = new MPBibliotecario();
            mPBibliotecario.Show();
            this.Close();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filtro = cbFiltro.Text;
                string dato = txtBuscar.Text;

                if (filtro == null || dato == null)
                {
                    MessageBox.Show("Debe llenar todos los campos");
                }
                else
                {
                    usuarios = data.getUsuariosBy(filtro, dato);
                    lvUsers.ItemsSource = usuarios;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            cbFiltro.SelectedIndex = -1;
            txtBuscar.Clear();
            bindData();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrestamos_Click(object sender, RoutedEventArgs e)
        {
            BibliotecarioPrestamo bibliotecarioPrestamo = new BibliotecarioPrestamo();
            bibliotecarioPrestamo.Show();
            this.Close();
        }

        private void btnDevoluciones_Click(object sender, RoutedEventArgs e)
        {
            BibliotecarioDevolucion bibliotecarioDevolucion = new BibliotecarioDevolucion();
            bibliotecarioDevolucion.Show();
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
