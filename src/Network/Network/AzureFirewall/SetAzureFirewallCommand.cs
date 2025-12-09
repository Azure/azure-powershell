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
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Firewall", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewall))]
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

            // Validate that EdgeZone and Zones are not both specified
            if (this.AzureFirewall.ExtendedLocation != null && 
                !string.IsNullOrEmpty(this.AzureFirewall.ExtendedLocation.Name) && 
                this.AzureFirewall.Zones != null && 
                this.AzureFirewall.Zones.Count > 0)
            {
                throw new ArgumentException("Zones cannot be specified when EdgeZone is provided. EdgeZone deployments do not support availability zones.");
            }

            // Validate that VirtualNetwork and PublicIpAddresses are in the same EdgeZone when EdgeZone is specified
            if (this.AzureFirewall.ExtendedLocation != null && !string.IsNullOrEmpty(this.AzureFirewall.ExtendedLocation.Name))
            {
                string edgeZone = this.AzureFirewall.ExtendedLocation.Name;

                // Check if firewall has IP configurations (for AZFW_VNet SKU)
                if (this.AzureFirewall.IpConfigurations != null && this.AzureFirewall.IpConfigurations.Count > 0)
                {
                    foreach (var ipConfig in this.AzureFirewall.IpConfigurations)
                    {
                        // Check subnet (VirtualNetwork)
                        if (ipConfig.Subnet != null && !string.IsNullOrEmpty(ipConfig.Subnet.Id))
                        {
                            var subnetResourceId = new Management.Internal.Resources.Utilities.Models.ResourceIdentifier(ipConfig.Subnet.Id);
                            var vnet = this.VirtualNetworkClient.Get(subnetResourceId.ResourceGroupName, subnetResourceId.ParentResource.Split('/')[1]);
                            var psVnet = NetworkResourceManagerProfile.Mapper.Map<Models.PSVirtualNetwork>(vnet);
                            
                            if (psVnet.ExtendedLocation == null || 
                                string.IsNullOrEmpty(psVnet.ExtendedLocation.Name) ||
                                !psVnet.ExtendedLocation.Name.Equals(edgeZone, StringComparison.OrdinalIgnoreCase))
                            {
                                throw new ArgumentException($"Virtual Network must be deployed in the same edge zone '{edgeZone}' as the firewall. The Virtual Network's extended location does not match.");
                            }
                        }

                        // Check PublicIpAddress
                        if (ipConfig.PublicIpAddress != null && !string.IsNullOrEmpty(ipConfig.PublicIpAddress.Id))
                        {
                            var pipResourceId = new Management.Internal.Resources.Utilities.Models.ResourceIdentifier(ipConfig.PublicIpAddress.Id);
                            var pip = this.PublicIPAddressesClient.Get(pipResourceId.ResourceGroupName, pipResourceId.ResourceName);
                            var psPip = NetworkResourceManagerProfile.Mapper.Map<Models.PSPublicIpAddress>(pip);
                            
                            if (psPip.ExtendedLocation == null || 
                                string.IsNullOrEmpty(psPip.ExtendedLocation.Name) ||
                                !psPip.ExtendedLocation.Name.Equals(edgeZone, StringComparison.OrdinalIgnoreCase))
                            {
                                throw new ArgumentException($"Public IP Address '{psPip.Name}' must be deployed in the same edge zone '{edgeZone}' as the firewall. The Public IP's extended location does not match.");
                            }
                        }
                    }
                }

                // Check ManagementIpConfiguration
                if (this.AzureFirewall.ManagementIpConfiguration != null)
                {
                    var mgmtIpConfig = this.AzureFirewall.ManagementIpConfiguration;

                    // Check management subnet (VirtualNetwork)
                    if (mgmtIpConfig.Subnet != null && !string.IsNullOrEmpty(mgmtIpConfig.Subnet.Id))
                    {
                        var subnetResourceId = new Management.Internal.Resources.Utilities.Models.ResourceIdentifier(mgmtIpConfig.Subnet.Id);
                        var vnet = this.VirtualNetworkClient.Get(subnetResourceId.ResourceGroupName, subnetResourceId.ParentResource.Split('/')[1]);
                        var psVnet = NetworkResourceManagerProfile.Mapper.Map<Models.PSVirtualNetwork>(vnet);
                        
                        if (psVnet.ExtendedLocation == null || 
                            string.IsNullOrEmpty(psVnet.ExtendedLocation.Name) ||
                            !psVnet.ExtendedLocation.Name.Equals(edgeZone, StringComparison.OrdinalIgnoreCase))
                        {
                            throw new ArgumentException($"Management Virtual Network must be deployed in the same edge zone '{edgeZone}' as the firewall. The Virtual Network's extended location does not match.");
                        }
                    }

                    // Check management PublicIpAddress
                    if (mgmtIpConfig.PublicIpAddress != null && !string.IsNullOrEmpty(mgmtIpConfig.PublicIpAddress.Id))
                    {
                        var pipResourceId = new Management.Internal.Resources.Utilities.Models.ResourceIdentifier(mgmtIpConfig.PublicIpAddress.Id);
                        var pip = this.PublicIPAddressesClient.Get(pipResourceId.ResourceGroupName, pipResourceId.ResourceName);
                        var psPip = NetworkResourceManagerProfile.Mapper.Map<Models.PSPublicIpAddress>(pip);
                        
                        if (psPip.ExtendedLocation == null || 
                            string.IsNullOrEmpty(psPip.ExtendedLocation.Name) ||
                            !psPip.ExtendedLocation.Name.Equals(edgeZone, StringComparison.OrdinalIgnoreCase))
                        {
                            throw new ArgumentException($"Management Public IP Address '{psPip.Name}' must be deployed in the same edge zone '{edgeZone}' as the firewall. The Management Public IP's extended location does not match.");
                        }
                    }
                }
            }

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
