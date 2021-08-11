using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureMe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if(this.WindowState==FormWindowState.Minimized)
            {
                this.Hide();
                notifyCaptureMe.ShowBalloonTip(1000,"Capture Me", "Capture Me Application is running to capture your screens at each 10 mins of interval.", ToolTipIcon.Info);
            }
        }

        private void notifyCaptureMe_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            var timer = new System.Threading.Timer(
                ex => SaveImage(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromMinutes(2));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void SaveImage()
        {

            var currentImage = CaptureScreen();
            currentImage.Save(string.Format(@"C:\Users\hp\Documents\CaptureImage\ShivKishor_{0}.jpg", DateString()), ImageFormat.Jpeg);

           
        }

        private string DateString()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");

        }


        private static Image CaptureScreen()
        {
            Rectangle screenSize = Screen.PrimaryScreen.Bounds;
            var target = new Bitmap(screenSize.Width, screenSize.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(screenSize.Width, screenSize.Height));
            }
            return target;
        }


    }
}
