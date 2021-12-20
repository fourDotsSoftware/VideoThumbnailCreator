using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel;

namespace VideoThumbnailCreator
{
    public partial class frmImportFromExcel : VideoThumbnailCreator.CustomForm
    {
        private int ColumnInput = 1;
        private int ColumnThumb = 2;
        private int ColumnParameters = 3;

        private bool BatchJoin = false;

        public frmImportFromExcel()
        {
            InitializeComponent();
        }
        
        public void ImportListExcel(string filepath)
        {
            using (FileStream stream = File.Open(filepath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader excelReader = null;

                string curdir = Environment.CurrentDirectory;

                try
                {
                    Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(filepath);

                    if (filepath.ToLower().EndsWith(".xls") || filepath.ToLower().EndsWith(".xlt"))
                    {
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (filepath.ToLower().EndsWith(".xlsx"))
                    {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }

                    excelReader.IsFirstRowAsColumnNames = chkHasHeaders.Checked;

                    DataSet result = excelReader.AsDataSet(false);

                    if (result.Tables.Count > 0)
                    {
                        for (int m = 0; m < result.Tables.Count; m++)
                        {
                            for (int k = 0; k < result.Tables[m].Rows.Count; k++)
                            {
                                if (result.Tables[m].Columns.Count > 0)
                                {
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
                                        string file = result.Tables[m].Rows[k][ColumnInput].ToString();

                                        file = GetPart(file);

                                        file = Path.GetFullPath(file);

                                        string thumb = result.Tables[m].Rows[k][ColumnThumb].ToString();

                                        string parameters = "";

                                        try
                                        {
                                            parameters = result.Tables[m].Rows[k][ColumnParameters].ToString();
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
                                        else if (thumb.IndexOf(":") >= 0)
                                        {
                                            try
                                            {
                                                int msecs = FFMpegArgsHelper.GetTimeFromString(thumb);

                                                if (parameters.Trim().ToLower() == "reversed")
                                                {
                                                    Properties.Settings.Default.ReverseTimePosition = true;
                                                }

                                                Properties.Settings.Default.DefaultTimePosition = true;
                                                Properties.Settings.Default.DefaultTimePositiionMsecs = msecs;
                                            }
                                            catch { }
                                        }
                                        else if (thumb.IndexOf("%") >= 0)
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

                                        frmMain.Instance.AddFile(file);
                                    }
                                    catch (Exception exk)
                                    {
                                        Module.ShowError(exk);
                                    }

                                    finally
                                    {
                                        Properties.Settings.Default.DefaultImage = fromimage;
                                        Properties.Settings.Default.DefaultImageFilepath = imagefp;
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
                    }
                }
                finally
                {
                    Environment.CurrentDirectory = curdir;

                    if (excelReader != null)
                    {
                        excelReader.Close();
                        excelReader.Dispose();
                    }
                }
            }
        }                
        private static string GetPart(string part)
        {
            if (part.StartsWith("\""))
            {
                int epos = part.IndexOf("\"", 1);

                if (epos > 0)
                {
                    part = part.Substring(1, epos - 1);
                }
            }
            else if (part.StartsWith("'"))
            {
                int epos = part.IndexOf("'", 1);

                if (epos > 0)
                {
                    part = part.Substring(1, epos - 1);
                }
            }

            return part;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel Files (*.xls;*.xlsx;*.xlt)|*.xls;*.xlsx;*.xlt";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilepath.Text = openFileDialog1.FileName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtFilepath.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify an Excel File !");
                return;
            }

            if (!System.IO.File.Exists(txtFilepath.Text))
            {
                Module.ShowMessage("Please specify a valid Excel FIle !");
                return;

            }            

            int column;

            if (txtColumnThumb.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify a valid Column !");
                return;
            }
            else
            {
                if (!int.TryParse(txtColumnThumb.Text, out column))
                {
                    char achar = 'A';
                    char colchar = txtColumnThumb.Text.ToUpper()[0];

                    int dif = colchar - achar;
                    column = dif + 1;
                }
            }

            ColumnThumb = column - 1;

            if (txtColumnInput.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify a valid Column !");
                return;
            }
            else
            {
                if (!int.TryParse(txtColumnInput.Text, out column))
                {
                    char achar = 'A';
                    char colchar = txtColumnInput.Text.ToUpper()[0];

                    int dif = colchar - achar;
                    column = dif + 1;
                }
            }

            ColumnInput = column - 1;

            if (txtColumnParameters.Text.Trim() == string.Empty)
            {
                Module.ShowMessage("Please specify a valid Column !");
                return;
            }
            else
            {
                if (!int.TryParse(txtColumnParameters.Text, out column))
                {
                    char achar = 'A';
                    char colchar = txtColumnParameters.Text.ToUpper()[0];

                    int dif = colchar - achar;
                    column = dif + 1;
                }
            }

            ColumnParameters = column - 1;

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
