using System;
using System.Collections.Generic;
using System.Text;

namespace EntryLog.Handler
{
    public interface ILogHandler
    {
        /// <summary>
        /// Checks whether the existing folder path exists and creates it
        /// </summary>
        /// <param name="foldername"></param>
        void FolderCheckerorCreater(string foldername);
        /// <summary>
        /// Writes logs to file
        /// </summary>
        /// <param name="log"></param>
        /// <param name="foldername"></param>
        void StreamWritter(string log, string foldername);
        /// <summary>
        /// Checks log interval and generates file name
        /// </summary>
        /// <returns></returns>
        string FileName();
    }
}
