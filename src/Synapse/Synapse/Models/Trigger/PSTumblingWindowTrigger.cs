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

        public TumblingWindowFrequency Frequency { get; set; }

        public int Interval { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public object Delay { get; set; }

        public int MaxConcurrency { get; set; }

        public RetryPolicy RetryPolicy { get; set; }

        public IList<DependencyReference> DependsOn { get; set; }
    }
}
