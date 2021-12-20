using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoThumbnailCreator
{
    public partial class frmOutputFileAsk : VideoThumbnailCreator.CustomForm
    {
        private string Filepath = "";
        private string Folder = "";
        private string ExistingFilepath = "";

        public static int RepeatActionIndex = 0;
        public static string Prefix = "";
        public static string Suffix = "";

        public frmOutputFileAsk(string filepath,string folder,string existingFilepath)
        {
            InitializeComponent();

            Filepath = filepath;
            Folder = folder;
            ExistingFilepath = existingFilepath;

            txtExistingFile.Text = existingFilepath;

            txtRename.Text = Properties.Settings.Default.RenamePattern;

            txtPrefix.Text = Properties.Settings.Default.OutputPrefix;
            txtSuffix.Text = Properties.Settings.Default.OutputSuffix;

            rdOverwrite_CheckedChanged(null, null);

            chkRepeatAction.Checked=frmMain.Instance.OutputFileActionRepeat;
        }

        private void rdOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            CalculateOutputFile();

            if (sender == rdRename)
            {
                txtRename.Focus();
            }
            else if (sender == rdSuffix)
            {
                txtSuffix.Focus();
            }
            else if (sender == rdPrefix)
            {
                txtPrefix.Focus();
            }
        }

        private void CalculateOutputFile()
        {
            JoinArgsHelper jh = new JoinArgsHelper();

            if (rdOverwrite.Checked)
            {
                txtNewFile.Text = System.IO.Path.GetFileName(ExistingFilepath);
                RepeatActionIndex = 0;
            }
            else if (rdSkip.Checked)
            {
                txtNewFile.Text = "";
                RepeatActionIndex = 1;
            }
            else if (rdRename.Checked)
            {
                txtNewFile.Text = txtRename.Text.Replace("[FILENAME]", System.IO.Path.GetFileNameWithoutExtension(Filepath)) +
                    System.IO.Path.GetExtension(ExistingFilepath);
                RepeatActionIndex = 2;
            }
            else if (rdSuffix.Checked)
            {
                txtNewFile.Text = System.IO.Path.GetFileNameWithoutExtension(
                    jh.GetJoinFileSuffix(Filepath, System.IO.Path.GetExtension(Filepath), txtSuffix.Text))
                +System.IO.Path.GetExtension(ExistingFilepath);

                RepeatActionIndex = 3;
            }
            else if (rdPrefix.Checked)
            {
                txtNewFile.Text = System.IO.Path.GetFileNameWithoutExtension(                    
                    jh.GetJoinFilePrefix(Filepath,System.IO.Path.GetExtension(Filepath),txtPrefix.Text))
                    + System.IO.Path.GetExtension(ExistingFilepath);
                    
                RepeatActionIndex = 4;
            }
            
        }

        public static string CalculateOutputFileRepeatAction(string firstFilepath,string existingFilepath,string folder)
        {                                   
            JoinArgsHelper jh = new JoinArgsHelper();

            if (RepeatActionIndex==0)
            {
                return existingFilepath;
            }
            else if (RepeatActionIndex==1)
            {
                return "-1";
            }
            else if (RepeatActionIndex==2)
            {
                return System.IO.Path.Combine(folder, Properties.Settings.Default.RenamePattern.Replace("[FILENAME]", System.IO.Path.GetFileNameWithoutExtension(firstFilepath)) +
                    System.IO.Path.GetExtension(existingFilepath));
                
            }            
            else if (RepeatActionIndex == 3)
            {
                return System.IO.Path.Combine(folder, System.IO.Path.GetFileNameWithoutExtension(
                    jh.GetJoinFileSuffix(firstFilepath, System.IO.Path.GetExtension(existingFilepath), Suffix)));
            }
            else if (RepeatActionIndex == 4)
            {
                return
                    System.IO.Path.Combine(folder,
                    System.IO.Path.GetFileNameWithoutExtension(
                    jh.GetJoinFilePrefix(firstFilepath, System.IO.Path.GetExtension(existingFilepath), Prefix)));                    
            }
            else
            {
                return "-1";
            }
        }

        private void txtRename_TextChanged(object sender, EventArgs e)
        {
            CalculateOutputFile();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdRename.Checked)
            {
                if (System.IO.File.Exists(txtNewFile.Text))
                {
                    Module.ShowMessage("Renamed File already exists !");
                    return;
                }
            }

            Suffix = txtSuffix.Text;
            Prefix = txtPrefix.Text;

            frmMain.Instance.OutputFileActionRepeat = chkRepeatAction.Checked;
            Properties.Settings.Default.RenamePattern = txtRename.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmOutputFileAsk_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
