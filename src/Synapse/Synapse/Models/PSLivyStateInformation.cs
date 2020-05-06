using Microsoft.Azure.Synapse.Models;
using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public abstract class PSLivyStateInformation
    {
        public PSLivyStateInformation(
            DateTimeOffset? notStartedAt,
            DateTimeOffset? startingAt,
            DateTimeOffset? deadAt,
            DateTimeOffset? killedAt,
            DateTimeOffset? recoveringAt,
            string currentState,
            LivyRequestBase jobCreationRequest)
        {
            this.NotStartedAt = notStartedAt;
            this.StartingAt = startingAt;
            this.DeadAt = deadAt;
            this.KilledAt = killedAt;
            this.RecoveringAt = recoveringAt;
            this.CurrentState = currentState;
            this.JobCreationRequest = jobCreationRequest != null ? new PSLivyRequestBase(jobCreationRequest) : null;
        }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? NotStartedAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? StartingAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? DeadAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? KilledAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? RecoveringAt { get; set; }

        /// <summary>
        /// </summary>
        public string CurrentState { get; set; }

        /// <summary>
        /// </summary>
        public PSLivyRequestBase JobCreationRequest { get; set; }
    }
}