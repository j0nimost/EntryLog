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

        /// <summary>
        /// Writes Audit Logs to a specific Audit Folder
        /// </summary>
        /// <param name="audit"></param>
        public void LogAudit(string audit)
        {
            if (String.IsNullOrEmpty(FolderName_Audit))
            {
                FolderName_Audit = "Audit";
            }

            this.logHandler.StreamWritter(audit, FolderName_Audit);
        }

        /// <summary>
        /// Takes in Audit FolderName and writes Audit Logs to that Folder
        /// </summary>
        /// <param name="audit"></param>
        /// <param name="auditFoldername"></param>
        public void LogAudit(string audit, string auditFoldername)
        {
            if (!String.IsNullOrEmpty(auditFoldername))
            {
                this.logHandler.StreamWritter(audit, auditFoldername);
            }
        }

        /// <summary>
        /// Writes Warning Logs to a specific Warning Folder
        /// </summary>
        /// <param name="warning"></param>
        public void LogWarning(string warning)
        {
            if (String.IsNullOrEmpty(FolderName_Warning))
            {
                FolderName_Warning = "Warning";
            }
            this.logHandler.StreamWritter(warning, FolderName_Warning);
        }

        /// <summary>
        /// Takes in Warning FolderName and writes Warning Logs to that Folder
        /// </summary>
        /// <param name="warning"></param>
        /// <param name="warningFoldername"></param>
        public void LogWarning(string warning, string warningFoldername)
        {
            if (!String.IsNullOrEmpty(warningFoldername))
            {
                this.logHandler.StreamWritter(warning, warningFoldername);
            }
        }

        /// <summary>
        /// Writes Error Logs to a specific Error Folder
        /// </summary>
        /// <param name="error"></param>
        public void LogError(string error)
        {
            if (String.IsNullOrEmpty(FolderName_Error))
            {
                FolderName_Error = "Error";
            }
            this.logHandler.StreamWritter(error, FolderName_Error);
        }

        /// <summary>
        /// Takes in Error FolderName and writes Error Logs to that Folder
        /// </summary>
        /// <param name="error"></param>
        /// <param name="errorFoldername"></param>
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
