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
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        List<List<string>> leaderboard = new List<List<string>>();
        List<string> tempLead = new List<string>();
        int count = 0;
        public Leaderboard(MainWindow mainWindow)
        {
            InitializeComponent();
            //Settings.Default.lb = "finn,10,0!joe,20,0!play3r1,1,0!play3r2,0,1!tim,5,0!Jim,3,2!George,2,3!Jamo,0,5!s1Perry,100,0!s2Perry,0,100!Cecil,5,0!glug,98,0!Johnng,5,5";Settings.Default.Save();

            string a = Settings.Default.lb;
            //leaderboard list becomes sorted version of lb Settings resource
            leaderboard = MainWindow.Sort(MainWindow.LoadCSV(a),1);//Sorted by most wins
            foreach(List<string> lis in leaderboard)
            {
                if (count < 10)//Displays the top 10 wins
                {
                    txtPlayer.Text += lis[0] + '\n';
                    txtWins.Text += lis[1] + '\n';
                    txtLosses.Text += lis[2] + '\n';
                    count++;
                }
                else
                {
                    break;
                }
            }
            string x = MainWindow.ReturnToString(leaderboard);
        }

       

        

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Enables all buttons
                ((MainWindow)System.Windows.Application.Current.MainWindow).btnReset.IsEnabled = true;
                ((MainWindow)System.Windows.Application.Current.MainWindow).btnLb.IsEnabled = true;
                ((MainWindow)System.Windows.Application.Current.MainWindow).btnClose.IsEnabled = true;
                ((MainWindow)System.Windows.Application.Current.MainWindow).btnPlay.IsEnabled = true;
                ((MainWindow)System.Windows.Application.Current.MainWindow).btnSettings.IsEnabled = true;
            }
            catch
            {
                //Closes window
                Close();
            }
            Close();
        }

        private void grid_MouseDown(object sender, MouseButtonEventArgs e)//Moves the window if the top border is held
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
