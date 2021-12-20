using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace VideoThumbnailCreator
{
    class VideoInfoHelper
    {
        public static MediaInfo GetInfo(string filepath, string str)
        {
            MediaInfo vi = new MediaInfo();

            string info = "";

            str = str.Replace("==========================================================================", "===\r\n");
            StringReader sr = new StringReader(str);

            string line = null;

            bool wrote_clip_info = false;
            bool in_clip_info_value = false;

            FileInfo fi = new FileInfo(filepath);

            info += TranslateHelper.Translate("File Information") + "\r\n\r\n";
            info += TranslateHelper.Translate("Filename") + " : " + filepath + "\r\n";
            info += TranslateHelper.Translate("Extension") + " : " + System.IO.Path.GetExtension(filepath) + "\r\n";


            decimal dkb = (decimal)fi.Length / (decimal)1024;

            decimal dmb = dkb / (decimal)1024;

            info += TranslateHelper.Translate("File Size (KB)") + " : " + dkb.ToString("#.00") + "\r\n";
            info += TranslateHelper.Translate("File Size (MB)") + " : " + dmb.ToString("#.00") + "\r\n";
            info += TranslateHelper.Translate("Last modified") + " : " + fi.LastWriteTime.ToString() + "\r\n";
            info += TranslateHelper.Translate("Creation Date") + " : " + fi.CreationTime.ToString() + "\r\n";

            info += "\r\n\r\n";

            bool wrote_video_stream_info = false;
            bool wrote_audio_stream_info = false;
            bool opened_audio_decoder = false;

            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains("Opening audio decoder:"))
                {
                    opened_audio_decoder = true;
                }

                if (line.StartsWith("ID_CLIP_INFO") && !wrote_clip_info)
                {
                    info += TranslateHelper.Translate("Clip Info") + "\r\n\r\n";
                    in_clip_info_value = false;
                    wrote_clip_info = true;
                }

                if (line.StartsWith("ID_VIDEO_FORMAT") && !wrote_video_stream_info)
                {
                    info += "\r\n" + TranslateHelper.Translate("Video Stream Info") + "\r\n\r\n";

                    wrote_video_stream_info = true;
                }

                if (line.StartsWith("ID_AUDIO_FORMAT") && !wrote_audio_stream_info)
                {
                    info += "\r\n" + TranslateHelper.Translate("Audio Stream Info") + "\r\n\r\n";

                    wrote_audio_stream_info = true;
                    in_clip_info_value = false;
                }

                if (line.StartsWith("ID_CLIP_INFO_NAME"))
                {
                    int spos = line.IndexOf("=");
                    info += line.Substring(spos + 1) + " : ";
                    in_clip_info_value = false;
                }
                else if (line.StartsWith("ID_CLIP_INFO_N="))
                {
                    in_clip_info_value = false;
                }
                else if (line.StartsWith("ID_CLIP_INFO_VALUE"))
                {
                    int spos = line.IndexOf("=");
                    info += line.Substring(spos + 1) + "\r\n";

                    in_clip_info_value = true;

                    continue;
                }
                else if (line.StartsWith("Load subtitles"))
                {
                    info += line + "\r\n";
                    in_clip_info_value = false;
                }
                else if (line.StartsWith("ID_DEMUXER"))
                {
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Demuxer") + " : " + line.Substring(spos + 1) + "\r\n";
                    in_clip_info_value = false;
                }
                else if (line.StartsWith("VIDEO:"))
                {
                    string[] vinfo = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    string vinfo_fps = "";
                    string vinfo_kbps = "";

                    for (int l = 0; l < vinfo.Length; l++)
                    {
                        if (vinfo[l] == "fps")
                        {
                            vinfo_fps = vinfo[l - 1];
                        }
                        else if (vinfo[l] == "kbps")
                        {
                            vinfo_kbps = vinfo[l - 1];
                        }


                    }

                    info += TranslateHelper.Translate("Video Format") + " : " + vinfo[1] + "\r\n";
                    info += TranslateHelper.Translate("Video Size") + " : " + vinfo[2] + "\r\n";
                    info += TranslateHelper.Translate("Video Color Depth") + " : " + vinfo[3] + "\r\n";
                    info += TranslateHelper.Translate("Video Frames Per Second") + " : " + vinfo_fps + " fps" + "\r\n";
                    info += TranslateHelper.Translate("Video Bitrate") + " : " + vinfo_kbps + " kbps" + "\r\n\r\n";

                    in_clip_info_value = false;
                    try
                    {
                        decimal color_depth = decimal.Parse(vinfo[3].Substring(0, vinfo[3].Length - 3), new System.Globalization.CultureInfo("en-US"));
                        vi.ColorDepth = color_depth;
                    }
                    catch { }
                    vi.FramesPerSecond = decimal.Parse(vinfo_fps, new System.Globalization.CultureInfo("en-US"));
                    vi.Bitrate = decimal.Parse(vinfo_kbps, new System.Globalization.CultureInfo("en-US"));
                    vi.VideoFormat = vinfo[1];

                }
                else if (line.StartsWith("ID_VIDEO_FORMAT"))
                {
                    int spos = line.IndexOf("=");
                    //info += TranslateHelper.Translate("Video Format") + " : " + line.Substring(spos+1)+"\r\n";
                    //vi.VideoFormat = line.Substring(spos + 1);

                    int spos2 = str.IndexOf("ID_VIDEO_CODEC=");
                    int epos2 = str.IndexOf("\n", spos2);
                    info += TranslateHelper.Translate("Video Codec") + " : " + str.Substring(spos2 + "ID_VIDEO_CODEC=".Length, epos2 - spos2 - "ID_VIDEO_CODEC=".Length) + "\r\n\r\n";
                    in_clip_info_value = false;
                }
                else if (line.StartsWith("ID_VIDEO_BITRATE"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    decimal decbitrate = decimal.Parse(line.Substring(spos + 1), new System.Globalization.CultureInfo("en-US"));
                    decimal dbrB = decbitrate / (decimal)1024;
                    decimal dbrk = decbitrate / (decimal)1000;

                    //info += TranslateHelper.Translate("Bitrate (kbps)") + " : " + dbrk.ToString("#.0") + "\r\n";
                    //info += TranslateHelper.Translate("Bitrate (kbytes/sec)") + " : " + dbrB.ToString("#.0#") + "\r\n";

                    //vi.Bitrate = dbrk;

                }
                else if (line.StartsWith("ID_VIDEO_WIDTH"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Width") + " : " + line.Substring(spos + 1) + "\r\n";

                    try
                    {
                        vi.VideoWidth = int.Parse(line.Substring(spos + 1));
                    }
                    catch { }

                }
                else if (line.StartsWith("ID_VIDEO_HEIGHT"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Height") + " : " + line.Substring(spos + 1) + "\r\n";

                    try
                    {
                        vi.VideoHeight = int.Parse(line.Substring(spos + 1));
                    }
                    catch { }
                }
                else if (line.StartsWith("ID_VIDEO_FPS"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    //info += TranslateHelper.Translate("Frames per Seconds (fps)") + " : " + line.Substring(spos+1) + "\r\n";
                    decimal decfps = decimal.Parse(line.Substring(spos + 1), new System.Globalization.CultureInfo("en-US"));
                    //vi.FramesPerSecond = decfps;

                }
                else if (line.StartsWith("ID_VIDEO_ASPECT"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Aspect") + " : " + line.Substring(spos + 1) + ":1\r\n";
                    vi.VideoAspect = line.Substring(spos + 1) + ":1";
                }
                else if (line.StartsWith("ID_AUDIO_FORMAT"))
                {

                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Audio Format") + " : " + line.Substring(spos + 1) + "\r\n";

                    vi.AudioFormat = line.Substring(spos + 1);

                    int spos2 = str.IndexOf("ID_AUDIO_CODEC=");
                    int epos2 = str.IndexOf("\n", spos2);
                    info += TranslateHelper.Translate("Audio Codec") + " : " + str.Substring(spos2 + "ID_AUDIO_CODEC=".Length, epos2 - spos2 - "ID_AUDIO_CODEC=".Length) + "\r\n\r\n";
                }
                else if (opened_audio_decoder && line.StartsWith("ID_AUDIO_BITRATE"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    decimal decbitrate = decimal.Parse(line.Substring(spos + 1), new System.Globalization.CultureInfo("en-US"));
                    decimal deckb = decbitrate / (decimal)1000;
                    info += TranslateHelper.Translate("Audio Bitrate (kbps)") + " : " + deckb.ToString("#.0") + "\r\n";

                    vi.AudioBitrate = deckb;
                }
                else if (opened_audio_decoder && line.StartsWith("ID_AUDIO_RATE"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    string sampling_rate = line.Substring(spos + 1);
                    decimal decrate = decimal.Parse(sampling_rate, new System.Globalization.CultureInfo("en-US"));

                    info += TranslateHelper.Translate("Audio Sampling Rate (Hz)") + " : " + decrate.ToString("#.0") + "\r\n";

                    vi.AudioSamplingRate = decrate;
                }
                else if (opened_audio_decoder && line.StartsWith("ID_AUDIO_NCH"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Number Of Channels") + " : " + line.Substring(spos + 1) + "\r\n";

                    if (line.Substring(spos + 1) == "2")
                    {
                        vi.Channels = "Stereo";
                    }
                    else
                    {
                        vi.Channels = "Mono";
                    }
                }
                else if (line.StartsWith("ID_LENGTH"))
                {
                    in_clip_info_value = false;
                    info += "\r\n" + TranslateHelper.Translate("Other Information") + "\r\n\r\n";
                    int spos = line.IndexOf("=");
                    int isecs = (int)decimal.Parse(line.Substring(spos + 1), new System.Globalization.CultureInfo("en-US"));
                    TimeSpan ts = new TimeSpan(0, 0, isecs);

                    info += TranslateHelper.Translate("Clip Length (time)") + " : " + ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "\r\n";
                }
                else if (line.StartsWith("ID_SEEKABLE"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Seekable") + " : " + (line.Substring(spos + 1) == "1" ? TranslateHelper.Translate("True") : TranslateHelper.Translate("False")) + "\r\n";
                }
                else if (line.StartsWith("ID_CHAPTERS"))
                {
                    in_clip_info_value = false;
                    int spos = line.IndexOf("=");
                    info += TranslateHelper.Translate("Chapters") + " : " + line.Substring(spos + 1) + "\r\n";

                }

                if (in_clip_info_value)
                {
                    info += line + "\r\n";
                }
            }

            vi.Text = info;

            return vi;
        }

        public static string GetVideoTime(string filepath)
        {
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
            
            psFFMpeg.StartInfo.Arguments = " -ao null -vo null -frames 0 -identify \"" + filepath + "\"";

            psFFMpeg.Start();

            psFFMpeg.BeginErrorReadLine();
            psFFMpeg.BeginOutputReadLine();

            psFFMpeg.WaitForExit();

            psFFMpeg.Close();

            psFFMpeg.Dispose();
            psFFMpeg = null;


            string str = LastFFMpegOutput;

            int ipos = str.IndexOf("ID_LENGTH=");

            if (ipos > 0)
            {
                ipos = ipos + "ID_LENGTH=".Length;
                int epos = str.IndexOf("\r", ipos);
                string slen = str.Substring(ipos, epos - ipos);

                return slen;
            }

            return "";
        }

        static string LastFFMpegOutput = "";
        static string last_line = "";

        static void psFFMpeg_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            string line = e.Data;

            //Console.WriteLine(line);

            if (line != null)
            {
                last_line = line;
            }

            LastFFMpegOutput += line + "\r\n";
        }

        static void psFFMpeg_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

        }
    }
}
