using SistemaRestaurante.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRestaurante.Controller
{
    internal class CLL_Cliente
    {

        public static DataTable VistaClientes()
        {
            DataTable Clientes = new DataTable("Vista Clientes");

            using (SqlConnection sqlConnection = new SqlConnection(Coneccion.Cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("MS_Clientes", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                    sqlData.Fill(Clientes);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception Message: ", ex.Message);
                    Clientes = null;
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
                }
                return Clientes;
            }
        }

        public static DataTable VistaClienteId(int IdUser)
        {
            DataTable Clientes = new DataTable("Vista ClienteId");

            using (SqlConnection sqlConnection = new SqlConnection(Coneccion.Cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("VS_ID_Cliente", sqlConnection);
                    cmd.Parameters.AddWithValue("IdCliente", IdUser);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
                    sqlData.Fill(Clientes);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception Message: ", ex.Message);
                    Clientes = null;
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
                }
                return Clientes;
            }
        }

        public static DataTable BS_Cliente_SC(string Element)
        {
            DataTable table = new DataTable("BS_Cliente_SC");

            using (SqlConnection sqlConnection = new SqlConnection(Coneccion.Cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("BS_Cliente_SC", sqlConnection);
                    cmd.Parameters.AddWithValue("Element", Element);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(table);
                }catch (Exception ex)
                {
                    Debug.WriteLine("Exception Message: ", ex.Message);
                    table = null;
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
                }
            }
            return table;
        }


        public static string RG_Clientes (string P_Nombre, string S_Nombre, string P_Apellido, string S_Apellido, string NoCedula, string NoTelefono)
        {
            MD_Clientes obj = new MD_Clientes
            {
                P_Nombre = P_Nombre,
                S_Nombre = S_Nombre,
                P_Apellido = P_Apellido,
                S_Apellido = S_Apellido,
                NoCedula = NoCedula,
                NoTelefono = NoTelefono
            };
            return CLL_Cliente.RG_Clientes(obj);
        }

        public static string ED_Clientes(int IdCliente, string P_Nombre, string S_Nombre, string P_Apellido, string S_Apellido, string NoCedula, string NoTelefono)
        {
            MD_Clientes obj = new MD_Clientes
            {
                IdCliente = IdCliente,
                P_Nombre = P_Nombre,
                S_Nombre = S_Nombre,
                P_Apellido = P_Apellido,
                S_Apellido = S_Apellido,
                NoCedula = NoCedula,
                NoTelefono = NoTelefono
            };
            return CLL_Cliente.ED_Clientes(obj);
        }

        private static string RG_Clientes (MD_Clientes clientes)
        {
            string rgCliente = string.Empty;

            using (SqlConnection sqlConnection = new SqlConnection(Coneccion.Cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("RG_Clientes", sqlConnection);
                    cmd.Parameters.AddWithValue("P_Nombre", clientes.P_Nombre);
                    cmd.Parameters.AddWithValue("S_Nombre", clientes.S_Nombre);
                    cmd.Parameters.AddWithValue("P_Apellido", clientes.P_Apellido);
                    cmd.Parameters.AddWithValue("S_Apellido", clientes.S_Apellido);
                    cmd.Parameters.AddWithValue("No_Cedula", clientes.NoCedula);
                    cmd.Parameters.AddWithValue("No_Telefono", clientes.NoTelefono);
                    cmd.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();
                    rgCliente = cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al Registrar Cliente";
                }
                catch (Exception ex)
                {
                    rgCliente = ex.Message;
                    Debug.WriteLine("Exception Message: ", ex.Message);
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
                }

                return rgCliente;
            }
        }

        private static string ED_Clientes (MD_Clientes clientes)
        {
            string edCliente = string.Empty;

            using (SqlConnection sqlConnection = new SqlConnection(Coneccion.Cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ED_Clientes", sqlConnection);
                    cmd.Parameters.AddWithValue("IdCliente", clientes.IdCliente);
                    cmd.Parameters.AddWithValue("P_Nombre", clientes.P_Nombre);
                    cmd.Parameters.AddWithValue("S_Nombre", clientes.S_Nombre);
                    cmd.Parameters.AddWithValue("P_Apellido", clientes.P_Apellido);
                    cmd.Parameters.AddWithValue("S_Apellido", clientes.S_Apellido);
                    cmd.Parameters.AddWithValue("No_Cedula", clientes.NoCedula);
                    cmd.Parameters.AddWithValue("No_Telefono", clientes.NoTelefono);
                    cmd.CommandType = CommandType.StoredProcedure;

                    sqlConnection.Open();
                    edCliente = cmd.ExecuteNonQuery() == 1 ? "OK" : "Error al Editar Cliente";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception Message: ", ex.Message);
                    edCliente = string.Empty;
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open) sqlConnection.Close();
                }
            }

            return edCliente;
        }

    }
}
