using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
using Styleholic.DataManager;

namespace BackorderManagement
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitBind();
        }

        public void InitBind()
        {
            StyleManage smForm = new StyleManage();
            smForm.MdiParent = this;
            smForm.Show();

            GetBackorderInformation gbiForm = new GetBackorderInformation();
            gbiForm.MdiParent = this;
            gbiForm.Show();

            BackorderManage bmForm = new BackorderManage();
            bmForm.MdiParent = this;
            bmForm.Show();

        }

        private void Main_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                MainTabControl.Visible = false; // If no any child form, hide tabControl
            else
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized; // Child form always maximized

                // If child form is new and no has tabPage, create new tabPage
                if (this.ActiveMdiChild.Tag == null)
                {
                    // Add a tabPage to tabControl with child form caption
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = MainTabControl;
                    MainTabControl.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }

                if (!MainTabControl.Visible) MainTabControl.Visible = true;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((MainTabControl.SelectedTab != null) && (MainTabControl.SelectedTab.Tag != null))
                (MainTabControl.SelectedTab.Tag as Form).Select();
        }
    }
}
