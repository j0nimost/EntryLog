using System;
using System.Collections.Generic;
using System.Text;

namespace EntryLog
{
    public interface IEntryLog
    {
        /// <summary>
        /// Writes Audit Logs to a specific Audit Folder
        /// </summary>
        /// <param name="audit"></param>
        void LogAudit(string audit);
        /// <summary>
        /// Takes in Audit FolderName and writes Audit Logs to that Folder
        /// </summary>
        /// <param name="audit"></param>
        /// <param name="auditFoldername"></param>
        void LogAudit(string audit, string auditFoldername);
        /// <summary>
        /// Writes Warning Logs to a specific Warning Folder
        /// </summary>
        /// <param name="warning"></param>
        void LogWarning(string warning);
        /// <summary>
        /// Takes in Warning FolderName and writes Warning Logs to that Folder
        /// </summary>
        /// <param name="warning"></param>
        /// <param name="warningFoldername"></param>
        void LogWarning(string warning, string warningFoldername);
        /// <summary>
        /// Writes Error Logs to a specific Error Folder
        /// </summary>
        /// <param name="error"></param>
        void LogError(string error);
        /// <summary>
        /// Takes in Error FolderName and writes Error Logs to that Folder
        /// </summary>
        /// <param name="error"></param>
        /// <param name="errorFoldername"></param>
        void LogError(string error, string errorFoldername);
    }
}
