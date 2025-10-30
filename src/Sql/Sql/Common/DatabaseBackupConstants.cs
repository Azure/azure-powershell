using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.Common
{
    internal static class DatabaseBackupConstants
    {
        internal static class TimeBasedImmutabilityValues
        {
            public const string Enabled = "Enabled";
            public const string Disabled = "Disabled";
        }

        internal static class TimeBasedImmutabilityModeValues
        {
            public const string Unlocked = "Unlocked";
            public const string Locked = "Locked";
        }
    }
}
