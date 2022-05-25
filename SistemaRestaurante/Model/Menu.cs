using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Model
{
    public class Menu
    {
        public string nombreMenu { get; set; }
        public string iconMenu { get; set; }
        public List <SubMenu> lstSubMenu { get; set; } 
    }
}
