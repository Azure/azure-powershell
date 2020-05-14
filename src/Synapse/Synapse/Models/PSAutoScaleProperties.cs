using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSAutoScaleProperties
    {
        public PSAutoScaleProperties(AutoScaleProperties autoScale)
        {
            this.MinNodeCount = autoScale?.MinNodeCount;
            this.Enabled = autoScale?.Enabled;
            this.MaxNodeCount = autoScale?.MaxNodeCount;
        }

        /// <summary>
        /// Gets the minimum number of nodes the Big Data pool can
        /// support.
        /// </summary>
        public int? MinNodeCount { get; set; }

        /// <summary>
        /// Gets whether automatic scaling is enabled for the Big Data
        /// pool.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Gets the maximum number of nodes the Big Data pool can
        /// support.
        /// </summary>
        public int? MaxNodeCount { get; set; }
    }
}