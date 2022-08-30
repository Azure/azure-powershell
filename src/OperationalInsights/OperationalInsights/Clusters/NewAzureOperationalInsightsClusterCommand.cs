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

using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using Microsoft.Azure.Commands.OperationalInsights.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;

namespace Microsoft.Azure.Commands.OperationalInsights.Clusters
{
    [CmdletOutputBreakingChange(typeof(PSCluster), DeprecatedOutputProperties = new String[] { "NextLink", "Sku" })]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsCluster", SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class NewAzureOperationalInsightsClusterCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The cluster name.")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The geographic region that the cluster will be deployed.")]
        [LocationCompleter("Microsoft.OperationalInsights/clusters")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "the identity type, value can be 'SystemAssigned', 'None', 'UserAssigned'.")]
        [ValidateSet("SystemAssigned", "None", "UserAssigned", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string IdentityType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Sku Name, now can be 'CapacityReservation' only")]
        [ValidateSet("CapacityReservation", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string SkuName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Sku Capacity, value need to be multiple of 100 and at least 1000.")]
        [ValidateNotNullOrEmpty]
        public long SkuCapacity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Tags of the cluster")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Key Vault Uri")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultUri { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Key Name")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Key Version")]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Flag for availability Zones,can be set to true only in supported regions")]
        public bool? IsAvailabilityZonesEnabled { get; private set; }

        [Parameter(Mandatory = false, HelpMessage = "Flag for Double Encryption, can be set to true only in supported regions")]
        public bool? IsDoubleEncryptionEnabled { get; private set; }

        [Parameter(Mandatory = false, HelpMessage = "Billing type can be set as 'Cluster' or 'Workspaces'")]
        [ValidateSet("Cluster", "Workspaces", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string BillingType { get; private set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            PSCluster parameters = new PSCluster()
            {
                Name = this.ClusterName,
                Location = this.Location,
                Identity = new PSIdentity(this.IdentityType),
                CapacityReservationProperties = new PSCapacityReservationProperties(maxCapacity: this.SkuCapacity, skuName: this.SkuName ?? AllowedClusterServiceTiers.CapacityReservation.ToString()),
                Tags = this.Tag,
                IsDoubleEncryptionEnabled = this.IsDoubleEncryptionEnabled,
                IsAvailabilityZonesEnabled = this.IsAvailabilityZonesEnabled,
                BillingType = this.BillingType,
                KeyVaultProperties = PSKeyVaultProperties.CreateKVProperties(this.KeyVaultUri, this.KeyName, this.KeyVersion),
            };

            if (ShouldProcess(this.ClusterName,
                string.Format("create cluster: {0} in resource group: {1}", this.ClusterName, this.ResourceGroupName)))
            {
                WriteObject(this.OperationalInsightsClient.CreatePSCluster(this.ResourceGroupName, this.ClusterName, parameters));
            }
        }
    }
}
