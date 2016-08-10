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
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.New, Constants.Workspace, SupportsShouldProcess = true), OutputType(typeof(PSWorkspace))]
    public class NewAzureOperationalInsightsWorkspaceCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The geographic region that the workspace will be created in.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Position = 3, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The service tier of the workspace.")]
        [ValidateSet("free", "standard", "premium", IgnoreCase = true)]
        public string Sku { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ID of an existing Operational Insights account that this workspace will be linked to.")]
        public Guid? CustomerId { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource tags for the workspace.")]
        public Hashtable Tags { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            CreatePSWorkspaceParameters parameters = new CreatePSWorkspaceParameters()
            {
                ResourceGroupName = ResourceGroupName,
                WorkspaceName = Name,
                Location = Location,
                Sku = Sku,
                CustomerId = CustomerId,
                Tags = Tags,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction
            };

            WriteObject(OperationalInsightsClient.CreatePSWorkspace(parameters));
        }
    }
}