using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_DesarrolloSoft1_M4.Models
{
    public class Devoluciones
    {
        public int id_devolucion { get; set; }
        public int id_prestamo { get; set; }
        public DateTime fecha_devolucion { get; set; }
    }
}
