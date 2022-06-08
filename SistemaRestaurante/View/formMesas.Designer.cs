namespace SistemaRestaurante.View
{
    partial class formMesas
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
            this.pnTituloCliente = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PnMesasContenedor = new System.Windows.Forms.Panel();
            this.tbPnTerraza = new System.Windows.Forms.TableLayoutPanel();
            this.tbPnNoFumadores = new System.Windows.Forms.TableLayoutPanel();
            this.tbPnFumadores = new System.Windows.Forms.TableLayoutPanel();
            this.pnTituloCliente.SuspendLayout();
            this.PnMesasContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTituloCliente
            // 
            this.pnTituloCliente.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.pnTituloCliente.Controls.Add(this.label2);
            this.pnTituloCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTituloCliente.Location = new System.Drawing.Point(0, 0);
            this.pnTituloCliente.Name = "pnTituloCliente";
            this.pnTituloCliente.Size = new System.Drawing.Size(1334, 38);
            this.pnTituloCliente.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(625, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "MESAS";
            // 
            // PnMesasContenedor
            // 
            this.PnMesasContenedor.Controls.Add(this.tbPnFumadores);
            this.PnMesasContenedor.Controls.Add(this.tbPnNoFumadores);
            this.PnMesasContenedor.Controls.Add(this.tbPnTerraza);
            this.PnMesasContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnMesasContenedor.Location = new System.Drawing.Point(0, 38);
            this.PnMesasContenedor.Name = "PnMesasContenedor";
            this.PnMesasContenedor.Size = new System.Drawing.Size(1334, 653);
            this.PnMesasContenedor.TabIndex = 11;
            // 
            // tbPnTerraza
            // 
            this.tbPnTerraza.ColumnCount = 3;
            this.tbPnTerraza.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.37759F));
            this.tbPnTerraza.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.62241F));
            this.tbPnTerraza.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tbPnTerraza.Location = new System.Drawing.Point(12, 125);
            this.tbPnTerraza.Name = "tbPnTerraza";
            this.tbPnTerraza.RowCount = 2;
            this.tbPnTerraza.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPnTerraza.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPnTerraza.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbPnTerraza.Size = new System.Drawing.Size(378, 259);
            this.tbPnTerraza.TabIndex = 0;
            // 
            // tbPnNoFumadores
            // 
            this.tbPnNoFumadores.ColumnCount = 3;
            this.tbPnNoFumadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPnNoFumadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPnNoFumadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tbPnNoFumadores.Location = new System.Drawing.Point(454, 125);
            this.tbPnNoFumadores.Name = "tbPnNoFumadores";
            this.tbPnNoFumadores.RowCount = 2;
            this.tbPnNoFumadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPnNoFumadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPnNoFumadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbPnNoFumadores.Size = new System.Drawing.Size(388, 259);
            this.tbPnNoFumadores.TabIndex = 1;
            // 
            // tbPnFumadores
            // 
            this.tbPnFumadores.ColumnCount = 3;
            this.tbPnFumadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPnFumadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPnFumadores.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tbPnFumadores.Location = new System.Drawing.Point(878, 125);
            this.tbPnFumadores.Name = "tbPnFumadores";
            this.tbPnFumadores.RowCount = 2;
            this.tbPnFumadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPnFumadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPnFumadores.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbPnFumadores.Size = new System.Drawing.Size(408, 259);
            this.tbPnFumadores.TabIndex = 2;
            // 
            // formMesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 691);
            this.Controls.Add(this.PnMesasContenedor);
            this.Controls.Add(this.pnTituloCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formMesas";
            this.Text = "formMesas";
            this.Load += new System.EventHandler(this.formMesas_Load);
            this.pnTituloCliente.ResumeLayout(false);
            this.pnTituloCliente.PerformLayout();
            this.PnMesasContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTituloCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PnMesasContenedor;
        private System.Windows.Forms.TableLayoutPanel tbPnTerraza;
        private System.Windows.Forms.TableLayoutPanel tbPnNoFumadores;
        private System.Windows.Forms.TableLayoutPanel tbPnFumadores;
    }
}