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
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "OperationalInsightsCluster", SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class NewAzureOperationalInsightsClusterCommand : OperationalInsightsBaseCmdlet
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

        [Parameter(Position = 2, Mandatory = true,
            HelpMessage = "The geographic region that the cluster will be deployed.")]
        [LocationCompleter("Microsoft.OperationalInsights/clusters")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "the identity type, value can be 'SystemAssigned', 'None'.")]
        [ValidateSet("SystemAssigned", "None")]
        [ValidateNotNullOrEmpty]
        public string IdentityType { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Sku Name, now can be 'CapacityReservation' only")]
        [ValidateSet("CapacityReservation")]
        [ValidateNotNullOrEmpty]
        public string SkuName { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "Sku Capacity, value need to be multiple of 100 and in the range of 1000-2000.")]
        [ValidateNotNullOrEmpty]
        public long SkuCapacity { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Tags of the cluster")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            PSCluster parameters = new PSCluster()
            {
                Name = this.ClusterName,
                Location = this.Location,
                Identity = new PSIdentity(this.IdentityType),
                Sku = new PSClusterSku(this.SkuName, this.SkuCapacity),
                Tags = this.Tag
            };

            if (ShouldProcess(this.ClusterName,
                string.Format("create cluster: {0} in resource group: {1}", this.ClusterName, this.ResourceGroupName)))
            {
                WriteObject(this.OperationalInsightsClient.CreatePSCluster(this.ResourceGroupName, this.ClusterName, parameters));
            }
        }
    }
}
