namespace VideoThumbnailCreator
{
    partial class frmDownloadRequiredUpdate
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownloadRequiredUpdate));
            this.lblTotalSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelDownload = new System.Windows.Forms.Button();
            this.pgBar = new VideoThumbnailCreator.ucTextProgressBar();
            this.bwDownload = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblTotalSize
            // 
            this.lblTotalSize.AutoSize = true;
            this.lblTotalSize.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSize.Location = new System.Drawing.Point(110, 78);
            this.lblTotalSize.Name = "lblTotalSize";
            this.lblTotalSize.Size = new System.Drawing.Size(16, 13);
            this.lblTotalSize.TabIndex = 12;
            this.lblTotalSize.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(14, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Update File Size ;";
            // 
            // btnCancelDownload
            // 
            this.btnCancelDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelDownload.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancelDownload.Location = new System.Drawing.Point(405, 29);
            this.btnCancelDownload.Name = "btnCancelDownload";
            this.btnCancelDownload.Size = new System.Drawing.Size(135, 29);
            this.btnCancelDownload.TabIndex = 10;
            this.btnCancelDownload.Text = "&Cancel";
            this.btnCancelDownload.UseVisualStyleBackColor = true;
            this.btnCancelDownload.Click += new System.EventHandler(this.btnCancelDownload_Click);
            // 
            // pgBar
            // 
            this.pgBar.BackColor = System.Drawing.SystemColors.Control;
            this.pgBar.Location = new System.Drawing.Point(14, 27);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(380, 34);
            this.pgBar.TabIndex = 9;
            // 
            // frmDownloadRequiredUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(555, 118);
            this.Controls.Add(this.lblTotalSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelDownload);
            this.Controls.Add(this.pgBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownloadRequiredUpdate";
            this.Text = "Downloading FFMPEG 32-bit Version";
            this.Load += new System.EventHandler(this.frmDownloadRequiredUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotalSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelDownload;
        private ucTextProgressBar pgBar;
        private System.ComponentModel.BackgroundWorker bwDownload;
    }
}
