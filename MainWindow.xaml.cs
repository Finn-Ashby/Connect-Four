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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Media;
namespace Connect_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     //Initialising variables   
        List<bool> flags = new List<bool> { false, false ,false,false,false,false};
        List<List<int>> board = new List<List<int>>();
        int collumn = 1;
        int con = 0;
        List<List<int>> heuristic = new List<List<int>>();
        Brush myBrush;
        List<List<string>> leaderboard = new List<List<string>>();
        List<string> tempLb = new List<string>();
        List<int> pointer = new List<int> { 0,0};
        List<SoundPlayer> sounds = new List<SoundPlayer>();
        public MainWindow()
        {
            InitializeComponent();
            //Changes the background colour to the value made in the settings resource
            myBrush = new SolidColorBrush((Color)Color.FromArgb(255, (byte)Settings.Default.bv1, (byte)Settings.Default.bv2, (byte)Settings.Default.bv3));
            grid.Background = myBrush;
            //Creates the 6x7 grid
            for (int i = 0; i < 6; i++)
            {
                List<int> row = new List<int> { 0, 0, 0, 0, 0, 0, 0 };
                board.Add(row);
            }
            System.IO.Stream str = Properties.Resources.beep;
            SoundPlayer snd = new System.Media.SoundPlayer(str);
            sounds.Add(new SoundPlayer((Stream) Properties.Resources.beep));
            sounds.Add(new SoundPlayer((Stream)Properties.Resources.victory));
            sounds.Add(new SoundPlayer((Stream)Properties.Resources.gameover));
            //Creates a list corresponding to the heuristic value of each coordinate for the AI
            List<int> heurow1 = new List<int> { 3, 4, 5, 7, 5, 4, 3 };
            List<int> heurow2 = new List<int> { 4, 6, 8, 10, 8, 6, 4 };
            List<int> heurow3 = new List<int> { 5, 8, 11, 13, 11, 8, 5 };
            heuristic.Add(heurow1);
            heuristic.Add(heurow2);
            heuristic.Add(heurow3);
            heuristic.Add(heurow3);
            heuristic.Add(heurow2);
            heuristic.Add(heurow1);
        }

        //Used to sort the leaderboard
        public static List<List<string>> Sort(List<List<string>> ogList, int sorted)
        {
            List<string> t = new List<string>();
            List<List<string>> newList = new List<List<string>>();
            //Bubble sort
            for (int p = 0; p <= ogList.Count - 2; p++)
            {
                for (int i = 0; i <= ogList.Count - 2; i++)
                {
                    try
                    {
                        if (Int32.Parse(ogList[i][sorted]) < Int32.Parse(ogList[i + 1][sorted]))
                        {
                            //Swaps the 2 lists if one of the wins is greater than the other
                            t = ogList[i + 1];
                            ogList[i + 1] = ogList[i];
                            ogList[i] = t;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            //Returns the newly sorted lis
            return ogList;

        }

        //Turns a list back into a string to be stored by the settings resource
        public static string ReturnToString(List<List<string>> list)
        {
            string test;
            string original = "";
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[0].Count; j++)
                {
                    try
                    {
                        original += list[i][j];
                    }
                    catch
                    {
                        continue;
                    }
                    
                    try
                    {
                        //At the end of each index in one of the lists, a comma is added
                        test = list[i][j + 1];
                        original += ',';
                    }
                    catch
                    {
                        continue;
                    }
                }
                try
                {
                    //At the end of each lsit, a '!' is added 
                    test = list[i+1][0];
                    original += '!';
                }
                catch
                {
                    break;
                }
            }
            //returns string to be stored 
            return original;
        }

        public static List<List<string>> LoadCSV(string lines)//Function returning a csv file as a 2d list
        {
            List<string> oneD = new List<string>();
            List<List<string>> list = new List<List<string>>();
            string temp="";
            
            foreach (char character in lines)
            {
                if (character != '!')
                {
                    temp += character;
                }
                else if (character == '!')
                {
                    if (temp != "")
                    {
                        //splits the temp string every comma
                        list.Add(temp.Split(',').ToList());
                    }
                    temp = "";
                }
            }
            //splits the temp.split list after every '!'
            list.Add(temp.Split(',').ToList());
            //returns the list
            return list;
        }

        //Closes the window
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Opens the leaderboard window
        private void btnLb_Click(object sender, RoutedEventArgs e)
        {
            Leaderboard leaderboard = new Leaderboard(this);
            btnSettings.IsEnabled = false;
            btnLb.IsEnabled = false;
            btnPlay.IsEnabled = false;
            btnClose.IsEnabled = false;
            btnReset.IsEnabled = false;
            leaderboard.Show();
        }

        //Opens the settings window
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Set settings = new Set(this);
            btnLb.IsEnabled = false;
            btnSettings.IsEnabled = false;
            btnPlay.IsEnabled = false;
            btnClose.IsEnabled = false;
            btnReset.IsEnabled = false;
            settings.Show();
        }

        //Moves the window if the top border is held down
        private void grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if ((txtPlayer1.Text != txtPlayer2.Text)&!(txtPlayer1.Text=="" |txtPlayer2.Text==""))//Makes sure both players have a name
            {
                if (!flags[3])//If not playing AI
                {
                    //Loads in leaderboard
                    leaderboard=LoadCSV(Settings.Default.lb);
                    foreach(List<string> lis in leaderboard)
                    {
                        if (lis[0] == txtPlayer1.Text)
                        {
                            //Player 1 already has their stats saved
                            flags[4] = true;
                        }
                        else if (lis[0] == txtPlayer2.Text)
                        {
                            //Player 2 already has their stats saved
                            flags[5] = true;
                        }
                    }
                    if (flags[4]==false) //If player1 hasnt played before
                    {
                        //Apppends player1's name and wins+losses of 0 to leaderboard
                        tempLb.Add(txtPlayer1.Text);
                        tempLb.Add("0");
                        tempLb.Add("0");
                        leaderboard.Add(tempLb);
                        tempLb = new List<string>();
                        //Sets the pointer to the last list
                        pointer[0] = leaderboard.Count - 1;
                    }
                    else
                    {
                        //looks for player2s name in the list
                        for (int i = 0; i < leaderboard.Count; i++)
                        {
                            if (leaderboard[i][0] == txtPlayer1.Text)
                            {
                                //Changes the pointer to the index of player 2's name
                                pointer[0] = i;
                                break;
                            }
                        }
                    }
                    if (flags[5]==false)
                    {
                        //Apppends player2's name and wins+losses of 0 to leaderboard
                        tempLb.Add(txtPlayer2.Text);
                        tempLb.Add("0");
                        tempLb.Add("0");
                        leaderboard.Add(tempLb);
                        tempLb = new List<string>();
                        //Sets the pointer to the last list
                        pointer[1] = leaderboard.Count - 1;
                    }
                    else
                    {
                        //looks for player2s name in the list
                        for (int i = 0; i < leaderboard.Count; i++)
                        {
                            if (leaderboard[i][0] == txtPlayer2.Text)
                            {
                                //Changes the pointer to the index of player 2's name
                                pointer[1] = i;
                                break;
                            }
                        }
                    }
                    Debug.WriteLine("Pointing to: " + leaderboard[pointer[0]][0]);
                    Debug.WriteLine("Pointing to: " + leaderboard[pointer[1]][0]);
                }
                tckAI.IsEnabled = false;
                btnPlay.IsEnabled = false;
                btnLb.IsEnabled = false;
                btnSettings.IsEnabled = false;
                flags[0] = true;
                flags[1] = false;
                flags[4] = false;
                flags[5] = false;
                txtPlayer1.IsEnabled = false;
                txtPlayer2.IsEnabled = false;
                con = 0;
                notepad.Text = $"{txtPlayer1.Text}'s\nturn";
            }

            //Data validation
            else if(txtPlayer1.Text == txtPlayer2.Text)
            {
                notepad.Text = "Player\nnames must\nbe different!";
            }
            else if(txtPlayer1.Text == "" | txtPlayer2.Text == "")
            {
                notepad.Text = "Player name\ncannot be\nempty!";
            }
        }
        private void cnvBoard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (flags[0])
            {
                collumn = ((int)Mouse.GetPosition(this).X - 235) / 75;
                if (collumn > 6)
                {
                    collumn--;
                }
                int i=CheckPlace(collumn);
                //i is the lowest row the counter can be in for that collumn (gravity)
                if (i !=8)//If i=8 then the collumn is full
                {
                    con++;
                    if (flags[1])//If player 2's turn
                    {
                        //Sets the board position index to 1
                        board[i][collumn] = 1;
                        //Draws the counter
                        Draw(collumn, i, false, Color.FromArgb(255, (byte)Settings.Default.p2v1, (byte)Settings.Default.p2v2, (byte)Settings.Default.p2v3));
                        if (i < 5)
                        {
                            //Draws the hologram
                            Draw(collumn, i + 1, true, Color.FromArgb(55, (byte)Settings.Default.p1v1, (byte)Settings.Default.p1v2, (byte)Settings.Default.p1v3));
                        }
                        if (WinCheck(flags[1]))//If player 2 wins
                        {
                            sounds[1].Play();
                            notepad.Text = $"{txtPlayer2.Text}\nwins!";
                            //Clears the holograms
                            Clear();
                            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new Action(delegate { this.UpdateLayout(); }));
                            //Adds 1 to player 2's wins and player 1's losses
                            leaderboard[pointer[1]][1]=(Int16.Parse(leaderboard[pointer[1]][1]) + 1).ToString();
                            leaderboard[pointer[0]][2] = (Int16.Parse(leaderboard[pointer[0]][2]) + 1).ToString();
                            Debug.WriteLine("Added wins/losses p2wins");
                            Settings.Default.lb = ReturnToString(leaderboard);
                            Settings.Default.Save();
                            //Saves the leaderbard
                            flags[0] = false;
                        }
                        else if (con == 42)//Draw
                        {
                            notepad.Text = "Draw!";
                            flags[0] = false;
                            Clear();
                        }
                        else //Player 2 hasnt won and it isnt a draw
                        {
                            sounds[0].Play();
                            notepad.Text = $"{txtPlayer1.Text}'s\nturn";
                        }
                        flags[1] = false;
                    }
                    else
                    {
                        //Sets the board position index to 10
                        board[i][collumn] = 10;
                        //Draws the counter
                        Draw(collumn, i, false, Color.FromArgb(255, (byte)Settings.Default.p1v1, (byte)Settings.Default.p1v2, (byte)Settings.Default.p1v3));
                        if (i < 5)
                        {
                            if (flags[3] == false)
                            {
                                //Draws the hologram
                                Draw(collumn, i + 1, true, Color.FromArgb(55, (byte)Settings.Default.p2v1, (byte)Settings.Default.p2v2, (byte)Settings.Default.p2v3));
                            }
                        }
                        if (WinCheck(flags[1]))//If player 1 wins
                        {
                            sounds[1].Play();
                            notepad.Text = $"{txtPlayer1.Text}\nwins!";
                            flags[0] = false;
                            Clear();//Clears the holograms
                            if (flags[3]==false)
                            {
                                //Adds a win to player 1 and a loss to player 2 on the leaderboards
                                Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new Action(delegate { this.UpdateLayout(); }));
                                leaderboard[pointer[0]][1] = (Int16.Parse(leaderboard[pointer[0]][1]) + 1).ToString();
                                leaderboard[pointer[1]][2] = (Int16.Parse(leaderboard[pointer[1]][2]) + 1).ToString();
                                Debug.WriteLine("Added wins/losses p1wins");
                                Settings.Default.lb = ReturnToString(leaderboard);
                                Settings.Default.Save();
                            }
                        }
                        else if (flags[3] == false)
                        {
                            sounds[0].Play();
                            notepad.Text = $"{txtPlayer2.Text}'s\nturn";
                            flags[1] = true;
                        }
                        else
                        {
                            sounds[0].Play();
                            flags[0] = false;
                            notepad.Text = "Calculating";
                            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new Action(delegate { this.UpdateLayout(); }));
                            con++;
                            //Passes the depth value to the AIHard function
                            collumn = AIHard(Int16.Parse(sldDifficulty.Value.ToString()), con);
                            sounds[0].Play();
                            flags[0] = true;
                            i = CheckPlace(collumn);
                            //Places the counter
                            board[i][collumn] = 1;
                            notepad.Text = $"{txtPlayer1.Text}'s\nturn";
                            //Draws the AIs counter
                            Draw(collumn, i, false, Color.FromArgb(255, (byte)Settings.Default.p2v1, (byte)Settings.Default.p2v2, (byte)Settings.Default.p2v3));
                            if ((i + 1) < 6)
                            {
                                //Draws the players hologram
                                Draw(collumn, i + 1, true, Color.FromArgb(55, (byte)Settings.Default.p1v1, (byte)Settings.Default.p1v2, (byte)Settings.Default.p1v3));
                            }
                                
                            
                            if (WinCheck(!flags[1]))//If AI wins
                            {
                                sounds[2].Play();
                                notepad.Text = "AI\nwins!";
                                flags[0] = false;
                                Clear();
                            }
                            else if (con == 42)//If draw
                            {
                                notepad.Text = "Draw!";
                                flags[0] = false;
                                Clear();
                            }
                        }
                    }
                    //Changes the hologram position if the mouse moved
                    cnvBoard_MouseOver(sender, e);
                }
            }
        }
        public int AIHard(int de,int co)//Returns the best collumn it evaluated
        {
            int bestCol=0;
            //de = 8;
            int bestScore = 1005;//Trying to get as low a ascore as possible
            int score;
            int x;
            for (int i = 0; i < 7; i++)
            {
                x = CheckPlace(i);
                if (x!= 8)//If the collumn isnt full
                {
                    board[x][i] = 1;
                    score = Minimax(true,de,co,-100,100);
                    board[x][i] = 0;
                    if (score < bestScore)//If the score of the move is lower than the lowest score
                    {
                        bestScore = score;//The new best score becomes the current score
                        bestCol = i;//The new best collumn becomes the current collumn
                    }
                }
            }
            return bestCol; //Returns the best collumn
        }

        public int Minimax(bool isMax, int depth,int count,int alpha,int beta)
        { 
            if (WinCheck(isMax))
            {
                if (isMax)//AI wins
                {
                    return -1000+count;//Returns a lowe score+the number of moves it took to get there
                }
                //Else user wins
                return 1000-count;//Returns a high score-the number of moves it took to get there
            }
            
            if (count >= 42)//Board is full
            {
                return 0;
            }
            if (depth <= 0)//End of depth
            {
                return heuristic2(isMax);//Returns the heuristic value of the board position
            }
            int scor;
            int bestScor;
            int x;
            if (isMax)//If maximising player, they are trying to get as high a score as possible
            {
                bestScor = -1001;

                for(int i = 0; i < 7; i++)
                {
                    x = CheckPlace(i);
                    if (x != 8)//If legal move
                    {
                        board[x][i] = 10;
                        scor = Minimax(false, depth - 1, count + 1, alpha, beta);//Recursively evaluates the position until the position is won,lost,drawn or the end of the depth is reached
                        board[x][i] = 0;
                        if (scor > bestScor)
                        {
                            //Gets highest score
                            bestScor = scor;
                        }
                        alpha = Math.Max(alpha, scor);
                        if (alpha >= beta)//Prunes next board position nodes because the maximiser gets to choose this position and it is better than the current best position
                        {
                            break;
                        }
                    }
                }
                return bestScor;
            }
            else//Minimising player sames as maximising but opposit
            {
                bestScor = 1001;

                for (int i = 0; i < 7; i++)
                {
                    x = CheckPlace(i);
                    if (x != 8)
                    {
                        board[x][i] = 1;
                        scor = Minimax(true, depth-1, count+1,alpha,beta);
                        board[x][i] = 0;
                        if (scor < bestScor)
                        {
                            bestScor = scor;
                        }
                        beta = Math.Min(beta, scor);
                        if (alpha>=beta)
                        {
                            break;
                        }
                    }
                }
                return bestScor;
            }
        }

        public int heuristic2(bool turn)//A function that returns the score of a board position
        {
            int score = 0;
            //Each position on the board has a set score e.g. a position in the centre has a higher score than one in the corner
            //Adds/Subtracts up all the currently filled in positions and evaluates a score based on it
            for (int h = 0; h < 2; h++)
            {
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (board[j][i] == 1)
                        {
                            //Subtracts score as minimising players counter is there
                            score -= heuristic[j][i];
                        }
                        if (board[j][i] == 10)
                        {
                            //Adds score as maximising players counter is there
                            score += heuristic[j][i];
                        }
                    }
                }
            }
            //Returns the score
            return score;
        }



        private int CheckPlace(int col)//Used to check if a collumn is full
        {
            for (int i = 0; i < 6; i++)
            {
                if (board[i][col] == 0)
                {
                    //Returns the lowest row for that collumn
                    return i;
                }
            }
            //If the collumn is full returns 8
            return 8;
        }
        private bool WinCheck(bool turn)//Checks for win on the current baord position
        {
            int dub = 40;//If turn is false then the winning value is 10*4
            if (turn)//If turn is true then the winning value is 1*4
            {
                dub = 4;
            }
            List<int> Total = new List<int> { 0, 0, 0, 0 };

            //Moves a 4x4 grid around the main grid to check for connect 4
            for (int g = 0; g <= 2; g++)//Starting position of the 4x4 grid
            {
                for (int h = 0; h <= 3; h++)//Starting position of the 4x4 grid
                {
                    for (int k = 0; k <= 3; k++)
                    {
                        for (int l = 0; l <= 3; l++)//Checks each row and collumn in 4x4
                        {
                            Total[0] += board[k + g][l + h];
                            Total[1] += board[l + g][k + h];
                        }
                        if (Total[0] == dub | Total[1] == dub)
                        {
                            return true;//If one of them adds up to 40/4 true is returned
                        }
                        Total[0] = 0;
                        Total[1] = 0;
                    }
                    for (int k = 0; k <= 3; k++)//Checks both diagonals in 4x3
                    {
                        Total[2] += board[g + k][h + k];
                        Total[3] += board[g + 3 - k][h + k];
                    }
                    if (Total[2] == dub | Total[3] == dub)
                    {
                        //If one of them adds up to 40/4 true is returned
                        return true;
                    }
                    Total[2] = 0;
                    Total[3] = 0;
                }
            }
            //If no win condition, returns false
            return false;
        }
        private void cnvBoard_MouseLeave(object sender, MouseEventArgs e)
        {
            //If the mouse leaves the grid, the hologram is removed
            Clear();
            collumn = 1;
        }
        private void cnvBoard_MouseOver(object sender, MouseEventArgs e)//Draws a hologram when the mouse is over the grid
        {
            if (flags[0])//Has the game started
            {
                if (collumn != ((int)Mouse.GetPosition(this).X - 235) / 75)
                {
                    //Removes last hologram
                    Clear();
                    collumn = ((int)Mouse.GetPosition(this).X - 235) / 75;//Gets position of mouse and finds what collumn it is in. -235 because the grid is 235 pixels away from the origin
                    if (collumn > 6)
                    {
                        collumn--;
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        if (board[i][collumn] == 0)
                        {
                            if (board[i][collumn] == 0)
                            {
                                if (flags[1])//If player 2
                                {
                                    //Draws counter with opacity of 55
                                    Draw(collumn, i, true, Color.FromArgb(55, (byte)Settings.Default.p2v1, (byte)Settings.Default.p2v2, (byte)Settings.Default.p2v3));
                                }
                                else//If player 1
                                {
                                    //Draws counter with opacity of 55
                                    Draw(collumn, i, true, Color.FromArgb(55, (byte)Settings.Default.p1v1, (byte)Settings.Default.p1v2, (byte)Settings.Default.p1v3));
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
        private void Clear()//Removes holograms from the temp list
        {
            cnvBoard.Children.Remove(temp);
        }
        Ellipse temp;
        List<Ellipse> circles = new List<Ellipse> { };
        private void Draw(int col, int row, bool transp = false, Color? colour = null)
        {
            if (colour == null)//Default colour if no value is passed
            {
                colour = Color.FromArgb(255, 200, 0, 200);
            }
            //Draw
            Ellipse circle = new Ellipse();
            circle.Height = 65;
            circle.Width = 65;
            circle.StrokeThickness = 35;
            Brush myBrush = new SolidColorBrush((Color)colour);
            circle.Stroke = myBrush;
            circle.Margin = new Thickness(col * 75 + 5, 380 - row * 75, 0, 0);//Draws counter at specified position
            cnvBoard.Children.Add(circle);
            if (transp)//If it is a hologram
            {
                temp = circle;//the hologram becomes part of circle list
            }
            else
            {
                //Clears hologram
                Clear();
                //Adds circle to list
                circles.Add(circle);
            }
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)//Resets board and enables all buttons
        {
            notepad.Text = "";
            btnLb.IsEnabled = true;
            tckAI.IsEnabled = true;
            btnSettings.IsEnabled = true;
            txtPlayer1.IsEnabled = true;
            if (!flags[3])
            {
                txtPlayer2.IsEnabled = true;
            }
            flags[0] = false;
            btnPlay.IsEnabled = true;
            for (int i = 0; i < circles.Count; i++)
            {
                cnvBoard.Children.Remove(circles[i]);
            }
            circles.Clear();
            for (int i = 0; i < board.Count; i++)
            {
                for (int j = 0; j < board[0].Count; j++)
                {
                    board[i][j] = 0;
                }
            }
        }
        private void txtPlayer_Click(object sender, RoutedEventArgs e)//Text box is clicked
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Text=="Player1"|txtBox.Text=="Player2")//if the text box name is Player1 or 2 the text box is cleared
            {
                txtBox.Text = "";
            }
        }

        private void tckAI_Checked(object sender, RoutedEventArgs e)//If AI is enabled
        {
            flags[3] = true;//AI flag =true
            txtPlayer2.IsEnabled = false;//Player 2 text box disabled
        }
        private void tckAI_Unchecked(object sender, RoutedEventArgs e)//If AI is disabled
        {
            flags[3] = false;//AI flag =false
            txtPlayer2.IsEnabled = true;//Player 2 text box enabled
        }

        private void txtPlayer_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            string x = box.Text;
            string text = "";
            for(int i = 0; i < 7; i++)
            {
                try
                {
                    //If the character isnt a number or letter it is deleted
                    if (((int)x[i] > 96 & (int)x[i] < 123) | ((int)x[i] > 64 & (int)x[i] < 91) | ((int)x[i] > 47 & (int)x[i] < 58))
                    {
                        text += x[i];
                    }
                }
                catch
                {
                    break;
                }
            }
            box.Text = text;
        }
    }
}