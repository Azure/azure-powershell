using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSNetAppFilesUsages
    {
        /// <summary>
        /// Gets the id of the usage.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the name of the usage.
        /// </summary>        
        public PSNetAppFilesUsageName Name { get; set; }

        /// <summary>
        /// Gets the current usage value for the subscription.
        /// </summary>        
        public int? CurrentValue { get; set; }

        /// <summary>
        /// Gets the limit of the usage.
        /// </summary>        
        public int? Limit { get; set; }

        /// <summary>
        /// Gets the unit of the usage.
        /// </summary>        
        public string Unit { get; set; }
    }
}
