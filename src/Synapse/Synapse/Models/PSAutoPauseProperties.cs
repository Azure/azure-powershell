using Microsoft.Azure.Management.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSAutoPauseProperties
    {
        public PSAutoPauseProperties(AutoPauseProperties autoPause)
        {
            this.DelayInMinutes = autoPause?.DelayInMinutes;
            this.Enabled = autoPause?.Enabled;
        }

        /// <summary>
        /// Gets number of minutes of idle time before the Big Data
        /// pool is automatically paused.
        /// </summary>
        public int? DelayInMinutes { get; set; }

        /// <summary>
        /// Gets whether auto-pausing is enabled for the Big Data pool.
        /// </summary>
        public bool? Enabled { get; set; }
    }
}