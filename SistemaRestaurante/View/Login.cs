using SistemaRestaurante.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.View
{
    public partial class Login : Form
    {
        private static int userId { get; set; }
        private static string userName { get; set; }
        private static string userRol { get; set; }
        private static string statusPass { get; set; }
        private static string userSucursal { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            DataTable dataTable;
            dataTable = CLL_Usuario.Acceso(this.txt_UserName.Text, this.pass_UserPass.Text);

            if (dataTable == null)
            {
                MessageBox.Show("No hay Conexión al Servidor", "SolTerraRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dataTable.Rows[0][0].ToString().Equals("Acceso Valido"))
                {
                    userId = (int) dataTable.Rows[0][1];
                    userName = (string) dataTable.Rows[0][2];
                    userRol = (string) dataTable.Rows[0][3];
                    statusPass = (string) dataTable.Rows[0][4];
                    userSucursal = (string) dataTable.Rows[0][5];

                    MessageBox.Show("Bienvenido al Sistema", "SolTerraRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Dashboard dashboard = new Dashboard(userId);
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Acceso Denegado al Sistema SolTerraRestaurant", "SolTerraRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txt_UserName.Text = string.Empty;
                    this.pass_UserPass.Text = string.Empty;
                    txt_UserName.Focus();
                }
            }
        }

        private void pass_UserPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                DataTable dataTable;
                dataTable = CLL_Usuario.Acceso(this.txt_UserName.Text, this.pass_UserPass.Text);

                if (dataTable == null)
                {
                    MessageBox.Show("No hay Conexión al Servidor", "Sistema SolTerraRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow dataRow;
                        dataRow = dataTable.Rows[0];

                        if (dataRow["Resultado"].ToString().Equals("Acceso Valido"))
                        {
                            userId = (int)dataTable.Rows[0][1];
                            userName = (string)dataTable.Rows[0][2];
                            userRol = (string)dataTable.Rows[0][3];
                            statusPass = (string)dataTable.Rows[0][4];
                            userSucursal = (string)dataTable.Rows[0][5];

                            MessageBox.Show("Bienvenido al Sistema", "SolTerraRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            Dashboard dashboard = new Dashboard(userId);
                            dashboard.Show();
                        }
                        else
                        {
                            MessageBox.Show("Acceso Denegado al Sistema SolTerraRestaurant", "Sistema SolTerraRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_UserName.Text = string.Empty;
                            pass_UserPass.Text = string.Empty;
                            txt_UserName.Focus();
                        }
                    }
                }
            }
        }

    }
}
