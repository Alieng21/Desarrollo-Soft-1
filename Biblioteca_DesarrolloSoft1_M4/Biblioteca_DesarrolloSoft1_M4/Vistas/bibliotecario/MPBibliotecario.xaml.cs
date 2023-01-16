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
        private List<Libros> libros = new List<Libros>();
        
        public MPBibliotecario()
        {
            InitializeComponent();
            bindData();   
        }

        private void bindData()
        {
            libros = data.getAllLibros();
            lvLibros.ItemsSource = libros;
        }

    
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filtro = cbFiltro.Text;
                string dato = txtBuscar.Text;

                if (filtro == null || dato == null)
                {
                    MessageBox.Show("Debe llenar todos los campos");
                }
                else
                {
                    libros = data.getLibrosBy(filtro, dato);
                    lvLibros.ItemsSource = libros;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            cbFiltro.SelectedIndex = -1;
            txtBuscar.Clear();
            bindData();
        }

        private void btnLibros_Click_1(object sender, RoutedEventArgs e)
        {
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            BibliotecarioUsers bibliotecarioUsers = new BibliotecarioUsers();
            bibliotecarioUsers.Show();
            this.Close();
        }
    }
}
