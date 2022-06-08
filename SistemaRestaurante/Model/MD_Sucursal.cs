using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Model
{
    internal class MD_Sucursal
	{
		public int IdSucursal { get; set; }
		public string Nombre { get; set; }
		public string NombreEncargado { get; set; }
		public string Telefono { get; set; }
		public string Direccion { get; set; }
		public List<MD_Deparstamento> Departamento { get; set; }
		public string Estado { get; set; }

    }
}
