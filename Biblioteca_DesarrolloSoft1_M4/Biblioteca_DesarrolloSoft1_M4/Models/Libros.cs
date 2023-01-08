using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_DesarrolloSoft1_M4.Models
{
    public class Libros
    {
        public int id_libro { get; set; }
        public string nombre_libro { get; set; }

        public string autor_libro { get; set; }

        public string editorial_libro { get; set; }

        public int copias_libro { get; set; }

        public string ISBN { get; set; }
    }
}
