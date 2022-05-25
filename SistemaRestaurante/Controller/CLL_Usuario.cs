using SistemaRestaurante.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Controller
{
    internal class CLL_Usuario
    {
        public static DataTable Acceso(string userName, string userPassword)
        {
            return new MD_Usuario().Acceso(userName, userPassword);
        }
    }
}
