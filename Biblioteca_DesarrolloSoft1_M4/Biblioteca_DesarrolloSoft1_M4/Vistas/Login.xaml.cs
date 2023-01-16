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
using Biblioteca_DesarrolloSoft1_M4.DataAccess;
using Biblioteca_DesarrolloSoft1_M4.Models;
using Biblioteca_DesarrolloSoft1_M4.Vistas.bibliotecario;
using Biblioteca_DesarrolloSoft1_M4.Vistas.Cliente;

namespace Biblioteca_DesarrolloSoft1_M4.Vistas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        readonly private DataDAO data = new DataDAO();
        public Usuarios usuario = new Usuarios();
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            usuario = data.GetUser(txtusuario.Text, txtpassword.Text);
            usuario.rol = "Admin";
            if (usuario.rol == "Admin")
            {
                MPBibliotecario bibliotecario= new MPBibliotecario(usuario);
                bibliotecario.Show();
                this.Close();


            } else if (usuario.rol == "Bibliotecario")
            {
                MPBibliotecario bibliotecario = new MPBibliotecario(usuario);
                bibliotecario.Show();
                this.Close();
            }
            else if(usuario.rol == "Cliente")
            {
                ClienteMP clienteMP = new ClienteMP(usuario);
                clienteMP.Show();
                this.Close();
            }

        }

        private void txtusuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registrar registrar = new Registrar();
            registrar.Show();
            this.Close();
        }
    }
}
