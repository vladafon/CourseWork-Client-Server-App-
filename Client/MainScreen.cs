using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void sendRequest_Click(object sender, EventArgs e)
        {
            //get response
            string url = "http://localhost/stringFinder/findString.php";
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection { { "path", dirPath.Text }, {"string",subString.Text} };
                var response = webClient.UploadValues(url, pars);
                string result = Encoding.UTF8.GetString(response);
                if (result.Contains("Warning"))
                {
                    resultBox.Clear();
                    return;
                }

                resultBox.Text = result.Replace("<br>","\n").Replace(";",",");
            }
        }


        private void getDirs_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            selectedPath += listBox1.Items[listBox1.SelectedIndex];
            if (selectedPath != "/")
                selectedPath += "/";

            //get response
            string url = "http://localhost/stringFinder/getDirs.php";
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection {{"directory", selectedPath}};
                var response = webClient.UploadValues(url, pars);
                string result = Encoding.UTF8.GetString(response);
                if (result.Contains("Warning"))
                {
                    listBox1.Items.Clear();
                    return;
                }

                string[] items = result.Split(';');
                listBox1.Items.Clear();
                foreach (var item in items)
                {
                    if (item != "" && item != "." && item != "..")
                        listBox1.Items.Add(item);
                }
            }
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


            //get response
            string url = "http://localhost/stringFinder/getDirs.php";
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection {{"directory", selectedPath}};
                var response = webClient.UploadValues(url, pars);
                string result = Encoding.UTF8.GetString(response);
                if (result.Contains("Warning"))
                {
                    listBox1.Items.Clear();
                    return;
                }

                string[] items = result.Split(';');
                listBox1.Items.Clear();
                foreach (var item in items)
                {
                    if (item != "" && item != "." && item != "..")
                        listBox1.Items.Add(item);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            dirPath.Text = selectedPath + listBox1.Items[listBox1.SelectedIndex];
            if (dirPath.Text != @"/")
                dirPath.Text += @"/";

        }
    }
}
