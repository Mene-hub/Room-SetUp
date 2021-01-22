using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SetupRoom
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public bool b;
        public MainWindow()
        {
            InitializeComponent();
            b = true;
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(2);
            Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Static.IsConnected();
        }

        public void on_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Static.b)
            {
                e.Cancel = true;
                this.Visibility = Visibility.Hidden;
            }
        }

        private void closeWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dragging(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Static.Studio();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Static.reset();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Static.exit(this);
        }

        private void Inizialized(object sender, EventArgs e)
        {
            this.Close();
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Static.Gaming();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Static.Music();
        }
    }
}
