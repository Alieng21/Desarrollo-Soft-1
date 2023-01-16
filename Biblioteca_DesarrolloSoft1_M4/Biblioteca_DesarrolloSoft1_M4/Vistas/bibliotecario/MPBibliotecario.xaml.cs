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

namespace Biblioteca_DesarrolloSoft1_M4.Vistas.bibliotecario
{
    /// <summary>
    /// Lógica de interacción para MPBibliotecario.xaml
    /// </summary>
    public partial class MPBibliotecario : Window
    {
        private DataDAO data = new DataDAO();
        public MPBibliotecario()
        {
            InitializeComponent();
            bindData();
        }

        private void bindData()
        {
            List <Libros> libros = data.getAllLibros();
            lvLibros.ItemsSource = libros;
        }
    }
}
