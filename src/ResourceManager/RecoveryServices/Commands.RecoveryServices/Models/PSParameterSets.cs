using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices
{
   /// <summary>
    /// Parameter Sets used for Azure Site Recovery commands.
    /// </summary>
    internal static class ARSParameterSets
    {
        /// <summary>
        /// For default parameter set
        /// </summary>
        internal const string ByDefault = "ByDefault";

        /// <summary>
        /// When excution has to be done for site
        /// </summary>
        internal const string ForSite = "ForSite";

        internal const string ForBackupVaultType = "ForBackupVaultType";
    }
}
