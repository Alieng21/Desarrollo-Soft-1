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

namespace Biblioteca_DesarrolloSoft1_M4.Vistas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Usuario usuario = new Usuario();
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            int n = usuario.GetUser(txtusuario.Text, txtpassword.Password.ToString());
            if(n == 0)
            {
                MessageBox.Show("Usuario o contraseña invalidos");
            }else if(n ==1)
            {
                MessageBox.Show("Bienvenido admin");
            }else if(n == 2) 
            {
                MessageBox.Show("");
            }else if(n == 3)
            {
                MessageBox.Show("");
            }else if(n == -1)
            {
                MessageBox.Show("Something went wrong!");
            }
        }
    }
}
