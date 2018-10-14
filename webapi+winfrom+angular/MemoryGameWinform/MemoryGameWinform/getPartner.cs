using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MemoryGameWinform
{
    public partial class GetPartner : Form
    {
        User partnerUser;
        string userName, partnerName;
        public GetPartner(string userName, string partnerName)
        {
            InitializeComponent();
            this.userName = userName;
            this.partnerName = partnerName;
        }

      
private void Button_start_game_Click(object sender, EventArgs e)
        {

        TheGame theGame = new TheGame(userName);
            theGame.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:58931/GetCurrentTurnDetails/" + this.partnerName);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            partnerUser = JsonConvert.DeserializeObject<User>(content);

            nameLabel.Text = this.partnerUser.UserName;
            AgeLabel.Text = this.partnerUser.Age.ToString();

        }
    }
}

