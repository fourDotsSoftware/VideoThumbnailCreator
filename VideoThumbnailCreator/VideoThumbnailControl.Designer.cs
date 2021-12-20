namespace VideoCutterJoinerExpert
{
    partial class VideoThumbnailControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPos = new System.Windows.Forms.Label();
            this.picThumbnail = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPos
            // 
            this.lblPos.BackColor = System.Drawing.Color.LightGray;
            this.lblPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPos.ForeColor = System.Drawing.Color.DimGray;
            this.lblPos.Location = new System.Drawing.Point(3, 106);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(153, 18);
            this.lblPos.TabIndex = 3;
            this.lblPos.Text = "00:00:00.00";
            this.lblPos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picThumbnail
            // 
            this.picThumbnail.Location = new System.Drawing.Point(2, 1);
            this.picThumbnail.Name = "picThumbnail";
            this.picThumbnail.Size = new System.Drawing.Size(156, 100);
            this.picThumbnail.TabIndex = 2;
            this.picThumbnail.TabStop = false;
            // 
            // VideoThumbnailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblPos);
            this.Controls.Add(this.picThumbnail);
            this.Name = "VideoThumbnailControl";
            this.Size = new System.Drawing.Size(161, 126);
            ((System.ComponentModel.ISupportInitialize)(this.picThumbnail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblPos;
        public System.Windows.Forms.PictureBox picThumbnail;
    }
}
