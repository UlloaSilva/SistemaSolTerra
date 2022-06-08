using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Model
{
    internal class MD_Area
    {
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public int CantidadPersonas { get; set; }
        public string Estado { get; set; }
    }
}
