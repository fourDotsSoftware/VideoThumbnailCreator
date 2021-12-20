namespace VideoThumbnailCreator
{
    partial class frmVideoInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVideoInfo));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblFilepath = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblVDAR = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lblVSAR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dgVMetadata = new System.Windows.Forms.DataGridView();
            this.colMetadataName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMetadataValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDuration = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVPixelFormat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblVSize = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVBitrate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVFramerate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVEncoder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgAMetadata = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAEncoder = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblABitrate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAChannels = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblASampleFormat = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblASamplingRate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVMetadata)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAMetadata)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblFilepath});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // slblFilepath
            // 
            this.slblFilepath.ForeColor = System.Drawing.Color.DimGray;
            this.slblFilepath.Name = "slblFilepath";
            resources.ApplyResources(this.slblFilepath, "slblFilepath");
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Image = global::VideoThumbnailCreator.Properties.Resources.check;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblVDAR);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.lblVSAR);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.dgVMetadata);
            this.tabPage1.Controls.Add(this.lblDuration);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lblVPixelFormat);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lblVSize);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lblVBitrate);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lblVFramerate);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.lblVEncoder);
            this.tabPage1.Controls.Add(this.label1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblVDAR
            // 
            resources.ApplyResources(this.lblVDAR, "lblVDAR");
            this.lblVDAR.Name = "lblVDAR";
            this.lblVDAR.ReadOnly = true;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.DarkBlue;
            this.label13.Name = "label13";
            // 
            // lblVSAR
            // 
            resources.ApplyResources(this.lblVSAR, "lblVSAR");
            this.lblVSAR.Name = "lblVSAR";
            this.lblVSAR.ReadOnly = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Name = "label8";
            // 
            // dgVMetadata
            // 
            this.dgVMetadata.AllowUserToAddRows = false;
            this.dgVMetadata.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgVMetadata, "dgVMetadata");
            this.dgVMetadata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgVMetadata.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgVMetadata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVMetadata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMetadataName,
            this.colMetadataValue});
            this.dgVMetadata.Name = "dgVMetadata";
            this.dgVMetadata.RowHeadersVisible = false;
            // 
            // colMetadataName
            // 
            this.colMetadataName.DataPropertyName = "metadataname";
            resources.ApplyResources(this.colMetadataName, "colMetadataName");
            this.colMetadataName.Name = "colMetadataName";
            this.colMetadataName.ReadOnly = true;
            // 
            // colMetadataValue
            // 
            this.colMetadataValue.DataPropertyName = "metadataval";
            resources.ApplyResources(this.colMetadataValue, "colMetadataValue");
            this.colMetadataValue.Name = "colMetadataValue";
            this.colMetadataValue.ReadOnly = true;
            // 
            // lblDuration
            // 
            resources.ApplyResources(this.lblDuration, "lblDuration");
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.ReadOnly = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Name = "label6";
            // 
            // lblVPixelFormat
            // 
            resources.ApplyResources(this.lblVPixelFormat, "lblVPixelFormat");
            this.lblVPixelFormat.Name = "lblVPixelFormat";
            this.lblVPixelFormat.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Name = "label5";
            // 
            // lblVSize
            // 
            resources.ApplyResources(this.lblVSize, "lblVSize");
            this.lblVSize.Name = "lblVSize";
            this.lblVSize.ReadOnly = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Name = "label4";
            // 
            // lblVBitrate
            // 
            resources.ApplyResources(this.lblVBitrate, "lblVBitrate");
            this.lblVBitrate.Name = "lblVBitrate";
            this.lblVBitrate.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Name = "label3";
            // 
            // lblVFramerate
            // 
            resources.ApplyResources(this.lblVFramerate, "lblVFramerate");
            this.lblVFramerate.Name = "lblVFramerate";
            this.lblVFramerate.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Name = "label2";
            // 
            // lblVEncoder
            // 
            resources.ApplyResources(this.lblVEncoder, "lblVEncoder");
            this.lblVEncoder.Name = "lblVEncoder";
            this.lblVEncoder.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Name = "label1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgAMetadata);
            this.tabPage2.Controls.Add(this.lblAEncoder);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.lblABitrate);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.lblAChannels);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.lblASampleFormat);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.lblASamplingRate);
            this.tabPage2.Controls.Add(this.label12);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgAMetadata
            // 
            this.dgAMetadata.AllowUserToAddRows = false;
            this.dgAMetadata.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgAMetadata, "dgAMetadata");
            this.dgAMetadata.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAMetadata.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dgAMetadata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAMetadata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgAMetadata.Name = "dgAMetadata";
            this.dgAMetadata.RowHeadersVisible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "metadataname";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "metadataval";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // lblAEncoder
            // 
            resources.ApplyResources(this.lblAEncoder, "lblAEncoder");
            this.lblAEncoder.Name = "lblAEncoder";
            this.lblAEncoder.ReadOnly = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Name = "label7";
            // 
            // lblABitrate
            // 
            resources.ApplyResources(this.lblABitrate, "lblABitrate");
            this.lblABitrate.Name = "lblABitrate";
            this.lblABitrate.ReadOnly = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Name = "label9";
            // 
            // lblAChannels
            // 
            resources.ApplyResources(this.lblAChannels, "lblAChannels");
            this.lblAChannels.Name = "lblAChannels";
            this.lblAChannels.ReadOnly = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Name = "label10";
            // 
            // lblASampleFormat
            // 
            resources.ApplyResources(this.lblASampleFormat, "lblASampleFormat");
            this.lblASampleFormat.Name = "lblASampleFormat";
            this.lblASampleFormat.ReadOnly = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Name = "label11";
            // 
            // lblASamplingRate
            // 
            resources.ApplyResources(this.lblASamplingRate, "lblASamplingRate");
            this.lblASamplingRate.Name = "lblASamplingRate";
            this.lblASamplingRate.ReadOnly = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.ForeColor = System.Drawing.Color.DarkBlue;
            this.label12.Name = "label12";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "metadataname";
            resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "metadataval";
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // frmVideoInfo
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmVideoInfo";
            this.Load += new System.EventHandler(this.frmVideoInfo_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVMetadata)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAMetadata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgVMetadata;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetadataName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetadataValue;
        private System.Windows.Forms.TextBox lblDuration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lblVPixelFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox lblVSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lblVBitrate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox lblVFramerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lblVEncoder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgAMetadata;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox lblAEncoder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox lblABitrate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox lblAChannels;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox lblASampleFormat;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox lblASamplingRate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slblFilepath;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox lblVDAR;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox lblVSAR;
        private System.Windows.Forms.Label label8;
    }
}
