using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using YeelightAPI;
using YeelightAPI.Models.Scene;

namespace SetupRoom
{
    public static class Static
    {
        public static bool b = true;
        public static Device device;

        public static void Studio()
        {
            Process.Start(@"OneNote for Windows 10.lnk");
            Process.Start(@"Spotify.lnk");
            device.SetPower(true);
            device.SetScene(Scene.FromColorTemperature(50, 100));
        }

        public static void reset()
        {
            device.SetPower(true);
            device.SetBrightness(100);
            device.SetColorTemperature(4500);
            device.SetDefault();
        }

        public static void exit(Window window)
        {
            //nIcon.Dispose();
            b = false;
            window.Close();
        }
    }
}
