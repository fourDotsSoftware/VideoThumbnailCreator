using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace VideoCutterJoinerExpert
{
    public partial class VideoThumbnailControl : UserControl
    {
        public string TimeString = "";
        public static string CurrentImageTimeString = "";

        public string Filepath = "";

        public bool UpdatingImage = false;

        public VideoThumbnailControl()
        {
            InitializeComponent();

            foreach (Control co in this.Controls)
            {
                co.MouseMove += co_MouseMove;
            }
        }

        void co_MouseMove(object sender, MouseEventArgs e)
        {
            this.Visible = false;
        }

        public void UpdatePosLabel()
        {
            lblPos.Text = TimeString;
        }

        public void UpdateImage()
        {            
            if (UpdatingImage) return;

            try
            {
                if (TimeString != CurrentImageTimeString)
                {
                    UpdatingImage = true;

                    CurrentImageTimeString = TimeString;

                    VideoThumbnail vt = new VideoThumbnail(Filepath, TimeString, 156, 100);

                    if (vt.ThumbnailImage != null)
                    {
                        this.picThumbnail.Image = vt.ThumbnailImage;
                    }
                    else
                    {
                        this.picThumbnail.Image = null;
                    }

                    this.picThumbnail.BackColor = SystemColors.Control;
                }
            }
            catch
            {

                this.picThumbnail.Image = null;
                this.picThumbnail.BackColor = Color.Black;
            }
            finally
            {
                UpdatingImage = false;
            }
        }
    }
}
