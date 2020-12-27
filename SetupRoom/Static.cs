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

        public static async void findip()
        {
            try
            {
                device = ((List<Device>)await DeviceLocator.DiscoverAsync())[0];
                device.Connect();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("Nessuna lampadina trovata");
            }
        }

        public static void Studio()
        {
            Process.Start(@"OneNote for Windows 10.lnk");
            Process.Start(@"Spotify.lnk");

            if (device == null)
                findip();

            try
            {
                device.SetPower(true);
                device.SetScene(Scene.FromColorTemperature(50, 100));
            }
            catch (Exception e){}
        }

        public static void reset()
        {
            if (device == null)
                findip();

            try
            {
                device.SetPower(true);
                device.SetBrightness(100);
                device.SetColorTemperature(4500);
                device.SetDefault();
            }catch (Exception e) { }
        }

        public static void exit(Window window)
        {
            //nIcon.Dispose();
            b = false;
            window.Close();
        }
    }
}
