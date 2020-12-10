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
    public partial class PSTumblingWindowTrigger : PSSinglePipelineTrigger
    {
        public PSTumblingWindowTrigger()
        {
            CustomInit();
        }

        partial void CustomInit();

        [JsonProperty(PropertyName = "typeProperties.frequency")]
        public TumblingWindowFrequency Frequency { get; set; }

        [JsonProperty(PropertyName = "typeProperties.interval")]
        public int Interval { get; set; }

        [JsonProperty(PropertyName = "typeProperties.startTime")]
        public DateTimeOffset StartTime { get; set; }

        [JsonProperty(PropertyName = "typeProperties.endTime")]
        public DateTimeOffset? EndTime { get; set; }

        [JsonProperty(PropertyName = "typeProperties.delay")]
        public object Delay { get; set; }

        [JsonProperty(PropertyName = "typeProperties.maxConcurrency")]
        public int MaxConcurrency { get; set; }

        [JsonProperty(PropertyName = "typeProperties.retryPolicy")]
        public RetryPolicy RetryPolicy { get; set; }

        [JsonProperty(PropertyName = "typeProperties.dependsOn")]
        public IList<DependencyReference> DependsOn { get; set; }
    }
}
