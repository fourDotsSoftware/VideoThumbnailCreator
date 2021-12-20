using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VideoThumbnailCreator
{
    public partial class frmVideoThumbnail : VideoThumbnailCreator.CustomForm
    {
        private string Filepath = "";

        public Image ThumbnailImage = null;
        public string ThumbnailImageFilepath = "";

        private string TimePositionString = "";
        private int DurationMsecs = 0;

        public frmVideoThumbnail(string filepath, int durationMsecs):this(
            filepath,
            durationMsecs,
            Properties.Settings.Default.DefaultTimePosition,Properties.Settings.Default.DefaultTimePositiionMsecs,
            Properties.Settings.Default.DefaultImageFilepath,
            Properties.Settings.Default.ReverseTimePosition,
            Properties.Settings.Default.ImageFromDurationPercentage,
            Properties.Settings.Default.DurationPercentage,
            Properties.Settings.Default.DurationPercentageText
            )
        {

        }

        public frmVideoThumbnail(
            string filepath,int durationMsecs,bool timePosition,int timePositionMsecs,string imageFilepath
            ,bool reverseTimePosition,bool durationPercentage,decimal durationPercentageValue,
            string durationPercentageText)
            
        {
            InitializeComponent();

            Filepath = filepath;

            DurationMsecs = durationMsecs;

            if (timePosition && timePositionMsecs>durationMsecs)
            {
                Module.ShowMessage("Error ! Thumbnail Time Position exceeds Video Duration !");
            }

            if (timePositionMsecs>durationMsecs)
            {
                timePositionMsecs = 0;
            }

            tbImage.Minimum = 0;
            tbImage.Maximum = durationMsecs;

            txtImageFilepath.Text = imageFilepath;

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, timePositionMsecs);

            nudH.Value = ts.Hours;
            nudM.Value = ts.Minutes;
            nudS.Value = ts.Seconds;
            nudMS.Value = (ts.Milliseconds / 100);

            tbImage.Value = timePositionMsecs;

            cmbDurationPercentage.Text = durationPercentageText;

            chkReverseTimePosition.Checked = reverseTimePosition;

            if (timePosition)
            {
                rdImageTimePosition.Checked = true;                

                UpdatePreview();
            }
            else if (durationPercentage)
            {
                rdDurationPercentage.Checked = true;

                UpdatePreview();
            }
            else if (imageFilepath!=string.Empty)
            {                
                rdImage.Checked = true;

                UpdatePreview();
            }            

            chkApplyToAllVideos.Checked = Properties.Settings.Default.ApplyToAllVideos;
        }

        private void rdImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdImage.Checked)
            {
                nudH.Enabled = false;
                nudM.Enabled = false;
                nudS.Enabled = false;
                nudMS.Enabled = false;
                lblH.Enabled = false;
                lblM.Enabled = false;
                lblS.Enabled = false;
                lblMS.Enabled = false;
                txtImageFilepath.Enabled = true;
                btnBrowse.Enabled = true;
                chkReverseTimePosition.Enabled = false;
                tbImage.Enabled = false;
                cmbDurationPercentage.Enabled = false;

                UpdatePreview();
            }
            
        }

        private void UpdatePreview()
        {
            if (InScroll) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (rdImage.Checked)
                {
                    try
                    {
                        if (System.IO.File.Exists(txtImageFilepath.Text))
                        {
                            Image img = Image.FromFile(txtImageFilepath.Text);

                            picThumb.Image = img;

                            ThumbnailImage = img;

                            ThumbnailImageFilepath = txtImageFilepath.Text;
                        }
                        else
                        {
                            picThumb.Image = null;

                            ThumbnailImage = null;

                            ThumbnailImageFilepath = "";
                        }
                    }
                    catch
                    {
                        picThumb.Image = null;

                        ThumbnailImage = null;

                        ThumbnailImageFilepath = "";
                    }
                }
                else if (rdImageTimePosition.Checked)
                {
                    try
                    {
                        TimeSpan ts = new TimeSpan(0, (int)nudH.Value, (int)nudM.Value, (int)nudS.Value, ((int)(nudMS.Value)) * 100);

                        string stime = FFMpegArgsHelperJoin.GetStringFromTime((int)ts.TotalMilliseconds);

                        if (chkReverseTimePosition.Checked)
                        {
                            stime = FFMpegArgsHelperJoin.GetStringFromTime(DurationMsecs-(int)ts.TotalMilliseconds);
                        }

                        VideoThumbnail vth = new VideoThumbnail(Filepath, stime);

                        picThumb.Image = vth.ThumbnailImage;

                        ThumbnailImage = vth.ThumbnailImage;

                        TimePositionString = stime;

                        ThumbnailImageFilepath = vth.ThumbnailFilepath;

                    }
                    catch
                    {
                        picThumb.Image = null;

                        ThumbnailImage = null;

                        TimePositionString = "";

                        ThumbnailImageFilepath = "";
                    }
                }
                else if (rdDurationPercentage.Checked)
                {
                    try
                    {
                        decimal dp = GetDurationPercentage();

                        if (dp<0)
                        {
                            picThumb.Image = null;

                            ThumbnailImage = null;

                            TimePositionString = "";

                            ThumbnailImageFilepath = "";
                        }

                        decimal ddur = (decimal)DurationMsecs;

                        decimal ddp = ddur * dp;

                        string stime = FFMpegArgsHelperJoin.GetStringFromTime((int)ddp);                        

                        VideoThumbnail vth = new VideoThumbnail(Filepath, stime);

                        picThumb.Image = vth.ThumbnailImage;

                        ThumbnailImage = vth.ThumbnailImage;

                        TimePositionString = stime;

                        ThumbnailImageFilepath = vth.ThumbnailFilepath;

                    }
                    catch
                    {
                        picThumb.Image = null;

                        ThumbnailImage = null;

                        TimePositionString = "";

                        ThumbnailImageFilepath = "";
                    }
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }

        private void rdImageTimePosition_CheckedChanged(object sender, EventArgs e)
        {
            if (rdImageTimePosition.Checked)
            {
                nudH.Enabled = true;
                nudM.Enabled = true;
                nudS.Enabled = true;
                nudMS.Enabled = true;
                lblH.Enabled = true;
                lblM.Enabled = true;
                lblS.Enabled = true;
                lblMS.Enabled = true;
                txtImageFilepath.Enabled = false;
                btnBrowse.Enabled = false;
                tbImage.Enabled = true;
                chkReverseTimePosition.Enabled = true;
                cmbDurationPercentage.Enabled = false;

                UpdatePreview();
            }
        }

        private void nudH_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdDurationPercentage.Checked)
            {
                decimal dp = GetDurationPercentage();

                if (dp<0)
                {
                    Module.ShowMessage("Please specify a correct Duration Percentage !");
                    return;
                }
            }

            Properties.Settings.Default.DefaultTimePosition = rdImageTimePosition.Checked;

            Properties.Settings.Default.DefaultImage = rdImage.Checked;

            Properties.Settings.Default.ImageFromDurationPercentage = rdDurationPercentage.Checked;

            if (rdDurationPercentage.Checked)
            {
                Properties.Settings.Default.DurationPercentage = GetDurationPercentage();
                Properties.Settings.Default.DurationPercentageText = cmbDurationPercentage.Text;
            }

            Properties.Settings.Default.ReverseTimePosition = chkReverseTimePosition.Checked;

            TimeSpan ts = new TimeSpan(0, (int)nudH.Value, (int)nudM.Value, (int)nudS.Value, ((int)(nudMS.Value)) * 100);

            Properties.Settings.Default.DefaultTimePositiionMsecs = (int)ts.TotalMilliseconds;

            Properties.Settings.Default.DefaultImageFilepath = txtImageFilepath.Text;

            Properties.Settings.Default.DefaultThumbnailImageFilepath = ThumbnailImageFilepath;

            Properties.Settings.Default.ApplyToAllVideos = chkApplyToAllVideos.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private bool InScroll = false;

        private void tbImage_Scroll(object sender, EventArgs e)
        {
            InScroll = true;

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, tbImage.Value);

            nudH.Value = ts.Hours;
            nudM.Value = ts.Minutes;
            nudS.Value = ts.Seconds;
            nudMS.Value = (ts.Milliseconds / 100);                       

            
        }

        private void tbImage_MouseUp(object sender, MouseEventArgs e)
        {
            InScroll = false;

            UpdatePreview();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif";

            if (ofd.ShowDialog()==DialogResult.OK)
            {
                txtImageFilepath.Text = ofd.FileName;

                UpdatePreview();
            }
        }

        private void btnShowPreview_Click(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void frmVideoThumbnail_Load(object sender, EventArgs e)
        {
            cmbDurationPercentage.Items.Add("1%");
            cmbDurationPercentage.Items.Add("10%");
            cmbDurationPercentage.Items.Add("20%");
            cmbDurationPercentage.Items.Add("30%");
            cmbDurationPercentage.Items.Add("40%");
            cmbDurationPercentage.Items.Add("50%");
            cmbDurationPercentage.Items.Add("60%");
            cmbDurationPercentage.Items.Add("70%");
            cmbDurationPercentage.Items.Add("80%");
            cmbDurationPercentage.Items.Add("90%");
            cmbDurationPercentage.Items.Add("99%");            
        }

        private decimal GetDurationPercentage()
        {
            string txt = cmbDurationPercentage.Text;

            return GetDurationPercentage(txt);
        }
        public static decimal GetDurationPercentage(string txt)
        {
            try
            {                
                if (txt.IndexOf("%") < 0)
                {
                    return -1;
                }
                else
                {
                    txt = txt.Replace("%", "");

                    decimal d = decimal.Parse(txt);
                    decimal d100 = (decimal)100;

                    if (d < 0 || d > 100)
                    {
                        return -1;
                    }

                    decimal dp = d / d100;                    

                    return dp;
                }
            }
            catch
            {
                return -1;
            }
        }

        private void chkReverseTimePosition_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void rdDurationPercentage_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDurationPercentage.Checked)
            {
                nudH.Enabled = false;
                nudM.Enabled = false;
                nudS.Enabled = false;
                nudMS.Enabled = false;
                lblH.Enabled = false;
                lblM.Enabled = false;
                lblS.Enabled = false;
                lblMS.Enabled = false;
                txtImageFilepath.Enabled = false;
                btnBrowse.Enabled = false;
                chkReverseTimePosition.Enabled = false;
                tbImage.Enabled = false;
                cmbDurationPercentage.Enabled = true;

                UpdatePreview();
            }
        }

        private void cmbDurationPercentage_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void cmbDurationPercentage_TextChanged(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void btnSaveThumbnail_Click(object sender, EventArgs e)
        {
            if (picThumb.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JPEG Files (*.jpg)|*.jpg";

                string outfolder = System.IO.Path.GetDirectoryName(Filepath);

                if (Properties.Settings.Default.OutputFolderIndex != 0)
                {
                    outfolder = Properties.Settings.Default.OutputFolder;
                }

                string thumbsavefp = System.IO.Path.Combine(outfolder, System.IO.Path.GetFileNameWithoutExtension(Filepath) + "_thumb.jpg");

                sfd.FileName = thumbsavefp;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    thumbsavefp = sfd.FileName;

                    if (System.IO.File.Exists(thumbsavefp))
                    {
                        FileInfo fi = new FileInfo(thumbsavefp);
                        fi.Attributes = FileAttributes.Normal;
                        fi.Delete();
                    }


                    picThumb.Image.Save(thumbsavefp, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
    }
}
