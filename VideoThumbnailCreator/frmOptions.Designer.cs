namespace VideoThumbnailCreator
{
    partial class frmOptions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutputFilenamePattern = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdOverwrite = new System.Windows.Forms.RadioButton();
            this.rdSkip = new System.Windows.Forms.RadioButton();
            this.rdAsk = new System.Windows.Forms.RadioButton();
            this.rdSuffix = new System.Windows.Forms.RadioButton();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.rdPrefix = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOpenOutputFolder = new System.Windows.Forms.Button();
            this.btnBrowseOutputFolder = new System.Windows.Forms.Button();
            this.cmbOutputFolder = new System.Windows.Forms.ComboBox();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chkMsgOnSuccess = new System.Windows.Forms.CheckBox();
            this.chkExploreOutputFolder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // txtOutputFilenamePattern
            // 
            resources.ApplyResources(this.txtOutputFilenamePattern, "txtOutputFilenamePattern");
            this.txtOutputFilenamePattern.Name = "txtOutputFilenamePattern";
            this.txtOutputFilenamePattern.TextChanged += new System.EventHandler(this.txtOutputFilenamePattern_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // txtPreview
            // 
            resources.ApplyResources(this.txtPreview, "txtPreview");
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Name = "label5";
            // 
            // rdOverwrite
            // 
            resources.ApplyResources(this.rdOverwrite, "rdOverwrite");
            this.rdOverwrite.BackColor = System.Drawing.Color.Transparent;
            this.rdOverwrite.Checked = true;
            this.rdOverwrite.Name = "rdOverwrite";
            this.rdOverwrite.TabStop = true;
            this.rdOverwrite.UseVisualStyleBackColor = false;
            // 
            // rdSkip
            // 
            resources.ApplyResources(this.rdSkip, "rdSkip");
            this.rdSkip.BackColor = System.Drawing.Color.Transparent;
            this.rdSkip.Name = "rdSkip";
            this.rdSkip.UseVisualStyleBackColor = false;
            // 
            // rdAsk
            // 
            resources.ApplyResources(this.rdAsk, "rdAsk");
            this.rdAsk.BackColor = System.Drawing.Color.Transparent;
            this.rdAsk.Name = "rdAsk";
            this.rdAsk.UseVisualStyleBackColor = false;
            // 
            // rdSuffix
            // 
            resources.ApplyResources(this.rdSuffix, "rdSuffix");
            this.rdSuffix.BackColor = System.Drawing.Color.Transparent;
            this.rdSuffix.Name = "rdSuffix";
            this.rdSuffix.UseVisualStyleBackColor = false;
            // 
            // txtSuffix
            // 
            resources.ApplyResources(this.txtSuffix, "txtSuffix");
            this.txtSuffix.Name = "txtSuffix";
            // 
            // txtPrefix
            // 
            resources.ApplyResources(this.txtPrefix, "txtPrefix");
            this.txtPrefix.Name = "txtPrefix";
            // 
            // rdPrefix
            // 
            resources.ApplyResources(this.rdPrefix, "rdPrefix");
            this.rdPrefix.BackColor = System.Drawing.Color.Transparent;
            this.rdPrefix.Name = "rdPrefix";
            this.rdPrefix.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Name = "label7";
            // 
            // btnOpenOutputFolder
            // 
            resources.ApplyResources(this.btnOpenOutputFolder, "btnOpenOutputFolder");
            this.btnOpenOutputFolder.Image = global::VideoThumbnailCreator.Properties.Resources.folder;
            this.btnOpenOutputFolder.Name = "btnOpenOutputFolder";
            this.toolTip1.SetToolTip(this.btnOpenOutputFolder, resources.GetString("btnOpenOutputFolder.ToolTip"));
            this.btnOpenOutputFolder.UseVisualStyleBackColor = true;
            this.btnOpenOutputFolder.Click += new System.EventHandler(this.btnOpenOutputFolder_Click);
            // 
            // btnBrowseOutputFolder
            // 
            resources.ApplyResources(this.btnBrowseOutputFolder, "btnBrowseOutputFolder");
            this.btnBrowseOutputFolder.Name = "btnBrowseOutputFolder";
            this.toolTip1.SetToolTip(this.btnBrowseOutputFolder, resources.GetString("btnBrowseOutputFolder.ToolTip"));
            this.btnBrowseOutputFolder.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFolder.Click += new System.EventHandler(this.btnBrowseOutputFolder_Click);
            // 
            // cmbOutputFolder
            // 
            resources.ApplyResources(this.cmbOutputFolder, "cmbOutputFolder");
            this.cmbOutputFolder.BackColor = System.Drawing.SystemColors.Control;
            this.cmbOutputFolder.FormattingEnabled = true;
            this.cmbOutputFolder.Name = "cmbOutputFolder";
            // 
            // lblOutputFolder
            // 
            resources.ApplyResources(this.lblOutputFolder, "lblOutputFolder");
            this.lblOutputFolder.BackColor = System.Drawing.Color.Transparent;
            this.lblOutputFolder.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblOutputFolder.Name = "lblOutputFolder";
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
            // chkMsgOnSuccess
            // 
            resources.ApplyResources(this.chkMsgOnSuccess, "chkMsgOnSuccess");
            this.chkMsgOnSuccess.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkMsgOnSuccess.Name = "chkMsgOnSuccess";
            this.chkMsgOnSuccess.UseVisualStyleBackColor = true;
            // 
            // chkExploreOutputFolder
            // 
            resources.ApplyResources(this.chkExploreOutputFolder, "chkExploreOutputFolder");
            this.chkExploreOutputFolder.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkExploreOutputFolder.Name = "chkExploreOutputFolder";
            this.chkExploreOutputFolder.UseVisualStyleBackColor = true;
            // 
            // frmOptions
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.chkExploreOutputFolder);
            this.Controls.Add(this.chkMsgOnSuccess);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnOpenOutputFolder);
            this.Controls.Add(this.btnBrowseOutputFolder);
            this.Controls.Add(this.cmbOutputFolder);
            this.Controls.Add(this.lblOutputFolder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.rdPrefix);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.rdSuffix);
            this.Controls.Add(this.rdAsk);
            this.Controls.Add(this.rdSkip);
            this.Controls.Add(this.rdOverwrite);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPreview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOutputFilenamePattern);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptions";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOutputFilenamePattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdOverwrite;
        private System.Windows.Forms.RadioButton rdSkip;
        private System.Windows.Forms.RadioButton rdAsk;
        private System.Windows.Forms.RadioButton rdSuffix;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.RadioButton rdPrefix;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOpenOutputFolder;
        private System.Windows.Forms.Button btnBrowseOutputFolder;
        public System.Windows.Forms.ComboBox cmbOutputFolder;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkMsgOnSuccess;
        private System.Windows.Forms.CheckBox chkExploreOutputFolder;
    }
}
