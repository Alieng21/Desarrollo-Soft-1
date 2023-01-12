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

namespace Biblioteca_DesarrolloSoft1_M4.Vistas
{
    /// <summary>
    /// Lógica de interacción para MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        private DataDAO data = new DataDAO();
        public MainPage()
        {
            InitializeComponent();
            bindLibros();
        }

        private void bindLibros()
        {
            List<Libros> libros = data.getLibrosBy("Nombre","Pepito");

            lvLibros.ItemsSource = libros;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
