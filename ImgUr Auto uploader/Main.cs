using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
//using System.Diagnostics;


namespace ImgurUploaderWin
{
    
    public class Main : ApplicationContext
    {

        public static string filename = "No file selected";
        public static bool UploadOnly = true;
        public static bool Copy2Clipboard = false;

        FetchFile FetchFile = new FetchFile();
        ImgurUploader imgur = new ImgurUploader();
                       
        public Main()
        {
            //Command line parameters stuff
            String[] arguments = Environment.GetCommandLineArgs();
            
            if (arguments.Length > 1 )
            {
                filename = arguments[1];
                

                if (arguments.Length > 2)
                {
                    switch (arguments[2])
                    {
                        case "-upload":
                            UploadOnly = true;
                            break;

                        case "-search":
                            UploadOnly = false;
                            break;

                        default:
                            UploadOnly = true;
                            break;
                    }
                }
            }
            //Command line stuff ends here

            if (filename == "No file selected")
            Application.Run(new ImgurUploaderWindow());
            
            Worker windowWorker = new Worker();
            Thread WindowThread = new Thread(new ThreadStart(windowWorker.DoWork));
            
            byte[] image = FetchFile.Take(filename);

            WindowThread.Start();
            //Debug.WriteLine("Uploading!");
            string result = imgur.UploadImage(image);
            windowWorker.RequestStop();

            if (result.Contains("Error!"))
            {
                Application.Run(new ErrorForm());
                Environment.Exit(0);
            }

            if (Copy2Clipboard == true)
            {
                System.Windows.Forms.Clipboard.SetText(result);
                Application.Run(new CopyClipboard());
            }

            if (UploadOnly == true)
            System.Diagnostics.Process.Start(result);

            else
            {
                string searchResult = "https://www.google.com/searchbyimage?image_url=" + result;
                System.Diagnostics.Process.Start(searchResult);
            }

            Environment.Exit(0);

        } 



        class Worker
    {
            public void DoWork()
            {
                while (!_shouldStop)
                {
                    Application.Run(new UploadingWindow());
                }
            }
            public void RequestStop()
            {
            _shouldStop = true;
            }

        private volatile bool _shouldStop;
        }
        

        void Exit(object sender, EventArgs e)
        {
            
            Environment.Exit(0);
        }
    }
}
