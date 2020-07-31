using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    using global::Azure.Analytics.Synapse.Artifacts.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [Newtonsoft.Json.JsonObject("ScheduleTrigger")]
    [Rest.Serialization.JsonTransformation]
    public partial class PSScheduleTrigger : PSMultiplePipelineTrigger
    {
        public PSScheduleTrigger()
        {
            CustomInit();
        }

        partial void CustomInit();

        [JsonProperty(PropertyName = "typeProperties.recurrence")]
        public PSScheduleTriggerRecurrence Recurrence { get; set; }

        public override Trigger ToSdkObject()
        {
            var trigger = new ScheduleTrigger(this.Recurrence?.ToSdkObject());
            trigger.Description = this.Description;
            this.Pipelines?.ForEach(item => trigger.Pipelines.Add(item));
            this.Annotations?.ForEach(item => trigger.Annotations.Add(item));
            return trigger;
        }
    }
}
