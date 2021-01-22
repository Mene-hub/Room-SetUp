using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using YeelightAPI;
using YeelightAPI.Core;
using YeelightAPI.Events;
using YeelightAPI.Models.Music;
using YeelightAPI.Models.ColorFlow;
using YeelightAPI.Models.Scene;

namespace SetupRoom
{
    public static class Static
    {
        public static bool b = true;
        public static bool connected = false;
        public static Device device;

        public static async void findip()
        {
            try
            {
                device = ((List<Device>)await DeviceLocator.DiscoverAsync())[0];
                device.Connect();
                connected = true;
            }
            catch (Exception e)
            {
                //System.Windows.MessageBox.Show("Nessuna lampadina trovata");
            }
        }

        public static void Studio()
        {
            Process.Start(@"OneNote for Windows 10.lnk");
            Process.Start(@"Spotify.lnk");

            IsConnected();
            if (device == null || !connected)
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
            IsConnected();
            if (device == null || !connected)
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

        public static async void IsConnected()
        {
            if (device == ((List<Device>)await DeviceLocator.DiscoverAsync())[0])
                connected = true;
            else
            {
                connected = false;
                findip();
            }
        }

        public static void Gaming()
        {
            IsConnected();
            if (device == null || !connected)
                findip();

            try
            {
                Process.Start("Discord.lnk");
                device.SetPower(true);
                device.SetRGBColor(255,0,0,1000);
                ColorFlow flow = new ColorFlow(0, ColorFlowEndAction.Restore);
                flow.Add(new ColorFlowSleepExpression(1000));
                flow.Add(new ColorFlowRGBExpression(255, 0, 0, 100, 60000));
                flow.Add(new ColorFlowRGBExpression(0, 255, 0, 100, 60000));
                flow.Add(new ColorFlowRGBExpression(0, 0, 255, 100, 60000));
                device.StartColorFlow(flow);
            }
            catch (Exception e) { }
        }

        public static void Music()
        {
            IsConnected();
            if (device == null || !connected)
                findip();

            try
            {
                device.SetPower(true);
                device.StartMusicMode("192.168.0.10");
                
            }
            catch (Exception e) { }
        }

    }
}
