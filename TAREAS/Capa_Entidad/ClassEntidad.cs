using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class ClassEntidad
    {
        public string TareaID { get; set; }
        public string Tarea { get; set;}
        public string Materia { get; set; }
        public DateTime Fecha_asignacion { get; set;}
        public DateTime Fecha_entrega { get; set; }
        public string MedioEntrega { get; set; }
        public string Estado { get; set; }
        public string Accion { get; set; }
    }
}
