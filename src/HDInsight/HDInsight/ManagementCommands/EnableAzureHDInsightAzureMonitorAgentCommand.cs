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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Management.HDInsight.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightAzureMonitorAgent", DefaultParameterSetName = EnableByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class EnableAzureHDInsightAzureMonitorAgentCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        private const string EnableByNameParameterSet = "EnableByNameParameterSet";
        private const string EnableByResourceIdParameterSet = "EnableByResourceIdParameterSet";
        private const string EnableByInputObjectParameterSet = "EnableByInputObjectParameterSet";

        [Parameter(Mandatory = false, HelpMessage = "Return the result of the operation.")]
        public SwitchParameter PassThru { get; set; }


        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = EnableByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = EnableByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.HDInsight/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = EnableByResourceIdParameterSet,
            HelpMessage = "Gets or sets the resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = EnableByInputObjectParameterSet,
            HelpMessage = "Gets or sets the input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster InputObject { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = EnableByNameParameterSet,
            HelpMessage = "Gets or sets the ID of the Log Analytics workspace.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = EnableByResourceIdParameterSet,
            HelpMessage = "Gets or sets the ID of the Log Analytics workspace.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = EnableByInputObjectParameterSet,
            HelpMessage = "Gets or sets the ID of the Log Analytics workspace.")]
        public string WorkspaceId { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ParameterSetName = EnableByNameParameterSet,
            HelpMessage = "Gets to sets the primary key of the Log Analytics workspace.")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = EnableByResourceIdParameterSet,
            HelpMessage = "Gets to sets the primary key of the Log Analytics workspace.")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = EnableByInputObjectParameterSet,
            HelpMessage = "Gets to sets the primary key of the Log Analytics workspace.")]
        public string PrimaryKey { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                this.ClusterName = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ClusterName = this.InputObject.Name;
                this.ResourceGroupName = this.InputObject.ResourceGroup;
            }

            if (ClusterName != null && ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            var azureMonitorParams = new AzureMonitorRequest
            {
                WorkspaceId = WorkspaceId,
                PrimaryKey = PrimaryKey
            };

            if (ShouldProcess("Enable Azure Monitor Agent"))
            {
                HDInsightManagementClient.EnableAzureMonitorAgent(ResourceGroupName, ClusterName, azureMonitorParams);
                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
