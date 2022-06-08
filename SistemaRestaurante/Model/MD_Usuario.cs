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

namespace SistemaRestaurante.Model
{
    internal class MD_Usuario
    {
        public DataTable Acceso(string User, string Password)
        {
            DataTable dataTable = new DataTable("Logging_In");
            SqlConnection sqlConnection = new SqlConnection();

            try
            {
                sqlConnection.ConnectionString = Coneccion.Cn;
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = "Acceso",
                    CommandType = CommandType.StoredProcedure
                };

                // Parametros que estan registrados en el procesoAlmacenado

                // USER
                SqlParameter sqlParUser = new SqlParameter
                {
                    ParameterName = "@User",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 80,
                    Value = User
                };
                sqlCommand.Parameters.Add(sqlParUser);

                SqlParameter sqlParPassword = new SqlParameter
                {
                    ParameterName = "@Pass",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = Password
                };
                sqlCommand.Parameters.Add(sqlParPassword);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception)
            {
                dataTable = null;
            }
            return dataTable;
        }

        public static List<Menu> ltsPermisos(int UserId)
        {
            List <Menu> Permisos = new List<Menu>();
            

            using (SqlConnection sqlConnection = new SqlConnection(Coneccion.Cn))
            {
                try
                {

                    SqlCommand sqlCommand = new SqlCommand("XML", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("IdUser", UserId);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();

                    XmlReader leerXML = sqlCommand.ExecuteXmlReader();

                    while (leerXML.Read())
                    {
                        XDocument xmlDoc = XDocument.Load(leerXML);

                        if (xmlDoc.Element("Permisos") != null)
                        {
                            Permisos = xmlDoc.Element("Permisos").Element("DetalleMenu") == null ? new List<Menu>() :
                                (
                                    from Menu in xmlDoc.Element("Permisos").Element("DetalleMenu").Elements("Menu")
                                    select new Menu()
                                    {
                                        nombreMenu = Menu.Element("Nombre").Value,
                                        iconMenu = Menu.Element("Icon").Value,
                                        lstSubMenu = Menu.Element("DetalleSubMenu") == null ? new List<SubMenu>() :
                                        (
                                            from SubMenu in Menu.Element("DetalleSubMenu").Elements("SubMenu")
                                            select new SubMenu()
                                            {
                                                nombreSubMenu = SubMenu.Element("Nombre").Value,
                                                FormSubMenu = SubMenu.Element("NombreFormulario").Value
                                            }
                                        ).ToList()
                                    }
                                ).ToList();
                        } 
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception Message: " + ex.Message);
                    Permisos = new List<Menu>();
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
