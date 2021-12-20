namespace VideoThumbnailCreator
{
    partial class frmOutputFileAsk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutputFileAsk));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.rdPrefix = new System.Windows.Forms.RadioButton();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.rdSuffix = new System.Windows.Forms.RadioButton();
            this.rdRename = new System.Windows.Forms.RadioButton();
            this.rdSkip = new System.Windows.Forms.RadioButton();
            this.rdOverwrite = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNewFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExistingFile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRepeatAction = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Name = "label7";
            // 
            // txtPrefix
            // 
            resources.ApplyResources(this.txtPrefix, "txtPrefix");
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.TextChanged += new System.EventHandler(this.txtRename_TextChanged);
            // 
            // rdPrefix
            // 
            resources.ApplyResources(this.rdPrefix, "rdPrefix");
            this.rdPrefix.BackColor = System.Drawing.Color.Transparent;
            this.rdPrefix.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdPrefix.Name = "rdPrefix";
            this.rdPrefix.UseVisualStyleBackColor = false;
            this.rdPrefix.CheckedChanged += new System.EventHandler(this.rdOverwrite_CheckedChanged);
            // 
            // txtSuffix
            // 
            resources.ApplyResources(this.txtSuffix, "txtSuffix");
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.TextChanged += new System.EventHandler(this.txtRename_TextChanged);
            // 
            // rdSuffix
            // 
            resources.ApplyResources(this.rdSuffix, "rdSuffix");
            this.rdSuffix.BackColor = System.Drawing.Color.Transparent;
            this.rdSuffix.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdSuffix.Name = "rdSuffix";
            this.rdSuffix.UseVisualStyleBackColor = false;
            this.rdSuffix.CheckedChanged += new System.EventHandler(this.rdOverwrite_CheckedChanged);
            // 
            // rdRename
            // 
            resources.ApplyResources(this.rdRename, "rdRename");
            this.rdRename.BackColor = System.Drawing.Color.Transparent;
            this.rdRename.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdRename.Name = "rdRename";
            this.rdRename.UseVisualStyleBackColor = false;
            this.rdRename.CheckedChanged += new System.EventHandler(this.rdOverwrite_CheckedChanged);
            // 
            // rdSkip
            // 
            resources.ApplyResources(this.rdSkip, "rdSkip");
            this.rdSkip.BackColor = System.Drawing.Color.Transparent;
            this.rdSkip.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdSkip.Name = "rdSkip";
            this.rdSkip.UseVisualStyleBackColor = false;
            this.rdSkip.CheckedChanged += new System.EventHandler(this.rdOverwrite_CheckedChanged);
            // 
            // rdOverwrite
            // 
            resources.ApplyResources(this.rdOverwrite, "rdOverwrite");
            this.rdOverwrite.BackColor = System.Drawing.Color.Transparent;
            this.rdOverwrite.Checked = true;
            this.rdOverwrite.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdOverwrite.Name = "rdOverwrite";
            this.rdOverwrite.TabStop = true;
            this.rdOverwrite.UseVisualStyleBackColor = false;
            this.rdOverwrite.CheckedChanged += new System.EventHandler(this.rdOverwrite_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // txtNewFile
            // 
            resources.ApplyResources(this.txtNewFile, "txtNewFile");
            this.txtNewFile.Name = "txtNewFile";
            this.txtNewFile.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // txtExistingFile
            // 
            resources.ApplyResources(this.txtExistingFile, "txtExistingFile");
            this.txtExistingFile.Name = "txtExistingFile";
            this.txtExistingFile.ReadOnly = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // txtRename
            // 
            resources.ApplyResources(this.txtRename, "txtRename");
            this.txtRename.Name = "txtRename";
            this.txtRename.TextChanged += new System.EventHandler(this.txtRename_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtRename);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPrefix);
            this.groupBox1.Controls.Add(this.rdPrefix);
            this.groupBox1.Controls.Add(this.txtSuffix);
            this.groupBox1.Controls.Add(this.rdSuffix);
            this.groupBox1.Controls.Add(this.rdRename);
            this.groupBox1.Controls.Add(this.rdSkip);
            this.groupBox1.Controls.Add(this.rdOverwrite);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkRepeatAction
            // 
            resources.ApplyResources(this.chkRepeatAction, "chkRepeatAction");
            this.chkRepeatAction.BackColor = System.Drawing.Color.Transparent;
            this.chkRepeatAction.Name = "chkRepeatAction";
            this.chkRepeatAction.UseVisualStyleBackColor = false;
            // 
            // frmOutputFileAsk
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.chkRepeatAction);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExistingFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNewFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOutputFileAsk";
            this.Load += new System.EventHandler(this.frmOutputFileAsk_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExistingFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRename;
        public System.Windows.Forms.TextBox txtNewFile;
        public System.Windows.Forms.RadioButton rdPrefix;
        public System.Windows.Forms.RadioButton rdSuffix;
        public System.Windows.Forms.RadioButton rdRename;
        public System.Windows.Forms.RadioButton rdSkip;
        public System.Windows.Forms.RadioButton rdOverwrite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox chkRepeatAction;
    }
}
