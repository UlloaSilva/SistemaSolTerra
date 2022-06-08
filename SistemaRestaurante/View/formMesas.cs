using SistemaRestaurante.Controller;
using SistemaRestaurante.Model;
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
    public partial class formMesas : Form
    {
        private int IdUser;
        public formMesas(int idUser)
        {
            InitializeComponent();
            IdUser = idUser;
        }

        private void formMesas_Load(object sender, EventArgs e)
        {
            openMesas();
        }
        private void openMesas()
        {
            List<MD_Mesas> mesasEsperadas = CLL_Mesas.Mesas(IdUser);

            MenuStrip MnStrip = new MenuStrip();

            foreach (MD_Mesas mesa in mesasEsperadas)
            {
                
                

                foreach (MD_Sucursal sucMesa in mesa.Sucursal)
                {
                    

                    foreach (MD_Area areMesa in mesa.Area)
                    {
                        if (areMesa.Nombre == "Terraza")
                        {
                            ToolStripContentPanel tool = new ToolStripContentPanel();

                            if (mesa.Estado == "Habilitada")
                            {
                                tbPnTerraza.Controls.Add(tool);
                                tool.Width = 200;
                                tool.Height = 200;
                                tool.BackColor = Color.Green;

                                tool.BackgroundImage = Image.FromFile("C:\\Users\\erwin\\Documents\\Clases\\DataBase\\SistemaRestaurante\\SistemaRestaurante\\Icon\\mesas.png");
                                tool.BorderStyle = BorderStyle.Fixed3D;
                                tool.Cursor = Cursors.Hand;
                            }
                            else
                            {

                                tbPnTerraza.Controls.Add(tool);
                                tool.Width = 200;
                                tool.Height = 200;
                                tool.BackColor = Color.Red;
                            }
                            

                        }
                        else if (areMesa.Nombre == "Salón no Fumadores")
                        {
                            ToolStripContentPanel tool = new ToolStripContentPanel();

                            if (mesa.Estado == "Habilitada")
                            {
                                tbPnNoFumadores.Controls.Add(tool);
                                tool.Width = 200;
                                tool.Height = 200;
                                tool.BackColor = Color.BlueViolet;

                                
                            }
                            else
                            {

                            }
                            
                        }
                        else if (areMesa.Nombre == "Salón Fumadores")
                        {
                            ToolStripContentPanel tool = new ToolStripContentPanel();

                            if (mesa.Estado == "Habilitada")
                            {
                                tbPnFumadores.Controls.Add(tool);
                                tool.Width = 200;
                                tool.Height = 200;
                                tool.BackColor = Color.Gray;

                                tool.BackgroundImage = Image.FromFile("C:\\Users\\erwin\\Documents\\Clases\\DataBase\\SistemaRestaurante\\SistemaRestaurante\\Icon\\mesas.png");
                                tool.BorderStyle = BorderStyle.Fixed3D;
                                tool.Cursor = Cursors.Hand;
                            }
                            else
                            {
                                
                            }
                            
                        }


                        //ToolStripMenuItem item = new ToolStripMenuItem(areMesa.Nombre);

                    }
                }
                
                
            }
            //foreach (Model.MD_Sucursal objSubMenu in menu.lstSubMenu)
            //{
            //    ToolStripMenuItem SubMenu = new ToolStripMenuItem(objSubMenu.nombreSubMenu, null, clickOnSubMenu, objSubMenu.FormSubMenu);
            //    princMenu.DropDownItems.Add(SubMenu);
            //}
            this.MainMenuStrip = MnStrip;
            Controls.Add(MnStrip);
        }
    }
}
