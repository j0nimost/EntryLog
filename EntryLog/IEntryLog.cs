using System;
using System.Collections.Generic;
using System.Text;

namespace EntryLog
{
    public interface IEntryLog
    {
        void LogAudit(string audit);
        void LogAudit(string audit, string auditFoldername);
        void LogWarning(string warning);
        void LogWarning(string warning, string warningFoldername);
        void LogError(string error);
        void LogError(string error, string errorFoldername);
    }
}
