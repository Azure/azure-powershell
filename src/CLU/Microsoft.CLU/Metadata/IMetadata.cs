using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.CLU.Metadata
{
    /// <summary>
    /// The contract that all parameter metadata providers needs to implement.
    /// </summary>
    internal interface IMetadata
    {
        /// <summary>
        /// Get name of all parameter-sets.
        /// </summary>
        /// <returns>All parameter-sets</returns>
        HashSet<string> AllParameterSets { get; }

        /// <summary>
        /// Get parameter-set metadata collection.
        /// </summary>
        /// <returns>All parameter-sets metadata collection</returns>
        ReadOnlyCollection<CommandParameterSetInfo> ParameterSets { get; }

        /// <summary>
        /// Get parameter metadata dictionary. The key is name of the
        /// parameter and value is the parameter metadata.
        /// </summary>
        /// <returns>All parameters metadata collection</returns>
        Dictionary<string, ParameterMetadata> Parameters { get; }
    }
}
