using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace VideoThumbnailCreator
{
    public partial class frmMain : VideoThumbnailCreator.CustomForm
    {
        public DataTable dt = new DataTable("table");
        
        public static frmMain Instance = null;

        public Process psFFMpeg = null;

        public bool ConversionStopped = false;
        public bool ConversionStarted = false;
        public bool ConversionPaused = false;
        public int ConversionProgressTime = 0;

        public int CompletedSecs = -1;
        private string _FirstOutputFile = "";

        public string ExplicitOutputFilepath = "";
        public bool OutputFileActionRepeat = false;

        public bool SilentAdd = false;

        public List<int> lstConversions = new List<int>();
        public string FirstOutputFile
        {
            get { return _FirstOutputFile; }
            set
            {
                if (value != string.Empty)
                {
                    tiToolsCopyPathOutput.Enabled = true;
                    tiToolsExploreOutput.Enabled = true;
                    tiToolsOpenOutput.Enabled = true;
                    tiToolsPlayOutputCommand.Enabled = true;
                    tiToolsVideoInfoOutput.Enabled = true;

                    _FirstOutputFile = value;
                }
            }
        }

        public string errstr = "";
        public string LastFFMpegOutput = "";

        int beforeCompletedSecs = 0;

        bool time_str_found = false;

        string last_line = "";

        BackgroundWorker bwConvert = new BackgroundWorker();

        public List<JoinArgs> BatchJoinArgs = new List<JoinArgs>();

        public frmMain()
        {
            InitializeComponent();

            Instance = this;

            if (ArgsHelper.IsFromWindowsExplorer)
            {
                this.Show();

                ArgsHelper.ExamineArgs(Module.args);
            }
            if (Module.IsCommandLine)
            {
                this.Visible = false;

                frmVideoJoin_Load(null, null);                

                ArgsHelper.ExamineArgsFromForm();

                //ArgsHelper.ExamineArgs(Module.args);

                ArgsHelper.ExecuteCommandLine();

                Environment.Exit(0);

                return;
            }


        }

        private void frmVideoJoin_Load(object sender, EventArgs e)
        {
            dgVideo.AutoGenerateColumns = false;

            slblTotalDuration.Text = "";
            slblTotalVideos.Text = "";
            lblElapsedTime.Visible = false;

            dt.Columns.Add("selected", typeof(bool));
            dt.Columns.Add("videoimg", typeof(Image));                       
            dt.Columns.Add("fullfilepath");
            dt.Columns.Add("isFromTimePosition",typeof(bool));
            dt.Columns.Add("timePositionMsecs", typeof(int));
            dt.Columns.Add("imagefilepath");
            dt.Columns.Add("thumbimage",typeof(Image));
            dt.Columns.Add("thumbimagefilepath");
            dt.Columns.Add("durationmsecs", typeof(int));
            dt.Columns.Add("videoinfo", typeof(FFMPEGInfo));

            dt.Columns.Add("reversetp",typeof(bool));
            dt.Columns.Add("isFromDurationPercentage",typeof(bool));
            dt.Columns.Add("DurationPercentageText");
            dt.Columns.Add("DurationPercentageValue",typeof(decimal));

            dgVideo.DataSource = dt;

            UpdateInfo();

            /*
            AddFile(@"c:\1\natgeo.mov");
            AddFile(@"c:\1\wings.mp4");
            AddFile(@"c:\1\wings30.mp4");
            AddFile(@"c:\1\zelda first commercial.mpeg");
            AddFile(@"c:\1\MOV04074.MPG");
            AddFile(@"c:\1\natgeo.mov");
            AddFile(@"c:\1\wings.mp4");
            AddFile(@"c:\1\wings30.mp4");
            AddFile(@"c:\1\zelda first commercial.mpeg");
            AddFile(@"c:\1\MOV04074.MPG");
            */

            bwConvert.DoWork += bwConvert_DoWork;
            bwConvert.RunWorkerCompleted += bwConvert_RunWorkerCompleted;
            bwConvert.ProgressChanged += bwConvert_ProgressChanged;
            bwConvert.WorkerReportsProgress = true;
            bwConvert.WorkerSupportsCancellation = true;

            SetupOnLoad();

            //DownloadFFMPEG32bit.CheckDownloadFFMPEG32bit();

            if (!Module.IsCommandLine && Properties.Settings.Default.CheckWeek)
            {
                UpdateHelper.InitializeCheckVersionWeek();
            }

            ResizeControls();

        }

        private void EnableDisableForm(bool enable)
        {
            foreach (Control co in this.Controls)
            {
                co.Enabled = enable;
            }
        }

        #region Join Function

        void bwConvert_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int pg = (int)e.UserState;            

            if (frmProgress.Instance != null && frmProgress.Instance.Visible)
            {
                if (pg >= 0 && pg <= frmProgress.Instance.pbarTotal.Maximum)
                {
                    frmProgress.Instance.pbarTotal.Value = pg;

                    decimal d1 = (decimal)frmProgress.Instance.pbarTotal.Value;
                    decimal d2 = (decimal)frmProgress.Instance.pbarTotal.Maximum;

                    decimal dprog = (d1 / d2) * 100;

                    int iprog = (int)dprog;

                    frmProgress.Instance.pbarTotal.lblText = iprog.ToString() + "%";                    
                }
            }
        }

        void ConvertReportProgress(int pg)
        {
            try
            {
                if (frmProgress.Instance != null && frmProgress.Instance.Visible)
                {
                    if (pg >= 0 && pg <= frmProgress.Instance.pbarTotal.Maximum)
                    {
                        frmProgress.Instance.pbarTotal.Value = pg;

                        // 100 max
                        //  x  val

                        decimal d1 = (decimal)frmProgress.Instance.pbarTotal.Value;
                        decimal d2 = (decimal)frmProgress.Instance.pbarTotal.Maximum - 1;

                        decimal dprog = (d1 / d2) * 100;

                        int iprog = (int)dprog;

                        frmProgress.Instance.pbarTotal.lblText = iprog.ToString() + "%";
                    }
                }
            }
            catch { }
        }

        void bwConvert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if no time= string was found this means that an error occured
            if (!time_str_found)
            {
                //errstr += last_line;
            }
        }

        void bwConvert_DoWork(object sender, DoWorkEventArgs e)
        {            
            //0sw.WriteLine("ARGS=");
            //0sw.WriteLine(psFFMpeg.StartInfo.Arguments);

            LastFFMpegOutput = "";

            beforeCompletedSecs = CompletedSecs;

            time_str_found = false;

            last_line = "";

            //Console.WriteLine("ARGS=" + psFFMpeg.StartInfo.Arguments);

            psFFMpeg.Start();

            psFFMpeg.BeginErrorReadLine();
            psFFMpeg.BeginOutputReadLine();

            psFFMpeg.WaitForExit();

            psFFMpeg.Close();

            psFFMpeg.Dispose();
            psFFMpeg = null;

            /*
            if (!time_str_found)
            {
                errstr += last_line;
            }*/

        }

        public void tsbStopJoin_Click(object sender, EventArgs e)
        {
            ConversionStopped = true;
            ConversionStarted = false;
            ConversionPaused = false;

            //1tsbStopCut.Visible = false;
            //1tsbCutVideo.Image = Properties.Resources.cut1;
            //1tsbCutVideo.Text = TranslateHelper.Translate("Cut Video");

            try
            {
                psFFMpeg.Kill();
            }
            catch { }

            bwConvert.CancelAsync();

            /*
            for (int k = 0; k < lstProcessConvert.Count; k++)
            {
                try
                {
                    lstProcessConvert[k].Kill();
                }
                catch { }
            }*/

            if (frmProgress.Instance != null && frmProgress.Instance.Visible)
            {
                frmProgress.Instance.Close();
            }

            if (ConversionStopped)
            {
                Module.ShowMessage("Join process stopped !");
                return;
            }
        }

        public void tsbJoinVideos_Click(object sender, EventArgs e)
        {            
            JoinArgs res = null;

            if (ConversionStarted)
            {

            }
            else
            {
                //1!!if (Properties.Settings.Default.MsgCutWithKeepSameFormat)
                /*
                if (true)
                {
                    frmMsgCheckBox fmc = new frmMsgCheckBox(frmMsgCheckBox.MsgModeEnum.OnCutWithKeepSameFormat,
                    TranslateHelper.Translate("For more accurate cutting, please select a Specific Output Format and do not just select to keep the same format"));

                    fmc.ShowDialog();
                }

                if (outputformat.Trim() == TranslateHelper.Translate("Keep same Format as Source"))
                {
                    Module.ShowMessage("You have to set a specific Output Format if you have more than 1 cuts !");
                    return;
                }
                */

                try
                {

                    errstr = "";

                    CompletedSecs = 0;

                    if (!Module.IsCommandLine)
                    {

                    }
                    else
                    {

                    }

                    if (Properties.Settings.Default.OutputFolderIndex!=0)
                    {
                        if (!System.IO.Directory.Exists(Properties.Settings.Default.OutputFolder))
                        {
                            try
                            {
                                System.IO.Directory.CreateDirectory(Properties.Settings.Default.OutputFolder);
                            }
                            catch
                            {
                                Module.ShowMessage("Error ! Could not create Output Folder !");
                                return;
                            }
                        }
                    }

                    timJoinVideos.Enabled = true;
                    lblElapsedTime.Visible = true;

                    decimal current_total_time = 0;

                    //this.Enabled = false;

                    EnableDisableForm(false);

                    FirstOutputFile = "";

                    if (!Module.IsCommandLine)
                    {
                        frmProgress f = new frmProgress();
                        f.Show(this);
                        f.timTime.Enabled = true;

                        f.pbarTotal.Maximum = dt.Rows.Count;
                        f.pbarTotal.Value = 0;
                        f.lblOutputFile.Text = "";
                    }

                    ConversionPaused = false;
                    ConversionStopped = false;
                    ConversionStarted = true;

                    JoinArgsHelper jhelper = new JoinArgsHelper();

                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        if (lstConversions.Count>=5 && frmAbout.LDT==string.Empty)
                        {
                            
                        }

                        while (ConversionPaused)
                        {
                            Application.DoEvents();
                        }

                        if (ConversionStopped)
                        {
                            return;
                        }

                        try
                        {                            
                            string filepath = dt.Rows[k]["fullfilepath"].ToString();
                            string thumbfilepath = dt.Rows[k]["thumbimagefilepath"].ToString();

                            res = jhelper.GetJoinArgs(filepath, thumbfilepath);

                            if (res == null) continue;

                            if (res.JoinFile == "-1")
                            {
                                errstr += filepath + " - " + TranslateHelper.Translate("Operation Skipped because of Output Filename.") + "\r\n";
                                continue;
                            }

                            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(res.JoinFile)))
                            {
                                try
                                {
                                    System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(res.JoinFile));
                                }
                                catch
                                {
                                    Module.ShowMessage("Error. Could not create Output Join File Directory !");
                                    errstr += filepath + " - " + TranslateHelper.Translate("Error. Could not create Output File Directory !") + "\r\n";
                                    continue;
                                }
                            }

                            //Console.WriteLine("=====================");

                            //Console.WriteLine(res.Args);                    


                            //File.WriteAllText(@"c:\1\vje.txt", argsout);

                            if (FirstOutputFile == string.Empty)
                            {
                                FirstOutputFile = res.JoinFile;
                            }

                            if (System.IO.File.Exists(res.JoinFile))
                            {
                                FileInfo fi = new FileInfo(res.JoinFile);
                                fi.Attributes = FileAttributes.Normal;
                                fi.Delete();
                            }

                            if (ConversionStopped) return;

                            CreateFFMpegProcess();

                            psFFMpeg.StartInfo.Arguments = res.Args;

                            bwConvert.RunWorkerAsync();

                            while (bwConvert.IsBusy)
                            {
                                Application.DoEvents();
                            }

                            if (ConversionStopped) return;

                            if (System.IO.File.Exists(res.JoinFile))
                            {
                                lstConversions.Add(0);

                                if (Properties.Settings.Default.CopyEXIF)
                                {
                                    System.Diagnostics.Process pr = new Process();
                                    pr.StartInfo.FileName = "\"" + System.IO.Path.Combine(Application.StartupPath, "exiftool.exe") + "\"";
                                    pr.StartInfo.Arguments = "-tagsfromfile \"" + filepath + "\" -exif \"" + res.JoinFile + "\"";

                                    pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                    pr.StartInfo.UseShellExecute = true;
                                    pr.Start();

                                    while (!pr.HasExited)
                                    {
                                        Application.DoEvents();
                                    }

                                    if (System.IO.File.Exists(res.JoinFile + "_original"))
                                    {
                                        try
                                        {
                                            System.IO.File.Delete(res.JoinFile + "_original");
                                        }
                                        catch
                                        {

                                        }
                                    }

                                    pr.Dispose();
                                    pr = null;
                                }

                                if (Properties.Settings.Default.KeepCreationDate)
                                {
                                    System.IO.FileInfo fi = new System.IO.FileInfo(filepath);

                                    System.IO.FileInfo fi2 = new System.IO.FileInfo(res.JoinFile);

                                    fi2.CreationTime = fi.CreationTime;

                                    fi2.CreationTimeUtc = fi.CreationTimeUtc;
                                }

                                if (Properties.Settings.Default.KeepLastModDate)
                                {
                                    System.IO.FileInfo fi = new System.IO.FileInfo(filepath);

                                    System.IO.FileInfo fi2 = new System.IO.FileInfo(res.JoinFile);

                                    fi2.LastWriteTime = fi.LastWriteTime;

                                    fi2.LastWriteTimeUtc = fi.LastWriteTimeUtc;
                                }
                            }

                            ConvertReportProgress(k+1);
                        }
                        catch (Exception exk)
                        {
                            errstr += "Error ! " + dt.Rows[k]["fullfilepath"].ToString()+" - "+exk.Message;
                        }
                    }
                }
                finally
                {
                    timJoinVideos.Enabled = false;
                    ConversionProgressTime = 0;
                    ConversionStarted = false;
                    //8OutputFileActionRepeat = false;                    

                    if (!Module.IsCommandLine)
                    {
                        if (frmProgress.Instance != null && frmProgress.Instance.Visible)
                        {
                            frmProgress.Instance.Close();
                        }
                    }

                    //this.Enabled = true;

                    EnableDisableForm(true);

                    if (ConversionStopped)
                    {
                        Module.ShowMessage("Operation stopped !");
                    }
                    else
                    {

                        if (res != null)
                        {
                            if (!ConversionStopped)
                            {
                                if (!Module.IsCommandLine)
                                {
                                    ProcessWhenFinished();
                                }

                                if (errstr != String.Empty)
                                {
                                    if (!Module.IsCommandLine)
                                    {
                                        if (System.IO.File.Exists(FirstOutputFile))
                                        {
                                            frmError fer = new frmError(TranslateHelper.Translate("Output Video was produced but operation was completed with Errors !"), errstr);
                                            fer.ShowDialog(this);
                                        }
                                        else
                                        {
                                            frmError fer = new frmError(TranslateHelper.Translate("Operation completed with Errors !"), errstr);
                                            fer.ShowDialog(this);
                                        }
                                    }
                                    else
                                    {
                                        Module.ShowMessage(TranslateHelper.Translate("Operation completed with Errors !") + "\n\n" + errstr);
                                    }
                                }
                                else
                                {
                                    if (Properties.Settings.Default.ShowMsgOnSuccess || Module.IsCommandLine)
                                    {
                                        Module.ShowMessage("Operation completed successfully !");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ProcessWhenFinished()
        {
            if (Properties.Settings.Default.ExploreOutputFolderWhenDone)
            {
                string args = string.Format("/e, /select, \"{0}\"", FirstOutputFile);
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "explorer";
                info.UseShellExecute = true;
                info.Arguments = args;
                Process.Start(info);
            }
        }

        private void timJoinVideos_Tick(object sender, EventArgs e)
        {
            ConversionProgressTime++;
            TimeSpan ts = new TimeSpan(0, 0, ConversionProgressTime);

            //8lblElapsedTime.Text = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2");//8
        }

        public void CreateFFMpegProcess()
        {
            System.Threading.Thread.Sleep(300);

            try
            {
                if (psFFMpeg != null && !psFFMpeg.HasExited)
                {
                    psFFMpeg.Kill();
                }
            }
            catch { }

            System.Threading.Thread.Sleep(300);

            LastFFMpegOutput = "";

            last_line = "";

            psFFMpeg = new Process();

            psFFMpeg.StartInfo.CreateNoWindow = true;
            psFFMpeg.StartInfo.UseShellExecute = false;
            psFFMpeg.StartInfo.RedirectStandardError = true;
            psFFMpeg.StartInfo.RedirectStandardOutput = true;

            psFFMpeg.OutputDataReceived += psFFMpeg_OutputDataReceived;
            psFFMpeg.ErrorDataReceived += psFFMpeg_ErrorDataReceived;

            psFFMpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            if (Properties.Settings.Default.FFMPEG64Bit == 1)
            {
                psFFMpeg.StartInfo.FileName = "ffmpeg64 ";
            }
            else
            {
                psFFMpeg.StartInfo.FileName = "ffmpeg32 ";
            }

            psFFMpeg.StartInfo.WorkingDirectory = System.Windows.Forms.Application.StartupPath;

            //System.Threading.Thread.Sleep(500);

        }

        void psFFMpeg_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string line = e.Data;
            
            //Console.WriteLine(line);

            if (line != null)
            {
                last_line = line;
            }

            LastFFMpegOutput += line + "\r\n";

            Application.DoEvents();

            if (line != null && line.ToLower().StartsWith("error"))
            {
                errstr += line;
            }
        }

        void psFFMpeg_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Console.WriteLine("OUTPUT:"+e.Data);
        }

        #endregion

        #region Basic Toolbar Functions

        public void AddFile(string filepath)
        {
            if (filepath.Trim() == string.Empty) return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Bitmap bmpth = null;
                string thfilepath = "";

                FFMPEGInfo finfo = null;

                finfo = new FFMPEGInfo(filepath);

                if (!finfo.Success)
                {
                    return;
                }

                if (Properties.Settings.Default.DefaultImage)
                {
                    bmpth = new Bitmap(Properties.Settings.Default.DefaultImageFilepath);

                    thfilepath = Properties.Settings.Default.DefaultImageFilepath;

                    Properties.Settings.Default.DefaultThumbnailImageFilepath = thfilepath;
                }
                else if (Properties.Settings.Default.DefaultTimePosition)
                {
                    if (Properties.Settings.Default.DefaultTimePosition
                                            && (Properties.Settings.Default.DefaultTimePositiionMsecs > finfo.DurationMsecs))
                    {
                        Module.ShowMessage(System.IO.Path.GetFileName(filepath) + " : " + TranslateHelper.Translate("Error ! Thumbnail Time Position exceeds Video Duration !"));
                    }
                    else
                    {
                        string stime = FFMpegArgsHelper.GetStringFromTime(Properties.Settings.Default.DefaultTimePositiionMsecs);

                        if (Properties.Settings.Default.ReverseTimePosition)
                        {
                            stime = FFMpegArgsHelperJoin.GetStringFromTime(finfo.DurationMsecs - Properties.Settings.Default.DefaultTimePositiionMsecs);
                        }

                        VideoThumbnail vt = new VideoThumbnail(filepath, stime);

                        bmpth = vt.ThumbnailImage;

                        thfilepath = vt.ThumbnailFilepath;

                        Properties.Settings.Default.DefaultThumbnailImageFilepath = vt.ThumbnailFilepath;

                    }
                }
                else if (Properties.Settings.Default.ImageFromDurationPercentage)
                {
                    decimal ddur = (decimal)finfo.DurationMsecs;

                    decimal ddp = ddur * Properties.Settings.Default.DurationPercentage;

                    string stime = FFMpegArgsHelperJoin.GetStringFromTime((int)ddp);

                    VideoThumbnail vth = new VideoThumbnail(filepath, stime);

                    bmpth = vth.ThumbnailImage;

                    thfilepath = vth.ThumbnailFilepath;

                    Properties.Settings.Default.DefaultThumbnailImageFilepath = vth.ThumbnailFilepath;
                }

                Bitmap bmp = new Bitmap(700, 110);

                int dur = -1;

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    string timestring = FFMpegArgsHelperJoin.GetStringFromTime((int)(finfo.DurationMsecs / 2));

                    //VideoThumbnail vt = new VideoThumbnail(filepath, timestring, 156, 100);

                    int x = 5;
                    int y = 5;

                    g.FillRectangle(Brushes.Black, new Rectangle(x, y, 156, 100));

                    Bitmap bmp1 = new Bitmap(156, 100);

                    if (bmpth != null)
                    {
                        using (Graphics gb = Graphics.FromImage(bmp1))
                        {
                            gb.Clear(Color.Black);

                            decimal d1 = (decimal)bmpth.Width;
                            decimal d2 = (decimal)bmpth.Height;
                            decimal d3 = (decimal)156;
                            decimal d4 = (decimal)100;

                            // w  h
                            // 156 y

                            decimal dh = (d3 * d2) / d1;
                            int id = (int)dh;

                            // w h
                            // x 100

                            decimal dw = (d4 * d1) / d2;
                            int idw = (int)dw;

                            if (idw >= 156)
                            {
                                gb.DrawImage(bmpth, new Rectangle(0, Math.Max(0, 100 / 2 - id / 2), 156, id), new Rectangle(0, 0, bmpth.Width, bmpth.Height), GraphicsUnit.Pixel);
                            }
                            else
                            {
                                gb.DrawImage(bmpth, new Rectangle(Math.Max(0, 156 / 2 - idw / 2), 0, idw, 100), new Rectangle(0, 0, bmpth.Width, bmpth.Height), GraphicsUnit.Pixel);
                            }

                        }
                    }
                    else
                    {
                        using (Graphics gb = Graphics.FromImage(bmp1))
                        {
                            gb.Clear(Color.Black);

                        }
                    }

                    //if (vt.ThumbnailImage != null)
                    //{
                    g.DrawImage(bmp1, new Rectangle(x, y, 156, 100));
                    //}

                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    Font f = new Font(dgVideo.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

                    x = 170;
                    y = 10;

                    g.DrawString(System.IO.Path.GetFileName(filepath), f, Brushes.DarkBlue, new PointF(x, y));
                    y += f.Height + 4;

                    string duration = TranslateHelper.Translate("Duration") + " : " + finfo.DurationStr;

                    dur = finfo.DurationMsecs;

                    g.DrawString(duration, f, Brushes.Black, new PointF(x, y));
                    y += f.Height + 4;


                    string video = "";

                    if (Properties.Settings.Default.DefaultTimePosition)
                    {
                        video = TranslateHelper.Translate("Thumbnail from Time Position") + " : " + FFMpegArgsHelper.GetStringFromTime(Properties.Settings.Default.DefaultTimePositiionMsecs);

                        if (Properties.Settings.Default.ReverseTimePosition)
                        {
                            video += " " + TranslateHelper.Translate("Reversed");
                        }
                    }
                    else if (Properties.Settings.Default.DefaultImage)
                    {
                        video = TranslateHelper.Translate("Thumbnail from Image") + " : " + System.IO.Path.GetFileName(Properties.Settings.Default.DefaultImageFilepath);
                    }
                    else if (Properties.Settings.Default.ImageFromDurationPercentage)
                    {
                        video = TranslateHelper.Translate("Thumbnail from Duration Percentage") + " : " + Properties.Settings.Default.DurationPercentageText;
                    }

                    g.DrawString(video, f, Brushes.Black, new PointF(x, y));

                    y += f.Height + 4;

                }

                DataRow dr = dt.NewRow();
                dr["selected"] = false;
                dr["videoimg"] = bmp;
                dr["fullfilepath"] = filepath;
                dr["thumbimage"] = bmpth;
                dr["thumbimagefilepath"] = Properties.Settings.Default.DefaultThumbnailImageFilepath;
                dr["durationmsecs"] = finfo.DurationMsecs;

                dr["isFromTimePosition"] = Properties.Settings.Default.DefaultTimePosition;
                dr["timePositionMsecs"] = Properties.Settings.Default.DefaultTimePosition ? Properties.Settings.Default.DefaultTimePositiionMsecs : 0;
                dr["imagefilepath"] = (!Properties.Settings.Default.DefaultTimePosition) ? Properties.Settings.Default.DefaultImageFilepath : "";

                dr["videoinfo"] = finfo;

                dr["reversetp"] = Properties.Settings.Default.ReverseTimePosition;
                dr["isFromDurationPercentage"] = Properties.Settings.Default.ImageFromDurationPercentage;
                dr["DurationPercentageText"] = Properties.Settings.Default.DurationPercentageText;
                dr["DurationPercentageValue"] = Properties.Settings.Default.DurationPercentage;

                dt.Rows.Add(dr);

                dgVideo.CurrentCell = (DataGridViewCell)dgVideo.Rows[dgVideo.Rows.Count - 1].Cells[0];
                dgVideo.BeginEdit(false);

                SetEnabled(true);

                UpdateInfo();

                RecentFilesHelper.AddRecentFileJoin(filepath);

            }
            catch (Exception ex)
            {
                this.Cursor = null;

                Module.ShowError(TranslateHelper.Translate("Error could not Add Video to List !") + " : " + filepath);
            }
            finally
            {
                this.Cursor = null;
            }
        }        
        public void AddFolder(string folder_path)
        {
            if (!System.IO.Directory.Exists(folder_path)) return;

            string[] filez = null;                        

            if (!Module.IsCommandLine)
            {
                if (System.IO.Directory.GetDirectories(folder_path).Length > 0)
                {
                    DialogResult dres = Module.ShowQuestionDialog("Would you like to add also Subdirectories ?", TranslateHelper.Translate("Add Subdirectories ?"));

                    if (dres == DialogResult.Yes)
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.AllDirectories);
                    }
                    else
                    {
                        filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.TopDirectoryOnly);
                    }
                }
                else
                {
                    filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.TopDirectoryOnly);
                }
            }
            else
            {
                // silent add for import list
                filez = System.IO.Directory.GetFiles(folder_path, "*.*", SearchOption.AllDirectories);
            }

            string folderfiles = "";

            try
            {
                this.Cursor = Cursors.WaitCursor;

                for (int k = 0; k < filez.Length; k++)
                {
                    if (Module.IsAcceptableMediaInput(filez[k]))
                    {
                        System.Threading.Thread.Sleep(100);
                        AddFile(filez[k]);
                    }
                }
            }
            finally
            {
                this.Cursor = null;
            }
        }
        private void tsbAddFolder_ButtonClick(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                AddFolder(folderBrowserDialog1.SelectedPath);
                RecentFilesHelper.AddRecentFolderJoin(folderBrowserDialog1.SelectedPath);
            }

        }

        private void tsbAddFolder_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!System.IO.Directory.Exists(e.ClickedItem.Text))
            {
                Module.ShowMessage(TranslateHelper.Translate("Folder does not exist !") + "\n\n" + e.ClickedItem.Text);
                return;
            }

            AddFolder(e.ClickedItem.Text);
            RecentFilesHelper.AddRecentFolderJoin(e.ClickedItem.Text);
        }

        private void tsbMoveUp_Click(object sender, EventArgs e)
        {
            if (dgVideo.SelectedRows == null) return;
            if (dgVideo.SelectedRows.Count == 0) return;

            List<DataRow> lst = new List<DataRow>();
            List<int> lstind = new List<int>();

            for (int k = 0; k < dgVideo.SelectedRows.Count; k++)
            {
                lstind.Add(dgVideo.SelectedRows[k].Index);
            }

            lstind.Sort();

            for (int k = 0; k < lstind.Count; k++)
            {
                DataRowView drv = (DataRowView)dgVideo.Rows[lstind[k]].DataBoundItem;
                lst.Add(drv.Row);
            }

            dgVideo.ClearSelection();

            for (int k = 0; k < lst.Count; k++)
            {
                int ind = lstind[k];

                if (ind > 0)
                {
                    DataRow dr = dt.NewRow();
                    /*
                    dr[0] = lst[k][0];
                    dr["durationmsecs"] = lst[k]["durationmsecs"];
                    dr["videoinfo"] = lst[k]["videoinfo"];
                    */

                    for (int n = 0; n < dt.Columns.Count; n++)
                    {
                        dr[n] = lst[k][n];
                    }

                    // 0 1 2 3 4 5
                    // remove 4
                    // insert 3
                    // select 3

                    dt.Rows.Remove(lst[k]);

                    dt.Rows.InsertAt(dr, ind - 1);
                }
            }

            //dgVideo.Refresh();

            dgVideo.ClearSelection();

            int newind = -1;

            for (int k = 0; k < lstind.Count; k++)
            {
                if (lstind[k] > 0)
                {
                    dgVideo.Rows[lstind[k] - 1].Selected = true;

                    if (k == 0)
                    {
                        newind = lstind[k] - 1;
                    }
                }
                else
                {
                    dgVideo.Rows[lstind[k]].Selected = true;

                    if (k == 0)
                    {
                        newind = lstind[k];
                    }
                }
            }

            dgVideo.FirstDisplayedScrollingRowIndex = newind;

            UpdateInfo();
        }

        private void tsbMoveDown_Click(object sender, EventArgs e)
        {
            if (dgVideo.SelectedRows == null) return;
            if (dgVideo.SelectedRows.Count == 0) return;

            List<DataRow> lst = new List<DataRow>();
            List<int> lstind = new List<int>();

            for (int k = 0; k < dgVideo.SelectedRows.Count; k++)
            {
                lstind.Add(dgVideo.SelectedRows[k].Index);
            }

            lstind.Sort();

            for (int k = 0; k < lstind.Count; k++)
            {
                DataRowView drv = (DataRowView)dgVideo.Rows[lstind[k]].DataBoundItem;
                lst.Add(drv.Row);
            }

            dgVideo.ClearSelection();

            for (int k = lst.Count - 1; k >= 0; k--)
            {
                int ind = lstind[k];

                if (ind < dt.Rows.Count - 1)
                {
                    DataRow dr = dt.NewRow();

                    for (int n = 0; n < dt.Columns.Count; n++)
                    {
                        dr[n] = lst[k][n];
                    }

                    /*
                    dr[0] = lst[k][0];
                    dr["durationmsecs"] = lst[k]["durationmsecs"];
                    dr["videoinfo"] = lst[k]["videoinfo"];
                    */

                    dt.Rows.Remove(lst[k]);

                    dt.Rows.InsertAt(dr, ind + 1);
                }
            }

            //dgVideo.Refresh();

            dgVideo.ClearSelection();

            int newind = -1;

            for (int k = lstind.Count - 1; k >= 0; k--)
            {
                if (lstind[k] < dgVideo.Rows.Count - 1)
                {
                    dgVideo.Rows[lstind[k] + 1].Selected = true;

                    if (k == 0)
                    {
                        newind = lstind[k] + 1;
                    }
                }
                else
                {
                    dgVideo.Rows[lstind[k]].Selected = true;

                    if (k == 0)
                    {
                        newind = lstind[k];
                    }
                }
            }

            dgVideo.FirstDisplayedScrollingRowIndex = newind;

            UpdateInfo();
        }

        private void UpdateInfo()
        {
            int tdur = 0;

            for (int k = 0; k < dt.Rows.Count; k++)
            {                
                tdur += ((int)dt.Rows[k]["durationmsecs"]);
            }

            slblTotalVideos.Text = TranslateHelper.Translate("Total Videos") + " : " + dt.Rows.Count.ToString();

            slblTotalDuration.Text = TranslateHelper.Translate("Total Duration") + " : " + FFMpegArgsHelperJoin.GetStringFromTime(tdur);
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (dgVideo.SelectedRows == null) return;

            List<DataRow> lst = new List<DataRow>();

            for (int k = 0; k < dgVideo.SelectedRows.Count; k++)
            {
                DataRowView drv = (DataRowView)dgVideo.SelectedRows[k].DataBoundItem;
                lst.Add(drv.Row);
            }

            for (int k = 0; k < lst.Count; k++)
            {
                dt.Rows.Remove(lst[k]);
            }

            if (dt.Rows.Count == 0)
            {
                SetEnabled(false);
            }

            UpdateInfo();
        }

        private void tsbAdd_ButtonClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = Module.OpenFilesFilter;

            openFileDialog1.Multiselect = true;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                for (int k = 0; k < openFileDialog1.FileNames.Length; k++)
                {
                    AddFile(openFileDialog1.FileNames[k]);
                }

            }
        }

        private void tsbAdd_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            AddFile(e.ClickedItem.Text);
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();

            SetEnabled(false);

            UpdateInfo();
        }

        #endregion                        

        #region Right Click Menu - Tools Menu

        private void cmsVideos_Opening(object sender, CancelEventArgs e)
        {
            Point p = dgVideo.PointToClient(new Point(Control.MousePosition.X, Control.MousePosition.Y));
            DataGridView.HitTestInfo hit = dgVideo.HitTest(p.X, p.Y);

            if (hit.Type == DataGridViewHitTestType.Cell)
            {
                dgVideo.CurrentCell = dgVideo.Rows[hit.RowIndex].Cells[hit.ColumnIndex];

                try
                {
                    DataRow dr = dt.Rows[hit.RowIndex];                                        
                }
                catch { }

            }

            if (dgVideo.CurrentRow == null)
            {
                e.Cancel = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgVideo.CurrentRow == null) return;

            DataRowView drv = (DataRowView)dgVideo.CurrentRow.DataBoundItem;

            DataRow dr = drv.Row;

            //FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

            //string filepath = finfo.Filepath;

            string filepath = dr["fullfilepath"].ToString();

            System.Diagnostics.Process.Start(filepath);

        }

        private void exploreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)dgVideo.CurrentRow.DataBoundItem;

            DataRow dr = drv.Row;

            //FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

            string filepath = dr["fullfilepath"].ToString();

            string args = string.Format("/e, /select, \"{0}\"", filepath);

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);

        }

        private void copyFullPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)dgVideo.CurrentRow.DataBoundItem;

            DataRow dr = drv.Row;

            //FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

            //string filepath = finfo.Filepath;

            string filepath = dr["fullfilepath"].ToString();

            Clipboard.Clear();

            Clipboard.SetText(filepath);
        }

        private void videoInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)dgVideo.CurrentRow.DataBoundItem;

            DataRow dr = drv.Row;

            if (dr["foldersep"].ToString() == bool.TrueString) return;

            FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

            string filepath = finfo.Filepath;

            frmVideoInfo f = new frmVideoInfo(filepath);

            f.ShowDialog();
        }

        private void tiToolsOpenOutput_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(FirstOutputFile))
            {
                Module.ShowMessage(TranslateHelper.Translate("Join Output File does not exist !") + "\n\n" + FirstOutputFile);
                return;
            }

            System.Diagnostics.Process.Start(FirstOutputFile);
        }

        private void tiToolsExploreOutput_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(FirstOutputFile))
            {
                Module.ShowMessage(TranslateHelper.Translate("Join Output File does not exist !") + "\n\n" + FirstOutputFile);
                return;
            }

            string filepath = FirstOutputFile;

            string args = string.Format("/e, /select, \"{0}\"", filepath);

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "explorer";
            info.UseShellExecute = true;
            info.Arguments = args;
            Process.Start(info);
        }

        private void tiToolsCopyPathOutput_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(FirstOutputFile))
            {
                Module.ShowMessage(TranslateHelper.Translate("Join Output File does not exist !") + "\n\n" + FirstOutputFile);
                return;
            }

            string filepath = FirstOutputFile;

            Clipboard.Clear();

            Clipboard.SetText(filepath);
        }

        private void tiToolsVideoInfoOutput_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(FirstOutputFile))
            {
                Module.ShowMessage(TranslateHelper.Translate("Join Output File does not exist !") + "\n\n" + FirstOutputFile);
                return;
            }

            frmVideoInfo f = new frmVideoInfo(FirstOutputFile);

            f.ShowDialog();
        }

        #endregion

        #region Drag and Drop

        private void dgVideo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dgVideo_DragOver(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void dgVideo_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] filez = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int k = 0; k < filez.Length; k++)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        if (System.IO.File.Exists(filez[k]))
                        {
                            AddFile(filez[k]);
                        }
                        else if (System.IO.Directory.Exists(filez[k]))
                        {
                            AddFolder(filez[k]);
                        }
                    }
                    finally
                    {
                        this.Cursor = null;
                    }
                }
            }
        }

        #endregion

        #region Help

        private void helpUsersManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.StartupPath + "\\Video Cutter Joiner Expert - User's Manual.chm");
            System.Diagnostics.Process.Start(Module.HelpURL);
        }

        private void pleaseDonateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/donate.php");
        }

        private void dotsSoftwarePRODUCTCATALOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com/downloads/4dots-Software-PRODUCT-CATALOG.pdf");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            frmUninstallQuestionnaire f = new frmUninstallQuestionnaire(false);
            f.ShowDialog();
            */

            System.Diagnostics.Process.Start("https://www.4dots-software.com/support/bugfeature.php?app=" + System.Web.HttpUtility.UrlEncode(Module.ShortApplicationTitle));
        }

        private void followUsOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.twitter.com/4dotsSoftware");
        }

        private void visit4dotsSoftwareWebpageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.4dots-software.com");
        }

        private void checkForNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Module.CheckVersion(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Share

        private void shareOnFacebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareFacebook();
        }

        private void shareOnTwitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareTwitter();
        }

        private void shareOnGooglePlusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareGooglePlus();
        }

        private void shareOnLinkedinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareLinkedIn();
        }

        private void shareWithEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShareHelper.ShareEmail();
        }

        #endregion

        #region Localization

        private void AddLanguageMenuItems()
        {
            for (int k = 0; k < frmLanguage.LangCodes.Count; k++)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = frmLanguage.LangDesc[k];
                ti.Tag = frmLanguage.LangCodes[k];
                ti.Image = frmLanguage.LangImg[k];

                if (Properties.Settings.Default.Language == frmLanguage.LangCodes[k])
                {
                    ti.Checked = true;
                }

                ti.Click += new EventHandler(tiLang_Click);

                if (k < 25)
                {
                    languages1ToolStripMenuItem.DropDownItems.Add(ti);
                }
                else
                {
                    languages2ToolStripMenuItem.DropDownItems.Add(ti);
                }

                //languageToolStripMenuItem.DropDownItems.Add(ti);
            }
        }

        void tiLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ti = (ToolStripMenuItem)sender;
            string langcode = ti.Tag.ToString();
            ChangeLanguage(langcode);

            //for (int k = 0; k < languageToolStripMenuItem.DropDownItems.Count; k++)
            for (int k = 0; k < languages1ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages1ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }

            for (int k = 0; k < languages2ToolStripMenuItem.DropDownItems.Count; k++)
            {
                ToolStripMenuItem til = (ToolStripMenuItem)languages2ToolStripMenuItem.DropDownItems[k];
                if (til == ti)
                {
                    til.Checked = true;
                }
                else
                {
                    til.Checked = false;
                }
            }
        }

        private bool InChangeLanguage = false;

        private void ChangeLanguage(string language_code)
        {
            try
            {
                InChangeLanguage = true;

                Properties.Settings.Default.Language = language_code;
                frmLanguage.SetLanguage();

                Properties.Settings.Default.Save();
                Module.ShowMessage("Please restart the application !");
                Application.Exit();
                return;

                bool maximized = (this.WindowState == FormWindowState.Maximized);
                this.WindowState = FormWindowState.Normal;

                /*
                RegistryKey key = Registry.CurrentUser;
                RegistryKey key2 = Registry.CurrentUser;

                try
                {
                    key = key.OpenSubKey("Software\\4dots Software", true);

                    if (key == null)
                    {
                        key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\4dots Software");
                    }

                    key2 = key.OpenSubKey(frmLanguage.RegKeyName, true);

                    if (key2 == null)
                    {
                        key2 = key.CreateSubKey(frmLanguage.RegKeyName);
                    }

                    key = key2;

                    //key.SetValue("Language", language_code);
                    key.SetValue("Menu Item Caption", TranslateHelper.Translate("Change PDF Properties"));
                }
                catch (Exception ex)
                {
                    Module.ShowError(ex);
                    return;
                }
                finally
                {
                    key.Close();
                    key2.Close();
                }
                */
                //1SaveSizeLocation();

                SavePositionSize();

                this.Controls.Clear();

                InitializeComponent();

                SetupOnLoad();

                if (maximized)
                {
                    this.WindowState = FormWindowState.Maximized;
                }

                this.ResumeLayout(true);
            }
            finally
            {
                InChangeLanguage = false;
            }
        }

        #endregion

        #region OnLoad

        private void SetupOnLoad()
        {
            this.Text = Module.ApplicationTitle;

            if (!Module.IsCommandLine)
            {
                RepositionResize();
            }

            AddLanguageMenuItems();

            SetEnabled(false);

            //1RecentFilesHelper.FillMenuRecentFile();

            RecentFilesHelper.FillJoinRecentFile();
            RecentFilesHelper.FillJoinRecentFolders();

            this.AllowDrop = true;
            this.DragDrop += dgVideo_DragDrop;
            this.DragOver += dgVideo_DragOver;
            this.DragEnter += dgVideo_DragEnter;

            /*
            //3

            enterLicenseKeyToolStripMenuItem.Visible = frmPurchase.RenMove;

            if (Properties.Settings.Default.Price != string.Empty && !buyApplicationToolStripMenuItem.Text.EndsWith(Properties.Settings.Default.Price))
            {
                buyApplicationToolStripMenuItem.Text = buyApplicationToolStripMenuItem.Text + " " + Properties.Settings.Default.Price;
            }            
            */

            copyEXIFInformationFromSelectedVideoToolStripMenuItem.Checked = Properties.Settings.Default.CopyEXIF;

            keepCreationDateFromSelectedVideoToolStripMenuItem.Checked = Properties.Settings.Default.KeepCreationDate;

            keepLastModificationDateFromSelectedVideoToolStripMenuItem.Checked = Properties.Settings.Default.KeepLastModDate;

            if (Properties.Settings.Default.FFMPEG64Bit == 0)
            {
                if (Module.IsWindows64Bit)
                {
                    useFFMPEG64bitToolStripMenuItem_Click(null, null);
                }
                else
                {
                    useFFMPEG32bitToolStripMenuItem_Click(null, null);
                }
            }
            else if (Properties.Settings.Default.FFMPEG64Bit == 1)
            {
                useFFMPEG64bitToolStripMenuItem_Click(null, null);
            }
            else if (Properties.Settings.Default.FFMPEG64Bit == 2)
            {
                useFFMPEG32bitToolStripMenuItem_Click(null, null);
            }

            /*
            if (frmAbout.LDT != string.Empty)
            {
                buyToolStripMenuItem.Visible = false;
            }
            */

            checkForNewVersionEachWeekToolStripMenuItem.Checked = Properties.Settings.Default.CheckWeek;
        }
        private void frmClip_Load(object sender, EventArgs e)
        {
            SetupOnLoad();

            UpdateHelper.InitializeCheckVersion();
        }

        private void RepositionResize()
        {
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

                if (Properties.Settings.Default.Width != -1)
                {
                    this.Width = Properties.Settings.Default.Width;
                }


                if (Properties.Settings.Default.Height != -1)
                {
                    this.Height = Properties.Settings.Default.Height;
                }

                if (Properties.Settings.Default.Left != -1)
                {
                    this.Left = Properties.Settings.Default.Left;
                }

                if (Properties.Settings.Default.Top != -1)
                {
                    this.Top = Properties.Settings.Default.Top;
                }
            }

            if (this.Width < 300)
            {
                this.Width = 300;
            }

            if (this.Height < 300)
            {
                this.Height = 300;
            }

            if (this.Top < 0)
            {
                this.Top = 0;
            }

            if (this.Left < 0)
            {
                this.Left = 0;
            }

            this.Show();
            this.BringToFront();
            this.Visible = true;
        }

        private void SavePositionSize()
        {
            if (Module.IsCommandLine) return;

            Properties.Settings.Default.Maximized = (this.WindowState == FormWindowState.Maximized);
            Properties.Settings.Default.Left = this.Left;
            Properties.Settings.Default.Top = this.Top;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Save();
        }

        private void SetEnabled(bool enabled)
        {
            tsbJoinVideos.Enabled = enabled;
        }

        public static bool WasInFormClosing = false;

        private void frmVideoJoin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WasInFormClosing) return;

            WasInFormClosing = true;

            /*
            if (!InChangeLanguage)
            {
                if (frmPurchase.RenMove && frmPurchase.Msg != DisplayMessageType1.License_Expired)
                {
                    if (frmPurchase.Datefrom != string.Empty)
                    {
                        frmPurchase f = new frmPurchase(frmPurchase.Msg, frmPurchase.Datefrom, frmPurchase.Datelast);
                        f.ShowDialog();
                    }
                    else
                    {
                        frmPurchase f = new frmPurchase(frmPurchase.Msg);
                    }
                }
            }
            */

            //1Application.RemoveMessageFilter(filter);                                              

            Properties.Settings.Default.CheckWeek = checkForNewVersionEachWeekToolStripMenuItem.Checked;

            if (!Module.IsCommandLine)
            {
                Properties.Settings.Default.Save();

                SavePositionSize();
            }

            for (int k = 0; k < Module.TempGeneratedFiles.Count; k++)
            {
                if (System.IO.File.Exists(Module.TempGeneratedFiles[k]))
                {
                    FileInfo fi = new FileInfo(Module.TempGeneratedFiles[k]);
                    fi.Attributes = FileAttributes.Normal;
                    fi.Delete();
                }
            }
        }
        private void frmVideoJoin_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                psFFMpeg.Kill();
            }
            catch { }

            /*
            if (System.IO.Directory.Exists(VideoThumbnail.ThumbnailsPath))
            {
                string[] filez = System.IO.Directory.GetFiles(VideoThumbnail.ThumbnailsPath);

                for (int k = 0; k < filez.Length; k++)
                {
                    try
                    {
                        System.IO.File.Delete(filez[k]);
                    }
                    catch
                    {
                    }
                }
            }*/
        }

        #endregion

        #region Media Player

        private string args_play = "";

        #endregion        

        #region Import - Enter List

        private void importVideosFromTextFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string curdir = Environment.CurrentDirectory;

                try
                {
                    Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);

                    using (System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName))
                    {
                        string line = null;

                        while ((line = sr.ReadLine()) != null)
                        {
                            string fullfilepath = System.IO.Path.GetFullPath(line);

                            try
                            {
                                AddFile(fullfilepath);
                            }
                            catch (Exception ex)
                            {
                                Module.ShowError("Error. Could not Add Video to list", ex);
                            }
                        }
                    }
                }
                finally
                {
                    Environment.CurrentDirectory = curdir;
                }
            }
        }

        private void importVideosFromCSVFIleToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            frmImportFromCSV f = new frmImportFromCSV();

            if (f.ShowDialog() == DialogResult.OK)
            {
                f.ImportCSV(f.txtFilepath.Text);
            }
        }

        private void importVideosFromExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            frmImportFromExcel f = new frmImportFromExcel();

            if (f.ShowDialog() == DialogResult.OK)
            {
                f.ImportListExcel(f.txtFilepath.Text);
            }            
        }

        private void enterListOfVideosToJoinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = "";

            for (int k = 0; k < dt.Rows.Count; k++)
            {                
                txt += dt.Rows[k]["fullfilepath"].ToString() + "\r\n";
            }

            frmMultipleFiles f = new frmMultipleFiles(false, txt);

            if (f.ShowDialog() == DialogResult.OK)
            {
                dt.Rows.Clear();

                for (int k = 0; k < f.txtFiles.Lines.Length; k++)
                {
                    AddFile(f.txtFiles.Lines[k]);
                }
            }
        }

        #endregion

        #region Batch Join        

        private void importBatchListFromTextFileMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importBatchListFromCSVFileMenuItem_Click_Click(object sender, EventArgs e)
        {

        }

        private void importBatchListFromExcelFileMenuItem_Click_Click(object sender, EventArgs e)
        {

        }

        private void enterBatchListMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void batchJoinToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        #endregion                        

        private void saveCurrentSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                Module.ShowMessage("Current Selection is Empty !");
                return;
            }

            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default))
                {
                    for (int k = 0; k < dt.Rows.Count; k++)
                    {
                        //FFMPEGInfo finfo=(FFMPEGInfo)dt.Rows[k]["videoinfo"];
                        //sw.WriteLine(finfo.Filepath);

                        sw.WriteLine(dt.Rows[k]["fullfilepath"].ToString());
                    }
                }
            }
        }


        public string CurrentFirstFilepath
        {
            get
            {
                if (dt.Rows.Count > 0)
                {
                    //FFMPEGInfo f = (FFMPEGInfo)dt.Rows[0]["videoinfo"];

                    //return f.Filepath;

                    return dt.Rows[0]["fullfilepath"].ToString();
                }

                return "";
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgVideo.Rows.Count; k++)
            {
                dgVideo.Rows[k].Selected = true;
            }
        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgVideo.Rows.Count; k++)
            {
                dgVideo.Rows[k].Selected = false;
            }
        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgVideo.Rows.Count; k++)
            {
                dgVideo.Rows[k].Selected = !dgVideo.Rows[k].Selected;
            }
        }        
        private void buyApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Module.BuyURL);
        }

        private void enterLicenseKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void copyEXIFInformationFromSelectedVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CopyEXIF = copyEXIFInformationFromSelectedVideoToolStripMenuItem.Checked;
        }

        private void keepCreationDateFromSelectedVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.KeepCreationDate = keepCreationDateFromSelectedVideoToolStripMenuItem.Checked;
        }

        private void keepLastModificationDateFromSelectedVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.KeepLastModDate = keepLastModificationDateFromSelectedVideoToolStripMenuItem.Checked;
        }        
        private void useFFMPEG64bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useFFMPEG64bitToolStripMenuItem.Checked = true;
            useFFMPEG32bitToolStripMenuItem.Checked = false;

            Properties.Settings.Default.FFMPEG64Bit = 1;
        }

        private void useFFMPEG32bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useFFMPEG64bitToolStripMenuItem.Checked = false;
            useFFMPEG32bitToolStripMenuItem.Checked = true;

            Properties.Settings.Default.FFMPEG64Bit = 2;
        }

        private void dgVideo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgVideo_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

        private void dgVideo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dgVideo.Columns[e.ColumnIndex].Name == "colVideo" && e.RowIndex >= 0)
            {
                if (dgVideo.SelectedRows!=null && dgVideo.SelectedRows.Count>0 &&
                    dgVideo.SelectedRows[0].Index == e.RowIndex)
                {
                    e.PaintBackground(e.ClipBounds, true);
                }
                else
                {
                    e.PaintBackground(e.ClipBounds, false);
                }

                e.PaintContent(e.ClipBounds);

                Font f = new Font(this.Font.FontFamily, 12, FontStyle.Bold);

                System.Drawing.SizeF sz = e.Graphics.MeasureString(TranslateHelper.Translate("Set Thubmnail"), f);

                int b = 9;                                                

                if (Control.MouseButtons == MouseButtons.Left &&
                    dgVideo.SelectedRows != null && dgVideo.SelectedRows.Count > 0 &&
                    (dgVideo.SelectedRows[0].Index == e.RowIndex) && PointInButtonRect)
                {
                    ControlPaint.DrawButton(e.Graphics,
                        e.CellBounds.X +
                        e.CellBounds.Width - (int)sz.Width - 12 - b,
                        e.CellBounds.Y +
                        e.CellBounds.Height - (int)sz.Height - 12 - b, (int)sz.Width + 12, (int)sz.Height + 12, ButtonState.Pushed);

                    ControlPaint.DrawBorder3D(e.Graphics,
                        e.CellBounds.X +
                        e.CellBounds.Width - (int)sz.Width - 12 + 3 - b,
                        e.CellBounds.Y +
                        e.CellBounds.Height - (int)sz.Height - 12 + 3 - b, (int)sz.Width + 12 - 3, (int)sz.Height + 12 - 3, Border3DStyle.Sunken);

                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    e.Graphics.DrawString(
                        TranslateHelper.Translate("Set Thumbnail"),
                        f, Brushes.DarkBlue, new PointF(
                        e.CellBounds.Width - (int)sz.Width - 12 + 5 - b,
                        e.CellBounds.Y +
                        e.CellBounds.Height - (int)sz.Height - 12 + 5 - b
                            ));
                }
                else
                {
                    ControlPaint.DrawButton(e.Graphics,
                        e.CellBounds.X +
                        e.CellBounds.Width - (int)sz.Width - 12 - b,
                        e.CellBounds.Y +
                        e.CellBounds.Height - (int)sz.Height - 12 - b, (int)sz.Width + 12, (int)sz.Height + 12, ButtonState.Flat);

                    ControlPaint.DrawBorder3D(e.Graphics,
                        e.CellBounds.X +
                        e.CellBounds.Width - (int)sz.Width - 12 + 3 - b,
                        e.CellBounds.Y +
                        e.CellBounds.Height - (int)sz.Height - 12 + 3 - b, (int)sz.Width + 12 - 3, (int)sz.Height + 12 - 3, Border3DStyle.Raised);

                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    e.Graphics.DrawString(
                        TranslateHelper.Translate("Set Thumbnail"),
                        f, Brushes.DimGray, new PointF(
                        e.CellBounds.Width - (int)sz.Width - 12 + 5 - b,
                        e.CellBounds.Y +
                        e.CellBounds.Height - (int)sz.Height - 12 + 5 - b
                            ));
                }

                e.Handled = true;

                f.Dispose();
                f = null;
            }
        }

        private bool PointInButtonRect = false;

        private void dgVideo_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {            
            if (dgVideo.Columns[e.ColumnIndex].Name == "colVideo" && e.RowIndex >= 0)
            {
                Font f = new Font(this.Font.FontFamily, 12, FontStyle.Bold);

                bool pointInRect = false;

                using (Graphics g = Graphics.FromHwnd(dgVideo.Handle))
                {
                    System.Drawing.SizeF sz = g.MeasureString(TranslateHelper.Translate("Set Thubmnail"), f);

                    int b = 9;

                    Rectangle rect = new Rectangle(dgVideo.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds.X +
                            dgVideo.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds.Width - (int)sz.Width - 12 - b,
                            dgVideo.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds.Y +
                            dgVideo.Rows[e.RowIndex].Cells[e.ColumnIndex].ContentBounds.Height - (int)sz.Height - 12 - b, (int)sz.Width + 12, (int)sz.Height + 12);

                    if (rect.Contains(new Point(e.X, e.Y)))
                    {
                        pointInRect = true;

                        PointInButtonRect = true;
                    }
                    else
                    {
                        pointInRect = false;

                        PointInButtonRect = false;
                    }
                }

                f.Dispose();
                f = null;

                if (Control.MouseButtons == MouseButtons.Left)
                {
                    this.Cursor = null;
                }
                else if (Control.MouseButtons != MouseButtons.Left && pointInRect)
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = null;
                }
            }
            else
            {
                PointInButtonRect = false;

                this.Cursor = null;
            }
        }

        private void dgVideo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PointInButtonRect)
            {
                if (dgVideo.CurrentRow != null && dgVideo.CurrentRow.Index >= 0)
                {
                    DataRow dr = dt.Rows[dgVideo.CurrentRow.Index];

                    bool btp = bool.Parse(dr["isFromTimePosition"].ToString());
                    int tps = int.Parse(dr["timePositionMsecs"].ToString());
                    string imgfp = dr["imagefilepath"].ToString();

                    Image bmpth = null;

                    if (dr["thumbimage"] != System.DBNull.Value)
                    {
                        bmpth = (Image)dr["thumbimage"];
                    }

                    string thfp = dr["thumbimagefilepath"].ToString();

                    int msecs = int.Parse(dr["durationmsecs"].ToString());
                    string videofp = dr["fullfilepath"].ToString();

                    bool reversetp = bool.Parse(dr["reversetp"].ToString());
                    bool isfromdurp = bool.Parse(dr["isFromDurationPercentage"].ToString());
                    string durptext = dr["DurationPercentageText"].ToString();
                    decimal durpval = decimal.Parse(dr["DurationPercentageValue"].ToString());

                    this.Cursor = Cursors.WaitCursor;

                    frmVideoThumbnail f = new frmVideoThumbnail(videofp, msecs, btp, tps, imgfp,reversetp,isfromdurp,durpval,durptext);

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        if (!f.chkApplyToAllVideos.Checked)
                        {

                            dr["isFromTimePosition"] = Properties.Settings.Default.DefaultTimePosition;
                            dr["timePositionMsecs"] = Properties.Settings.Default.DefaultTimePositiionMsecs;
                            dr["imagefilepath"] = Properties.Settings.Default.DefaultImageFilepath;
                            dr["thumbimage"] = f.ThumbnailImage;
                            dr["thumbimagefilepath"] = Properties.Settings.Default.DefaultThumbnailImageFilepath;

                            dr["reversetp"] = Properties.Settings.Default.ReverseTimePosition;
                            dr["isFromDurationPercentage"] = Properties.Settings.Default.ImageFromDurationPercentage;
                            dr["DurationPercentageText"] = Properties.Settings.Default.DurationPercentageText;
                            dr["DurationPercentageValue"] = Properties.Settings.Default.DurationPercentage;

                            Bitmap bmp = new Bitmap(700, 110);

                            int dur = -1;

                            FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

                            using (Graphics g = Graphics.FromImage(bmp))
                            {
                                string timestring = FFMpegArgsHelperJoin.GetStringFromTime((int)(finfo.DurationMsecs / 2));

                                //VideoThumbnail vt = new VideoThumbnail(filepath, timestring, 156, 100);

                                int x = 5;
                                int y = 5;

                                g.FillRectangle(Brushes.Black, new Rectangle(x, y, 156, 100));

                                Bitmap bmp1 = new Bitmap(156, 100);

                                if (Properties.Settings.Default.DefaultThumbnailImageFilepath != string.Empty)
                                {
                                    using (Graphics gb = Graphics.FromImage(bmp1))
                                    {
                                        gb.Clear(Color.Black);

                                        decimal d1 = (decimal)f.ThumbnailImage.Width;
                                        decimal d2 = (decimal)f.ThumbnailImage.Height;
                                        decimal d3 = (decimal)156;
                                        decimal d4 = (decimal)100;

                                        // w  h
                                        // 156 y

                                        decimal dh = (d3 * d2) / d1;
                                        int id = (int)dh;

                                        // w h
                                        // x 100

                                        decimal dw = (d4 * d1) / d2;
                                        int idw = (int)dw;

                                        if (idw >= 156)
                                        {
                                            gb.DrawImage(f.ThumbnailImage, new Rectangle(0, Math.Max(0, 100 / 2 - id / 2), 156, id), new Rectangle(0, 0, f.ThumbnailImage.Width, f.ThumbnailImage.Height), GraphicsUnit.Pixel);
                                        }
                                        else
                                        {
                                            gb.DrawImage(f.ThumbnailImage, new Rectangle(Math.Max(0, 156 / 2 - idw / 2), 0, idw, 100), new Rectangle(0, 0, f.ThumbnailImage.Width, f.ThumbnailImage.Height), GraphicsUnit.Pixel);
                                        }
                                    }
                                }
                                else
                                {
                                    using (Graphics gb = Graphics.FromImage(bmp1))
                                    {
                                        gb.Clear(Color.Black);

                                    }
                                }

                                g.DrawImage(bmp1, new Rectangle(x, y, 156, 100));

                                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                                Font fo = new Font(dgVideo.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

                                x = 170;
                                y = 10;

                                g.DrawString(System.IO.Path.GetFileName(videofp), fo, Brushes.DarkBlue, new PointF(x, y));
                                y += fo.Height + 4;

                                string duration = TranslateHelper.Translate("Duration") + " : " + finfo.DurationStr;

                                dur = finfo.DurationMsecs;

                                g.DrawString(duration, fo, Brushes.Black, new PointF(x, y));
                                y += fo.Height + 4;

                                string video = "";

                                if (Properties.Settings.Default.DefaultTimePosition)
                                {
                                    video = TranslateHelper.Translate("Thumbnail from Time Position") + " : " + FFMpegArgsHelper.GetStringFromTime(Properties.Settings.Default.DefaultTimePositiionMsecs);

                                    if (Properties.Settings.Default.ReverseTimePosition)
                                    {
                                        video += " " + TranslateHelper.Translate("Reversed");
                                    }
                                }
                                else if (Properties.Settings.Default.DefaultImage)
                                {
                                    video = TranslateHelper.Translate("Thumbnail from Image") + " : " + System.IO.Path.GetFileName(Properties.Settings.Default.DefaultImageFilepath);
                                }
                                else if (Properties.Settings.Default.ImageFromDurationPercentage)
                                {
                                    video = TranslateHelper.Translate("Thumbnail from Duration Percentage") + " : " + Properties.Settings.Default.DurationPercentageText;
                                }

                                g.DrawString(video, fo, Brushes.Black, new PointF(x, y));

                                y += fo.Height + 4;

                            }

                            dr["videoimg"] = bmp;
                        }
                        else if (f.chkApplyToAllVideos.Checked)
                        {
                            for (int k = 0; k < dt.Rows.Count; k++)
                            {
                                try
                                {
                                    dr = dt.Rows[k];

                                    btp = bool.Parse(dr["isFromTimePosition"].ToString());
                                    tps = int.Parse(dr["timePositionMsecs"].ToString());
                                    imgfp = dr["imagefilepath"].ToString();

                                    bmpth = null;

                                    if (dr["thumbimage"] != System.DBNull.Value)
                                    {
                                        bmpth = (Image)dr["thumbimage"];
                                    }

                                    thfp = dr["thumbimagefilepath"].ToString();

                                    msecs = int.Parse(dr["durationmsecs"].ToString());
                                    videofp = dr["fullfilepath"].ToString();

                                    dr["isFromTimePosition"] = Properties.Settings.Default.DefaultTimePosition;
                                    dr["timePositionMsecs"] = Properties.Settings.Default.DefaultTimePositiionMsecs;
                                    dr["imagefilepath"] = Properties.Settings.Default.DefaultImageFilepath;

                                    dr["reversetp"] = Properties.Settings.Default.ReverseTimePosition;
                                    dr["isFromDurationPercentage"] = Properties.Settings.Default.ImageFromDurationPercentage;
                                    dr["DurationPercentageText"] = Properties.Settings.Default.DurationPercentageText;
                                    dr["DurationPercentageValue"] = Properties.Settings.Default.DurationPercentage;

                                    FFMPEGInfo finfo = (FFMPEGInfo)dr["videoinfo"];

                                    if (Properties.Settings.Default.DefaultImage)
                                    {
                                        dr["thumbimage"] = f.ThumbnailImage;
                                        dr["thumbimagefilepath"] = Properties.Settings.Default.DefaultThumbnailImageFilepath;

                                        bmpth = f.ThumbnailImage;
                                    }
                                    else if (Properties.Settings.Default.DefaultTimePosition)
                                    {
                                        if (Properties.Settings.Default.DefaultTimePosition
                                            && (Properties.Settings.Default.DefaultTimePositiionMsecs > finfo.DurationMsecs))
                                        {
                                            Module.ShowMessage(System.IO.Path.GetFileName(videofp) + " : " + TranslateHelper.Translate("Error ! Thumbnail Time Position exceeds Video Duration !"));

                                            dr["thumbimage"] = null;
                                            dr["thumbimagefilepath"] = string.Empty;

                                            bmpth = null;

                                            continue;
                                        }

                                        string stime = FFMpegArgsHelperJoin.GetStringFromTime(Properties.Settings.Default.DefaultTimePositiionMsecs);

                                        if (Properties.Settings.Default.ReverseTimePosition)
                                        {
                                            stime = FFMpegArgsHelperJoin.GetStringFromTime(finfo.DurationMsecs - Properties.Settings.Default.DefaultTimePositiionMsecs);
                                        }

                                        VideoThumbnail vth = new VideoThumbnail(videofp, stime);

                                        dr["thumbimage"] = vth.ThumbnailImage;
                                        dr["thumbimagefilepath"] = vth.ThumbnailFilepath;

                                        bmpth = vth.ThumbnailImage;
                                    }
                                    else if (Properties.Settings.Default.ImageFromDurationPercentage)
                                    {
                                        decimal ddur = (decimal)finfo.DurationMsecs;

                                        decimal ddp = ddur * Properties.Settings.Default.DurationPercentage;

                                        string stime = FFMpegArgsHelperJoin.GetStringFromTime((int)ddp);

                                        VideoThumbnail vth = new VideoThumbnail(videofp, stime);

                                        if (vth.ThumbnailImage == null)
                                        {
                                            dr["thumbimage"] = null;
                                            dr["thumbimagefilepath"] = string.Empty;

                                            bmpth = null;

                                            continue;
                                        }

                                        dr["thumbimage"] = vth.ThumbnailImage;
                                        dr["thumbimagefilepath"] = vth.ThumbnailFilepath;

                                        bmpth = vth.ThumbnailImage;
                                    }

                                    Bitmap bmp = new Bitmap(700, 110);

                                    int dur = -1;

                                    using (Graphics g = Graphics.FromImage(bmp))
                                    {
                                        string timestring = FFMpegArgsHelperJoin.GetStringFromTime((int)(finfo.DurationMsecs / 2));

                                        //VideoThumbnail vt = new VideoThumbnail(filepath, timestring, 156, 100);

                                        int x = 5;
                                        int y = 5;

                                        g.FillRectangle(Brushes.Black, new Rectangle(x, y, 156, 100));

                                        Bitmap bmp1 = new Bitmap(156, 100);

                                        if (bmpth != null)
                                        {
                                            using (Graphics gb = Graphics.FromImage(bmp1))
                                            {
                                                gb.Clear(Color.Black);

                                                decimal d1 = (decimal)bmpth.Width;
                                                decimal d2 = (decimal)bmpth.Height;
                                                decimal d3 = (decimal)156;
                                                decimal d4 = (decimal)100;

                                                // w  h
                                                // 156 y

                                                decimal dh = (d3 * d2) / d1;
                                                int id = (int)dh;

                                                // w h
                                                // x 100

                                                decimal dw = (d4 * d1) / d2;
                                                int idw = (int)dw;

                                                if (idw >= 156)
                                                {
                                                    gb.DrawImage(bmpth, new Rectangle(0, Math.Max(0, 100 / 2 - id / 2), 156, id), new Rectangle(0, 0, bmpth.Width, bmpth.Height), GraphicsUnit.Pixel);
                                                }
                                                else
                                                {
                                                    gb.DrawImage(bmpth, new Rectangle(Math.Max(0, 156 / 2 - idw / 2), 0, idw, 100), new Rectangle(0, 0, bmpth.Width, bmpth.Height), GraphicsUnit.Pixel);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            using (Graphics gb = Graphics.FromImage(bmp1))
                                            {
                                                gb.Clear(Color.Black);

                                            }
                                        }

                                        g.DrawImage(bmp1, new Rectangle(x, y, 156, 100));

                                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                                        Font fo = new Font(dgVideo.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

                                        x = 170;
                                        y = 10;

                                        g.DrawString(System.IO.Path.GetFileName(videofp), fo, Brushes.DarkBlue, new PointF(x, y));
                                        y += fo.Height + 4;

                                        string duration = TranslateHelper.Translate("Duration") + " : " + finfo.DurationStr;

                                        dur = finfo.DurationMsecs;

                                        g.DrawString(duration, fo, Brushes.Black, new PointF(x, y));
                                        y += fo.Height + 4;

                                        string video = "";

                                        if (Properties.Settings.Default.DefaultTimePosition)
                                        {
                                            video = TranslateHelper.Translate("Thumbnail from Time Position") + " : " + FFMpegArgsHelper.GetStringFromTime(Properties.Settings.Default.DefaultTimePositiionMsecs);

                                            if (Properties.Settings.Default.ReverseTimePosition)
                                            {
                                                video += " " + TranslateHelper.Translate("Reversed");
                                            }
                                        }
                                        else if (Properties.Settings.Default.DefaultImage)
                                        {
                                            video = TranslateHelper.Translate("Thumbnail from Image") + " : " + System.IO.Path.GetFileName(Properties.Settings.Default.DefaultImageFilepath);
                                        }
                                        else if (Properties.Settings.Default.ImageFromDurationPercentage)
                                        {
                                            video = TranslateHelper.Translate("Thumbnail from Duration Percentage") + " : " + Properties.Settings.Default.DurationPercentageText;
                                        }

                                        g.DrawString(video, fo, Brushes.Black, new PointF(x, y));

                                        y += fo.Height + 4;

                                    }

                                    dr["videoimg"] = bmp;

                                }
                                catch (Exception exk)
                                {
                                    Module.ShowError(exk);
                                }
                            }
                        }
                    }

                    this.Cursor = null;


                }
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOptions f = new frmOptions();
            f.ShowDialog(this);
        }

        private void extractThumbnailImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                string filepath = dt.Rows[k]["fullfilepath"].ToString();
                string thumbimagefp = dt.Rows[k]["thumbimagefilepath"].ToString();

                if (System.IO.File.Exists(thumbimagefp))
                {
                    string outfolder = System.IO.Path.GetDirectoryName(filepath);

                    if (Properties.Settings.Default.OutputFolderIndex != 0)
                    {
                        outfolder = Properties.Settings.Default.OutputFolder;
                    }

                    string thumbsavefp = System.IO.Path.Combine(outfolder, System.IO.Path.GetFileNameWithoutExtension(filepath) + "_thumb.jpg");

                    if (System.IO.File.Exists(thumbsavefp))
                    {
                        FileInfo fi = new FileInfo(thumbsavefp);
                        fi.Attributes = FileAttributes.Normal;
                        fi.Delete();
                    }

                    System.IO.File.Copy(thumbimagefp, thumbsavefp);
                }
            }

            Module.ShowMessage("Operation completed successfully !");
        }
    }
}