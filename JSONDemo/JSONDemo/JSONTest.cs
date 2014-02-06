using System;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JSONDemo
{
    public partial class JSONTest : Form
    {
        public JSONTest()
        {
            InitializeComponent();
        }

        private void btnTEST_Click(object sender, EventArgs e)
        {
            string host = "10.4.134.123:8124";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" +host + "?cmd=control");
            request.Method = "POST";
            request.ContentType = "text/html";

            string postJSON = "{\"mode\":\"control\",\"lights\":[{\"id\":\"6\",\"state\":\"on\"}]}";

            byte[] buffer = Encoding.ASCII.GetBytes(postJSON);
            Stream postData = request.GetRequestStream();
            postData.Write(buffer, 0, buffer.Length);
            postData.Close();

            Stream response = request.GetResponse().GetResponseStream();
            StreamReader responseReader = new StreamReader(response);
            string responseJSON = responseReader.ReadToEnd();
        }

        private void btnOFF_Click(object sender, EventArgs e)
        {
            string host = "10.4.134.123:8124";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://" + host + "?cmd=control");
            request.Method = "POST";
            request.ContentType = "text/html";

            string postJSON = "{\"mode\":\"control\",\"lights\":[{\"id\":\"6\",\"state\":\"off\"}]}";

            byte[] buffer = Encoding.ASCII.GetBytes(postJSON);
            Stream postData = request.GetRequestStream();
            postData.Write(buffer, 0, buffer.Length);
            postData.Close();

            Stream response = request.GetResponse().GetResponseStream();
            StreamReader responseReader = new StreamReader(response);
            string responseJSON = responseReader.ReadToEnd();
        }
    }
}
