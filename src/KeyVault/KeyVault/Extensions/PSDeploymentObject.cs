using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System;
using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;

namespace Microsoft.Azure.Commands.KeyVault.Extensions
{
    public class PSDeploymentObject
    {
        public string DeploymentName { get; set; }

        public string CorrelationId { get; set; }

        public string ProvisioningState { get; set; }

        public DateTime Timestamp { get; set; }

        public DeploymentMode Mode { get; set; }

        public TemplateLink TemplateLink { get; set; }

        public string TemplateLinkString { get; set; }

        public string DeploymentDebugLogLevel { get; set; }

        public Dictionary<string, DeploymentVariable> Parameters { get; set; }

        public IDictionary<string, string> Tags { get; set; }

        public string ParametersString
        {
            get { return ResourcesExtensions.ConstructDeploymentVariableTable(Parameters); }
        }

        public Dictionary<string, DeploymentVariable> Outputs { get; set; }

        public string OutputsString
        {
            get { return ResourcesExtensions.ConstructDeploymentVariableTable(Outputs); }
        }
    }
}