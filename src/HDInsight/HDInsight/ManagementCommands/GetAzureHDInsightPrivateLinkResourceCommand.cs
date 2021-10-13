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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightPrivateLinkResource", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(AzureHDInsightPrivateLinkResource))]
    public class GetAzureHDInsightPrivateLinkResourceCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByClusterResourceIdParameterSet = "GetByClusterResourceIdParameterSet";
        private const string GetByClusterInputObjectParameterSet = "GetByClusterInputObjectParameterSet";
        private const string GetByPrivateLinkResourceIdParameterSet = "GetByPrivateLinkResourceIdParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ResourceNameCompleter("Microsoft.HDInsight/clusters", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetByClusterResourceIdParameterSet,
            HelpMessage = "Gets or sets the cluster resource id.")]
        [ValidateNotNullOrEmpty]
        public string ClusterResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = GetByClusterInputObjectParameterSet,
            HelpMessage = "Gets or sets the cluster input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster ClusterInputObject { get; set; }

        [Parameter(
            Position = 2,
            ParameterSetName = GetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the private link resources.")]
        [Parameter(
            Position = 1,
            ParameterSetName = GetByClusterResourceIdParameterSet,
            HelpMessage = "Gets or sets the name of the private link resources.")]
        [Parameter(
            Position = 1,
            ParameterSetName = GetByClusterInputObjectParameterSet,
            HelpMessage = "Gets or sets the name of the private link resources.")]
        public string PrivateLinkResourceName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetByPrivateLinkResourceIdParameterSet,
            HelpMessage = "Gets or sets the private link resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
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
                this.PrivateLinkResourceName = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ClusterName = resourceIdentifier.ParentResource.Split('/').Last();
            }

            var result = HDInsightManagementClient.GetPrivateLinkResources(ResourceGroupName, ClusterName, PrivateLinkResourceName);
            var output = result.Select(item => new AzureHDInsightPrivateLinkResource(item)).ToList();
            WriteObject(output, true);
        }
    }
}
