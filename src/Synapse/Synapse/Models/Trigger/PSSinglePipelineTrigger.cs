using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    using global::Azure.Analytics.Synapse.Artifacts.Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class PSSinglePipelineTrigger : PSTrigger
    {
        public PSSinglePipelineTrigger()
        {
            CustomInit();
        }

        partial void CustomInit();

        [JsonProperty(PropertyName = "pipeline")]
        public TriggerPipelineReference Pipeline { get; set; }
    }
}
