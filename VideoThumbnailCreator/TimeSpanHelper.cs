using System;
using System.Collections.Generic;
using System.Text;

namespace VideoThumbnailCreator
{
    public class TimeSpanHelper
    {
        public static string TimeSpanToFFMpegString(TimeSpan ts)
        {
            return ts.Hours.ToString("D2") + ":" + ts.Minutes.ToString("D2") + ":" + ts.Seconds.ToString("D2") + "." + ts.Milliseconds.ToString("D3");
        }

        public static string MsecsToFFMpegString(int msecs)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, msecs);

            return TimeSpanToFFMpegString(ts);
        }
    }
}
