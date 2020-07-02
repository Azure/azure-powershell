using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSCreateRunResponse
    {
        public PSCreateRunResponse(CreateRunResponse response)
        {
            this.RunId = response.RunId;
        }

        public string RunId { get; set; }
    }
}
