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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Clusters
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsCluster", SupportsShouldProcess = true), OutputType(typeof(PSLinkedService))]
    public class UpdateAzureOperationalInsightsClusterCommand : OperationalInsightsBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "The cluster name.")]
        [ValidateNotNullOrEmpty]
        public string ClusterName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Sku Name, now can be 'CapacityReservation' only")]
        [ValidateSet("CapacityReservation")]
        [ValidateNotNullOrEmpty]
        public string SkuName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Sku Capacity")]
        [ValidateNotNullOrEmpty]
        public long SkuCapacity { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Key Vault Uri")]
        [ValidateNotNullOrEmpty]
        public string KeyVaultUri { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Key Name")]
        [ValidateNotNullOrEmpty]
        public string KeyName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Key Version")]
        [ValidateNotNullOrEmpty]
        public string KeyVersion { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Tags of the cluster")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            PSClusterPatch parameters = new PSClusterPatch()
            {
                KeyVaultProperties = new PSKeyVaultProperties(this.KeyVaultUri, this.KeyName, this.KeyVersion),
                Sku = new PSClusterSku(this.SkuName, this.SkuCapacity),
                Tags = this.Tag
            };

            if (ShouldProcess(this.ClusterName,
                string.Format("update cluster: {0} in resource group: {1}", this.ClusterName, this.ResourceGroupName)))
            {
                WriteObject(this.OperationalInsightsClient.UpdatePSCluster(this.ResourceGroupName, this.ClusterName, parameters));
            }
        }
    }
}
