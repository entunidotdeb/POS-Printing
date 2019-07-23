using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private HttpListener listener = new HttpListener();
        private HttpListenerContext context;
        private HttpListenerRequest request;
        private HttpListenerResponse response;
        private Stream body;
        public Form1()
        {
            listener.Prefixes.Add("http://localhost:8085/");
            listener.Start();
            Console.WriteLine("Listening...");
            context = listener.GetContext();
            request = context.Request;
            response = context.Response;
            body = request.InputStream;
            //InitializeComponent();
            PrintHelpPage();
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void PrintHelpPage()
        {
             
            WebBrowser webBrowserForPrinting = new WebBrowser();

            
            webBrowserForPrinting.DocumentCompleted +=
                new WebBrowserDocumentCompletedEventHandler(PrintDocument);

            
            webBrowserForPrinting.DocumentStream = body;
            Console.WriteLine(body);
        }
        private void PrintDocument(object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Print();
            //Console.WriteLine("reached");
            ((WebBrowser)sender).Dispose();
        }
    }
}
