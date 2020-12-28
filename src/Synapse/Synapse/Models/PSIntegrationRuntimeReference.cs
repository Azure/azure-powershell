using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
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

        public IntegrationRuntimeReferenceType? Type { get; set; }

        public string ReferenceName { get; set; }

        public IDictionary<string, object> Parameters { get; set; }
    }
}
