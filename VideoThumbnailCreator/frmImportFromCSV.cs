using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LumenWorks.Framework.IO.Csv;
using System.IO;

namespace VideoThumbnailCreator
{
    public partial class frmImportFromCSV : VideoThumbnailCreator.CustomForm
    {        
        public frmImportFromCSV()
        {
            InitializeComponent();
        }        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFilepath.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify a CSV File !");
                return;
            }

            if (!System.IO.File.Exists(txtFilepath.Text))
            {
                Module.ShowMessage("Please specify a valid CSV FIle !");
                return;

            }

            if (cmbDelimiter.SelectedIndex==5 && txtDelimiterOther.Text.Trim()==string.Empty)
            {
                Module.ShowMessage("Please specify a valid Delimiter !");
                return;

            }

            int column;

            if (txtColumnThumbnail.Text.Trim()==string.Empty || !int.TryParse(txtColumnThumbnail.Text,out column))
            {
                Module.ShowMessage("Please specify a valid Videos to Join Column !");
                return;
            }

            /*
            if (BatchJoin)
            {
                int outcolumn;

                if (txtColumnOutput.Text.Trim() == string.Empty || !int.TryParse(txtColumnOutput.Text, out outcolumn))
                {
                    Module.ShowMessage("Please specify a valid Output Video Column !");
                    return;
                }
            }
            */

            this.DialogResult = DialogResult.OK;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilepath.Text = openFileDialog1.FileName;
            }
        }

        private void frmImportCSV_Load(object sender, EventArgs e)
        {
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Comma (,)"));
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Tab (     )"));
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Semicolon (;)"));
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Colon (:)"));
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Space ( )"));
            cmbDelimiter.Items.Add(TranslateHelper.Translate("Other"));
            cmbDelimiter.SelectedIndex = 0;

            cmbTextDelimiter.Items.Add("\"");
            cmbTextDelimiter.Items.Add("'");
            cmbTextDelimiter.SelectedIndex = 0;

            txtEscape.Text="/";

        }

        private void cmbDelimiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDelimiter.SelectedIndex == 5)
            {
                txtDelimiterOther.Visible = true;
            }
            else
            {
                txtDelimiterOther.Visible = false;
            }
        }

        private char GetSelectedDelimiter()
        {            
            switch (cmbDelimiter.SelectedIndex)
            {
                case 0:
                    return ',';
                    break;
                case 1:
                    return '\t';
                    break;
                case 2:
                    return ';';
                    break;
                case 3:
                    return ':';
                    break;
                case 4:
                    return ' ';
                    break;
                case 5:
                    return txtDelimiterOther.Text[0];
                    break;
                default:
                    return ',';
                    break;
            }
        }

        public bool ImportCSV(string filepath)
        {
            int columnInput = int.Parse(txtColumnInput.Text);
            int columnThumb = int.Parse(txtColumnThumbnail.Text);
            int columnParameters = int.Parse(txtColumnParameters.Text);

            string curdir = Environment.CurrentDirectory;

            try
            {
                Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(filepath);

                char delim = GetSelectedDelimiter();
                char quote = cmbTextDelimiter.SelectedItem.ToString()[0];

                char escape = txtEscape.Text[0];

                using (CsvReader csv = new CsvReader(new StreamReader(filepath), chkHasHeaders.Checked,delim ,quote, escape, '#', ValueTrimmingOptions.All))
                {
                    int fieldCount = csv.FieldCount;
                    string[] headers = csv.GetFieldHeaders();


                    while (csv.ReadNextRecord())
                    {
                        string file = ArgsHelper.RemoveQuotes(csv[columnInput - 1]);
                        string fullfilepath = System.IO.Path.GetFullPath(file);

                        bool fromimage = Properties.Settings.Default.DefaultImage;
                        string imagefp = Properties.Settings.Default.DefaultImageFilepath;
                        bool fromtp = Properties.Settings.Default.DefaultTimePosition;
                        int tpmsecs = Properties.Settings.Default.DefaultTimePositiionMsecs;
                        bool fromdur = Properties.Settings.Default.ImageFromDurationPercentage;
                        string durtxt = Properties.Settings.Default.DurationPercentageText;
                        decimal dur = Properties.Settings.Default.DurationPercentage;
                        bool reversed = Properties.Settings.Default.ReverseTimePosition;

                        try
                        {                            
                            string thumb = ArgsHelper.RemoveQuotes(csv[columnThumb - 1]);

                            string parameters = "";

                            try
                            {
                                parameters = ArgsHelper.RemoveQuotes(csv[columnParameters - 1]);
                            }
                            catch { }

                            Properties.Settings.Default.DefaultImage = false;
                            Properties.Settings.Default.DefaultTimePosition = false;
                            Properties.Settings.Default.ImageFromDurationPercentage = false;

                            if (System.IO.File.Exists(thumb))
                            {
                                Properties.Settings.Default.DefaultImage = true;
                                Properties.Settings.Default.DefaultTimePosition = false;
                                Properties.Settings.Default.ImageFromDurationPercentage = false;

                                Properties.Settings.Default.DefaultImageFilepath = thumb;
                            }
                            else if (thumb.IndexOf(":")>=0)
                            {
                                try
                                {
                                    int msecs = FFMpegArgsHelper.GetTimeFromString(thumb);

                                    if (parameters.Trim().ToLower()=="reversed")
                                    {
                                        Properties.Settings.Default.ReverseTimePosition = true;
                                    }

                                    Properties.Settings.Default.DefaultTimePosition = true;
                                    Properties.Settings.Default.DefaultTimePositiionMsecs = msecs;
                                }
                                catch { }
                            }
                            else if (thumb.IndexOf("%")>=0)
                            {
                                try
                                {
                                    decimal ddur = frmVideoThumbnail.GetDurationPercentage(thumb);

                                    Properties.Settings.Default.DurationPercentage = ddur;
                                    Properties.Settings.Default.DurationPercentageText = thumb;
                                    Properties.Settings.Default.ImageFromDurationPercentage = true;
                                }
                                catch { }
                            }

                            frmMain.Instance.AddFile(fullfilepath);
                            /*
                            for (int i = 0; i < fieldCount; i++)
                                Console.Write(string.Format("{0} = {1};", headers[i], csv[i]));
                             * 
                             * Console.WriteLine();
                            */
                        }
                        finally
                        {
                            Properties.Settings.Default.DefaultImage = fromimage;
                            Properties.Settings.Default.DefaultImageFilepath=imagefp;
                            Properties.Settings.Default.DefaultTimePosition = fromtp;
                            Properties.Settings.Default.DefaultTimePositiionMsecs = tpmsecs;
                            Properties.Settings.Default.ImageFromDurationPercentage = fromdur;
                            Properties.Settings.Default.DurationPercentageText = durtxt;
                            Properties.Settings.Default.DurationPercentage = dur;
                            Properties.Settings.Default.ReverseTimePosition = reversed;
                        }

                    }
                }
            }
            finally
            {
                Environment.CurrentDirectory = curdir;
            }
            return true;
        }                
    }
}
