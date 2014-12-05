using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    /// <summary>
    /// Represents resource / vault credentials.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all contracts together.")]
    public class ResourceCredentials
    {
        /// <summary>
        /// Gets or sets the name of the resource name.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the cloud service name.
        /// </summary>
        public string CloudServiceName { get; set; }

        ///<summary>
        ///
        ///</summary>
        public string ResourceNameSpace { get; set; }

        public string ResourceType { get; set; }

        public string StampId { get; set; }

        public string ResourceId { get; set; }

        public string BackendStampId { get; set; }

        public string ResourceState { get; set; }
    }
}
