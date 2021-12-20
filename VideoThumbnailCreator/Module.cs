using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;

namespace VideoThumbnailCreator
{
    class Module
    {
        public static System.Drawing.Color BlueForeColor = System.Drawing.Color.FromArgb(52, 89, 152);

        public static string ApplicationName = "Video Thumbnail Creator";
        public static string Version = "1.3";

        public static string Ver = "3";

        public static string ShortApplicationTitle = ApplicationName + " V" + Version;
        public static string ApplicationTitle = ShortApplicationTitle + " - 4dots Software";                
        
        public static string DownloadURL = "http://www.4dots-software.com/d/VideoThumbnailCreator/";
        public static string HelpURL = "http://www.4dots-software.com/video-thumbnail-creator/how-to-use.php";
        public static string ProductWebpageURL = "http://www.4dots-software.com/video-thumbnail-creator/";
        public static string BuyURL = "http://www.4dots-software.com/store/buy-video-thumbnail-creator.php";        
        public static string VersionURL = "http://cssspritestool.com/versions/video-thumbnail-creator.txt";        

        public static string TipText = "Great application to add Thumbnails to Videos for Windows Explorer Thumbnail Preview !";

        public static List<string> TempGeneratedFiles = new List<string>();

        public static string _ProfilesFile
        = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\"+ApplicationName+"\\ffmpeg_profiles.xml";            

        public static string ProfilesFile
        {
            get
            {
                if (!System.IO.File.Exists(_ProfilesFile))
                {
                    if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(_ProfilesFile)))
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(_ProfilesFile));
                    }

