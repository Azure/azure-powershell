using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    using global::Azure.Analytics.Synapse.Artifacts.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
        using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

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
    }
}
