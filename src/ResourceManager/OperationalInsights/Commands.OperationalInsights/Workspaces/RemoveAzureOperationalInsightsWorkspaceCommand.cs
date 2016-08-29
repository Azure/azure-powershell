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

using Microsoft.Azure.Commands.OperationalInsights.Properties;
using System.Globalization;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.Remove, Constants.Workspace, SupportsShouldProcess = true)]
    public class RemoveAzureOperationalInsightsWorkspaceCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The workspace name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.WorkspaceDeleteConfirmationMessage,
                    Name,
                    ResourceGroupName),
                string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.WorkspaceRemoving,
                    Name,
                    ResourceGroupName),
                Name,
                ExecuteDelete);
        }

        public void ExecuteDelete()
        {
            HttpStatusCode response = OperationalInsightsClient.DeleteWorkspace(ResourceGroupName, Name);

            if (response == HttpStatusCode.NoContent)
            {
                WriteWarning(string.Format(CultureInfo.InvariantCulture, Resources.WorkspaceNotFound, Name, ResourceGroupName));
            }
        }
    }
}