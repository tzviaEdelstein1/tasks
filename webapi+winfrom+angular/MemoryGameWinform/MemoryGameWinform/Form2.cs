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
    public partial class Form2 : Form
    {
        List<User>users;
        Timer MyTimer = new Timer();
        private User currentUserDetails;
       private User user=new User();
        public Form2(string userName)
        {

            InitializeComponent();
            this.user.UserName = userName;
               
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            GetList();
            MyTimer = new Timer();


            MyTimer.Interval = (3000);
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();

        }

        //get the list of the users from the server and display it
        private void GetList()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:58931/GetList/" + user.UserName);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            users = JsonConvert.DeserializeObject<List<User>>(content);
            tableLayoutPanel1.RowStyles.Clear();  //first you must clear rowStyles
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                Label l1 = new Label();
                Label l2 = new Label();
                Button b = new Button();
                b.Click += B_Click;
                b.Text = "choose";
                b.BackColor = Color.LightBlue;
                l1.Text = users[i].UserName;
                l2.Text = users[i].Age.ToString();
                b.Name = l1.Text;
                tableLayoutPanel1.Controls.Add(l1, 0, i);  // add button in column0
                tableLayoutPanel1.Controls.Add(l2, 1, i);  // add button in column1
                tableLayoutPanel1.Controls.Add(b, 2, i);  // add button in column2

                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30)); // 30 is the rows space
            }
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {

            GetList();
            GetCurrentUser();
        }

        private void GetCurrentUser()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://localhost:58931/GetCurrentTurnDetails/" + user.UserName);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();

            currentUserDetails = JsonConvert.DeserializeObject<User>(content);
            if(currentUserDetails.PartnerUserName!=null)
            {
                Form3 form3 = new Form3(user.UserName,currentUserDetails.PartnerUserName);
                form3.Show();
                MyTimer.Stop();
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            try
            { string s = (sender as Button).Name.ToString();

                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:58931/CreateGame/"+s);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(user);
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
                            MessageBox.Show("ok");
                            //Form2 form2 = new Form2(user.UserName);
                            //form2.Show();
                            //this.Close();

                        }
                        else
                        { MessageBox.Show("error"); }
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("error");

            }

        }

    }
}
