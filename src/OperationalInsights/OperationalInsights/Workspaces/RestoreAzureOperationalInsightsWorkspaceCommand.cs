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

using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsData.Restore, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsWorkspace", SupportsShouldProcess = true), OutputType(typeof(PSWorkspace))]
    public class RestoreAzureOperationalInsightsWorkspaceCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The geographic region that the workspace will be created in.")]
        [LocationCompleter("Microsoft.OperationalInsights/workspaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!OperationalInsightsClient.DeletedWorkspace(ResourceGroupName, Name))
            {
                throw new PSArgumentException("workspace: " + Name + " under resource group: " + ResourceGroupName + " is not available to restore");
            }

            CreatePSWorkspaceParameters parameters = new CreatePSWorkspaceParameters()
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = Name,
                Location = Location,
                ConfirmAction = ConfirmAction
            };

            WriteObject(OperationalInsightsClient.CreatePSWorkspace(parameters));
        }
    }
}
