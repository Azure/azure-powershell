// ----------------------------------------------------------------------------------
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

using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;

namespace Microsoft.Azure.Commands.OperationalInsights.Clusters
{
    [CmdletOutputBreakingChange(typeof(PSCluster), DeprecatedOutputProperties = new String[] { "NextLink", "Sku" })]
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsCluster", DefaultParameterSetName = UpdateByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class UpdateAzureOperationalInsightsClusterCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "The cluster name.")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = UpdateByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = UpdateByInputObjectParameterSet)]
        [ValidateNotNull]
        public PSCluster InputCluster { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Sku Name, now can be 'CapacityReservation' only")]
        [ValidateSet("CapacityReservation")]
        [ValidateNotNullOrEmpty]
        public string SkuName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "Sku Capacity")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByResourceIdParameterSet, HelpMessage = "Sku Capacity")]
        [ValidateNotNullOrEmpty]
        public long? SkuCapacity { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "Key Vault Uri")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByResourceIdParameterSet, HelpMessage = "Key Vault Uri")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultUri { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "Key Name")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByResourceIdParameterSet, HelpMessage = "Key Name")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "Key Version")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByResourceIdParameterSet, HelpMessage = "Key Version")]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "Tags of the cluster")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByResourceIdParameterSet, HelpMessage = "Tags of the cluster")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "the identity type, value can be 'SystemAssigned', 'None', 'UserAssigned'.")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByResourceIdParameterSet, HelpMessage = "the identity type, value can be 'SystemAssigned', 'None', 'UserAssigned'.")]
        [ValidateSet("SystemAssigned", "None", "UserAssigned", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string IdentityType { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AllParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByNameParameterSet, HelpMessage = "Billing type can be set as 'Cluster' or 'Workspaces'")]
        [Parameter(Mandatory = false, ParameterSetName = UpdateByResourceIdParameterSet, HelpMessage = "Billing type can be set as 'Cluster' or 'Workspaces'")]
        [ValidateSet("Cluster", "Workspaces", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string BillingType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.ClusterName = resourceIdentifier.ResourceName;
            }

            PSCluster parameters = new PSCluster();

            if (this.IsParameterBound(c => c.InputCluster))
            {
                parameters.KeyVaultProperties = PSKeyVaultProperties.CreateKVProperties(InputCluster.KeyVaultProperties?.KeyVaultUri, InputCluster.KeyVaultProperties?.KeyName, InputCluster.KeyVaultProperties?.KeyVersion);
                parameters.CapacityReservationProperties = InputCluster.CapacityReservationProperties;
                parameters.Tags = InputCluster.Tags;
                parameters.Identity = InputCluster.Identity;
                parameters.BillingType = InputCluster.BillingType;
            }
            else
            {
                parameters.KeyVaultProperties = PSKeyVaultProperties.CreateKVProperties(this.KeyVaultUri, this.KeyName, this.KeyVersion);
                parameters.CapacityReservationProperties = this.SkuCapacity == null ? null : new PSCapacityReservationProperties(this.SkuCapacity, this.SkuName ?? AllowedClusterServiceTiers.CapacityReservation.ToString());
                parameters.Tags = this.Tag;
                parameters.Identity = new PSIdentity(IdentityType);
                parameters.BillingType = BillingType;
            }

            if (ShouldProcess(this.ClusterName,
                $"update cluster: {this.ClusterName} in resource group: {this.ResourceGroupName}"))
            {
                WriteObject(this.OperationalInsightsClient.UpdatePSCluster(this.ResourceGroupName, this.ClusterName, parameters));
            }
        }
    }
}
