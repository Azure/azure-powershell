using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSDynamicExecutorAllocation
    {
        public PSDynamicExecutorAllocation(DynamicExecutorAllocation dynamicExecutorAllocation)
        {
            this.Enabled = dynamicExecutorAllocation?.Enabled ?? false;
        }

        /// <summary>
        /// Gets or sets indicates whether Dynamic Executor Allocation is
        /// enabled or not.
        /// </summary>
        public bool Enabled { get; set; }
    }
}
