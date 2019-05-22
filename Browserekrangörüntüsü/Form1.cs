using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Browserekrangörüntüsü
{
    public partial class Form1 : Form
    {
        public IWebDriver drv;
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            drv = new ChromeDriver(service);
            InitializeComponent();
        }
        string url = "https://web.whatsapp.com/"; Thread th;
        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                Hide();
                drv.Navigate().GoToUrl(url); 
                timer1.Start();
               
            }
            catch
            {
                drv.Quit();
                Application.Exit();
            }
           // th = new Thread(resimcek);th.Start();
        }
        void resimcek()
        {
            string path = @"C:\";
            Screenshot ss = ((ITakesScreenshot)drv).GetScreenshot();
            ss.SaveAsFile((path + "s1"));
            // pictureBox1.Image = Base64ToImage(ss.ToString());
        }
        Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            resimcek();
        }
    }
}
