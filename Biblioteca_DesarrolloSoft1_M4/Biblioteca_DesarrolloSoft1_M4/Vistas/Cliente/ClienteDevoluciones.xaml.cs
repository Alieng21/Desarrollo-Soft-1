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
        Usuarios usuarios = new Usuarios();
        public ClienteDevoluciones(Usuarios user)
        {
            InitializeComponent();
            usuarios = user;
            bindData();
            lblNombre.Content = user.nombre_miembro + " " + user.apellido_miembro;
        }

        public void bindData()
        {
            devoluciones = data.GetDevolucionesByUSer(usuarios.identificacion_miembro);
            lvDevoluciones.ItemsSource = devoluciones;
        }

        private void btnLibros_Click(object sender, RoutedEventArgs e)
        {
            ClienteMP clienteMP = new ClienteMP(usuarios);
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
