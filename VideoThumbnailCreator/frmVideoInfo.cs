using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace VideoThumbnailCreator
{
    public partial class frmVideoInfo : VideoThumbnailCreator.CustomForm
    {
        private string Filepath = "";

        public frmVideoInfo(string file)
        {
            InitializeComponent();

            Filepath = file;
        }

        private void frmVideoInfo_Load(object sender, EventArgs e)
        {
            slblFilepath.Text = Filepath;

            FFMPEGInfo finfo = new FFMPEGInfo(Filepath);
            lblABitrate.Text = finfo.AudioBitRate;
            lblAChannels.Text = finfo.AudioChannels;
            lblAEncoder.Text = finfo.AudioEncoder;
            lblASampleFormat.Text = finfo.AudioSampleFormat;
            lblASamplingRate.Text = finfo.AudioSamplingRate;
            lblDuration.Text = finfo.DurationStr;
            lblVBitrate.Text = finfo.VideoBitRate;
            lblVEncoder.Text = finfo.VideoEncoder;
            lblVFramerate.Text = finfo.VideoFrameRate;
            lblVPixelFormat.Text = finfo.VideoPixelFormat;
            lblVSize.Text = finfo.VideoSize;
            lblVSAR.Text = finfo.VideoSAR;
            lblVDAR.Text = finfo.VideoDAR;
            
            DataTable dtam = new DataTable("table");
            dtam.Columns.Add("metadataname");
            dtam.Columns.Add("metadataval");

            foreach (KeyValuePair<string,string> d in finfo.AudioMetadata)
            {
                DataRow dr = dtam.NewRow();
                dr["metadataname"] = d.Key;
                dr["metadataval"] = d.Value;

                dtam.Rows.Add(dr);
            }

            dgAMetadata.DataSource = dtam;

            //---

            DataTable dtvm = new DataTable("table");
            dtvm.Columns.Add("metadataname");
            dtvm.Columns.Add("metadataval");

            foreach (KeyValuePair<string, string> d in finfo.VideoMetadata)
            {
                DataRow dr = dtvm.NewRow();
                dr["metadataname"] = d.Key;
                dr["metadataval"] = d.Value;

                dtvm.Rows.Add(dr);
            }

            dgVMetadata.DataSource = dtvm;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
