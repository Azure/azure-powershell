﻿using Microsoft.Azure.Synapse.Models;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLivyBatchStateInformation : PSLivyStateInformation
    {
        public PSLivyBatchStateInformation(LivyBatchStateInformation stateInfo)
            : base(stateInfo?.NotStartedAt,
                stateInfo?.StartingAt,
                stateInfo?.DeadAt,
                stateInfo?.KilledAt,
                stateInfo?.RecoveringAt,
                stateInfo?.CurrentState,
                stateInfo?.JobCreationRequest)
        {
            this.RunningAt = stateInfo?.RunningAt;
            this.SuccessAt = stateInfo?.SuccessAt;
        }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? RunningAt { get; set; }

        /// <summary>
        /// </summary>
        public System.DateTimeOffset? SuccessAt { get; set; }
    }
}
