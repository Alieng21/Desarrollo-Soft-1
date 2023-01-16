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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Biblioteca_DesarrolloSoft1_M4.Vistas.Cliente
{
    /// <summary>
    /// Lógica de interacción para ClienteMP.xaml
    /// </summary>
    public partial class ClienteMP : Window
    {
        DataDAO data = new DataDAO();
        List<Prestamos> prestamos = new List<Prestamos>();
        Usuarios usuarios= new Usuarios();

        public ClienteMP(Usuarios user)
        {
            InitializeComponent();
            usuarios = user;
            bindData();
            lblNombre.Content = user.nombre_miembro + " " + user.apellido_miembro;
        }

        public void bindData()
        {
            prestamos = data.getPrestamosByUSer(usuarios.identificacion_miembro);
            lvPrestamos.ItemsSource = prestamos;
        }

        private void btnCerrarsesion_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnDevoluciones_Click(object sender, RoutedEventArgs e)
        {
            ClienteDevoluciones clienteDevoluciones = new ClienteDevoluciones(usuarios);
            clienteDevoluciones.Show();
            this.Close();
        }
    }
}
