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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Linq;

namespace Microsoft.Azure.Commands.OperationalInsights.DataExports
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsDataExport", DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDataExport))]
    public class UpdateAzureOperationalInsightsDataExportCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet,
            HelpMessage = "The name of the workspace that will contain the storage insight.")]
        [ValidateNotNullOrEmpty]
        public string WorkspaceName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet,
            HelpMessage = "The data export name.")]
        [ValidateNotNullOrEmpty]
        public string DataExportName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = UpdateByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSDataExport InputDataExport { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet,
            HelpMessage = "An array of tables to export, for example: [“Heartbeat, SecurityEvent”].")]
        public string[] TableName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet,
            HelpMessage = "The destination resource ID. This can be copied from the Properties entry of the destination resource in Azure.")]
        public string DestinationResourceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet,
            HelpMessage = "Optional. Allows to define an Event Hub name. Not applicable when destination is Storage Account.")]
        public string EventHubName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet,
            HelpMessage = "Active when enabled.")]
        public bool? Enable { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.WorkspaceName = resourceIdentifier.ParentResource.ToLower().Replace("workspaces/", "");
                this.DataExportName = resourceIdentifier.ResourceName;
            }

            CreatePSDataExportParameters parameters; ;

            if (this.IsParameterBound(c => c.InputDataExport))
            {
                var resourceIdentifier = new ResourceIdentifier(this.InputDataExport.Id);
                parameters = new CreatePSDataExportParameters(
                    resourceGroupName: resourceIdentifier.ResourceGroupName,
                    workspaceName: resourceIdentifier.ParentResource.ToLower().Replace("workspaces/", ""),
                    dataExportName: resourceIdentifier.ResourceName,
                    tableNames: InputDataExport.TableNames,
                    destinationResourceId: InputDataExport.ResourceId,
                    eventHubName: InputDataExport.EventHubName,
                    enable: InputDataExport.Enable);
            }
            else
            {
                parameters = new CreatePSDataExportParameters(
                    resourceGroupName: ResourceGroupName,
                    workspaceName: WorkspaceName,
                    dataExportName: DataExportName,
                    tableNames: TableName.ToList(),
                    destinationResourceId: DestinationResourceId,
                    eventHubName: EventHubName,
                    enable: Enable);
            }

            if (ShouldProcess(DataExportName, $"Update Data export: {DataExportName}, in workspace: {WorkspaceName}, resource group: {ResourceGroupName}"))
            {
                WriteObject(this.OperationalInsightsClient.UpdateDataExport(ResourceGroupName, parameters), true);
            }
        }
    }
}
