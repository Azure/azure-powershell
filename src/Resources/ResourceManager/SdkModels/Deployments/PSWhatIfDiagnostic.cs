using Microsoft.Azure.Management.Resources.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments
{
    public class PSWhatIfDiagnostic
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public string Severity { get; set; }

        public string Target { get; set; }

        public string Details { get; set; }

        public PSWhatIfDiagnostic(DeploymentDiagnosticsDefinition deploymentDiagnosticsDefinition)
        {
            this.Code = deploymentDiagnosticsDefinition.Code;
            this.Message = deploymentDiagnosticsDefinition.Message;
            this.Target = deploymentDiagnosticsDefinition.Target;
        }
    }
}
