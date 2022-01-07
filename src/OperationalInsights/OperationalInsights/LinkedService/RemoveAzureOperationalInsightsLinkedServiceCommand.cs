// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights.Clusters
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsLinkedService", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureOperationalInsightsLinkedServiceCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "The Workspace name.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Position = 2, Mandatory = true,
            HelpMessage = "The Workspace name.")]
        [ValidateNotNullOrEmpty]
        public string LinkedServiceName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.LinkedServiceName,
                string.Format("delete linked service: {0} in for workspace: {1}", this.LinkedServiceName, this.WorkspaceName)))
            {
                HttpStatusCode response = this.OperationalInsightsClient.DeletePSLinkedService(this.ResourceGroupName, this.WorkspaceName, this.LinkedServiceName);
                WriteObject(true);
            }
        }
    }
}