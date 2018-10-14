using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Web.Script.Serialization;
namespace MemoryGameWinform
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void signin_button_Click(object sender, EventArgs e)
        {
            string result = "";
            string name = nameTextBox.Text;
            int age = (int)LabelAge.Value;
            if (name.Length < 3 || name.Length > 10)
            {
                MessageBox.Show("Name length must be between 2-20 characters");

            }
            else
            {
                User user = new User() { UserName = name, Age = age };
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:58931/SignIn");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
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
                            result = streamReader.ReadToEnd();
                            if (result == "true")
                            {
                                MessageBox.Show("ok");
                                ChoosePartner choosePartner = new ChoosePartner(user.UserName);
                                choosePartner.Show();


                            }
                            else
                            { MessageBox.Show(result); }
                        }

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("error", ex.Message.ToString());

                }


            }
        }
    }
}

