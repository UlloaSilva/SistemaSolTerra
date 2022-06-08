using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Model
{
    internal class MD_Mesas
    {
        public int IdMesa { get; set ; }
        public List<MD_Sucursal> Sucursal { get; set; }
        public List<MD_Area> Area { get; set; }
        public string Asientos { get; set; }
        public string Estado { get; set; }
    }
}
