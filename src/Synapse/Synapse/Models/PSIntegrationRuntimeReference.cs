using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSIntegrationRuntimeReference
    {
        public PSIntegrationRuntimeReference(IntegrationRuntimeReference integrationRuntimeReference)
        {
            this.Type = integrationRuntimeReference?.Type;
            this.ReferenceName = integrationRuntimeReference?.ReferenceName;
            this.Parameters = integrationRuntimeReference?.Parameters;
        }

        public string Type { get; set; }

        public string ReferenceName { get; set; }

        public IDictionary<string, object> Parameters { get; set; }

        public IntegrationRuntimeReference ToSdkObject()
        {
            IntegrationRuntimeReference integrationRuntimeReference = new IntegrationRuntimeReference(this.ReferenceName)
            {
                Type = this.Type,
                Parameters = this.Parameters
            };
            return integrationRuntimeReference;
        }
    }
}
