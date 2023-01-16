using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_DesarrolloSoft1_M4.Models
{
    public class Devoluciones
    {
        public string libro { get; set; }
        public string ISBN { get; set; }
        public string prestatario { get; set; }
        public string identificacion { get; set; }
        public int copias { get; set; }
        public DateTime fecha_devolucion { get; set; }
    }
}
