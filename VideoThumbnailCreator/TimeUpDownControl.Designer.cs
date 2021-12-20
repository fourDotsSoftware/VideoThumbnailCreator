namespace VideoThumbnailCreator
{
    partial class TimeUpDownControl
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
            this.nUpDown = new System.Windows.Forms.NumericUpDown();
            this.txtBox = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nUpDown
            // 
            this.nUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nUpDown.Location = new System.Drawing.Point(83, 1);
            this.nUpDown.Name = "nUpDown";
            this.nUpDown.Size = new System.Drawing.Size(17, 20);
            this.nUpDown.TabIndex = 118;
            this.nUpDown.ValueChanged += new System.EventHandler(this.nUpDown_ValueChanged);
            // 
            // txtBox
            // 
            this.txtBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtBox.Location = new System.Drawing.Point(1, 0);
            this.txtBox.Mask = "00:00:00.000";
            this.txtBox.Name = "txtBox";
            this.txtBox.PromptChar = '0';
            this.txtBox.ResetOnPrompt = false;
            this.txtBox.ResetOnSpace = false;
            this.txtBox.Size = new System.Drawing.Size(81, 22);
            this.txtBox.TabIndex = 117;
            this.txtBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtBox.Click += new System.EventHandler(this.txtBox_Click);
            this.txtBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBox_KeyUp);
            this.txtBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtBox_MouseUp);
            // 
            // TimeUpDownControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.nUpDown);
            this.Controls.Add(this.txtBox);
            this.Name = "TimeUpDownControl";
            this.Size = new System.Drawing.Size(102, 22);
            ((System.ComponentModel.ISupportInitialize)(this.nUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MaskedTextBox txtBox;
        public System.Windows.Forms.NumericUpDown nUpDown;
    }
}
