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
        public MainScreen()
        {
            InitializeComponent();

            treeView1.BeforeSelect += treeView1_BeforeSelect;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void sendRequest_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {

        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode rootNode = e.Node.Parent;
            string filePath = "/";
            while (rootNode != null)
            {
                filePath += rootNode.Parent.Name;
                rootNode = rootNode.Parent;
            }

            dirPath.Text = filePath;
        }

        private string GetResponse(string name, string path)
        {
            string url = "http://localhost/Server/" + name+ ".php";
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection {{name, path}};
                var response = webClient.UploadValues(url, pars);
                return Encoding.UTF8.GetString(response);

            }
        }
    }
}
