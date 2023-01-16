using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_DesarrolloSoft1_M4.Models
{
    public class Prestamos
    {
        public int id { get; set; }
        public string libro { get; set; }
        public string ISBN { get; set; }
        public string prestatario { get; set; }

        public string identificacion { get; set; }
        public int copias { get; set; }
        public DateTime fecha_prestamo { get; set; }
        public DateTime fecha_limite { get; set; }
        public string estado { get; set; }
    }
}
