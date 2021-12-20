using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace VideoThumbnailCreator
{ 
    class ArgsHelper
    {
        public static bool ExamineArgs(string[] args)
        {
            if (args.Length == 0) return true;

            Module.args = args;

            try
            {
                if (args[0].ToLower().Trim().StartsWith("-tempfile:"))
                {
                    string tempfile = GetParameter(args[0]);

                    //MessageBox.Show(tempfile);

                    using (StreamReader sr = new StreamReader(tempfile, Encoding.Unicode))
                    {
                        string scont = sr.ReadToEnd();

                        //args = scont.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        args = SplitArguments(scont);
                        Module.args = args;

                        // MessageBox.Show(scont);
                    }

                    Module.IsFromWindowsExplorer = true;
                }
                else if (args.Length > 0 && (Module.args.Length == 1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0]))))
                {

                }
                else
                {
                    Module.IsCommandLine = true;                                        
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not parse Arguments !", ex.ToString());
                return false;
            }

            return true;
        }

        public static void ExamineArgsFromForm()
        {
            frmMain.Instance.dt.Rows.Clear();

            for (int k = 0; k < Module.args.Length; k++)
            {
                if (Module.args[k].ToLower().StartsWith("-fromimage")
    || Module.args[k].ToLower().StartsWith("/fromimage"))
                {
                    Properties.Settings.Default.ImageFromDurationPercentage = false;
                    Properties.Settings.Default.DefaultTimePosition = false;
                    Properties.Settings.Default.DefaultImage = true;

                    string imgfile = GetParameter(Module.args[k]);

                    Properties.Settings.Default.DefaultImageFilepath = imgfile;
                }
                else if (Module.args[k].ToLower().StartsWith("-fromtime")
    || Module.args[k].ToLower().StartsWith("/fromtime"))
                {
                    Properties.Settings.Default.ImageFromDurationPercentage = false;
                    Properties.Settings.Default.DefaultTimePosition = true;
                    Properties.Settings.Default.DefaultImage = false;

                    string tp = GetParameter(Module.args[k]);
                    try
                    {
                        Properties.Settings.Default.DefaultTimePositiionMsecs = FFMpegArgsHelper.GetTimeFromString(tp);
                    }
                    catch
                    {
                        Module.ShowMessage("Please enter the Time Position in the correct format ! e.g. 00:00:15");
                        Environment.Exit(0);
                        return;
                    }
                }
                else if (Module.args[k].ToLower().StartsWith("-fromduration")
    || Module.args[k].ToLower().StartsWith("/fromduration"))
                {
                    Properties.Settings.Default.ImageFromDurationPercentage = true;
                    Properties.Settings.Default.DefaultTimePosition = false;
                    Properties.Settings.Default.DefaultImage = false;

                    string txt = GetParameter(Module.args[k]);

                    decimal dp = frmVideoThumbnail.GetDurationPercentage(txt);

                    if (dp<0)
                    {
                        Module.ShowMessage("Please enter the Duration Percentage in the correct format ! e.g. 50%");
                        Environment.Exit(0);
                        return;
                    }

                    Properties.Settings.Default.DurationPercentage = dp;
                    Properties.Settings.Default.DurationPercentageText = txt;
                }
                else if (Module.args[k].ToLower().StartsWith("-reversetime")
    || Module.args[k].ToLower().StartsWith("/reversetime"))
                {
                    Properties.Settings.Default.ReverseTimePosition = true;
                }
                else if (Module.args[k].ToLower().StartsWith("-keepcreationdate")
    || Module.args[k].ToLower().StartsWith("/keepcreationdate"))
                {
                    Properties.Settings.Default.KeepCreationDate = true;
                }
                else if (Module.args[k].ToLower().StartsWith("-keeplastmodified")
    || Module.args[k].ToLower().StartsWith("/keeplastmodified"))
                {
                    Properties.Settings.Default.KeepLastModDate = true;
                }
                else if (Module.args[k].ToLower().StartsWith("-copyexif")
    || Module.args[k].ToLower().StartsWith("/copyexif"))
                {
                    Properties.Settings.Default.CopyEXIF = true;
                }
                else if (Module.args[k].ToLower().StartsWith("-outputfolder")
    || Module.args[k].ToLower().StartsWith("/outputfolder"))
                {
                    string outputfolder = GetParameter(Module.args[k]);

                    Properties.Settings.Default.OutputFolder = outputfolder;
                }
                else if (Module.args[0].ToLower() == "/h" ||
                        Module.args[0].ToLower() == "-h" ||
                        Module.args[0].ToLower() == "-?" ||
                        Module.args[0].ToLower() == "/?")
                {
                    ShowCommandUsage();
                    Environment.Exit(1);
                    return;
                }
            }

            for (int k = 0; k < Module.args.Length; k++)
            {
                if (System.IO.File.Exists(Module.args[k]))
                {
                    frmMain.Instance.AddFile(Module.args[k]);
                }
                else if (System.IO.Directory.Exists(Module.args[k]))
                {
                    frmMain.Instance.SilentAdd = true;

                    frmMain.Instance.AddFolder(Module.args[k]);
                }
            }        
        }

        public static string RemoveQuotes(string str)
        {
            if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
            {
                if (str.Length > 2)
                {
                    str = str.Substring(1, str.Length - 2);
                }
                else
                {
                    str = "";
                }
            }

            return str;
        }

        private static string GetParameter(string arg)
        {
            int spos = arg.IndexOf(":");
            if (spos == arg.Length - 1) return "";
            else
            {
                string str = arg.Substring(spos + 1);

                if ((str.StartsWith("\"") && str.EndsWith("\"")) ||
                    (str.StartsWith("'") && str.EndsWith("'")))
                {
                    if (str.Length > 2)
                    {
                        str = str.Substring(1, str.Length - 2);
                    }
                    else
                    {
                        str = "";
                    }
                }

                return str;
            }
        }

        public static string[] SplitArguments(string commandLine)
        {
            char[] parmChars = commandLine.ToCharArray();
            bool inSingleQuote = false;
            bool inDoubleQuote = false;
            for (int index = 0; index < parmChars.Length; index++)
            {
                if (parmChars[index] == '"' && !inSingleQuote)
                {
                    inDoubleQuote = !inDoubleQuote;
                    parmChars[index] = '\n';
                }
                if (parmChars[index] == '\'' && !inDoubleQuote)
                {
                    inSingleQuote = !inSingleQuote;
                    parmChars[index] = '\n';
                }
                if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
                    parmChars[index] = '\n';
            }
            return (new string(parmChars)).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void ShowCommandUsage()
        {
            string msg = "\n\nAdd Thumbnails to Videos for Windows Explorer Thumbnail Preview.\n\n" +
            "VideoThumbnailCreator.exe [file|directory]]\n" +
            "[/fromimage:IMAGE_FILE_PATH]\n"+
            "[/fromtime:TIME_POSITION]\n"+
            "[/fromduration:DURATION_PERCENTAGE]\n"+
            "[/reversetime]\n"+
            "[/keepcreationdate]\n"+
            "[/keeplastmodified]\n"+
            "[/copyexif]\n"+
            "[/outputfolder:OUTPUT_FOLDER_PATH\n"+
            "[/?]\n\n\n" + 
            "The application will use the default settings but you can force to change some parameters of it.\n\n"+
            "file : one or more audio files to be processed.\n" +
            "directory : one or more directories containing files to be processed.\n" +
            "fromimage : use an image for the thumbnail.\n"+
            "fromtime : use a thumbnail from a time position of the video e.g. 00:00:15.\n"+
            "fromduration: use a thumbnail from a duration percentage of the video e.g. 50%.\n"+
            "reversetime : reverse time position value for /fromtime parameter.\n"+
            "keepcreationdate : keep creation date of source video.\n"+
            "keeplastmodified : keep last modified date of source video.\n"+
            "copyexif : copy exif information from source video.\n"+
            "outputfolder : output folder.\n"+
            "/? : show help\n\n\n" +
            "Example :\n" +
            "VideoThumbnailCreator.exe \"c:\\video\\sample1.mp4\" \"c:\\video\\sample2.mp4\" " +
            " \"c:\\samplejoin\" /fromtime:\"00:00:15\" /outputfolder:\"c:\videothumbs\"";

            Module.ShowMessage(msg);

            Environment.Exit(0);
        }

        public static bool IsFromFolderWatcher
        {
            get
            {
                // new
                if (Module.args.Length > 0 && Module.args[0].ToLower().Trim() == "/cmdfw")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsFromWindowsExplorer
        {
            get
            {
                if (Module.IsFromWindowsExplorer) return true;

                // new
                if (Module.args.Length > 0 && (Module.args[0].ToLower().Trim().Contains("-tempfile:")
                    || (Module.args.Length == 1 && (System.IO.File.Exists(Module.args[0]) || System.IO.Directory.Exists(Module.args[0])))))
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool IsFromCommandLine
        {
            get
            {
                if (Module.args == null || Module.args.Length == 0)
                {
                    return false;
                }

                if (ArgsHelper.IsFromWindowsExplorer)
                {
                    Module.IsCommandLine = false;
                    return false;
                }
                else
                {
                    Module.IsCommandLine = true;
                    return true;
                }
            }
        }

        /*
        public static bool IsFromWindowsExplorer()
        {
            if (Module.args == null || Module.args.Length == 0)
            {
                return false;
            }

            for (int k = 0; k < Module.args.Length; k++)
            {
                if (Module.args[k] == "-visual")
                {
                    Module.IsFromWindowsExplorer = true;
                    return true;
                }
            }

            Module.IsFromWindowsExplorer = false;
            return false;
        }
        */

        public static void ExecuteCommandLine()
        {
            string err = "";
            bool finished = false;

            try
            {
                /*
                if (Module.CmdLogFile != string.Empty)
                {
                    try
                    {
                        Module.CmdLogFileWriter = new StreamWriter(Module.CmdLogFile, true);
                        Module.CmdLogFileWriter.AutoFlush = true;
                        Module.CmdLogFileWriter.WriteLine("[" + DateTime.Now.ToString() + "] Started compressing PDF files !");
                    }
                    catch (Exception exl)
                    {
                        Module.ShowMessage("Error could not start log writer !");
                        ShowCommandUsage();
                        Environment.Exit(0);
                        return;
                    }
                }                

                if (Module.CmdImportListFile != string.Empty)
                {
                    frmMain.Instance.ImportList(Module.CmdImportListFile);

                    err += frmMain.Instance.SilentAddErr;

                }
                */
                                

                if (Module.args[0].ToLower() == "/h" ||
                        Module.args[0].ToLower() == "-h" ||
                        Module.args[0].ToLower() == "-?" ||
                        Module.args[0].ToLower() == "/?")
                {
                    ShowCommandUsage();
                    Environment.Exit(1);
                    return;
                }                

                if (frmMain.Instance.dt.Rows.Count == 0)
                {
                    Module.ShowMessage("Please specify video files !");
                    ShowCommandUsage();
                    Environment.Exit(0);
                    return;
                }

                Console.Clear();

                Module.ShowMessage("Please wait...\nPress ^C (Control + C) to cancel operation.");

                Console.CancelKeyPress += Console_CancelKeyPress;

                bwMsg.DoWork += BwMsg_DoWork;
                bwMsg.WorkerReportsProgress = true;
                bwMsg.WorkerSupportsCancellation = true;
                bwMsg.ProgressChanged += BwMsg_ProgressChanged;
                bwMsg.RunWorkerAsync();

                frmMain.Instance.tsbJoinVideos_Click(null, null);

                bwMsg.CancelAsync();                

                Environment.Exit(0);

            }
            finally
            {

            }
            Environment.Exit(0);
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine("Operation cancelled !");

            try
            {
                frmMain.Instance.psFFMpeg.Kill();
            }
            catch { }

            Environment.Exit(1);
        }

        private static void BwMsg_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            Console.Write(".");
        }

        private static void BwMsg_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                if (bwMsg.CancellationPending)
                {
                    return;
                }
                else
                {
                    bwMsg.ReportProgress(0);
                    System.Threading.Thread.Sleep(1500);
                }
            }
        }

        public static System.ComponentModel.BackgroundWorker bwMsg = new System.ComponentModel.BackgroundWorker();

        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();

        const int ATTACH_PARENT_PROCESS = -1;
        const int ERROR_ACCESS_DENIED = 5;

    }
}
