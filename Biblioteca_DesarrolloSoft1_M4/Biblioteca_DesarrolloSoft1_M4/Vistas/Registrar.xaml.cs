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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biblioteca_DesarrolloSoft1_M4.Vistas
{
    /// <summary>
    /// Lógica de interacción para Registrar.xaml
    /// </summary>
    public partial class Registrar : Page
    {
        DataDAO data = new DataDAO();
        private Miembros miembro = new Miembros();
        public Registrar()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnregistrar_Click(object sender, RoutedEventArgs e)
        {
            miembro.nombre_miembro = txtnombre.Text;
            miembro.apellido_miembro = txtapellido.Text;
            miembro.identificacion_miembro = txtid.Text;
            miembro.email_miembro = txtemail.Text;
            miembro.telefono_miembro = txttelefono.Text;
            miembro.direccion_miembro = txtdireccion.Text;

            string username = txtusername.Text;
            string password = txtpassword.Text;

            data.registrarUsuarios(miembro, 3, username, password);
        }
    }
}
