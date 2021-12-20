using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace VideoThumbnailCreator
{
    public class JoinArgsHelper
    {        
        public JoinArgsHelper()
        {

        }        

        public string GetJoinFilePrefix(string filepath, string ext, string prefix)
        {
            string fn = "";
            string joinfile = "";
            string outfolder = System.IO.Path.GetDirectoryName(filepath);

            if (Properties.Settings.Default.OutputFolderIndex != 0)
            {
                outfolder = Properties.Settings.Default.OutputFolder;
            }

            fn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

            string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

            if (System.IO.File.Exists(jfp))
            {
                int k = 1;
                bool found = false;

                while (!found)
                {
                    jfp = System.IO.Path.Combine(outfolder,
                        prefix.Replace("[N]", k.ToString()) + joinfile + ext);

                    if (!System.IO.File.Exists(jfp))
                    {
                        return jfp;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            else
            {
                return jfp;
            }

            return "-1";
        }
        public string GetJoinFileSuffix(string filepath, string ext,string suffix)
        {
            string fn = "";
            string joinfile = "";
            string outfolder = System.IO.Path.GetDirectoryName(filepath);

            if (Properties.Settings.Default.OutputFolderIndex != 0)
            {
                outfolder = Properties.Settings.Default.OutputFolder;
            }

            fn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

            string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

            if (System.IO.File.Exists(jfp))
            {
                int k = 1;
                bool found = false;

                while (!found)
                {
                    jfp = System.IO.Path.Combine(outfolder,
                        joinfile + suffix.Replace("[N]", k.ToString()) + ext);

                    if (!System.IO.File.Exists(jfp))
                    {
                        return jfp;
                    }
                    else
                    {
                        k++;
                    }
                }
            }
            else
            {
                return jfp;
            }

            return "-1";
        }

        public string GetJoinFileSkip(string filepath, string ext)
        {
            string fn = "";
            string joinfile = "";
            string outfolder = System.IO.Path.GetDirectoryName(filepath);

            if (Properties.Settings.Default.OutputFolderIndex != 0)
            {
                outfolder = Properties.Settings.Default.OutputFolder;
            }

            fn = System.IO.Path.GetFileNameWithoutExtension(filepath);

            joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

            string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

            if (!System.IO.File.Exists(jfp))
            {
                return jfp;
            }
            else
            {
                return "-1";
            }

        }
        public string GetJoinFile(string filepath,string ext)
        {
            if (frmMain.Instance.ExplicitOutputFilepath != string.Empty)
            {
                return frmMain.Instance.ExplicitOutputFilepath;
            }
            else
            {
                string fn = "";
                string joinfile = "";
                string outfolder=System.IO.Path.GetDirectoryName(filepath);

                if (Properties.Settings.Default.OutputFolderIndex!=0)
                {
                    outfolder=Properties.Settings.Default.OutputFolder;
                }
                
                fn = System.IO.Path.GetFileNameWithoutExtension(filepath);                

                joinfile = Properties.Settings.Default.OutputFilenamePattern.Replace("[FILENAME]", fn);

                if (Properties.Settings.Default.OutputWhenExists == 0)
                {
                    return System.IO.Path.Combine(outfolder, joinfile + ext);
                }
                else if (Properties.Settings.Default.OutputWhenExists == 1)
                {
                    return GetJoinFileSkip(filepath, ext);       
                }
                else if (Properties.Settings.Default.OutputWhenExists == 2)
                {
                    string jfp = System.IO.Path.Combine(outfolder, joinfile + ext);

                    if (!System.IO.File.Exists(jfp))
                    {
                        return jfp;
                    }
                    else
                    {
                        if (!frmMain.Instance.OutputFileActionRepeat)
                        {
                            frmOutputFileAsk f = new frmOutputFileAsk(filepath , outfolder,jfp);

                            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                return frmOutputFileAsk.CalculateOutputFileRepeatAction(filepath,
                                    jfp, outfolder);
                            }
                            else
                            {
                                return "-1";
                            }
                        }
                        else
                        {
                            return frmOutputFileAsk.CalculateOutputFileRepeatAction(filepath,jfp, outfolder);
                        }
                    }
                }
                else if (Properties.Settings.Default.OutputWhenExists == 3)
                {
                    return GetJoinFileSuffix(filepath, ext, Properties.Settings.Default.OutputSuffix);
                }
                else if (Properties.Settings.Default.OutputWhenExists == 4)
                {
                    return GetJoinFilePrefix(filepath, ext, Properties.Settings.Default.OutputPrefix);
                }
            }

            return "-1";
        }

        public JoinArgs GetJoinArgs(string filepath, string thumbfilepath)
        {
            if (System.IO.File.Exists(thumbfilepath))
            {
                string joinfile = GetJoinFile(filepath, System.IO.Path.GetExtension(filepath));
                string args = "-i \"" + filepath + "\" -i \"" + thumbfilepath + "\" -map 0 -map 1 -c copy -c:v:1 png -disposition:v:1 attached_pic -strict -2 -y \"" + joinfile + "\"";

                JoinArgs ja = new JoinArgs();
                ja.Args = args;
                ja.JoinFile = joinfile;

                return ja;
            }

            return null;
        }
    }

    public class JoinArgs
    {                
        public string Args = "";                

        public string JoinFile = "";


    }

    
}


