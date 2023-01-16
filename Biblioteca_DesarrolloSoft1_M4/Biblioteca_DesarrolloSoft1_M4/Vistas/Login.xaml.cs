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

            if (usuario.rol == "Admin")
            {
                MPBibliotecario bibliotecario= new MPBibliotecario();
                bibliotecario.Show();
                this.Close();



            } else if (usuario.rol == "Bibliotecario")
            {
                
            }else if(usuario.rol == "Cliente")
            {

            }

        }

        private void txtusuario_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
