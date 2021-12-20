using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace VideoThumbnailCreator
{
    public partial class frmOptions : VideoThumbnailCreator.CustomForm
    {
        public frmOptions()
        {
            InitializeComponent();
        }

        private void btnOpenOutputFolder_Click(object sender, EventArgs e)
        {
            string outfolder = "";

            if (cmbOutputFolder.Text == TranslateHelper.Translate("Same as Video Folder"))
            {
                if (frmMain.Instance.CurrentFirstFilepath == string.Empty)
                {
                    Module.ShowMessage("Please add a Video File first !");
                    return;
                }
                else
                {
                    outfolder = System.IO.Path.GetDirectoryName(frmMain.Instance.CurrentFirstFilepath);
                }
            }
            else if (cmbOutputFolder.Text.Trim() == string.Empty) // || !System.IO.Directory.Exists(cmbOutputFolder.Text))
            {
                Module.ShowMessage("Please specify a valid Output Folder !");
                return;
            }
            else
            {
                outfolder = cmbOutputFolder.Text;
            }

            try
            {
                if (!System.IO.Directory.Exists(outfolder))
                {
                    System.IO.Directory.CreateDirectory(outfolder);
                }
            }
            catch
            {
                Module.ShowMessage("Invalid Output Folder !");
                return;
            }

            //string args = string.Format("/e, /select, \"{0}\"", txtOutputFolder.Text);
            string args = string.Format("\"{0}\"", outfolder);
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);

        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            cmbOutputFolder.Items.Add(TranslateHelper.Translate("Same as Video Folder"));
            cmbOutputFolder.Items.Add(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\"+Module.ApplicationName+" Videos");
            cmbOutputFolder.SelectedIndex = 0;

            if (Properties.Settings.Default.OutputFolderIndex == 0
                || Properties.Settings.Default.OutputFolderIndex == 1)
            {
                cmbOutputFolder.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;

            }

            string[] folderz = Properties.Settings.Default.RecentOutputFolders.Split(new string[] { "|||" }, StringSplitOptions.None);

            for (int k = 0; k < folderz.Length; k++)
            {
                if (folderz[k].Trim() != string.Empty)
                {
                    cmbOutputFolder.Items.Add(folderz[k]);

                    if ((Properties.Settings.Default.OutputFolderIndex == -1)
                        && (Properties.Settings.Default.OutputFolder == folderz[k]))
                    {
                        cmbOutputFolder.SelectedIndex = cmbOutputFolder.Items.Count - 1;

                    }
                }
            }

            /*
            string[] folderz = Properties.Settings.Default.RecentOutputFolders.Split(new string[] { "|||" }, StringSplitOptions.None);

            for (int k = 0; k < folderz.Length; k++)
            {
                if (folderz[k].Trim() != string.Empty)
                {
                    cmbOutputFolder.Items.Add(folderz[k]);
                }
            }
            */

            txtOutputFilenamePattern.Text = Properties.Settings.Default.OutputFilenamePattern;

            if (Properties.Settings.Default.OutputWhenExists == 0)
            {
                rdOverwrite.Checked = true;
            }
            else if (Properties.Settings.Default.OutputWhenExists == 1)
            {
                rdSkip.Checked = true;
            }
            else if (Properties.Settings.Default.OutputWhenExists == 2)
            {
                rdAsk.Checked = true;
            }
            else if (Properties.Settings.Default.OutputWhenExists == 3)
            {
                rdSuffix.Checked = true;
            }
            else if (Properties.Settings.Default.OutputWhenExists == 4)
            {
                rdPrefix.Checked = true;
            }

            txtPrefix.Text = Properties.Settings.Default.OutputPrefix;
            txtSuffix.Text = Properties.Settings.Default.OutputSuffix;

            //3cmbOutputFolder.Text = Properties.Settings.Default.OutputFolder;           

            txtOutputFilenamePattern_TextChanged(null, null);

            chkMsgOnSuccess.Checked = Properties.Settings.Default.ShowMsgOnSuccess;

            if ((Properties.Settings.Default.OutputFolderIndex == 0) ||
                (Properties.Settings.Default.OutputFolderIndex == 1))
            {
                cmbOutputFolder.SelectedIndex = Properties.Settings.Default.OutputFolderIndex;
            }

            chkExploreOutputFolder.Checked = Properties.Settings.Default.ExploreOutputFolderWhenDone;
        }

        private void btnBrowseOutputFolder_Click(object sender, EventArgs e)
        {
            if (cmbOutputFolder.Text.Trim() != string.Empty && System.IO.Directory.Exists(cmbOutputFolder.Text))
            {
                folderBrowserDialog1.SelectedPath = cmbOutputFolder.Text;
            }

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                bool found = false;

                for (int k = 0; k < cmbOutputFolder.Items.Count; k++)
                {
                    if (cmbOutputFolder.Items[k].ToString() == folderBrowserDialog1.SelectedPath)
                    {
                        found = true;
                        cmbOutputFolder.SelectedIndex = k;
                        return;
                    }
                }

                if (!found)
                {
                    cmbOutputFolder.Items.Add(folderBrowserDialog1.SelectedPath);
                    cmbOutputFolder.SelectedIndex = cmbOutputFolder.Items.Count - 1;
                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbOutputFolder.Text != TranslateHelper.Translate("Same as Video Folder"))
            {                
                try
                {
                    if (!System.IO.Directory.Exists(cmbOutputFolder.Text))
                    {
                        System.IO.Directory.CreateDirectory(cmbOutputFolder.Text);
                    }
                }
                catch
                {
                    Module.ShowMessage("Invalid Output Folder !");
                    return;
                }
            }

            if (cmbOutputFolder.Text!=cmbOutputFolder.Items[0].ToString() && cmbOutputFolder.Text!=cmbOutputFolder.Items[1].ToString())
            {
                string of = cmbOutputFolder.Text;

                string[] folderz =Properties.Settings.Default.RecentOutputFolders.Split(new string[] { "|||" }, StringSplitOptions.None);

                List<string> lst = new List<string>(folderz);

                lst.Insert(0, of);

                for (int m = 1; m < lst.Count; m++)
                {
                    if (lst[m] == of)
                    {
                        lst.RemoveAt(m);
                        m--;
                    }                    
                }

                string recentof = "";

                for (int m = 0; m < lst.Count && m < 11; m++)
                {
                    recentof += lst[m] + "|||";
                }

                Properties.Settings.Default.RecentOutputFolders = recentof;
            }

            Properties.Settings.Default.OutputFilenamePattern = txtOutputFilenamePattern.Text;

            if (rdOverwrite.Checked)
            {
                Properties.Settings.Default.OutputWhenExists = 0;
            }
            else if (rdSkip.Checked)
            {
                Properties.Settings.Default.OutputWhenExists = 1;
            }
            else if (rdAsk.Checked)
            {
                Properties.Settings.Default.OutputWhenExists = 2;
            }
            else if (rdSuffix.Checked)
            {
                Properties.Settings.Default.OutputWhenExists = 3;
            }
            else if (rdPrefix.Checked)
            {
                Properties.Settings.Default.OutputWhenExists = 4;
            }

            Properties.Settings.Default.OutputPrefix=txtPrefix.Text;
            Properties.Settings.Default.OutputSuffix=txtSuffix.Text;

            Properties.Settings.Default.OutputFolderIndex = (cmbOutputFolder.Text == cmbOutputFolder.Items[0].ToString()) ? 0 :
                (cmbOutputFolder.Text == cmbOutputFolder.Items[1].ToString() ? 1 : -1);

            Properties.Settings.Default.OutputFolder = cmbOutputFolder.Text;

            Properties.Settings.Default.ShowMsgOnSuccess = chkMsgOnSuccess.Checked;

            Properties.Settings.Default.ExploreOutputFolderWhenDone = chkExploreOutputFolder.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void txtOutputFilenamePattern_TextChanged(object sender, EventArgs e)
        {
            string fn = "";

            if (frmMain.Instance.CurrentFirstFilepath != string.Empty)
            {
                fn = System.IO.Path.GetFileNameWithoutExtension(frmMain.Instance.CurrentFirstFilepath);
            }

            txtPreview.Text = txtOutputFilenamePattern.Text.Replace("[FILENAME]",fn);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
