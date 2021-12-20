namespace VideoThumbnailCreator
{
    partial class frmImportFromCSV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportFromCSV));
            this.txtColumnThumbnail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDelimiterOther = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFilepath = new System.Windows.Forms.TextBox();
            this.cmbDelimiter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chkHasHeaders = new System.Windows.Forms.CheckBox();
            this.cmbTextDelimiter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEscape = new System.Windows.Forms.TextBox();
            this.txtColumnInput = new System.Windows.Forms.TextBox();
            this.lblColumnOutput = new System.Windows.Forms.Label();
            this.txtColumnParameters = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtColumnThumbnail
            // 
            resources.ApplyResources(this.txtColumnThumbnail, "txtColumnThumbnail");
            this.txtColumnThumbnail.Name = "txtColumnThumbnail";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // txtDelimiterOther
            // 
            resources.ApplyResources(this.txtDelimiterOther, "txtDelimiterOther");
            this.txtDelimiterOther.Name = "txtDelimiterOther";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Name = "label6";
            // 
            // txtFilepath
            // 
            resources.ApplyResources(this.txtFilepath, "txtFilepath");
            this.txtFilepath.Name = "txtFilepath";
            // 
            // cmbDelimiter
            // 
            resources.ApplyResources(this.cmbDelimiter, "cmbDelimiter");
            this.cmbDelimiter.FormattingEnabled = true;
            this.cmbDelimiter.Name = "cmbDelimiter";
            this.cmbDelimiter.SelectedIndexChanged += new System.EventHandler(this.cmbDelimiter_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::VideoThumbnailCreator.Properties.Resources.exit;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = global::VideoThumbnailCreator.Properties.Resources.check;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chkHasHeaders
            // 
            resources.ApplyResources(this.chkHasHeaders, "chkHasHeaders");
            this.chkHasHeaders.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkHasHeaders.Name = "chkHasHeaders";
            this.chkHasHeaders.UseVisualStyleBackColor = true;
            // 
            // cmbTextDelimiter
            // 
            resources.ApplyResources(this.cmbTextDelimiter, "cmbTextDelimiter");
            this.cmbTextDelimiter.FormattingEnabled = true;
            this.cmbTextDelimiter.Name = "cmbTextDelimiter";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // txtEscape
            // 
            resources.ApplyResources(this.txtEscape, "txtEscape");
            this.txtEscape.Name = "txtEscape";
            // 
            // txtColumnInput
            // 
            resources.ApplyResources(this.txtColumnInput, "txtColumnInput");
            this.txtColumnInput.Name = "txtColumnInput";
            // 
            // lblColumnOutput
            // 
            resources.ApplyResources(this.lblColumnOutput, "lblColumnOutput");
            this.lblColumnOutput.BackColor = System.Drawing.Color.Transparent;
            this.lblColumnOutput.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblColumnOutput.Name = "lblColumnOutput";
            // 
            // txtColumnParameters
            // 
            resources.ApplyResources(this.txtColumnParameters, "txtColumnParameters");
            this.txtColumnParameters.Name = "txtColumnParameters";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Name = "label5";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Name = "label8";
            // 
            // frmImportFromCSV
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtColumnParameters);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtColumnInput);
            this.Controls.Add(this.lblColumnOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEscape);
            this.Controls.Add(this.cmbTextDelimiter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkHasHeaders);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtColumnThumbnail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDelimiterOther);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFilepath);
            this.Controls.Add(this.cmbDelimiter);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportFromCSV";
            this.Load += new System.EventHandler(this.frmImportCSV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.CheckBox chkHasHeaders;
        public System.Windows.Forms.TextBox txtColumnThumbnail;
        public System.Windows.Forms.TextBox txtDelimiterOther;
        public System.Windows.Forms.TextBox txtFilepath;
        public System.Windows.Forms.ComboBox cmbDelimiter;
        public System.Windows.Forms.ComboBox cmbTextDelimiter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtEscape;
        public System.Windows.Forms.TextBox txtColumnInput;
        private System.Windows.Forms.Label lblColumnOutput;
        public System.Windows.Forms.TextBox txtColumnParameters;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
