﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAREAS.modelos
{
    public class Menus
    {
        public string Nombre { get; set; }
        public string Icono { get; set; }
        public List<SubMenu> ListaSubMenu { get; set; }
    }
}
