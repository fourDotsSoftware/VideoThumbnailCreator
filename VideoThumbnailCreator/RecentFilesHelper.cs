using System;
using System.Collections.Generic;
using System.Text;

namespace VideoThumbnailCreator
{
    class RecentFilesHelper
    {        
        public static void FillJoinRecentFile()
        {
            frmMain.Instance.tsbAdd.DropDownItems.Clear();

            string[] str = Properties.Settings.Default.AddJoinVideoRecent.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < str.Length; k++)
            {
                frmMain.Instance.tsbAdd.DropDownItems.Add(str[k]);
            }
        }

        public static void AddRecentFileJoin(string filepath)
        {
            string[] str = Properties.Settings.Default.AddJoinVideoRecent.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> strl = ArrayToListString(str);

            if (strl.IndexOf(filepath) >= 0)
            {
                strl.RemoveAt(strl.IndexOf(filepath));
            }

            strl.Insert(0, filepath);

            frmMain.Instance.tsbAdd.DropDownItems.Clear();

            string newrec = "";

            for (int k = 0; k < strl.Count && k <= 12; k++)
            {
                frmMain.Instance.tsbAdd.DropDownItems.Add(strl[k]);
                newrec += strl[k] + "|||";
            }

            Properties.Settings.Default.AddJoinVideoRecent = newrec;
        }

        public static void FillJoinRecentFolders()
        {
            frmMain.Instance.tsbAddFolder.DropDownItems.Clear();

            string[] str = Properties.Settings.Default.AddJoinVideoFolderRecent.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < str.Length; k++)
            {
                frmMain.Instance.tsbAddFolder.DropDownItems.Add(str[k]);
            }
        }

        public static void AddRecentFolderJoin(string filepath)
        {
            string[] str = Properties.Settings.Default.AddJoinVideoFolderRecent.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> strl = ArrayToListString(str);

            if (strl.IndexOf(filepath) >= 0)
            {
                strl.RemoveAt(strl.IndexOf(filepath));
            }

            strl.Insert(0, filepath);

            frmMain.Instance.tsbAddFolder.DropDownItems.Clear();

            string newrec = "";

            for (int k = 0; k < strl.Count && k <= 12; k++)
            {
                frmMain.Instance.tsbAddFolder.DropDownItems.Add(strl[k]);
                newrec += strl[k] + "|||";
            }

            Properties.Settings.Default.AddJoinVideoFolderRecent = newrec;
        }

        public static List<string> ArrayToListString(string[] str)
        {
            List<string> strl = new List<string>();

            for (int k = 0; k < str.Length; k++)
            {
                strl.Add(str[k]);
            }

            return strl;
        }

        //===============================================================
        /*
        public static void FillBatchJoinRecentFile()
        {
            frmBatchJoin.Instance.tsbAdd.DropDownItems.Clear();

            string[] str = Properties.Settings.Default.RecentBatchFiles.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < str.Length; k++)
            {
                frmBatchJoin.Instance.tsbAdd.DropDownItems.Add(str[k]);
            }
        }

        public static void AddRecentFileBatchJoin(string filepath)
        {
            string[] str = Properties.Settings.Default.RecentBatchFiles.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> strl = ArrayToListString(str);

            if (strl.IndexOf(filepath) >= 0)
            {
                strl.RemoveAt(strl.IndexOf(filepath));
            }

            strl.Insert(0, filepath);

            frmBatchJoin.Instance.tsbAdd.DropDownItems.Clear();

            string newrec = "";

            for (int k = 0; k < strl.Count && k <= 12; k++)
            {
                frmBatchJoin.Instance.tsbAdd.DropDownItems.Add(strl[k]);
                newrec += strl[k] + "|||";
            }

            Properties.Settings.Default.RecentBatchFiles = newrec;
        }

        public static void FillBatchJoinRecentFolders()
        {
            frmBatchJoin.Instance.tsbAddFolder.DropDownItems.Clear();

            string[] str = Properties.Settings.Default.RecentBatchFolders.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            for (int k = 0; k < str.Length; k++)
            {
                frmBatchJoin.Instance.tsbAddFolder.DropDownItems.Add(str[k]);
            }
        }

        public static void AddRecentFolderBatchJoin(string filepath)
        {
            string[] str = Properties.Settings.Default.RecentBatchFolders.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);

            List<string> strl = ArrayToListString(str);

            if (strl.IndexOf(filepath) >= 0)
            {
                strl.RemoveAt(strl.IndexOf(filepath));
            }

            strl.Insert(0, filepath);

            frmBatchJoin.Instance.tsbAddFolder.DropDownItems.Clear();

            string newrec = "";

            for (int k = 0; k < strl.Count && k <= 12; k++)
            {
                frmBatchJoin.Instance.tsbAddFolder.DropDownItems.Add(strl[k]);
                newrec += strl[k] + "|||";
            }

            Properties.Settings.Default.RecentBatchFolders = newrec;
        }*/
    }
}
