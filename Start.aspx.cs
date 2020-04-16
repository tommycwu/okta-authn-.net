using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PerfTest
{
    public partial class Start : System.Web.UI.Page
    {
        public string PostAuthN(string apiUrl, string userName, string userPassword)
        {
            string responseText = "";
            try
            {
                Uri endpoint = new Uri(apiUrl);
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(endpoint);
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.Accept = "application/json";
                    webRequest.ContentType = "application/json";
                    string postData = "{\"username\": \"" + userName + "\",\"password\": \"" + userPassword + "\",\"options\": {\"multiOptionalFactorEnroll\": true,\"warnBeforePasswordExpired\": true}}";
                    byte[] byteMe = Encoding.UTF8.GetBytes(postData);
                    webRequest.ContentLength = byteMe.Length;
                    Stream requestStream = webRequest.GetRequestStream();
                    requestStream.Write(byteMe, 0, byteMe.Length);
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
                    string jsonString = readStream.ReadToEnd();
                    dynamic jsonObject = JsonConvert.DeserializeObject(jsonString);
                    JToken parsedJson = JToken.Parse(jsonObject.ToString());
                    responseText = parsedJson.ToString(Formatting.Indented);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return responseText;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonPost_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Add(DateTime.UtcNow.ToString("hh:mm:ss:ffff"));
            TextBox1.Text = "Running... ";
            TextBox1.Text = PostAuthN(TextBoxUrl.Text, TextBox3.Text, TextBox4.Text);
            ListBox2.Items.Add(DateTime.UtcNow.ToString("hh:mm:ss:ffff"));
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string countString = TextBox2.Text;
            int countInt = Int32.Parse(countString);
            DateTime StartDT = DateTime.UtcNow;
            for (int i = 0; i < countInt; i++)
            {
                ButtonPost_Click(ButtonPost, null);
            }
            DateTime StopDT = DateTime.UtcNow;
            TimeSpan TotalTime = StopDT - StartDT;
            LabelTotal.Text = "Total time = " + TotalTime.TotalMilliseconds.ToString();
        }
    }
}