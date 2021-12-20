namespace VideoThumbnailCreator
{
    partial class frmVideoThumbnail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVideoThumbnail));
            this.picThumb = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.rdImage = new System.Windows.Forms.RadioButton();
            this.txtImageFilepath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.rdImageTimePosition = new System.Windows.Forms.RadioButton();
            this.nudH = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudM = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudS = new System.Windows.Forms.NumericUpDown();
            this.nudMS = new System.Windows.Forms.NumericUpDown();
            this.lblH = new System.Windows.Forms.Label();
            this.lblM = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.lblMS = new System.Windows.Forms.Label();
            this.tbImage = new System.Windows.Forms.TrackBar();
            this.chkApplyToAllVideos = new System.Windows.Forms.CheckBox();
            this.chkReverseTimePosition = new System.Windows.Forms.CheckBox();
            this.rdDurationPercentage = new System.Windows.Forms.RadioButton();
            this.cmbDurationPercentage = new System.Windows.Forms.ComboBox();
            this.btnShowPreview = new System.Windows.Forms.Button();
            this.btnSaveThumbnail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picThumb
            // 
            resources.ApplyResources(this.picThumb, "picThumb");
            this.picThumb.BackColor = System.Drawing.Color.DimGray;
            this.picThumb.Name = "picThumb";
            this.picThumb.TabStop = false;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::VideoThumbnailCreator.Properties.Resources.exit;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Image = global::VideoThumbnailCreator.Properties.Resources.check;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // rdImage
            // 
            resources.ApplyResources(this.rdImage, "rdImage");
            this.rdImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdImage.Name = "rdImage";
            this.rdImage.TabStop = true;
            this.rdImage.UseVisualStyleBackColor = true;
            this.rdImage.CheckedChanged += new System.EventHandler(this.rdImage_CheckedChanged);
            // 
            // txtImageFilepath
            // 
            resources.ApplyResources(this.txtImageFilepath, "txtImageFilepath");
            this.txtImageFilepath.Name = "txtImageFilepath";
            this.txtImageFilepath.ReadOnly = true;
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // rdImageTimePosition
            // 
            resources.ApplyResources(this.rdImageTimePosition, "rdImageTimePosition");
            this.rdImageTimePosition.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdImageTimePosition.Name = "rdImageTimePosition";
            this.rdImageTimePosition.TabStop = true;
            this.rdImageTimePosition.UseVisualStyleBackColor = true;
            this.rdImageTimePosition.CheckedChanged += new System.EventHandler(this.rdImageTimePosition_CheckedChanged);
            // 
            // nudH
            // 
            resources.ApplyResources(this.nudH, "nudH");
            this.nudH.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.nudH.Name = "nudH";
            this.nudH.ValueChanged += new System.EventHandler(this.nudH_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // nudM
            // 
            resources.ApplyResources(this.nudM, "nudM");
            this.nudM.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudM.Name = "nudM";
            this.nudM.ValueChanged += new System.EventHandler(this.nudH_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // nudS
            // 
            resources.ApplyResources(this.nudS, "nudS");
            this.nudS.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudS.Name = "nudS";
            this.nudS.ValueChanged += new System.EventHandler(this.nudH_ValueChanged);
            // 
            // nudMS
            // 
            resources.ApplyResources(this.nudMS, "nudMS");
            this.nudMS.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudMS.Name = "nudMS";
            this.nudMS.ValueChanged += new System.EventHandler(this.nudH_ValueChanged);
            // 
            // lblH
            // 
            resources.ApplyResources(this.lblH, "lblH");
            this.lblH.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblH.Name = "lblH";
            // 
            // lblM
            // 
            resources.ApplyResources(this.lblM, "lblM");
            this.lblM.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblM.Name = "lblM";
            // 
            // lblS
            // 
            resources.ApplyResources(this.lblS, "lblS");
            this.lblS.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblS.Name = "lblS";
            // 
            // lblMS
            // 
            resources.ApplyResources(this.lblMS, "lblMS");
            this.lblMS.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMS.Name = "lblMS";
            // 
            // tbImage
            // 
            resources.ApplyResources(this.tbImage, "tbImage");
            this.tbImage.Name = "tbImage";
            this.tbImage.Scroll += new System.EventHandler(this.tbImage_Scroll);
            this.tbImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbImage_MouseUp);
            // 
            // chkApplyToAllVideos
            // 
            resources.ApplyResources(this.chkApplyToAllVideos, "chkApplyToAllVideos");
            this.chkApplyToAllVideos.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkApplyToAllVideos.Name = "chkApplyToAllVideos";
            this.chkApplyToAllVideos.UseVisualStyleBackColor = true;
            // 
            // chkReverseTimePosition
            // 
            resources.ApplyResources(this.chkReverseTimePosition, "chkReverseTimePosition");
            this.chkReverseTimePosition.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkReverseTimePosition.Name = "chkReverseTimePosition";
            this.chkReverseTimePosition.UseVisualStyleBackColor = true;
            this.chkReverseTimePosition.CheckedChanged += new System.EventHandler(this.chkReverseTimePosition_CheckedChanged);
            // 
            // rdDurationPercentage
            // 
            resources.ApplyResources(this.rdDurationPercentage, "rdDurationPercentage");
            this.rdDurationPercentage.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdDurationPercentage.Name = "rdDurationPercentage";
            this.rdDurationPercentage.TabStop = true;
            this.rdDurationPercentage.UseVisualStyleBackColor = true;
            this.rdDurationPercentage.CheckedChanged += new System.EventHandler(this.rdDurationPercentage_CheckedChanged);
            // 
            // cmbDurationPercentage
            // 
            resources.ApplyResources(this.cmbDurationPercentage, "cmbDurationPercentage");
            this.cmbDurationPercentage.FormattingEnabled = true;
            this.cmbDurationPercentage.Name = "cmbDurationPercentage";
            this.cmbDurationPercentage.SelectedIndexChanged += new System.EventHandler(this.cmbDurationPercentage_SelectedIndexChanged);
            this.cmbDurationPercentage.TextChanged += new System.EventHandler(this.cmbDurationPercentage_TextChanged);
            // 
            // btnShowPreview
            // 
            resources.ApplyResources(this.btnShowPreview, "btnShowPreview");
            this.btnShowPreview.Name = "btnShowPreview";
            this.btnShowPreview.UseVisualStyleBackColor = true;
            this.btnShowPreview.Click += new System.EventHandler(this.btnShowPreview_Click);
            // 
            // btnSaveThumbnail
            // 
            this.btnSaveThumbnail.Image = global::VideoThumbnailCreator.Properties.Resources.disk_blue;
            resources.ApplyResources(this.btnSaveThumbnail, "btnSaveThumbnail");
            this.btnSaveThumbnail.Name = "btnSaveThumbnail";
            this.btnSaveThumbnail.UseVisualStyleBackColor = true;
            this.btnSaveThumbnail.Click += new System.EventHandler(this.btnSaveThumbnail_Click);
            // 
            // frmVideoThumbnail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnSaveThumbnail);
            this.Controls.Add(this.btnShowPreview);
            this.Controls.Add(this.cmbDurationPercentage);
            this.Controls.Add(this.rdDurationPercentage);
            this.Controls.Add(this.chkReverseTimePosition);
            this.Controls.Add(this.chkApplyToAllVideos);
            this.Controls.Add(this.tbImage);
            this.Controls.Add(this.lblMS);
            this.Controls.Add(this.lblS);
            this.Controls.Add(this.lblM);
            this.Controls.Add(this.lblH);
            this.Controls.Add(this.nudMS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudH);
            this.Controls.Add(this.rdImageTimePosition);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtImageFilepath);
            this.Controls.Add(this.rdImage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.picThumb);
            this.Name = "frmVideoThumbnail";
            this.Load += new System.EventHandler(this.frmVideoThumbnail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picThumb;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.RadioButton rdImage;
        private System.Windows.Forms.TextBox txtImageFilepath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.RadioButton rdImageTimePosition;
        private System.Windows.Forms.NumericUpDown nudH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudS;
        private System.Windows.Forms.NumericUpDown nudMS;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblM;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Label lblMS;
        private System.Windows.Forms.TrackBar tbImage;
        public System.Windows.Forms.CheckBox chkApplyToAllVideos;
        public System.Windows.Forms.CheckBox chkReverseTimePosition;
        private System.Windows.Forms.RadioButton rdDurationPercentage;
        private System.Windows.Forms.ComboBox cmbDurationPercentage;
        private System.Windows.Forms.Button btnShowPreview;
        private System.Windows.Forms.Button btnSaveThumbnail;
    }
}
