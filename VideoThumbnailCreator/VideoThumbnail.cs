using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace VideoThumbnailCreator
{
    class VideoThumbnail
    {
        public Bitmap ThumbnailImage = null;

        public string ThumbnailFilepath = "";

        public static string ThumbnailsPath = System.IO.Path.GetTempPath() + "\\VideoCutterExpertThumbs";

        //public VideoThumbnail(string filepath, string time_position):this(filepath,time_position,"-s 128x65")
        public VideoThumbnail(string filepath, string time_position)
            : this(filepath, time_position, "")
        //: this(filepath, time_position, "-vf scale=94:52")
        //: this(filepath, time_position, "-s 94x52")
        {

        }

        //public VideoThumbnail(string filepath, string time_position, int width,int height):this(filepath,time_position,"-s "+width.ToString()+"x"+height.ToString())
        public VideoThumbnail(string filepath, string time_position, int width, int height)
            : this(filepath, time_position, "-vf scale=" + width.ToString() + ":" + height.ToString())
        {

        }

        public VideoThumbnail(string filepath,string time_position,string strsize)
        {
            try
            {
                
                //frmClip.Instance.Cursor = Cursors.WaitCursor;                

                if (!System.IO.Directory.Exists(ThumbnailsPath))
                {
                    System.IO.Directory.CreateDirectory(ThumbnailsPath);
                }

                string iotempfile = System.IO.Path.Combine(ThumbnailsPath, Guid.NewGuid().ToString() + ".jpg");

                ThumbnailFilepath = iotempfile;

                Module.TempGeneratedFiles.Add(iotempfile);

                Process psFFMpeg = new Process();

                if (Properties.Settings.Default.FFMPEG64Bit == 1)
                {
                    psFFMpeg.StartInfo.FileName = "ffmpeg64 ";
                }
                else
                {
                    psFFMpeg.StartInfo.FileName = "ffmpeg32 ";
                }

                psFFMpeg.StartInfo.WorkingDirectory = System.Windows.Forms.Application.StartupPath;

                psFFMpeg.StartInfo.CreateNoWindow = true;
                psFFMpeg.StartInfo.UseShellExecute = false;
                psFFMpeg.StartInfo.RedirectStandardError = true;
                psFFMpeg.StartInfo.RedirectStandardOutput = true;

                psFFMpeg.OutputDataReceived += psFFMpeg_OutputDataReceived;
                psFFMpeg.ErrorDataReceived += psFFMpeg_ErrorDataReceived;

                psFFMpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                LastFFMpegOutput = "";

                last_line = "";            

                psFFMpeg.StartInfo.Arguments = " -ss " + time_position + " -i \"" + filepath + "\" -y "+ strsize+" -f image2 -vcodec mjpeg -vframes 1 \"" + iotempfile + "\"";
                //0psImage.StartInfo.Arguments = " -ao null -frames 1 -identify \"" + file + "\" -vo jpeg:outdir=\"\"\"" + tempdir + "\"\"\"";
                
                psFFMpeg.Start();

                psFFMpeg.BeginErrorReadLine();
                psFFMpeg.BeginOutputReadLine();

                psFFMpeg.WaitForExit();

                psFFMpeg.Close();

                psFFMpeg.Dispose();
                psFFMpeg = null;


                Image img = Image.FromFile(iotempfile);
                Image img2 = (Image)img.Clone();

                /*
                int iwidth = img2.Width;
                int iheight = img2.Height;
                int newheight = 0;
                int newwidth = 0;

                if (iwidth > iheight)
                {
                    newheight = (int)(((float)picPlayer.Width / (float)img2.Width) * img2.Height);
                    newwidth = picPlayer.Width;

                }
                else
                {
                    newwidth = (int)(((float)picPlayer.Height / (float)img2.Height) * img2.Width);
                    newheight = picPlayer.Height;
                }
                Bitmap bmp = new Bitmap(img2, newwidth, newheight);
                 
                */

                Bitmap bmp = new Bitmap(img2);
                img.Dispose();
                img2.Dispose();
                ThumbnailImage = bmp;                

                GC.Collect();

                System.Threading.Thread.Sleep(100);
            }
            catch { }
            finally
            {
                //frmClip.Instance.Cursor = null;
            }
        }

        string LastFFMpegOutput = "";
        string last_line = "";

        void psFFMpeg_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string line = e.Data;

            //Console.WriteLine(line);

            if (line != null)
            {
                last_line = line;
            }

            LastFFMpegOutput += line + "\r\n";
        }

        void psFFMpeg_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

        }

        public static void SaveFrameAsImage(string filepath, bool original_size,int width,int height,string time_position,string outfilepath)
        {
                string ext = System.IO.Path.GetExtension(outfilepath).ToLower();

                string size = "";

                if (!original_size)
                {
                    size = " -vf scale=" + width.ToString() + ":" + height.ToString();
                }

                Process psFFMpeg = new Process();

                if (Properties.Settings.Default.FFMPEG64Bit == 1)
                {
                    psFFMpeg.StartInfo.FileName = "ffmpeg64 ";
                }
                else
                {
                    psFFMpeg.StartInfo.FileName = "ffmpeg32 ";
                }

                psFFMpeg.StartInfo.WorkingDirectory = System.Windows.Forms.Application.StartupPath;

                psFFMpeg.StartInfo.CreateNoWindow = true;
                psFFMpeg.StartInfo.UseShellExecute = false;
                psFFMpeg.StartInfo.RedirectStandardError = true;
                psFFMpeg.StartInfo.RedirectStandardOutput = true;

                psFFMpeg.OutputDataReceived += spsFFMpeg_OutputDataReceived;
                psFFMpeg.ErrorDataReceived += spsFFMpeg_ErrorDataReceived;

                psFFMpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                sLastFFMpegOutput = "";

                slast_line = "";            

                if (ext == ".jpg" || ext == ".jpeg")
                {
                    psFFMpeg.StartInfo.Arguments = " -ss " + time_position + " -i \"" + filepath + "\" -y -f image2 -vcodec mjpeg -vframes 1 "+size+" \"" + outfilepath + "\"";
                }
                else
                {
                    psFFMpeg.StartInfo.Arguments = " -ss " + time_position + " -i \"" + filepath + "\" -y -vframes 1 "+size+" \"" + outfilepath + "\"";
                }

                psFFMpeg.Start();

                psFFMpeg.BeginErrorReadLine();
                psFFMpeg.BeginOutputReadLine();

                psFFMpeg.WaitForExit();

                psFFMpeg.Close();

                psFFMpeg.Dispose();
                psFFMpeg = null;

        }

        static string sLastFFMpegOutput = "";
        static string slast_line = "";

        static void spsFFMpeg_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string line = e.Data;

            //Console.WriteLine(line);

            if (line != null)
            {
                slast_line = line;
            }

            sLastFFMpegOutput += line + "\r\n";
        }

        static void spsFFMpeg_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

        }
    }
}
