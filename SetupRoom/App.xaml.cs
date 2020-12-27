using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Diagnostics;
using YeelightAPI;
using YeelightAPI.Models.Scene;

namespace SetupRoom
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {
        public System.Windows.Forms.NotifyIcon nIcon = new System.Windows.Forms.NotifyIcon();
        //Window Mw;
        System.Windows.Forms.ContextMenu cm = new System.Windows.Forms.ContextMenu();
        public App()
        {
            nIcon.Icon = new Icon(@"Room-SetUp.ico");
            nIcon.Visible = true;
            nIcon.MouseClick += NIcon_MouseClick;

            Static.findip();
            //device = new Device("192.168.0.5");

            System.Windows.Forms.MenuItem Mi = new System.Windows.Forms.MenuItem();
            Mi.Text = "Exit";
            Mi.Click += Mi_Click1;

            System.Windows.Forms.MenuItem Mi2 = new System.Windows.Forms.MenuItem();
            Mi2.Text = "Studio";
            Mi2.Click += Mi2_Click;

            System.Windows.Forms.MenuItem Mi3 = new System.Windows.Forms.MenuItem();
            Mi3.Text = "Reset";
            Mi3.Click += Mi3_Click;


            cm.MenuItems.Add(Mi2);
            cm.MenuItems.Add(Mi3);
            cm.MenuItems.Add(Mi);
            nIcon.ContextMenu = cm;
        }
        private void NIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                try
                {
                    nIcon.ContextMenu.Show(new System.Windows.Forms.Control(), e.Location);
                }
                catch (Exception E) { }
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MainWindow.Visibility = Visibility.Visible;
                MainWindow.WindowState = WindowState.Normal;
            }
        }

        private void Mi_Click1(object sender, EventArgs e)
        {
            Static.exit(MainWindow);
        }

        private void Mi2_Click(object sender, EventArgs e)
        {
            Static.Studio();
        }

        private void Mi3_Click(object sender, EventArgs e)
        {
            Static.reset();
        }

    }
}