                    System.IO.File.Copy(System.IO.Path.Combine(Application.StartupPath, "ffmpeg_profiles.xml"),
                        _ProfilesFile, true);
                }

                return _ProfilesFile;
            }
        }

        public static string _VideoOptionsFile 
        = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\"+ApplicationName+"\\video_options.xml";

        public static string VideoOptionsFile
        {
            get
            {
                if (!System.IO.File.Exists(_VideoOptionsFile))
                {
                    if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(_VideoOptionsFile)))
                    {
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(_VideoOptionsFile));
                    }

                    System.IO.File.Copy(System.IO.Path.Combine(Application.StartupPath, "video_options.xml"),
                        _VideoOptionsFile, true);
                }

                return _VideoOptionsFile;
            }
        }


        public static string OpenFilesFilter = 
            "All Supported Video Files (*.avi;*.mp4;*.mpeg;*.mpg;*.mov;*.mkv;*.flv;*.wmv;*.3gp;*.vob;*.swf;*.3g2;*.asf;*.m2p;*.m2ts;*.m2v;*.m4v;*.mp2;*.ogm;*.ogv;*.qt;*.rm;*.rmvb;*.ts;*.webm)|"+
            "*.avi;*.mp4;*.mpeg;*.mpg;*.mov;*.mkv;*.flv;*.wmv;*.3gp;*.vob;*.swf;*.3g2;*.asf;*.m2p;*.m2ts;*.m2v;*.m4v;*.mp2;"+
            "*.ogm;*.ogv;*.qt;*.rm;*.rmvb;*.ts;*.webm|" +
            "AVI Files (*.avi)|*.avi|MP4 Files (*.mp4)|*.mp4|MPEG Files (*.mpeg;*.mpg)|*.mpeg;*.mpg|MOV Files (*.mov)|*.mov|MKV Files (*.mkv)|*.mkv|"+
            "FLV Files (*.flv)|*.flv|WMV Files (*.wmv)|*.wmv|3GP 3G2 Files (*.3gp;*.3g2)|*.3gp;*.3g2|VOB Files (*.vob)|*.vob|"+
            "SWF Files (*.swf)|*.swf|Quicktime Files (*.qt)|*.qt|Real Media Files (*.rm;*.rmvb)|*.rm;*.rmvb|"+
            "Webm Files (*.webm)|*.webm|Other Video Files (*.asf;*.m2p;*.m2ts;*.m2v;*.m4v;*.mp2;*.ogm;*.ogv;*.ts)|*.asf;"+
            "*.m2p;*.m2ts;*.m2v;*.m4v;*.mp2;*.ogm;*.ogv;*.ts|All Files (*.*)|*.*";

        public static string AudioFilesFilter=
            "All Supported Audio Files (*.mp3;*.flac;*.wma;*.aac;*.m4a;*.ogg;*.aif;*.aiff;*.wav;*.ac3;wv;*.ape;*.mpc;*.opus;*.mp2;*.au;*.amr)|"+
            "*.mp3;*.flac;*.wma;*.aac;*.m4a;*.ogg;*.aif;*.aiff;*.wav;*.ac3;wv;*.ape;*.mpc;*.opus;*.mp2;*.au;*.amr"+
            "|All Files (*.*)|*.*";


        public static string AcceptableMediaInputPattern =
         "*.avi;*.mp4;*.mpeg;*.mpg;*.mov;*.mkv;*.flv;*.wmv;*.3gp;*.vob;*.swf;*.3g2;*.asf;*.m2p;*.m2ts;*.m2v;*.m4v;*.mp2;*.ogm;*.ogv;*.qt;*.rm;*.rmvb;*.ts;*.webm";                    

        public static string AppDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Video Joiner Expert\\";

        public static string SelectedLanguage = "";

        public static string StoreUrl = "http://www.pdfdocmerge.com/store/";
        public static string[] args = null;
        public static bool IsCommandLine = false;
        public static bool IsFromWindowsExplorer = false;

        public static bool CmdMerge = false;
        public static bool CmdSplit = false;
        public static bool CmdDelete = false;
        public static bool CmdExtract = false;
        public static int CmdPageFrom = -1;
        public static int CmdPageTo = -1;
        public static int CmdPageOddFrom = -1;
        public static int CmdPageOddTo = -1;
        public static int CmdPageEvenFrom = -1;
        public static int CmdPageEvenTo = -1;
        public static int CmdPageEvery = -1;
        public static int CmdPageEveryFrom = -1;
        public static int CmdPageEveryTo = -1;
        public static string CmdPageRange = "";
        public static string CmdPageContaining = "";
        public static string CmdTitle = "";
        public static string CmdAuthor = "";
        public static string CmdKeywords = "";
        public static string CmdSubject = "";
        public static string CmdOwnerPassword = "";
        public static string CmdUserPassword = "";
        public static string CmdOutputFile = "";
        public static string CmdOutputFolder = "";
        public static string CmdHeaderText = "";
        public static string CmdFooterText = "";
        public static int CmdSplitBookmarks = -1;
        public static int CmdSplitBlank = -1;
        public static bool CmdAddSubdirectories = false;


        public static List<string> CmdFiles = new List<string>();

        public static List<string> SelectedFilepaths = new List<string>();
        public static List<string> SelectedOperations = new List<string>();
        public static List<string> SelectedParameters = new List<string>();

        public static string PresetFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ImgTransformer\Presets.xml";
        public static string ImageFilter = "JPEG Images (*.jpg)|*.jpg;*.jpeg|GIF Images (*.gif)|*.gif" +
        "|Bitmap Images (*.bmp)|*.bmp|PNG Images (*.png)|*.png|Jpeg 2000 Images (*.jp2)|*.jp2|Images Files (*.jpg;*.jpeg;*.gif;*.png;*.bmp)|" +
        "*.jpg;*.jpeg;*.gif;*.png;*.bmp|All Files (*.*)|*.*";

        public static string ImageFilterForSave = "JPEG Images (*.jpg)|*.jpg;*.jpeg|GIF Images (*.gif)|*.gif" +
        "|Bitmap Images (*.bmp)|*.bmp|PNG Images (*.png)|*.png";

