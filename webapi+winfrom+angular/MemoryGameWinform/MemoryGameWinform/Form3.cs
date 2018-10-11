using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MemoryGameWinform
{
    public partial class Form3 : Form
    {
        User partnerUser;
        string userName, partnerName;
        public Form3(string userName, string partnerName)
        {
            InitializeComponent();
            this.userName = userName;
            this.partnerName = partnerName;
        }

      
private void Button_start_game_Click(object sender, EventArgs e)
        {

        Form4 form4 = new Form4(userName);
        form4.Show();
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

