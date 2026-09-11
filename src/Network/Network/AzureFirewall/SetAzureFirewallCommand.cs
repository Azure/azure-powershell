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

using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    // TODO: Support WhatIf https://github.com/Azure/azure-powershell/issues/27667
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Firewall", SupportsShouldProcess = false), OutputType(typeof(PSAzureFirewall))]
    public class SetAzureFirewallCommand : AzureFirewallBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The AzureFirewall")]
        public PSAzureFirewall AzureFirewall { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsAzureFirewallPresent(this.AzureFirewall.ResourceGroupName, this.AzureFirewall.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            if (this.AzureFirewall.Sku != null && this.AzureFirewall.Sku.Tier != null && this.AzureFirewall.Sku.Tier.Equals(MNM.AzureFirewallSkuTier.Basic) && !string.IsNullOrEmpty(this.AzureFirewall.Location))
            {
                if (FirewallConstants.IsRegionRestrictedForBasicFirewall(this.AzureFirewall.Location))
                {
                    throw new ArgumentException("Basic Sku Firewall is not supported in this region yet - " + this.AzureFirewall.Location, nameof(this.AzureFirewall.Location));
                }
            }

            // Validate that EdgeZone and Zones are not both specified.
            // Treat any non-null Zones (including empty list) as invalid when ExtendedLocation is set,
            // and explicitly null it out to prevent an empty list from being sent in the update payload.
            if (this.AzureFirewall.ExtendedLocation != null && 
                !string.IsNullOrEmpty(this.AzureFirewall.ExtendedLocation.Name))
            {
                if (this.AzureFirewall.Zones != null && this.AzureFirewall.Zones.Count > 0)
                {
                    throw new ArgumentException("Zones cannot be specified when EdgeZone is provided. EdgeZone deployments do not support availability zones.", nameof(this.AzureFirewall.Zones));
                }

                // Ensure an empty Zones list is not sent in the payload for EdgeZone firewalls
                this.AzureFirewall.Zones = null;
            }

            // Note: VNet/PIP co-location validation is intentionally omitted for Set-AzFirewall.
            // New-AzFirewall already validates at creation time, and the ARM service will reject
            // mismatches during CreateOrUpdate. Avoiding extra GET calls on every update improves
            // performance and eliminates a potential failure point.

            // Map to the sdk object
            var secureGwModel = NetworkResourceManagerProfile.Mapper.Map<MNM.AzureFirewall>(this.AzureFirewall);
            secureGwModel.Tags = TagsConversionHelper.CreateTagDictionary(this.AzureFirewall.Tag, validate: true);

            // Execute the PUT AzureFirewall call
            this.AzureFirewallClient.CreateOrUpdate(this.AzureFirewall.ResourceGroupName, this.AzureFirewall.Name, secureGwModel);

            var getAzureFirewall = this.GetAzureFirewall(this.AzureFirewall.ResourceGroupName, this.AzureFirewall.Name);
            WriteObject(getAzureFirewall);
        }
    }
}
