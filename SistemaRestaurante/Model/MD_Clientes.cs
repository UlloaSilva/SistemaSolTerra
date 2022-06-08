using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Model
{
    internal class MD_Clientes
    {
        public int IdCliente { get; set; }
        public string P_Nombre { get; set; }
        public string S_Nombre { get; set; }
        public string P_Apellido { get; set; }
        public string S_Apellido { get; set; }
        public string NoCedula { get; set; }
        public string NoTelefono { get; set; }

    }
}
