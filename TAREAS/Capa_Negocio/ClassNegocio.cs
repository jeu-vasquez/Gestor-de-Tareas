using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos();

        public DataTable N_listar_tareas()
        {
            return objd.D_listar_tareas();
        }

        public string N_mantenimiento_tareas(ClassEntidad obje)
        {
            return (string)objd.D_mantenimiento_tareas(obje);
        }
    }
}
