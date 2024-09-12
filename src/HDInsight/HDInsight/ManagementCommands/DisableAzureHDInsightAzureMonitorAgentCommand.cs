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

using Microsoft.Azure.Commands.HDInsight.Commands;
using Microsoft.Azure.Commands.HDInsight.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightAzureMonitorAgent", DefaultParameterSetName = DisableByNameParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class DisableAzureHDInsightAzureMonitorAgentCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions

        private const string DisableByNameParameterSet = "DisableByNameParameterSet";
        private const string DisableByResourceIdParameterSet = "DisableByResourceIdParameterSet";
        private const string DisableByInputObjectParameterSet = "DisableByInputObjectParameterSet";

        [Parameter(Mandatory = false, HelpMessage = "Return the result of the operation.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = DisableByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = DisableByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.HDInsight/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DisableByResourceIdParameterSet,
            HelpMessage = "Gets or sets the resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = DisableByInputObjectParameterSet,
            HelpMessage = "Gets or sets the input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster InputObject { get; set; }

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

            if (ShouldProcess("Disable Azure Monitor Agent"))
            {
                HDInsightManagementClient.DisableAzureMonitorAgent(ResourceGroupName, ClusterName);
                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
