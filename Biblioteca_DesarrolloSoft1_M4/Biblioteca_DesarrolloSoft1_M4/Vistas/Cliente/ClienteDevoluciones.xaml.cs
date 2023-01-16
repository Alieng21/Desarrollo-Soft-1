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

namespace Biblioteca_DesarrolloSoft1_M4.Vistas.Cliente
{
    /// <summary>
    /// Lógica de interacción para ClienteDevoluciones.xaml
    /// </summary>
    public partial class ClienteDevoluciones : Window
    {
        DataDAO data = new DataDAO();
        List<Devoluciones> devoluciones = new List<Devoluciones>();
        public ClienteDevoluciones()
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

        private void btnLibros_Click(object sender, RoutedEventArgs e)
        {
            ClienteMP clienteMP = new ClienteMP();
            clienteMP.Show();
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
