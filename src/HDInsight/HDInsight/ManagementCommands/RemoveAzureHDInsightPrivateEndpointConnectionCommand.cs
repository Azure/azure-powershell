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
using Microsoft.Azure.Commands.HDInsight.Models.Management;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightPrivateEndpointConnection", DefaultParameterSetName = RemoveByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(AzureHDInsightPrivateEndpointConnection))]
    public class RemoveAzureHDInsightPrivateEndpointConnectionCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions
        private const string RemoveByNameParameterSet = "RemoveByNameParameterSet";
        private const string RemoveByClusterResourceIdParameterSet = "RemoveByClusterResourceIdParameterSet";
        private const string RemoveByClusterInputObjectParameterSet = "RemoveByClusterInputObjectParameterSet";
        private const string RemoveByPrivateEndpointConnectionResourceIdParameterSet = "RemoveByPrivateEndpointConnectionResourceIdParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = RemoveByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = RemoveByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.HDInsight/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = RemoveByClusterResourceIdParameterSet,
            HelpMessage = "Gets or sets the cluster resource id.")]
        [ValidateNotNullOrEmpty]
        public string ClusterResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = RemoveByClusterInputObjectParameterSet,
            HelpMessage = "Gets or sets the cluster input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster ClusterInputObject { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = RemoveByNameParameterSet,
            HelpMessage = "Gets or sets the name of the private endpoint connection.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = RemoveByClusterResourceIdParameterSet,
            HelpMessage = "Gets or sets the name of the private endpoint connection.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = RemoveByClusterInputObjectParameterSet,
            HelpMessage = "Gets or sets the name of the private endpoint connection.")]
        public string PrivateEndpointConnectionName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = RemoveByPrivateEndpointConnectionResourceIdParameterSet,
            HelpMessage = "Gets or sets the private endpoint connection resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ClusterResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(ClusterResourceId);
                this.ClusterName = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (this.IsParameterBound(c => c.ClusterInputObject))
            {
                this.ClusterName = this.ClusterInputObject.Name;
                this.ResourceGroupName = this.ClusterInputObject.ResourceGroup;
            }

            if (ClusterName != null && ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                this.PrivateEndpointConnectionName = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ClusterName = resourceIdentifier.ParentResource.Split('/').Last();
            }

            if (ShouldProcess(PrivateEndpointConnectionName))
            {
                HDInsightManagementClient.DeletePrivateEndpointConnection(ResourceGroupName, ClusterName, PrivateEndpointConnectionName);

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
