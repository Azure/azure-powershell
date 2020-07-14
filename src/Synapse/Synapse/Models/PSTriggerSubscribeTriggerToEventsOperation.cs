using Azure.Analytics.Synapse.Artifacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSTriggerSubscribeTriggerToEventsOperation
    {
        public PSTriggerSubscribeTriggerToEventsOperation(TriggerSubscribeTriggerToEventsOperation operation)
        {
            this.Id = operation?.Id;
            this.Value = new PSTriggerSubscriptionOperationStatus(operation?.Value);
            this.HasCompleted = operation?.HasCompleted;
            this.HasValue = operation?.HasValue;
        }

        public string Id { get; }

        public PSTriggerSubscriptionOperationStatus Value { get; }

        public bool? HasCompleted { get; }

        public bool? HasValue { get; }
    }
}