//        public static string DialogFilesFilter = "PDF Files (*.pdf)|*.pdf|JPEG Images (*.jpg)|*.jpg;*.jpeg|GIF Images (*.gif)|*.gif" +
  //      "|Bitmap Images (*.bmp)|*.bmp|PNG Images (*.png)|*.png|All Files (*.*)|*.*";


        
        public static bool DoNotOverwriteFiles = false;
        public static bool AskBeforeOverwrite = false;
        public static bool LeaveSameDateTime = false;


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam,
        int lParam);

        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        public static void WaitNMSeconds(int mseconds)
        {
            if (mseconds < 1) return;
            DateTime _desired = DateTime.Now.AddMilliseconds(mseconds);
            while (DateTime.Now < _desired)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        public static bool IsLegalFilename(string name)
        {
            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsWindows64Bit
        {
            get
            {
                try
                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "get32or64bit.exe");
                    p.Start();
                    p.WaitForExit();

                    if (p.ExitCode == 64)
                    {
                        return true;
                    }
                    else if (p.ExitCode == 32)
                    {
                        return false;
                    }

                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static string GetRelativePath(string mainDirPath, string absoluteFilePath)
        {
            string[] firstPathParts = mainDirPath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
            string[] secondPathParts = absoluteFilePath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);

            int sameCounter = 0;
            for (int i = 0; i < Math.Min(firstPathParts.Length,
            secondPathParts.Length); i++)
            {
                if (
                !firstPathParts[i].ToLower().Equals(secondPathParts[i].ToLower()))
                {
                    break;
                }
                sameCounter++;
            }

            if (sameCounter == 0)
            {
                return absoluteFilePath;
            }

            string newPath = String.Empty;
            for (int i = sameCounter; i < firstPathParts.Length; i++)
            {
                if (i > sameCounter)
                {
                    newPath += Path.DirectorySeparatorChar;
                }
                newPath += "..";
            }
            if (newPath.Length == 0)
            {
                newPath = ".";
            }
            for (int i = sameCounter; i < secondPathParts.Length; i++)
            {
                newPath += Path.DirectorySeparatorChar;
                newPath += secondPathParts[i];
            }
            return newPath;
        }

        public static void ShowMessage(string msg)
        {
            if (Module.IsCommandLine)
            {
                Console.WriteLine("\n"+TranslateHelper.Translate(msg));
            }
            else
            {
                MessageBox.Show(TranslateHelper.Translate(msg));
            }
        }

        public static DialogResult ShowQuestionDialog(string msg, string caption)
        {
            return MessageBox.Show(TranslateHelper.Translate(msg), TranslateHelper.Translate(caption), MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
        }


        public static void ShowError(Exception ex)
        {
            ShowError("Error", ex);
        }

        public static void ShowError(string msg)
        {
            if (Module.IsCommandLine)
            {
                Console.WriteLine("Error:" + msg);
            }
            else
            {
                try
                {
                    frmError f = new frmError("Error", msg);
                    f.ShowDialog();
                }
                catch
                {

                }
                //MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public static void ShowError(string msg, Exception ex)
        {
            ShowError(msg + "\n\n" + ex.Message);
        }

        public static void ShowError(string msg, string exstr)
        {
            ShowError(msg + "\n\n" + exstr);
        }

        public static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {           
            
        }

        public static DialogResult ShowQuestionDialogYesFocus(string msg, string caption)
        {
            return MessageBox.Show(TranslateHelper.Translate(msg), TranslateHelper.Translate(caption), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
        

        public static bool IsAcceptableMediaInput(string filepath)
        {
            try
            {
                filepath = filepath.ToLower();
                FileInfo fi = new FileInfo(filepath);

                if (fi.Extension != String.Empty && Module.AcceptableMediaInputPattern.IndexOf(fi.Extension) >= 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        public static int _Modex64 = -1;

        public static bool Modex64
        {
            get
            {
                if (_Modex64 == -1)
                {
                    if (Marshal.SizeOf(typeof(IntPtr)) == 8)
                    {
                        _Modex64 = 1;
                        return true;
                    }
                    else
                    {
                        _Modex64 = 0;
                        return false;
                    }
                }
                else if (_Modex64 == 1)
                {
                    return true;
                }
                else if (_Modex64 == 0)
                {
                    return false;
                }
                return false;
            }
        }

        public static string DownloadPage(string uri)
        {
            try
            {
                WebClient client = new WebClient();

                Stream data = client.OpenRead(uri);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                return s;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        public static String HexConverter(System.Drawing.Color c)
        {
            String rtn = String.Empty;
            try
            {
                rtn = "0x" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
            }
            catch (Exception ex)
            {
                //doing nothing
            }

            return rtn;
        }

        public static void CheckVersion(bool onstart)
        {
            try
            {
                string str = DownloadPage("http://www.4dots-software.com/versions.txt");

                if (str != "Error" && str != String.Empty)
                {
                    StringReader sr = new StringReader(str);
                    string line;

                    bool found = false;

                    while ((line = sr.ReadLine()) != null)
                    {
                        int epos = line.IndexOf("=");

                        string title = line.Substring(0, epos);
                        string version = line.Substring(epos + 1, line.Length - epos - 1);

                        string app = title + " V" + version;

                        if (Module.ShortApplicationTitle.StartsWith(title) && app != Module.ShortApplicationTitle)
                        {
                            found = true;
                            Module.ShowMessage("A new version has been released. Press the OK button to download the new version");

                            System.Diagnostics.Process.Start(Module.DownloadURL);
                        }
                        else if (Module.ShortApplicationTitle.StartsWith(title))
                        {
                            found = true;
                            if (!onstart)
                            {
                                Module.ShowMessage("This is the latest version !");
                            }
                        }
                    }

                    if (!found)
                    {
                        if (!onstart)
                        {
                            Module.ShowMessage("An error occured !");
                        }
                    }
                }
                else
                {
                    if (!onstart)
                    {
                        Module.ShowMessage("An error occured !");
                    }
                }
            }
            catch
            {
                if (!onstart)
                {
                    Module.ShowMessage("An error occured !");
                }
            }
        }

        public static CheckVersionResult CheckVersionBackground()
        {
            bool onstart = true;
            CheckVersionResult res = new CheckVersionResult();

            try
            {
                string str = DownloadPage("http://www.4dots-software.com/versions.txt");

                if (str != "Error" && str != String.Empty)
                {
                    StringReader sr = new StringReader(str);
                    string line;

                    bool found = false;

                    while ((line = sr.ReadLine()) != null)
                    {
                        int epos = line.IndexOf("=");

                        string title = line.Substring(0, epos);
                        string version = line.Substring(epos + 1, line.Length - epos - 1);

                        string app = title + " V" + version;

                        if (Module.ShortApplicationTitle.StartsWith(title) && app != Module.ShortApplicationTitle)
                        {
                            found = true;
                            res.OutputMessage=TranslateHelper.Translate("A new version has been released. Press the OK button to download the new version");
                            res.NewVersionReleased = true;

                            //System.Diagnostics.Process.Start(Module.DownloadURL);
                        }
                        else if (Module.ShortApplicationTitle.StartsWith(title))
                        {
                            found = true;
                            if (!onstart)
                            {
                                res.OutputMessage=TranslateHelper.Translate("This is the latest version !");
                            }
                        }
                    }

                    if (!found)
                    {
                        if (!onstart)
                        {
                            res.OutputMessage=TranslateHelper.Translate("An error occured !");
                        }
                    }
                }
                else
                {
                    if (!onstart)
                    {
                        res.OutputMessage = TranslateHelper.Translate("An error occured !");
                    }
                }
            }
            catch
            {
                if (!onstart)
                {
                    res.OutputMessage = TranslateHelper.Translate("An error occured !");
                }
            }

            return res;
        }

        public static bool DeleteApplicationSettingsFile()
        {
            try
            {
                string settingsFile = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;

                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();

                System.IO.FileInfo fi = new FileInfo(settingsFile);
                fi.Attributes = System.IO.FileAttributes.Normal;
                fi.Delete();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    public class MediaInfo
    {
        public string Text = "";

        public string VideoFormat = "";
        public decimal FramesPerSecond = 0;
        public decimal ColorDepth = 0;
        public decimal SamplingRate = 0;
        public decimal Bitrate = 0;
        public string VideoAspect = "";
        public int VideoWidth = 0;
        public int VideoHeight = 0;

        public string AudioFormat = "";
        public decimal AudioBitrate = 0;
        public decimal AudioSamplingRate = 0;
        public string Channels = "";

        public MediaInfo()
        {

        }
    }      
}