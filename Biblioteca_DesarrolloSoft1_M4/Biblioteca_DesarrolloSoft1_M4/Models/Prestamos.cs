using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_DesarrolloSoft1_M4.Models
{
    public class Prestamos
    {
        public int id_prestamo { get; set; }
        public int id_libro { get; set; }
        public int id_usuario { get; set; }
        public int id_estado { get; set; }
        public DateTime fecha_retiro { get; set; }
        public DateTime fecha_entrega { get; set; }
    }
}
