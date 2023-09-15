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
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [GenericBreakingChangeWithVersionAttribute(Constants.diskEncryptionChangeInfo + Constants.workerNodeDataDisksGroupsChangeInfo,Constants.deprecateByAzVersion,Constants.deprecateByVersion)]
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightClusterAutoscaleConfiguration", DefaultParameterSetName = RemoveByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(AzureHDInsightCluster))]
    public class RemoveAzureHDInsightClusterAutoscaleConfigurationCommand : HDInsightCmdletBase
    {
        #region Input Parameter Definitions
        private const string RemoveByNameParameterSet = "RemoveByNameParameterSet";
        private const string RemoveByResourceIdParameterSet = "RemoveByResourceIdParameterSet";
        private const string RemoveByInputObjectParameterSet = "RemoveByInputObjectParameterSet";

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
            ParameterSetName = RemoveByResourceIdParameterSet,
            HelpMessage = "Gets or sets the resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = RemoveByInputObjectParameterSet,
            HelpMessage = "Gets or sets the input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

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

            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            if (ShouldProcess(ClusterName))
            {
                AutoscaleConfigurationUpdateParameter parameter = new AutoscaleConfigurationUpdateParameter();
                HDInsightManagementClient.UpdateAutoScaleConfiguration(ResourceGroupName, ClusterName, parameter);

                Cluster cluster = HDInsightManagementClient.Get(ResourceGroupName, ClusterName);
                WriteObject(new AzureHDInsightCluster(cluster));
            }
        }
    }
}
