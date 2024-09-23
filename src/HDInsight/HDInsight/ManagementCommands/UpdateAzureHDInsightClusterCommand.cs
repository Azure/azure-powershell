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
using Microsoft.Azure.Management.HDInsight.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.HDInsight
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightCluster", SupportsShouldProcess = true),OutputType(typeof(AzureHDInsightCluster))]
    public class UpdateAzureHDInsightClusterCommand : HDInsightCmdletBase
    {
        private ClusterIdentity clusterIdentity;
        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = "Gets or sets the name of the cluster.")]
        public string ClusterName { get; set; }

        [Parameter(
            HelpMessage = "Gets or sets the type of identity used for the cluster. Possible values include: SystemAssigned, UserAssigned.")]
        public string IdentityType { get; set; }

        [Parameter(
            HelpMessage = "Gets or sets the list of user identities associated with the cluster.")]
        public string IdentityId { get; set; }

        [Parameter(
            HelpMessage = "The resource tags.")]
        public Dictionary<string, string> Tag { get; set; }

        [Parameter(HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        #endregion

        public UpdateAzureHDInsightClusterCommand()
        {
            
        }

        public override void ExecuteCmdlet()
        {
            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(ClusterName);
            }

            if (IdentityType != null) {
                clusterIdentity = new ClusterIdentity() { Type = IdentityType};
                }
            if (IdentityId != null)
            {
                clusterIdentity.UserAssignedIdentities = new Dictionary<string, UserAssignedIdentity>();
                clusterIdentity.UserAssignedIdentities[IdentityId] = new UserAssignedIdentity();
            }

            HDInsightManagementClient.UpdateCluster(ResourceGroupName, ClusterName, Tag, clusterIdentity);

            var cluster = HDInsightManagementClient.GetCluster(ResourceGroupName, ClusterName);
            if (cluster != null)
            {
                WriteObject(new AzureHDInsightCluster(cluster.First()));
            }
        }
    }
}
