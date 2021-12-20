using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace VideoThumbnailCreator
{
    public class FFMPEGInfo
    {
        public string Filepath = "";
        public bool Success = false;
 
        public string DurationStr = "";
        public int DurationMsecs = 0;

        public string VideoEncoder = "";
        public string AudioEncoder = "";

        public string VideoPixelFormat = "";
        public string VideoSize = "";
        public string VideoBitRate = "";
        public string VideoFrameRate = "";
        public string VideoSAR = "0:1";
        public string VideoDAR = "0:1";

        public decimal decVideoSAR
        {
            get
            {
                try
                {
                    int spos = VideoSAR.IndexOf(":");
                    decimal d1 = decimal.Parse(VideoSAR.Substring(0, spos));
                    decimal d2 = decimal.Parse(VideoSAR.Substring(spos + 1));

                    decimal d = d1 / d2;

                    return d;
                }
                catch
                {
                    return (decimal)-1;

                }
            }
        }

        public decimal decVideoDAR
        {
            get
            {
                try
                {
                    int spos = VideoDAR.IndexOf(":");
                    decimal d1 = decimal.Parse(VideoDAR.Substring(0, spos));
                    decimal d2 = decimal.Parse(VideoDAR.Substring(spos + 1));

                    decimal d = d1 / d2;

                    return d;
                }
                catch
                {
                    return (decimal)-1;

                }
            }
        }
        public int VideoWidth = -1;
        public int VideoHeight = -1;

        public int displayVideoWidth
        {
            get
            {
                if (decVideoSAR == (decimal)0)
                {
                    return VideoWidth;
                }
                else
                {
                    decimal d1 = (decimal)VideoWidth;
                    decimal d2 = d1 * decVideoSAR;

                    decimal d = d1 * d2;

                    return (int)d;
                }
            }
        }

        public int displayVideoHeight
        {
            get
            {
                if (decVideoSAR == (decimal)0)
                {
                    return VideoHeight;
                }
                else
                {                    
                    decimal d2 = displayVideoWidth;

                    decimal d3 = (decimal)1;
                    decimal d4 = d3 / decVideoDAR;

                    decimal d = d2 * d4;

                    return (int)d;                       
                }
            }
        }

        public Dictionary<string, string> VideoMetadata = new Dictionary<string, string>();

        public string AudioSamplingRate = "";
        public string AudioChannels = "";
        public string AudioBitRate = "";
        public string AudioSampleFormat = "";

        public Dictionary<string, string> AudioMetadata = new Dictionary<string, string>();

        public FFMPEGInfo(string filepath)
        {
            try
            {
                Filepath = filepath;

                //frmClip.Instance.Cursor = Cursors.WaitCursor;

                Process psFFMpeg = new Process();

                if (Properties.Settings.Default.FFMPEG64Bit == 1)
                {
                    psFFMpeg.StartInfo.FileName = "ffmpeg64 ";
                }
                else
                {
                    psFFMpeg.StartInfo.FileName = "ffmpeg32 ";
                }

                psFFMpeg.StartInfo.WorkingDirectory = System.Windows.Forms.Application.StartupPath;

                psFFMpeg.StartInfo.CreateNoWindow = true;
                psFFMpeg.StartInfo.UseShellExecute = false;
                psFFMpeg.StartInfo.RedirectStandardError = true;
                psFFMpeg.StartInfo.RedirectStandardOutput = true;

                psFFMpeg.OutputDataReceived += psFFMpeg_OutputDataReceived;
                psFFMpeg.ErrorDataReceived += psFFMpeg_ErrorDataReceived;

                psFFMpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                LastFFMpegOutput = "";

                last_line = "";            

                psFFMpeg.StartInfo.Arguments = " -i \"" + filepath + "\"";

                psFFMpeg.Start();

                psFFMpeg.BeginErrorReadLine();
                psFFMpeg.BeginOutputReadLine();

                psFFMpeg.WaitForExit();

                psFFMpeg.Close();

                psFFMpeg.Dispose();
                psFFMpeg = null;


                System.IO.StringReader sr = new System.IO.StringReader(LastFFMpegOutput);

                string line = null;

                Regex rgvideo=new Regex(@"\s*Stream #0[\s\S]* Video: ");
                Regex rgaudio=new Regex(@"\s*Stream #0[\s\S]* Audio: ");

                Regex rgpar = new Regex(@"\([\s\S]+?\)");

                bool aftervideoinfo = false;
                bool afteraudioinfo = false;
                bool aftervideometadata = false;
                bool afteraudiometadata = false;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("    Metadata:"))
                    {
                        aftervideometadata = aftervideoinfo;
                        afteraudiometadata = afteraudioinfo;
                    }
                    else if (line.StartsWith("    Stream #"))
                    {
                        aftervideometadata = false;
                        afteraudiometadata = false;
                        aftervideoinfo = false;
                        afteraudioinfo = false;
                    }

                    if (afteraudiometadata && line.StartsWith("      "))
                    {
                        try
                        {
                            Regex metadata = new Regex(@"\s+?(?<metadataname>\S[\s\S]*?)\s*:\s(?<metadataval>[\s\S]+?)$");
                            string mname = metadata.Match(line).Groups["metadataname"].Value;
                            string mval = metadata.Match(line).Groups["metadataval"].Value;

                            AudioMetadata.Add(mname, mval);
                        }
                        catch { }
                    }
                    else if (aftervideometadata && line.StartsWith("      "))
                    {
                        try
                        {
                            Regex metadata = new Regex(@"\s+?(?<metadataname>\S[\s\S]*?)\s*:\s(?<metadataval>[\s\S]+?)$");
                            string mname = metadata.Match(line).Groups["metadataname"].Value;
                            string mval = metadata.Match(line).Groups["metadataval"].Value;

                            VideoMetadata.Add(mname, mval);
                        }
                        catch { }
                    }


                    if (rgvideo.IsMatch(line))
                    {
                        string match = rgvideo.Match(line).Value;

                        string infoline = line.Substring(match.Length);

                        string linenopar=rgpar.Replace(infoline, new MatchEvaluator(ReplaceRegexMatchEvaluator));                                                

                        string[] info = linenopar.Split(new string[] { "," }, StringSplitOptions.None);
                        string[] info2 = infoline.Split(new string[] { "," }, StringSplitOptions.None);

                        Regex firstinfo = new Regex(@"\S+\s(?:\([\s\S]+?\))*");

                        Regex firstval = new Regex(@"\S+\s\S+");

                        try
                        {
                            if (firstinfo.IsMatch(info2[0]))
                            {
                                VideoEncoder = firstinfo.Match(info2[0]).Value;
                            }
                            else
                            {
                                VideoEncoder = info[0];
                            }
                        }
                        catch { }

                        try
                        {
                            VideoPixelFormat = info[1].Trim();
                        }
                        catch { }
                        try
                        {
                            VideoSize = info[2].Trim();
                        }
                        catch { }

                        try
                        {
                            Regex rsz=new Regex(@"(?<width>\S+)x(?<height>\S+)");

                            if (rsz.IsMatch(VideoSize))
                            {
                                VideoWidth = int.Parse(rsz.Match(VideoSize).Groups["width"].Value);
                                VideoHeight = int.Parse(rsz.Match(VideoSize).Groups["height"].Value);
                            }

                            Regex rsar = new Regex(@"[\[|\s]SAR\s(?<sar>\S+)\s");

                            if (rsar.IsMatch(infoline))
                            {
                                VideoSAR = rsar.Match(infoline).Groups["sar"].Value;
                            }

                            Regex rdar = new Regex(@"\sDAR\s(?<dar>\S+?)[\]|,]");

                            if (rdar.IsMatch(infoline))
                            {
                                VideoDAR = rdar.Match(infoline).Groups["dar"].Value;
                            }

                        }
                        catch { }

                        try
                        {
                            VideoBitRate = firstval.Match(info[3].Trim()).Value;
                        }
                        catch { }
                        try
                        {
                            VideoFrameRate = info[4].Trim();
                        }
                        catch { }

                        aftervideoinfo = true;
                        afteraudioinfo = false;

                    }
                    else if (rgaudio.IsMatch(line))
                    {
                        string match = rgaudio.Match(line).Value;

                        string infoline = line.Substring(match.Length);

                        string[] info = infoline.Split(new string[] { "," }, StringSplitOptions.None);

                        Regex firstinfo = new Regex(@"\S+\s(?:\([\s\S]+?\))*");

                        Regex firstval = new Regex(@"\S+\s\S+");

                        try
                        {
                            AudioEncoder = firstinfo.Match(info[0]).Value;
                        }
                        catch { }
                        try
                        {
                            AudioSamplingRate = info[1].Trim();
                        }
                        catch { }
                        try
                        {
                            AudioChannels = info[2].Trim();
                        }
                        catch { }
                        try
                        {
                            AudioSampleFormat = info[3].Trim();
                        }
                        catch { }

                        try
                        {
                            AudioBitRate = firstval.Match(info[4].Trim()).Value;
                        }
                        catch { }

                        aftervideoinfo = false;
                        afteraudioinfo = true;
                    }


                    if (line.Trim().StartsWith("Duration: "))
                    {
                        line=line.Trim();
                        int epos=line.IndexOf(",");
                        DurationStr=line.Substring("Duration: ".Length,epos-"Duration: ".Length);                        

                        DurationMsecs = TimeUpDownControl.StringToMsecs2DecimalPlaces(DurationStr);//TimeStringToMsecs(DurationStr); // -3; //fix bug of ffmpeg
                        DurationStr = TimeUpDownControl.MsecsToString2DecimalPlaces(DurationMsecs);//TimeMsecsToString(DurationMsecs);
                    }
                }
                                
                if (DurationMsecs == 0)
                {
                    Module.ShowMessage(TranslateHelper.Translate("Error could not get Info for Video !")+" : "+filepath);
                    Success = false;

                    return;
                }

                Success = true;
            }
            catch (Exception ex)
            {
                Module.ShowError(TranslateHelper.Translate("Error could not get info for Video !")+" : "+filepath, ex);
                Success = false;

                return;
            }
            finally
            {
                
            }
        }

        string LastFFMpegOutput = "";
        string last_line = "";

        void psFFMpeg_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string line = e.Data;

            //Console.WriteLine(line);

            if (line != null)
            {
                last_line = line;
            }

            LastFFMpegOutput += line + "\r\n";
        }

        void psFFMpeg_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

        }
        public string ReplaceRegexMatchEvaluator(Match m)
        {
            return "";
        }
        public static int TimeStringToMsecs(string str)
        {
            /*
            TimeSpan ts = new TimeSpan(0, int.Parse(str.Substring(0, 2)),
                            int.Parse(str.Substring(3, 2)),
                            int.Parse(str.Substring(6, 2)),
                                int.Parse(str.Substring(9, 2))*10);

            return (int)ts.TotalMilliseconds;            
            */

            if (str.Length == 11)
            {
                TimeSpan ts=new TimeSpan(0, int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)),
                        int.Parse(str.Substring(6, 2)),
                        int.Parse(str.Substring(9, 2)) * 10);

                return (int)(ts.TotalMilliseconds/10);
            }
            else
            {
                TimeSpan ts=new TimeSpan(0, int.Parse(str.Substring(0, 2)),
                        int.Parse(str.Substring(3, 2)),
                        int.Parse(str.Substring(6, 2)),
                        int.Parse(str.Substring(9, 3)));

                return (int)(ts.TotalMilliseconds/10);
            }
        }

        public static string TimeMsecsToString(int msecs)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs);

            string str = ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "." + ts.Milliseconds.ToString("D2");

            return str;
        }

    }
}
