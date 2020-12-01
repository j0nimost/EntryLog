using EntryLog.Handler;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntryLog
{
    public class EntryLog: IEntryLog
    {
        internal static Uri LogPath;
        public static string FolderName_Audit;
        public static string FolderName_Warning;
        public static string FolderName_Error;
        private readonly ILogHandler logHandler;

        public EntryLog(ILogHandler logHandler, Uri logfolderPath = null)
        {
            this.logHandler = logHandler;

            if (logfolderPath == null)
            {
                LogPath = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            }
            else
            {

                LogPath = logfolderPath;
            }
        }

        public void LogAudit(string audit)
        {
            if (String.IsNullOrEmpty(FolderName_Audit))
            {
                FolderName_Audit = "Audit";
            }

            this.logHandler.StreamWritter(audit, FolderName_Audit);
        }

        public void LogAudit(string audit, string auditFoldername)
        {
            if (!String.IsNullOrEmpty(auditFoldername))
            {
                this.logHandler.StreamWritter(audit, auditFoldername);
            }
        }

        public void LogWarning(string warning)
        {
            if (String.IsNullOrEmpty(FolderName_Warning))
            {
                FolderName_Warning = "Warning";
            }
            this.logHandler.StreamWritter(warning, FolderName_Warning);
        }

        public void LogWarning(string warning, string warningFoldername)
        {
            if (!String.IsNullOrEmpty(warningFoldername))
            {
                this.logHandler.StreamWritter(warning, warningFoldername);
            }
        }

        public void LogError(string error)
        {
            if (String.IsNullOrEmpty(FolderName_Error))
            {
                FolderName_Error = "Error";
            }
            this.logHandler.StreamWritter(error, FolderName_Error);
        }

        public void LogError(string error, string errorFoldername)
        {
            if (!String.IsNullOrEmpty(errorFoldername))
            {
                this.logHandler.StreamWritter(error, errorFoldername);
            }
        }
    }

    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// It takes one optional parameter the Uri path to a folder.
        /// If not provided it will write logs to the default execution path.
        /// </summary>
        /// <param name="logfolderPath"></param>
        public static void AddEntryLog(this IServiceCollection services, Uri logfolderPath = null)
        {
            services.AddSingleton<ILogHandler, LogProcessorHandler>();
            services.AddSingleton<IEntryLog, EntryLog>(v => new EntryLog(v.GetRequiredService<ILogHandler>(), logfolderPath));
        }
    }
}
