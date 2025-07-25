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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Clusters
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsLinkedService", SupportsShouldProcess = true), OutputType(typeof(PSLinkedService))]
    public class SetAzureOperationalInsightsLinkedServiceCommand : OperationalInsightsBaseCmdlet
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

        [Parameter(Mandatory = false,
            HelpMessage = "Tags.")]
        [ValidateNotNullOrEmpty]
        public IDictionary<string, string> Tag { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The resource id of the resource that will be linked to the workspace. This should be used for linking resources which require write access.")]
        [ValidateNotNullOrEmpty]
        public string WriteAccessResourceId { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The resource id of the resource that will be linked to the workspace. This should be used for linking resources which require read access")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            PSLinkedService parameters = new PSLinkedService()
            {
                Tags = this.Tag,
                WriteAccessResourceId = this.WriteAccessResourceId,
                ResourceId = this.ResourceId
            };

            if (ShouldProcess(this.LinkedServiceName,
                string.Format("Set linked service: {0} for workspace: {1}", this.LinkedServiceName, this.WorkspaceName)))
            {
                WriteObject(this.OperationalInsightsClient.SetPSLinkedService(this.ResourceGroupName, this.WorkspaceName, this.LinkedServiceName, parameters));
            }
        }
    }
}
