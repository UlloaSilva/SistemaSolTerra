namespace SistemaRestaurante.View
{
    partial class formClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formClientes));
            this.PnClientesContenedor = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtClientes = new System.Windows.Forms.DataGridView();
            this.txtPnom = new System.Windows.Forms.TextBox();
            this.txtSnom = new System.Windows.Forms.TextBox();
            this.txtPape = new System.Windows.Forms.TextBox();
            this.txtSape = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.pnTituloCliente = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNcedu = new System.Windows.Forms.MaskedTextBox();
            this.txtNtele = new System.Windows.Forms.MaskedTextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.btnHomeMesas = new System.Windows.Forms.Button();
            this.PnClientesContenedor.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtClientes)).BeginInit();
            this.pnTituloCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnClientesContenedor
            // 
            this.PnClientesContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.PnClientesContenedor.Controls.Add(this.btnHomeMesas);
            this.PnClientesContenedor.Controls.Add(this.btnBuscarCliente);
            this.PnClientesContenedor.Controls.Add(this.txtBuscar);
            this.PnClientesContenedor.Controls.Add(this.btnGuardar);
            this.PnClientesContenedor.Controls.Add(this.btnCancelar);
            this.PnClientesContenedor.Controls.Add(this.panel6);
            this.PnClientesContenedor.Controls.Add(this.label8);
            this.PnClientesContenedor.Controls.Add(this.btnEditar);
            this.PnClientesContenedor.Controls.Add(this.panel5);
            this.PnClientesContenedor.Controls.Add(this.btnRegistrar);
            this.PnClientesContenedor.Controls.Add(this.panel4);
            this.PnClientesContenedor.Controls.Add(this.panel3);
            this.PnClientesContenedor.Controls.Add(this.txtNtele);
            this.PnClientesContenedor.Controls.Add(this.panel10);
            this.PnClientesContenedor.Controls.Add(this.txtNcedu);
            this.PnClientesContenedor.Controls.Add(this.panel9);
            this.PnClientesContenedor.Controls.Add(this.label6);
            this.PnClientesContenedor.Controls.Add(this.panel8);
            this.PnClientesContenedor.Controls.Add(this.label7);
            this.PnClientesContenedor.Controls.Add(this.pnTituloCliente);
            this.PnClientesContenedor.Controls.Add(this.panel1);
            this.PnClientesContenedor.Controls.Add(this.label5);
            this.PnClientesContenedor.Controls.Add(this.txtSape);
            this.PnClientesContenedor.Controls.Add(this.txtPnom);
            this.PnClientesContenedor.Controls.Add(this.panel2);
            this.PnClientesContenedor.Controls.Add(this.label3);
            this.PnClientesContenedor.Controls.Add(this.label4);
            this.PnClientesContenedor.Controls.Add(this.txtPape);
            this.PnClientesContenedor.Controls.Add(this.txtSnom);
            this.PnClientesContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnClientesContenedor.Location = new System.Drawing.Point(0, 0);
            this.PnClientesContenedor.Name = "PnClientesContenedor";
            this.PnClientesContenedor.Size = new System.Drawing.Size(1334, 691);
            this.PnClientesContenedor.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.SlateBlue;
            this.panel1.Controls.Add(this.dtClientes);
            this.panel1.Location = new System.Drawing.Point(12, 305);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 355);
            this.panel1.TabIndex = 1;
            // 
            // dtClientes
            // 
            this.dtClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtClientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dtClientes.BackgroundColor = System.Drawing.Color.Lavender;
            this.dtClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtClientes.ColumnHeadersHeight = 40;
            this.dtClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtClientes.EnableHeadersVisualStyles = false;
            this.dtClientes.GridColor = System.Drawing.Color.Gainsboro;
            this.dtClientes.Location = new System.Drawing.Point(0, 0);
            this.dtClientes.Name = "dtClientes";
            this.dtClientes.ReadOnly = true;
            this.dtClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtClientes.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dtClientes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dtClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtClientes.Size = new System.Drawing.Size(856, 355);
            this.dtClientes.TabIndex = 39;
            // 
            // txtPnom
            // 
            this.txtPnom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPnom.BackColor = System.Drawing.Color.SlateBlue;
            this.txtPnom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPnom.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPnom.ForeColor = System.Drawing.Color.GhostWhite;
            this.txtPnom.Location = new System.Drawing.Point(228, 89);
            this.txtPnom.Name = "txtPnom";
            this.txtPnom.Size = new System.Drawing.Size(147, 28);
            this.txtPnom.TabIndex = 2;
            // 
            // txtSnom
            // 
            this.txtSnom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSnom.BackColor = System.Drawing.Color.SlateBlue;
            this.txtSnom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSnom.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSnom.ForeColor = System.Drawing.Color.GhostWhite;
            this.txtSnom.Location = new System.Drawing.Point(660, 90);
            this.txtSnom.Name = "txtSnom";
            this.txtSnom.Size = new System.Drawing.Size(135, 28);
            this.txtSnom.TabIndex = 3;
            // 
            // txtPape
            // 
            this.txtPape.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPape.BackColor = System.Drawing.Color.SlateBlue;
            this.txtPape.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPape.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPape.ForeColor = System.Drawing.Color.GhostWhite;
            this.txtPape.Location = new System.Drawing.Point(235, 162);
            this.txtPape.Name = "txtPape";
            this.txtPape.Size = new System.Drawing.Size(140, 28);
            this.txtPape.TabIndex = 4;
            // 
            // txtSape
            // 
            this.txtSape.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSape.BackColor = System.Drawing.Color.SlateBlue;
            this.txtSape.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSape.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSape.ForeColor = System.Drawing.Color.GhostWhite;
            this.txtSape.Location = new System.Drawing.Point(668, 162);
            this.txtSape.Name = "txtSape";
            this.txtSape.Size = new System.Drawing.Size(140, 28);
            this.txtSape.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegistrar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrar.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistrar.Image")));
            this.btnRegistrar.Location = new System.Drawing.Point(914, 162);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(401, 58);
            this.btnRegistrar.TabIndex = 8;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // pnTituloCliente
            // 
            this.pnTituloCliente.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pnTituloCliente.Controls.Add(this.label1);
            this.pnTituloCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTituloCliente.Location = new System.Drawing.Point(0, 0);
            this.pnTituloCliente.Name = "pnTituloCliente";
            this.pnTituloCliente.Size = new System.Drawing.Size(1334, 38);
            this.pnTituloCliente.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(625, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "CLIENTES";
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.Location = new System.Drawing.Point(891, 89);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(213, 59);
            this.btnEditar.TabIndex = 10;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(1000, 233);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(213, 59);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(66, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 2);
            this.panel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "PRIMER APELLIDO :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(478, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "SEGUNDO NOMBRE :";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(477, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "SEGUNDO APELLIDO :";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(478, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 22);
            this.label6.TabIndex = 14;
            this.label6.Text = "TELEFONO :";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(64, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 22);
            this.label7.TabIndex = 16;
            this.label7.Text = "CEDULA :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(1115, 89);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(213, 59);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNcedu
            // 
            this.txtNcedu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNcedu.BackColor = System.Drawing.Color.SlateBlue;
            this.txtNcedu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNcedu.Font = new System.Drawing.Font("Microsoft YaHei UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNcedu.ForeColor = System.Drawing.Color.GhostWhite;
            this.txtNcedu.Location = new System.Drawing.Point(153, 233);
            this.txtNcedu.Mask = "000-000000-0000L";
            this.txtNcedu.Name = "txtNcedu";
            this.txtNcedu.Size = new System.Drawing.Size(228, 29);
            this.txtNcedu.TabIndex = 14;
            this.txtNcedu.Leave += new System.EventHandler(this.txtNcedu_Leave);
            // 
            // txtNtele
            // 
            this.txtNtele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNtele.BackColor = System.Drawing.Color.SlateBlue;
            this.txtNtele.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNtele.Font = new System.Drawing.Font("Microsoft YaHei UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNtele.ForeColor = System.Drawing.Color.GhostWhite;
            this.txtNtele.Location = new System.Drawing.Point(590, 233);
            this.txtNtele.Mask = "0000-0000";
            this.txtNtele.Name = "txtNtele";
            this.txtNtele.Size = new System.Drawing.Size(123, 29);
            this.txtNtele.TabIndex = 18;
            this.txtNtele.Leave += new System.EventHandler(this.txtNtele_Leave);
            // 
            // panel8
            // 
            this.panel8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel8.Location = new System.Drawing.Point(66, 191);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(315, 2);
            this.panel8.TabIndex = 10;
            // 
            // panel9
            // 
            this.panel9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel9.Location = new System.Drawing.Point(481, 119);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(319, 2);
            this.panel9.TabIndex = 10;
            // 
            // panel10
            // 
            this.panel10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel10.Location = new System.Drawing.Point(481, 191);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(330, 2);
            this.panel10.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Location = new System.Drawing.Point(66, 261);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(316, 2);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Location = new System.Drawing.Point(482, 261);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(235, 2);
            this.panel4.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Location = new System.Drawing.Point(869, 47);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2, 614);
            this.panel5.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(64, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 22);
            this.label8.TabIndex = 19;
            this.label8.Text = "PRIMER NOMBRE :";
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Location = new System.Drawing.Point(5, 305);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1329, 2);
            this.panel6.TabIndex = 12;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscar.BackColor = System.Drawing.Color.SlateBlue;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.GhostWhite;
            this.txtBuscar.Location = new System.Drawing.Point(929, 351);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(322, 28);
            this.txtBuscar.TabIndex = 20;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.Leave += new System.EventHandler(this.txtBuscar_Leave);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBuscarCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarCliente.FlatAppearance.BorderSize = 0;
            this.btnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.Image")));
            this.btnBuscarCliente.Location = new System.Drawing.Point(1257, 348);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(32, 32);
            this.btnBuscarCliente.TabIndex = 22;
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnHomeMesas
            // 
            this.btnHomeMesas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHomeMesas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHomeMesas.FlatAppearance.BorderSize = 0;
            this.btnHomeMesas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHomeMesas.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHomeMesas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomeMesas.Image = ((System.Drawing.Image)(resources.GetObject("btnHomeMesas.Image")));
            this.btnHomeMesas.Location = new System.Drawing.Point(1229, 597);
            this.btnHomeMesas.Name = "btnHomeMesas";
            this.btnHomeMesas.Size = new System.Drawing.Size(60, 60);
            this.btnHomeMesas.TabIndex = 23;
            this.btnHomeMesas.UseVisualStyleBackColor = true;
            this.btnHomeMesas.Click += new System.EventHandler(this.btnHomeMesas_Click);
            // 
            // formClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 691);
            this.Controls.Add(this.PnClientesContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.formClientes_Load);
            this.PnClientesContenedor.ResumeLayout(false);
            this.PnClientesContenedor.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtClientes)).EndInit();
            this.pnTituloCliente.ResumeLayout(false);
            this.pnTituloCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnClientesContenedor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSape;
        private System.Windows.Forms.TextBox txtPape;
        private System.Windows.Forms.TextBox txtSnom;
        private System.Windows.Forms.TextBox txtPnom;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Panel pnTituloCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MaskedTextBox txtNcedu;
        private System.Windows.Forms.MaskedTextBox txtNtele;
        private System.Windows.Forms.DataGridView dtClientes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnHomeMesas;
    }
}