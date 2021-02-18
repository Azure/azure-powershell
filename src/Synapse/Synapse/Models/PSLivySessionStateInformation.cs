using Azure.Analytics.Synapse.Spark.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLivySessionStateInformation : PSLivyStateInformation
    {
        public PSLivySessionStateInformation(SparkSessionState stateInfo)
            : base(stateInfo?.NotStartedAt,
                stateInfo?.StartingAt,
                stateInfo?.DeadAt,
                stateInfo?.TerminatedAt,
                stateInfo?.RecoveringAt,
                stateInfo?.CurrentState,
                stateInfo?.JobCreationRequest)
        {
            this.IdleAt = stateInfo?.IdleAt;
            this.ShuttingDownAt = stateInfo?.ShuttingDownAt;
            this.BusyAt = stateInfo?.BusyAt;
            this.ErrorAt = stateInfo?.ErrorAt;
        }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? IdleAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? ShuttingDownAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? BusyAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? ErrorAt { get; set; }
    }
}