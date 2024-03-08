using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Connect_4
{
    /// <summary>
    /// Interaction logic for Set.xaml
    /// </summary>
    public partial class Set : Window
    {
        List<List<string>> settings = new List<List<string>>();
        Brush myBrush;
        Color colour;
        public Set(MainWindow mainWindow)
        {
            InitializeComponent();
            //Slider values become what was set in settings resource
            sldp1v1.Value = Settings.Default.p1v1;
            sldp1v2.Value = Settings.Default.p1v2;
            sldp1v3.Value = Settings.Default.p1v3;
            sldp2v1.Value = Settings.Default.p2v1;
            sldp2v2.Value = Settings.Default.p2v2;
            sldp2v3.Value = Settings.Default.p2v3;
            sldBack1.Value = Settings.Default.bv1;
            sldBack2.Value = Settings.Default.bv2;
            sldBack3.Value = Settings.Default.bv3;

            //Rectangles of the colours changed colour to the settings
            colour = Color.FromArgb(255,(byte)sldp1v1.Value, (byte)sldp1v2.Value, (byte)sldp1v3.Value);
            myBrush = new SolidColorBrush((Color)colour);
            p1.Fill=myBrush;

            colour = Color.FromArgb(255, (byte)sldp2v1.Value, (byte)sldp2v2.Value, (byte)sldp2v3.Value);
            myBrush = new SolidColorBrush((Color)colour);
            p2.Fill = myBrush;

            colour = Color.FromArgb(255, (byte)sldBack1.Value, (byte)sldBack2.Value, (byte)sldBack3.Value);
            myBrush = new SolidColorBrush((Color)colour);
            b.Fill = myBrush;
        }


        private void grid_MouseDown(object sender, MouseButtonEventArgs e)//Moves the window if the top border is held
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Saves settings
                Settings.Default.Save();
                
                //Enables all buttons
                ((MainWindow)System.Windows.Application.Current.MainWindow).btnReset.IsEnabled = true;
                ((MainWindow)System.Windows.Application.Current.MainWindow).btnLb.IsEnabled = true;
                ((MainWindow)System.Windows.Application.Current.MainWindow).btnClose.IsEnabled = true;
                ((MainWindow)System.Windows.Application.Current.MainWindow).btnPlay.IsEnabled = true;
                ((MainWindow)System.Windows.Application.Current.MainWindow).btnSettings.IsEnabled = true;
            }
            catch
            {
                Close();
            }
            Close();
        }

        
        //If any of the slider values are changed, rectangle colour corresponding
        //to it is changed and the settings value is too
        private void sldp1v1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Default.p1v1 = Convert.ToInt32(sldp1v1.Value);
            colour = Color.FromArgb(255, (byte)sldp1v1.Value, (byte)sldp1v2.Value, (byte)sldp1v3.Value);
            myBrush = new SolidColorBrush((Color)colour);
            p1.Fill = myBrush;
        }

        private void sldp1v2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Default.p1v2 = Convert.ToInt32(sldp1v2.Value);
            colour = Color.FromArgb(255, (byte)sldp1v1.Value, (byte)sldp1v2.Value, (byte)sldp1v3.Value);
            myBrush = new SolidColorBrush((Color)colour);
            p1.Fill = myBrush;
        }

        private void sldp1v3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Default.p1v3 = Convert.ToInt32(sldp1v3.Value);
            colour = Color.FromArgb(255, (byte)sldp1v1.Value, (byte)sldp1v2.Value, (byte)sldp1v3.Value);
            myBrush = new SolidColorBrush((Color)colour);
            p1.Fill = myBrush;
        }

        private void sldp2v1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Default.p2v1 = Convert.ToInt32(sldp2v1.Value);
            Settings.Default.Save();
            colour = Color.FromArgb(255, (byte)sldp2v1.Value, (byte)sldp2v2.Value, (byte)sldp2v3.Value);
            myBrush = new SolidColorBrush((Color)colour);
            p2.Fill = myBrush;
        }

        private void sldp2v2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Default.p2v2 = Convert.ToInt32(sldp2v2.Value);
            colour = Color.FromArgb(255, (byte)sldp2v1.Value, (byte)sldp2v2.Value, (byte)sldp2v3.Value);
            myBrush = new SolidColorBrush((Color)colour);
            p2.Fill = myBrush;
        }

        private void sldp2v3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Settings.Default.p2v3 = Convert.ToInt32(sldp2v3.Value);
            colour = Color.FromArgb(255, (byte)sldp2v1.Value, (byte)sldp2v2.Value, (byte)sldp2v3.Value);
            myBrush = new SolidColorBrush((Color)colour);
            p2.Fill = myBrush;
        }

        private void sldBack1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myBrush = new SolidColorBrush((Color)Color.FromArgb(255, (byte)sldBack1.Value, (byte)sldBack2.Value, (byte)sldBack3.Value));
            ((MainWindow)System.Windows.Application.Current.MainWindow).grid.Background = myBrush;
            Settings.Default.bv1 = Convert.ToInt32(sldBack1.Value);
            grid.Background = myBrush;
            b.Fill = myBrush;
        }

        private void sldBack2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myBrush = new SolidColorBrush((Color)Color.FromArgb(255, (byte)sldBack1.Value, (byte)sldBack2.Value, (byte)sldBack3.Value));
            ((MainWindow)System.Windows.Application.Current.MainWindow).grid.Background = myBrush;
            Settings.Default.bv2 = Convert.ToInt32(sldBack2.Value);
            grid.Background = myBrush;
            b.Fill = myBrush;
        }

        private void sldBack3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            myBrush = new SolidColorBrush((Color)Color.FromArgb(255, (byte)sldBack1.Value, (byte)sldBack2.Value, (byte)sldBack3.Value));
            ((MainWindow)System.Windows.Application.Current.MainWindow).grid.Background = myBrush;
            grid.Background = myBrush;
            Settings.Default.bv3 = Convert.ToInt32(sldBack3.Value);
            b.Fill = myBrush;
        }

      
    }
}
