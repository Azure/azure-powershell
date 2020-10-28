using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSActivityRunsQueryResponse
    {
        public PSActivityRunsQueryResponse(ActivityRunsQueryResponse response)
        {
            this.Value = response?.Value?.Select(element => new PSActivityRun(element)).ToList();
            this.ContinuationToken = response?.ContinuationToken;
        }

        public IReadOnlyList<PSActivityRun> Value { get; set; }

        public string ContinuationToken { get; set; }
    }
}
