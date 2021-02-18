using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class SynapseSqlPoolCreateMode
    {
        public const string Default = "Default";
        public const string Recovery = "Recovery";
        public const string Restore = "Restore";
        public const string PointInTimeRestore = "PointInTimeRestore";
    }
}
