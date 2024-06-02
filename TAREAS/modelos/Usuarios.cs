using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TAREAS.modelos
{
    public class Usuarios
    {
        public int usuarioId { get; set; }
        public int roleId { get; set; }
        public string nombre { get;set; }
        public string usuario { get;set; }
        public string passwordHash { get;set; }
        public string accion { get; set; }
    }
}
