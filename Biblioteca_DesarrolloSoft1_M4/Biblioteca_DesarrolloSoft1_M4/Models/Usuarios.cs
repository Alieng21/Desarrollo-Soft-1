using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_DesarrolloSoft1_M4.Models
{
    public class Usuarios
    {
        public int id_usuario { get; set; }
        public int id_miembro { get; set; }
        public int id_rol { get; set; }
        public string nombre_usuario { get; set; }
        public string clave_usuario { get; set; }
    }
}
