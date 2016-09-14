using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.WebApps.Cmdlets
{
    /// <summary>
    /// A simple class containing data associated with an app snapshot
    /// </summary>
    public class AzureWebAppSnapshot
    {
        /// <summary>
        /// The resource group of the web app
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The name of the web app
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the web app slot
        /// </summary>
        public string Slot { get; set; }

        /// <summary>
        /// The time a snapshot of the web app content was made
        /// </summary>
        public DateTime SnapshotTime { get; set; }
    }
}
