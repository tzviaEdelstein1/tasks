using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MemoryGameWinform
{
    public partial class Form4 : Form
    {
        Timer MyTimer;
        Game game = new Game();
        string userName;
        List<string> selectedCards = new List<string>();
        List<Button> randButtons = new List<Button>();
        public Form4(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //get the game
            GetGame();
            namePlayerLabel.Text = game.CurrentTurn;
            if (game.Player1.UserName == userName)
            {
                counterLabel.Text = game.Player2.UserName;
                yourCounterLabel.Text = game.Player2.Score.ToString();
                partnerCounterLabel.Text = game.Player1.Score.ToString();
            }
            else
            {
                counterLabel.Text = game.Player1.UserName;
                yourCounterLabel.Text = game.Player1.Score.ToString();
                partnerCounterLabel.Text = game.Player2.Score.ToString();
            }

            List<Button> buttons = new List<Button>();
            foreach (KeyValuePair<string, string> card in game.CardArray)
            {

                for (int i = 0; i < 2; i++)
                {
                    Button btn = new Button();
                    btn.Name = i + "a";
                    btn.Text = card.Key;
                   btn.Width = 70;
                btn.Height = 70;
                    buttons.Add(btn);

                }

            }
            randButtons = new List<Button>();
            int f = 0;
            for (int w = 0; w < 18; w++)
            {
                randButtons.Add(new Button() { Text = "x" });

            }
            while (f < 18)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, 18);
                Button b = buttons[f];
                if (randButtons[x].Text == "x")
                {
                    randButtons[x] = new Button();
                    randButtons[x].Text = b.Text;
                    randButtons[x].Width = 70;
                    randButtons[x].Height = 70;
                    randButtons[x].Name = f + b.Text;
                    randButtons[x].Click += Btn_Click;
                    randButtons[x].BackColor = Color.Black;
                    f++;
                }

            }
            int k = 0, row = 50, col = 50;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    randButtons[k].Location = new Point(row, col);
                    row += randButtons[k].Width + 1;
                    Button b = randButtons[k];
                    panel1.Controls.Add(b);
                    k++;
                }
                row = 50;
                col += randButtons[k - 1].Height + 2;

            }

            ChangeCurrenTurn();
            MyTimer = new Timer();
            MyTimer.Interval = (2000);
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Color.White;
            selectedCards.Add((sender as Button).Text);
            if (selectedCards.Count == 2)
            {
                if (namePlayerLabel.Text == game.Player2.UserName)
                {
                    namePlayerLabel.Text = game.Player1.UserName;
                }
                else
                    namePlayerLabel.Text = game.Player2.UserName;
                for (int i = 0; i < randButtons.Count; i++)
                {
                    randButtons[i].Enabled = false;


                }
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:58931/UpdateGame/" + userName + "/" + selectedCards[1]);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(selectedCards[0]);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();

                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    {
                        var result = streamReader.ReadToEnd();
                        if (result == "true")
                        {
                            for (int i = 0; i < randButtons.Count; i++)
                            {
                                if (randButtons[i].Text == selectedCards[0])
                                {
                                    randButtons[i].BackColor = Color.Blue;
                                    randButtons[i].Enabled = false;
                                }

                            }
                            MessageBox.Show("good");
                            GetGame();

                        }
                        else
                        {
                            MessageBox.Show("mistake!!");
                            for (int i = 0; i < randButtons.Count; i++)
                            {
                                if (randButtons[i].Text == selectedCards[0] || randButtons[i].Text == selectedCards[1])
                                {
                                    randButtons[i].BackColor = Color.Black;

                                }

                            }

                        }
                    }

                }
                selectedCards.Clear();
            }
        }

        private void GameOver()
        {
            string winner;
            int pointUser1 = 0;
            int pointUser2 = 0;
            foreach (var item in game.CardArray.Values)
            {
                if (item == game.Player1.UserName)
                {

                    pointUser1++;
                }

                else if (item == game.Player2.UserName)
                    pointUser2++;
            }

            if (pointUser1 + pointUser2 == game.CardArray.Count)
            {

                winner = pointUser1 > pointUser2 ? game.Player1.UserName : game.Player2.UserName;
                MyTimer.Stop();
                MessageBox.Show("Game over the winnwr is: " + winner);
            }
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
           
            GetGame();
            ChangeCurrenTurn();
            GameOver();

        }

        private void ChangeCurrenTurn()
        {
            if (game.CurrentTurn == userName)
            {
                label_turn.Text = "Your turn now!!!";
                namePlayerLabel.Text = userName;


                for (int i = 0; i < randButtons.Count; i++)
                {

                    if (game.CardArray.FirstOrDefault(g => g.Key == randButtons[i].Text).Value != null)
                    {
                        randButtons[i].BackColor = Color.Blue;

                    }
                    else
                    {
                        randButtons[i].Enabled = true;
                    }

                }
            }
            else
            {
                label_turn.Text = "Wait for your turn!!!";
                namePlayerLabel.Text = game.CurrentTurn;
                for (int i = 0; i < randButtons.Count; i++)
                {
                    randButtons[i].Enabled = false;

                }
            }

        }
        private void GetGame()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:58931/GetGame/" + userName);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            game = JsonConvert.DeserializeObject<Game>(content);
 
        }


    }
}

