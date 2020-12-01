using System;
using System.Collections.Generic;
using System.Text;

namespace EntryLog.Handler
{
    public interface ILogHandler
    {
        void FolderCheckerorCreater(string foldername);
        void StreamWritter(string log, string foldername);
    }
}
