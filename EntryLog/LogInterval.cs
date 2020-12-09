using System;
using System.Collections.Generic;
using System.Text;

namespace EntryLog
{
    /// <summary>
    /// Log Interval spaces out the interval between which a new log file is created
    /// </summary>
    public enum LogInterval
    {
        EveryDay =0,
        EveryHour=1,
        EveryMinute=2,
        EverySecond=3
    }
}
