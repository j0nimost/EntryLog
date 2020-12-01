using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntryLog.Handler
{
    public class LogProcessorHandler : ILogHandler
    {
        public void FolderCheckerorCreater(string foldername)
        {
            string FolderPath = EntryLog.LogPath.LocalPath.ToString() + @"\" + foldername;

            // Check LocalPath
            if (!Directory.Exists(EntryLog.LogPath.LocalPath.ToString()))
            {
                Directory.CreateDirectory(EntryLog.LogPath.LocalPath.ToString());
            }

            // Check Folder Path
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
        }

        public void StreamWritter(string log, string foldername)
        {
            FolderCheckerorCreater(foldername);

            string currentTimeFilename = DateTime.Now.ToString("yyyy-MM-dd HH_mm");

            string path = EntryLog.LogPath.LocalPath.ToString() + "\\" + foldername + "\\" + currentTimeFilename + " - " + $"{foldername}.log";

            var fileStreamer = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            var streamWriter = new StreamWriter(fileStreamer);

            try
            {
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                streamWriter.WriteLine(" " + currentTime);
                streamWriter.WriteLine("***************************************************");
                streamWriter.WriteLine(log);
                streamWriter.WriteLine("---------------------------------------------------------------------------------------------------");

            }
            finally
            {
                streamWriter.Flush();
                streamWriter.Close();
            }

        }
    }
}
