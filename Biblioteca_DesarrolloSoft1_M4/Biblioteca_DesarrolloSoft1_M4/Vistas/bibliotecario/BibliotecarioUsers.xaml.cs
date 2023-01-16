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
        public BibliotecarioUsers()
        {
            InitializeComponent();
        }

        private void btnLibros_Click(object sender, RoutedEventArgs e)
        {
            MPBibliotecario mPBibliotecario = new MPBibliotecario();
            mPBibliotecario.Show();
            this.Close();
        }
    }
}
