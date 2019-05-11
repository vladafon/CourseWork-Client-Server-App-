using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainScreen : Form
    {
        private string selectedPath;

        public MainScreen()
        {
            selectedPath = "";
            InitializeComponent();
            listBox1.SetSelected(0,true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void sendRequest_Click(object sender, EventArgs e)
        {
            resultBox.Text = "Пожалуйста, подождите...";
            //get response
            string url = "http://localhost/stringFinder/findString.php";
              var pars = new NameValueCollection { { "path", dirPath.Text }, {"string",subString.Text} };
              string result = WebRequest(url, pars);
              if (result == "")
                  return;

            resultBox.Text = result.Replace("<br>","\n").Replace(";",",");
            
        }


        private void getDirs_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;

            selectedPath += listBox1.Items[listBox1.SelectedIndex];
            if (selectedPath != "/")
                selectedPath += "/";

            resultBox.Text = "Пожалуйста, подождите...";
            //get response
            string url = "http://localhost/stringFinder/getDirs.php";
            var pars = new NameValueCollection { { "directory", selectedPath } };
            string result = WebRequest(url, pars);
            if (result == "")
            {
                listBox1.Items.Clear();
                resultBox.Clear();
                return;
            }
            string[] items = result.Split(';');
                listBox1.Items.Clear();
                foreach (var item in items)
                {
                    if (item != "" && item != "." && item != "..")
                        listBox1.Items.Add(item);
                }

                resultBox.Text = "";
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (selectedPath == "/")
                return;

            string[] splittedPath = selectedPath.Split('/');

            selectedPath = "/";
            for (int i=0; i<splittedPath.Length-2;i++)
            { 
                if (splittedPath[i] != "")
                    selectedPath += splittedPath[i]+"/";
            }

            resultBox.Text = "Пожалуйста, подождите...";
            //get response
            string url = "http://localhost/stringFinder/getDirs.php";
                var pars = new NameValueCollection {{"directory", selectedPath}};
            string result = WebRequest(url, pars);
            if (result == "")
            {
                listBox1.Items.Clear();
                resultBox.Clear();
                return;
            }
            string[] items = result.Split(';');
                listBox1.Items.Clear();
                foreach (var item in items)
                {
                    if (item != "" && item != "." && item != "..")
                        listBox1.Items.Add(item);
                }
            
            resultBox.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            dirPath.Text = selectedPath + listBox1.Items[listBox1.SelectedIndex];
            if (dirPath.Text != @"/")
                dirPath.Text += @"/";

        }

        //public string HttpWebReq(string url, string content)
        //{
        //    var request = (HttpWebRequest)System.Net.WebRequest.Create(url);

        //    var postData = "thing1=hello";
        //    postData += "&thing2=world";
        //    var data = Encoding.ASCII.GetBytes(postData);

        //    request.Method = "POST";
        //    request.ContentType = "application/x-www-form-urlencoded";
        //    request.ContentLength = data.Length;

        //    using (var stream = request.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }

        //    var response = (HttpWebResponse)request.GetResponse();

        //    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //}


        public string WebRequest(string url,NameValueCollection parsCollection)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.UploadValues(url, parsCollection);
                }
                catch
                {
                    resultBox.Text = "522 Connection Timed Out";
                    return "";
                }

                var response = webClient.UploadValues(url, parsCollection);
                string result = Encoding.UTF8.GetString(response);

                return result;
            }
            //string result = "";
            //HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            //HttpWebResponse response = (HttpWebResponse)req..GetResponse();
            //using (StreamReader stream = new StreamReader(response.GetResponseStream(),Encoding.UTF8))
            //{
            //    try
            //    {
            //        result = stream.ReadToEnd();
            //    }
            //    catch (Exception e)
            //    {
            //        result = e.Message;
            //    }

            //}

            //return result;


        }
        }
}
