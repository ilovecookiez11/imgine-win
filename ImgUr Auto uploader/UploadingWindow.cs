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

        }

      public delegate void CloseDelagate();

      private void button1_Click(object sender, EventArgs e)
      {
          System.Environment.Exit(0);
      }

      private void label1_Click(object sender, EventArgs e)
      {

      } 

      

    }      
        
        
}
