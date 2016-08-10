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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.OperationalInsights
{
    [Cmdlet(VerbsCommon.New, Constants.StorageInsight, SupportsShouldProcess = true, 
        DefaultParameterSetName = ByWorkspaceName), OutputType(typeof(PSStorageInsight))]
    public class NewAzureOperationalInsightsStorageInsightCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, ParameterSetName = ByWorkspaceObject, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The workspace that will contain the storage insight.")]
        [ValidateNotNull]
        public PSWorkspace Workspace { get; set; }

        [Parameter(Position = 1, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = ByWorkspaceName, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the workspace that will contain the storage insight.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage insight name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 4, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The full Azure Resource Manager ID of the storage account.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountResourceId { get; set; }

        [Parameter(Position = 5, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The access key for the storage account.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountKey { get; set; }

        [Parameter(Position = 6, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure Storage tables that the storage insight will read data from.")]
        public string[] Tables { get; set; }

        [Parameter(Position = 7, Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure Storage blob containers that the storage insight will read data from.")]
        public string[] Containers { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Don't ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            CreatePSStorageInsightParameters parameters = new CreatePSStorageInsightParameters()
            {
                Name = Name,
                StorageAccountResourceId = StorageAccountResourceId,
                StorageAccountKey = StorageAccountKey,
                Tables = Tables != null ? Tables.ToList() : null,
                Containers = Containers != null ? Containers.ToList() : null,
                Force = Force.IsPresent,
                ConfirmAction = ConfirmAction
            };

            if (ParameterSetName == ByWorkspaceObject)
            {
                parameters.ResourceGroupName = Workspace.ResourceGroupName;
                parameters.WorkspaceName = Workspace.Name;
            }
            else
            {
                parameters.ResourceGroupName = ResourceGroupName;
                parameters.WorkspaceName = WorkspaceName;
            }

            WriteObject(OperationalInsightsClient.CreatePSStorageInsight(parameters));
        }
    }
}