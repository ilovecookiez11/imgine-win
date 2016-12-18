using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ImgurUploaderWin
{
    public partial class UploadingWindow : Form
    {
        public UploadingWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Image thumbnail = Image.FromFile(Main.filename);
            pictureBox1.Image = thumbnail;
            label1.Text = "Uploading " + System.IO.Path.GetFileName(Main.filename) + "...";
        }

      public delegate void CloseDelagate();

      private void button1_Click(object sender, EventArgs e)
      {
          System.Environment.Exit(0);
      }

      private void label1_Click(object sender, EventArgs e)
      {

      }

      private void pictureBox1_Click(object sender, EventArgs e)
      {

      } 

      

    }      
        
        
}
