using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;

namespace VideoThumbnailCreator
{
    public partial class frmDownloadRequiredUpdate : VideoThumbnailCreator.CustomForm
    {
        public string DownloadFilename = "";
        public string DownloadURL = "";
        public string DestinationFilepath = "";
        public string TempDownloadFilepath = "";
        public string TextFile = "";

        public WebClient client = null;
        public bool Cancelled = false;

        public frmDownloadRequiredUpdate(string download_filename,string download_url,string destination_filepath,string text_file,string caption)
        {
            InitializeComponent();

            pgBar.Value = 0;
            pgBar.Maximum = 100;

            DownloadFilename = download_filename;
            DownloadURL = download_url;
            DestinationFilepath = destination_filepath;
            TextFile = text_file;

            TempDownloadFilepath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), download_filename);

            this.Text = caption;
        }        

        private void frmDownloadRequiredUpdate_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(TempDownloadFilepath))
            {
                System.IO.File.Delete(TempDownloadFilepath);
            }

            client = new WebClient();
            client.DownloadProgressChanged += client_DownloadProgressChanged;
            client.DownloadFileCompleted += client_DownloadFileCompleted;
            client.DownloadFileAsync(new Uri(DownloadURL), TempDownloadFilepath);
        }

        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!Cancelled)
            {
                Module.ShowMessage("Download Complete. Please allow UAC to Move File");

                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "4dotsAdminActions.exe");
                p.StartInfo.Arguments = "-movefile \"" + TempDownloadFilepath + "\" \"" + DestinationFilepath + "\" \"" + TextFile + "\"";
                p.Start();

                p.WaitForExit();

                if (p.ExitCode == 0)
                {
                    Module.ShowMessage("Application was updated successfully !");
                }
                else
                {
                    Module.ShowMessage("Error could not update application !");
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            pgBar.Value = e.ProgressPercentage;
            pgBar.SetText(e.ProgressPercentage.ToString() + " %");

            decimal ukb = (decimal)e.TotalBytesToReceive / (decimal)1024;
            decimal umb = ukb / (decimal)1024;

            lblTotalSize.Text = umb.ToString("#0.0") + " MB";
        }        

        private void btnCancelDownload_Click(object sender, EventArgs e)
        {
            Cancelled = true;

            client.CancelAsync();

            this.DialogResult = DialogResult.Cancel;
        }
    }
}
