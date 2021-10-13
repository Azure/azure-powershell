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
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightPrivateEndpointConnection", DefaultParameterSetName = SetByNameParameterSet), OutputType(typeof(AzureHDInsightPrivateEndpointConnection))]
    public class SetAzureHDInsightPrivateEndpointConnectionCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByClusterResourceIdParameterSet = "SetByClusterResourceIdParameterSet";
        private const string SetByClusterInputObjectParameterSet = "SetByClusterInputObjectParameterSet";
        private const string SetByPrivateEndpointConnectionResourceIdParameterSet = "SetByPrivateEndpointConnectionResourceIdParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.HDInsight/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SetByClusterResourceIdParameterSet,
            HelpMessage = "Gets or sets the cluster resource id.")]
        [ValidateNotNullOrEmpty]
        public string ClusterResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = SetByClusterInputObjectParameterSet,
            HelpMessage = "Gets or sets the cluster input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster ClusterInputObject { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the private endpoint connection.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = SetByClusterResourceIdParameterSet,
            HelpMessage = "Gets or sets the name of the private endpoint connection.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = SetByClusterInputObjectParameterSet,
            HelpMessage = "Gets or sets the name of the private endpoint connection.")]
        public string PrivateEndpointConnectionName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SetByPrivateEndpointConnectionResourceIdParameterSet,
            HelpMessage = "Gets or sets the private endpoint connection resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the connection status of the private endpoint connection.")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = SetByClusterResourceIdParameterSet,
            HelpMessage = "Gets or sets the connection status of the private endpoint connection.")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = SetByClusterInputObjectParameterSet,
            HelpMessage = "Gets or sets the connection status of the private endpoint connection.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = SetByPrivateEndpointConnectionResourceIdParameterSet,
            HelpMessage = "Gets or sets the connection status of the private endpoint connection.")]
        [ValidateSet("Approved", "Rejected")]
        public string PrivateLinkServiceConnectionState { get; set; }

        [Parameter(
            Position = 4,
            Mandatory = false,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the description when setting the connection status of the private endpoint connection.")]
        [Parameter(
            Position = 3,
            Mandatory = false,
            ParameterSetName = SetByClusterResourceIdParameterSet,
            HelpMessage = "Gets or sets the description when setting the connection status of the private endpoint connection.")]
        [Parameter(
            Position = 3,
            Mandatory = false,
            ParameterSetName = SetByClusterInputObjectParameterSet,
            HelpMessage = "Gets or sets the description when setting the connection status of the private endpoint connection.")]
        [Parameter(
            Position = 2,
            Mandatory = false,
            ParameterSetName = SetByPrivateEndpointConnectionResourceIdParameterSet,
            HelpMessage = "Gets or sets the description when setting the connection status of the private endpoint connection.")]

        public string Description { get; set; }

        [Parameter(
            Position = 5,
            Mandatory = false,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the actions required when setting the connection status of the private endpoint connection.")]
        [Parameter(
            Position = 4,
            Mandatory = false,
            ParameterSetName = SetByClusterResourceIdParameterSet,
            HelpMessage = "Gets or sets the actions required when setting the connection status of the private endpoint connection.")]
        [Parameter(
            Position = 4,
            Mandatory = false,
            ParameterSetName = SetByClusterInputObjectParameterSet,
            HelpMessage = "Gets or sets the actions required when setting the connection status of the private endpoint connection.")]
        [Parameter(
            Position = 3,
            Mandatory = false,
            ParameterSetName = SetByPrivateEndpointConnectionResourceIdParameterSet,
            HelpMessage = "Gets or sets the actions required when setting the connection status of the private endpoint connection.")]
        public string ActionsRequired { get; set; }

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


            // if the private endpoint connection does not exist then the bellow statement will throw exception, so don't need to verify whether it exists or not
            var existingPrivateEndpointConnection = HDInsightManagementClient.GetPrivateEndpointConnections(ResourceGroupName, ClusterName, PrivateEndpointConnectionName)?.FirstOrDefault();

            // Set private link service connection state
            existingPrivateEndpointConnection.PrivateLinkServiceConnectionState = new Management.HDInsight.Models.PrivateLinkServiceConnectionState()
            {
                Status = PrivateLinkServiceConnectionState,
                Description = Description,
                ActionsRequired = ActionsRequired
            };

            // update private endpoint connection
            var result = HDInsightManagementClient.UpdatePrivateEndpointConnection(ResourceGroupName, ClusterName, PrivateEndpointConnectionName, existingPrivateEndpointConnection);
            var output = new AzureHDInsightPrivateEndpointConnection(result);
            WriteObject(output, true);
        }
    }
}
