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
        public BibliotecarioPrestamo()
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
                    prestamos = data.getPrestamosByUSer(id);
                    lvDevoluciones.ItemsSource = prestamos;
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

        private void btnregistrar_Click(object sender, RoutedEventArgs e)
        {
            string isbn = txtisbn.Text;
            string id = txtidentificacion.Text;
            DateTime fechaprestamo = Convert.ToDateTime(dpfechaprestamo.Text);
            DateTime fechalimite = Convert.ToDateTime(dpfechalimite.Text);
            int copias = Convert.ToInt32(txtcopias.Text);
            data.registrarPrestamo(isbn, id, fechaprestamo, fechalimite, copias);
        }
    }
}
