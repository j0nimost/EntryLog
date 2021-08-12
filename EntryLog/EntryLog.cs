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
        internal static LogInterval Log_Interval;
        public static string FolderName_Audit;
        public static string FolderName_Warning;
        public static string FolderName_Error;
        private readonly ILogHandler logHandler;

        public EntryLog(ILogHandler logHandler,LogInterval? logInterval= null, Uri logfolderPath = null)
        {
            this.logHandler = logHandler;
            Log_Interval = logInterval.HasValue ? logInterval.Value : LogInterval.EveryMinute;

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
        /// Initializes an EntryLog Instance with default values for
        ///  - Log Interval
        /// - Uri path to a folder
        /// </summary>
        /// <param name="logInterval"></param>
        public static IServiceCollection AddEntryLog(this IServiceCollection services)
        {
            services.AddSingleton<ILogHandler, LogProcessorHandler>();
            services.AddSingleton<IEntryLog, EntryLog>(v => new EntryLog(v.GetRequiredService<ILogHandler>()));
            return services;
        }
        /// <summary>
        /// Takes one parameter log interval.
        /// Writes logs to the default execution path.
        /// </summary>
        /// <param name="logInterval"></param>
        public static IServiceCollection AddEntryLog(this IServiceCollection services, LogInterval logInterval)
        {
            services.AddSingleton<ILogHandler, LogProcessorHandler>();
            services.AddSingleton<IEntryLog, EntryLog>(v => new EntryLog(v.GetRequiredService<ILogHandler>(), logInterval));
            return services;
        }

        /// <summary>
        /// It takes two parameters:
        /// - Log Interval
        /// - Uri path to a folder
        /// Writes logs to the default execution path, with a default interval.
        /// </summary>
        /// <param name="logfolderPath"></param>
        public static IServiceCollection AddEntryLog(this IServiceCollection services, LogInterval logInterval, Uri logfolderPath)
        {
            services.AddSingleton<ILogHandler, LogProcessorHandler>();
            services.AddSingleton<IEntryLog, EntryLog>(v => new EntryLog(v.GetRequiredService<ILogHandler>(), logInterval, logfolderPath));

            return services;
        }
    }
}
