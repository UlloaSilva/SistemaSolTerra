using SistemaRestaurante.Controller;
using SistemaRestaurante.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.View
{
    public partial class formClientes : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private ErrorProvider errorProvider0, errorProvider1;

        public formClientes()
        {
            InitializeComponent();
            InicializaErrorProvider();
        }

        private void formClientes_Load(object sender, EventArgs e)
        {
            Habilitar(false);
            this.txtBuscar.Visible = false;
            this.dtClientes.DataSource = CLL_Cliente.VistaClientes();
            this.dtClientes.Columns[0].Visible = false;
            
        }
        #region BOTONES
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnRegistrar.Enabled = false;
                this.btnEditar.Enabled = false;
            }
            else
            {
                this.Habilitar(false);
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
                this.btnRegistrar.Enabled = true;
                this.btnEditar.Enabled = true;
            }
        }
        private void Habilitar(bool Valor)
        {
            this.txtPnom.ReadOnly = !Valor;
            this.txtSnom.ReadOnly = !Valor;
            this.txtPape.ReadOnly = !Valor;
            this.txtSape.ReadOnly = !Valor;
            this.txtNcedu.ReadOnly = !Valor;
            this.txtNtele.ReadOnly = !Valor;
        }
        private void Limpiar()
        {
            this.txtPnom.Text = string.Empty;
            this.txtSnom.Text = string.Empty;
            this.txtPape.Text = string.Empty;
            this.txtSape.Text = string.Empty;
            this.txtNcedu.Text = string.Empty;
            this.txtNtele.Text = string.Empty;
        }
        #endregion


        #region VALIDAR
        private void txtNcedu_Leave(object sender, EventArgs e)
        {
            if (!txtNcedu.MaskCompleted)
            {
                errorProvider0.SetError(txtNcedu, "Campo Obligatorio.");
            }
            else
            {
                errorProvider0.Clear();
                txtNcedu.Text = txtNcedu.Text.ToUpper();
                validarCedula();
            }
        }
        private bool validarCedula()
        {
            bool bandera = false;
            try
            {
                string fechaString = txtNcedu.Text.Substring(4, 6);
                DateTime dateTime = DateTime.ParseExact(fechaString, "ddMMyy", null);
                bandera = true;
            }
            catch
            {
                errorProvider0.SetError(txtNcedu, "Cédula Incorrecta");
                bandera = false;
            }
            return bandera;
        }

        private void txtNtele_Leave(object sender, EventArgs e)
        {
            if (!txtNtele.MaskCompleted)
            {
                errorProvider1.SetError(txtNtele, "Campo Obligatorio.");
            }
            else
            {
                errorProvider1.Clear();
                validarTelefono();
            }
        }
        private bool validarTelefono()
        {
            int telefonoInt = Convert.ToInt32(txtNtele.Text.Substring(0, 1));
            bool bandera = false;

            if (telefonoInt != 8 && telefonoInt != 7 && telefonoInt != 5 && telefonoInt != 2)
            {
                errorProvider1.SetError(txtNtele, "Iniciar Con: 8, 7, 5 o 2");
                bandera = false;
            }
            else
            {
                bandera = true;
            }
            return bandera;
        }

        #endregion


        private void InicializaErrorProvider()
        {
            errorProvider0 = new ErrorProvider();
            errorProvider1 = new ErrorProvider();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtPnom.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataTable data;

            if (this.dtClientes.SelectedRows.Count == 1)
            {
                data = CLL_Cliente.VistaClienteId(Convert.ToInt32(this.dtClientes.CurrentRow.Cells["Id Cliente"].Value));
                txtPnom.Text = (string)data.Rows[0][0];
                txtSnom.Text = (string)data.Rows[0][1];
                txtPape.Text = (string)data.Rows[0][2];
                txtSape.Text = (string)data.Rows[0][3];
                txtNcedu.Text = (string)data.Rows[0][4];
                txtNtele.Text = (string)data.Rows[0][5];

                this.IsNuevo = false;
                this.IsEditar = true;
                this.Botones();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una Fila antes de Modificar", "Sistema SolTerraRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.dtClientes.CurrentCell = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            this.txtBuscar.Visible = true;
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            this.txtBuscar.Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.dtClientes.DataSource = CLL_Cliente.BS_Cliente_SC(this.txtBuscar.Text);    
        }

        private void btnHomeMesas_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rgCliente = string.Empty;
                bool valCedu = validarCedula();
                bool valTele = validarTelefono();
                if (this.IsNuevo && (valCedu != false) && (valTele != false))
                {
                    rgCliente = CLL_Cliente.RG_Clientes(this.txtPnom.Text, this.txtSnom.Text, this.txtPape.Text, this.txtSape.Text, this.txtNcedu.Text, this.txtNtele.Text);

                }
                else if ((valCedu != false) && (valTele != false))
                {
                    rgCliente = CLL_Cliente.ED_Clientes(Convert.ToInt32(this.dtClientes.CurrentRow.Cells["Id Cliente"].Value),
                        this.txtPnom.Text, this.txtSnom.Text, this.txtPape.Text, this.txtSape.Text, this.txtNcedu.Text, this.txtNtele.Text);

                }

                if (rgCliente.Equals("OK"))
                {
                    if (this.IsNuevo)
                    {
                        MessageBox.Show("Cliente Registrado", "Sistema SolTerraRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Datos Actualizados", "Sistema SolTerraRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(rgCliente, "Sistema SolTerraRestaurant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.IsNuevo = false;
                this.IsEditar = false;
                this.Botones();
                this.Limpiar();

                this.dtClientes.DataSource = CLL_Cliente.VistaClientes();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Message: ", ex.Message + ex.StackTrace);
            }
        }
    }
}
