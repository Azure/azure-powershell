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
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.HDInsight
{
    [GenericBreakingChangeWithVersionAttribute(Constants.diskEncryptionChangeInfo + Constants.workerNodeDataDisksGroupsChangeInfo,Constants.deprecateByAzVersion,Constants.deprecateByVersion)]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HDInsightClusterDiskEncryptionKey", DefaultParameterSetName = SetByNameParameterSet, SupportsShouldProcess = true),OutputType(typeof(AzureHDInsightCluster))]
    public class SetAzureHDInsightClusterDiskEncryptionKeyCommand : HDInsightCmdletBase
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";

        #region Input Parameter Definitions

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the resource group.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Alias("ClusterName")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = SetByNameParameterSet,
            HelpMessage = "Gets or sets the name of the cluster.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = SetByResourceIdParameterSet,
            HelpMessage = "Gets or sets the resource id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = SetByInputObjectParameterSet,
            HelpMessage = "Gets or sets the input object.")]
        [ValidateNotNull]
        public AzureHDInsightCluster InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Gets or sets the encryption key name.")]
        public string EncryptionKeyName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Gets or sets the encryption key version.")]
        public string EncryptionKeyVersion { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Gets or sets the encryption vault uri.")]
        public string EncryptionVaultUri { get; set; }

        #endregion

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                this.Name = resourceIdentifier.ResourceName;
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.Name = this.InputObject.Name;
                this.ResourceGroupName = this.InputObject.ResourceGroup;
            }

            if (ResourceGroupName == null)
            {
                ResourceGroupName = GetResourceGroupByAccountName(Name);
            }

            var rotateParams = new ClusterDiskEncryptionParameters
            {
                KeyName = EncryptionKeyName,
                KeyVersion = EncryptionKeyVersion,
                VaultUri = EncryptionVaultUri
            };

            HDInsightManagementClient.RotateDiskEncryptionKey(ResourceGroupName, Name, rotateParams);

            var cluster = HDInsightManagementClient.GetCluster(ResourceGroupName, Name);
            if (cluster != null)
            {
                WriteObject(new AzureHDInsightCluster(cluster.First()));
            }
        }
    }
}
