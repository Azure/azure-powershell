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

namespace Microsoft.Azure.Commands.OperationalInsights.WorkspacePurge
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsPurgeWorkspaceStatus"), OutputType(typeof(PSWorkspacePurgeStatusResponse))]
    public class GetAzureOperationalInsightsWorkspacePurgeStatusCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the workspace that contains the table.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "In a purge status request, this is the Id of the operation the status of which is returned.")]
        [ValidateNotNullOrEmpty]
        public string PurgeId { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(OperationalInsightsClient.GetPurgeWorkspaceStatus(ResourceGroupName, WorkspaceName, PurgeId));
        }
    }
}
