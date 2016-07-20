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
    public partial class ImgurUploaderWindow : Form
    {
        public ImgurUploaderWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private delegate void UpdateTextDelegate(string filename);
        
        public void ImgurUploaderWindow_DragEnter(object sender, DragEventArgs e)
        {

            
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
               string[] filenameArray = (string[])e.Data.GetData(DataFormats.FileDrop);
               foreach (string file in filenameArray);

               string filenameLast = filenameArray.Last();
               Main.filename = filenameLast;
             
            }

            else
            { string filenameLast = "No filename selected";
            Main.filename = filenameLast;
            }

            textBox1.Invoke(new UpdateTextDelegate(TextUpdate), Main.filename);
            Debug.WriteLine(Main.filename);

            
        }

        private void label2_Click(object sender, EventArgs e, string Filename1)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a Cursor File";

            
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Main.filename = openFileDialog1.FileName;
                Debug.WriteLine(Main.filename);
                textBox1.Invoke(new UpdateTextDelegate(TextUpdate), Main.filename);
            }
        }


        private void TextUpdate(string filename)
        {
            textBox1.Text = filename;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (GoogleSearchCheckbox.Checked)
                Main.UploadOnly = false;
        }

        private void CopyLink_CheckedChanged(object sender, EventArgs e)
        {
            if (CopyLink.Checked)
                Main.Copy2Clipboard = true;
        }


        private void Form_FormClosed(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
         

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ilovecookiez11/imgine-win");
        }
    }

}
