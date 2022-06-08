using SistemaRestaurante.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace SistemaRestaurante.View
{
    public partial class Dashboard : Form
    {
        private int IdUser;
        private Form subMenuForm = new Form();
        private static Screen screen = Screen.PrimaryScreen;
        new private int Height = screen.Bounds.Width;
        new private int Width = screen.Bounds.Height;
        public Dashboard(int idUser)
        {
            InitializeComponent();
            FullScreen(Height, Width);
            this.IdUser = idUser;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            openPermissions();
            //OpenForm(new formMesas(IdUser));
        }

        private void openPermissions()
        {
            List<Model.Menu> permisosEsp = MD_Usuario.ltsPermisos(IdUser);

            MenuStrip MnStrip = new MenuStrip();

            foreach (Model.Menu menu in permisosEsp)
            {
                ToolStripMenuItem princMenu = new ToolStripMenuItem(menu.nombreMenu);
                princMenu.TextImageRelation = TextImageRelation.ImageAboveText;
                string imagPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"../../") + menu.iconMenu);
                princMenu.Image = new Bitmap(imagPath);
                princMenu.ImageScaling = ToolStripItemImageScaling.None;

                foreach (Model.SubMenu objSubMenu in menu.lstSubMenu)
                {
                    ToolStripMenuItem SubMenu = new ToolStripMenuItem(objSubMenu.nombreSubMenu, null, clickOnSubMenu, objSubMenu.FormSubMenu);
                    princMenu.DropDownItems.Add(SubMenu);
                }

                MnStrip.Items.Add(princMenu);
            }
            this.MainMenuStrip = MnStrip;
            Controls.Add(MnStrip);
        }

        public void clickOnSubMenu(object sender, System.EventArgs e)
        {
           
            ToolStripMenuItem subMenuSelect = (ToolStripMenuItem)sender;

            Assembly asm = Assembly.GetExecutingAssembly();

            Type element = asm.GetType(string.Format("{0}.{1}", "SistemaRestaurante.View", subMenuSelect.Name));

            


            if (element == null)
            {
                return;
            }
            else
            {
                if (element.Name == "formMesas")
                {
                    OpenForm(new formMesas(IdUser));
                }
                else
                {
                    Form form = (Form)Activator.CreateInstance(element);
                    OpenForm(form);
                }
               
            }


        }

        public void OpenForm(object childForm)
        {
            if (this.PnContenedor.Controls.Count > 0)
                this.PnContenedor.Controls.RemoveAt(0);
            subMenuForm = childForm as Form;
            subMenuForm.TopLevel = false;
            subMenuForm.Dock = DockStyle.Fill;
            this.PnContenedor.Controls.Add(subMenuForm);
            this.PnContenedor.Tag = subMenuForm;
            subMenuForm.Show();
        }

        private void FullScreen(int Height, int Width)
        {
            this.Size = new Size(Height, Width);
        }

    }

}
