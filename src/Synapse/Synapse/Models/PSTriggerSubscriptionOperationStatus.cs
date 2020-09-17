using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSTriggerSubscriptionOperationStatus
    {
        public PSTriggerSubscriptionOperationStatus(TriggerSubscriptionOperationStatus status)
        {
            this.TriggerName = status?.TriggerName;
            this.Status = status?.Status;
        }

        public string TriggerName { get; }

        public EventSubscriptionStatus? Status { get; }
    }
}
