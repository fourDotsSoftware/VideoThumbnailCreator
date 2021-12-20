using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace VideoThumbnailCreator
{
    class FFMpegArgsHelper
    {        
        public static string GetStringFromTime(int msecs)
        {
            return TimeSpanHelper.MsecsToFFMpegString(msecs);
            //7
            /*
            int d1sec = msecs;
            int d1isec = d1sec / 10;
            int d1imsec = d1sec % 10;                       

            TimeSpan tsS = new TimeSpan(0, 0, d1isec);
            
            return tsS.Hours.ToString("D2") + ":" + tsS.Minutes.ToString("D2") + ":" + tsS.Seconds.ToString("D2") + "." + d1imsec.ToString();
            */
        }

        public static int GetTimeFromSecsString(string str)
        {
            //7
            /*
            int spos = str.IndexOf(".");

            //1string smsecs = str.Substring(spos + 1);
            string smsecs = str.Substring(spos + 1,1);
            int imsecs = int.Parse(smsecs);

            string ssecs = str.Substring(0, spos);
            int isecs = int.Parse(ssecs);
                        
            return isecs * 10 + imsecs;
            */

            return TimeUpDownControl.StringToMsecs(str);
        }

        public static int GetTimeFromString(string str)
        {
            //7
            /*
            int hours = 0;
            int minutes = 0;
            int secs = 0;
            int msecs = 0;

            try
            {
                hours = int.Parse(str.Substring(0, 2).Replace("_", ""));
            }
            catch { }

            try
            {
                minutes = int.Parse(str.Substring(3, 2).Replace("_", ""));
            }
            catch { }

            try
            {
                secs = int.Parse(str.Substring(6, 2).Replace("_", ""));
            }
            catch { }

            try
            {
                msecs = int.Parse(str.Substring(9, 1).Replace("_", ""));
            }
            catch { }

            TimeSpan ts = new TimeSpan(hours, minutes, secs);

            return (int)ts.TotalSeconds * 10 + msecs;
             
             */

            return TimeUpDownControl.StringToMsecs(str);
        }

        public static string GetDecimalTimeToString(decimal dec)
        {
            return Convert.ToString(dec, System.Globalization.CultureInfo.InvariantCulture).Replace(",",".");            
        }

        public static string GetSecsTimeFromMsecs(int tm)
        {
            //7
            /*
            int tsecs = tm / 10;
            int tmsecs = tm % 10;

            return tsecs.ToString() + "." + tmsecs.ToString() + "0";
            */

            int tsecs = tm / 1000;
            int tmsecs = tm % 1000;

            return tsecs.ToString() + "." + tmsecs.ToString("D2");
        }

        public static int GetMsecsFromSecsTime(string time)
        {
            int dotpos = time.IndexOf(".");

            int tsecs = 0;
            int tmsecs = 0;

            if (dotpos > 0)
            {
                tsecs = int.Parse(time.Substring(0, dotpos));

                string ms=time.Substring(dotpos + 1);

                if (ms.Length>3)
                {
                    ms=ms.Substring(0,3);
                }

                if (ms.Length==1)
                {
                    tmsecs=int.Parse(ms)*100;
                }
                else if (ms.Length==2)
                {
                    tmsecs=int.Parse(ms)*10;
                }
                else if (ms.Length==3)
                {
                    tmsecs=int.Parse(ms);
                }
            }
            else
            {
                tsecs = int.Parse(time);
            }

            return (tsecs * 1000 + tmsecs);
        }


        public static decimal GetTimeFromStringDecimal(string str)
        {
            return Convert.ToDecimal(str, System.Globalization.CultureInfo.InvariantCulture);
            /*
            int spos = str.IndexOf(".");

            if (spos < 0)
            {
                spos = str.IndexOf(",");
            }

            decimal dec = int.Parse(str.Substring(0, spos));

            int decpartlen = int.Parse(str.Substring(spos + 1));
            decimal decpart = 1;

            if (decpartlen == 0)
            {
                decpart = 0;
            }
            else
            {                
                for (int k = 0; k < decpartlen; k++)
                {
                    decpart = decimal.Multiply(decpart, (decimal)0.1);
                }
            }

            return dec + decpart;
            */
        }
    }
}
