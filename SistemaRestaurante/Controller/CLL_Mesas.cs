using SistemaRestaurante.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SistemaRestaurante.Controller
{
    internal class CLL_Mesas
    {
        public static List<MD_Mesas> Mesas (int IdUser)
        {
            List<MD_Mesas> Permisos = new List<MD_Mesas>();

            using (SqlConnection sqlConnection = new SqlConnection(Coneccion.Cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("MesasXML", sqlConnection);
                    cmd.Parameters.AddWithValue("IdUser", IdUser);
                    cmd.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();

                    XmlReader leerXML = cmd.ExecuteXmlReader();

                    while (leerXML.Read())
                    {
                        XDocument xmlDoc = XDocument.Load(leerXML);

                        if (xmlDoc.Element("Usuarios") != null)
                        {
                            Permisos = xmlDoc.Element("Usuarios").Element("DetalleMesa") == null ? new List<MD_Mesas>() :
                                (
                                     from _Mesas in xmlDoc.Element("Usuarios").Element("DetalleMesa").Elements("Mesa")
                                     select new MD_Mesas()
                                     {
                                         Asientos = _Mesas.Element("CantidadAsientos").Value,
                                         Estado = _Mesas.Element("Estado").Value,
                                         Sucursal = _Mesas.Element("DetalleSucMesa") == null ? new List<MD_Sucursal>() :
                                         (
                                            from Sucursal in _Mesas.Element("DetalleSucMesa").Elements("SucursalMesas")
                                            select new MD_Sucursal()
                                            {
                                                Nombre = Sucursal.Element("NombreSucursal").Value
                                            }
                                         ).ToList(),

                                         Area = _Mesas.Element("DetalleAreMesa") == null ? new List<MD_Area>():
                                         (
                                            from Area in _Mesas.Element("DetalleAreMesa").Elements("AreaMesas")
                                            select new MD_Area()
                                            {
                                                Nombre = Area.Element("NombreArea").Value
                                            }
                                         ).ToList()
                                     }
                                ) .ToList();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception Message: ", ex.Message);
                    Permisos = new List<MD_Mesas>();
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
                }
            }
            return Permisos;
        }
    }
}
