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
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicy", SupportsShouldProcess = true, DefaultParameterSetName = SetByNameParameterSet), OutputType(typeof(PSAzureFirewallPolicy))]
    public class SetAzureFirewallPolicyCommand : AzureFirewallPolicyBaseCmdlet
    {

        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Alias("ResourceName")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.", ParameterSetName = SetByNameParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/azureFirewalls", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The AzureFirewall Policy", ParameterSetName = SetByInputObjectParameterSet)]
        public PSAzureFirewallPolicy InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
                    Mandatory = true,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The resource Id.", ParameterSetName = SetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceId { get; set; }

        [Parameter(
                    Mandatory = false,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The operation mode for Threat Intelligence.")]
        [ValidateSet(
                    MNM.AzureFirewallThreatIntelMode.Alert,
                    MNM.AzureFirewallThreatIntelMode.Deny,
                    MNM.AzureFirewallThreatIntelMode.Off,
                    IgnoreCase = false)]
        public string ThreatIntelMode { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The whitelist for Threat Intelligence")]
        public PSAzureFirewallPolicyThreatIntelWhitelist ThreatIntelWhitelist { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The base policy to inherit from")]
        public string BasePolicy { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The DNS Setting")]
        public PSAzureFirewallPolicyDnsSettings DnsSetting { get; set; }

        [Parameter(
                    Mandatory = true,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "location.", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = SetByResourceIdParameterSet)]
        [Parameter(Mandatory = false, ParameterSetName = SetByInputObjectParameterSet)]
        public virtual string Location { get; set; }

        [Parameter(
                    Mandatory = false,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Intrusion Detection Setting")]
        [ValidateNotNull]
        public PSAzureFirewallPolicyIntrusionDetection IntrusionDetection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Transport security name")]
        public string TransportSecurityName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault")]
        public string TransportSecurityKeyVaultSecretId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Firewall policy sku tier")]
        [ValidateSet(
            MNM.FirewallPolicySkuTier.Standard,
            MNM.FirewallPolicySkuTier.Premium,
            IgnoreCase = true)]
        public string SkuTier { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "ResourceId of the user assigned identity to be assigned to Firewall Policy.")]
        [ValidateNotNullOrEmpty]
        [Alias("UserAssignedIdentity")]
        public string UserAssignedIdentityId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Firewall Policy Identity to be assigned to Firewall Policy.")]
        [ValidateNotNullOrEmpty]
        public PSManagedServiceIdentity Identity { get; set; }

        private void AddPremiumProperties(PSAzureFirewallPolicy firewallPolicy)
        {
            firewallPolicy.Sku = new PSAzureFirewallPolicySku
            {
                Tier = this.SkuTier ?? MNM.FirewallPolicySkuTier.Standard
            };
            firewallPolicy.IntrusionDetection = this.IntrusionDetection;

            if (this.UserAssignedIdentityId != null)
            {
                firewallPolicy.Identity = new PSManagedServiceIdentity
                {
                    Type = MNM.ResourceIdentityType.UserAssigned,
                    UserAssignedIdentities = new Dictionary<string, PSManagedServiceIdentityUserAssignedIdentitiesValue>
                    {
                        { this.UserAssignedIdentityId, new PSManagedServiceIdentityUserAssignedIdentitiesValue() }
                    }
                };
            }
            else if (this.Identity != null)
            {
                firewallPolicy.Identity = this.Identity;
            }

            if (this.TransportSecurityKeyVaultSecretId != null)
            {
                if (this.TransportSecurityName == null)
                {
                    throw new ArgumentException("TransportSecurityName must be provided with TransportSecurityKeyVaultSecretId");
                }

                if (this.Identity == null && this.UserAssignedIdentityId == null)
                {
                    throw new ArgumentException("Identity must be provided with TransportSecurityKeyVaultSecretId");
                }

                firewallPolicy.TransportSecurity = new PSAzureFirewallPolicyTransportSecurity
                {
                    CertificateAuthority = new PSAzureFirewallPolicyTransportSecurityCertificateAuthority
                    {
                        Name = this.TransportSecurityName,
                        KeyVaultSecretId = this.TransportSecurityKeyVaultSecretId
                    }
                };
            }
        }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;
            }
            else if (this.IsParameterBound(c => c.InputObject))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Name = InputObject.Name;
            }

            if (!NetworkBaseCmdlet.IsResourcePresent(() => GetAzureFirewallPolicy(ResourceGroupName, Name)))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.Location = this.IsParameterBound(c => c.Location) ? Location : InputObject.Location;
                this.ThreatIntelMode = this.IsParameterBound(c => c.ThreatIntelMode) ? ThreatIntelMode : InputObject.ThreatIntelMode;
                this.ThreatIntelWhitelist = this.IsParameterBound(c => c.ThreatIntelWhitelist) ? ThreatIntelWhitelist : InputObject.ThreatIntelWhitelist;
                this.BasePolicy = this.IsParameterBound(c => c.BasePolicy) ? BasePolicy : (InputObject.BasePolicy != null ? InputObject.BasePolicy.Id : null);
                this.DnsSetting = this.IsParameterBound(c => c.DnsSetting) ? DnsSetting : (InputObject.DnsSettings != null ? InputObject.DnsSettings : null);
                this.IntrusionDetection = this.IsParameterBound(c => c.IntrusionDetection) ? IntrusionDetection : (InputObject.IntrusionDetection != null ? InputObject.IntrusionDetection : null);
                this.TransportSecurityName = this.IsParameterBound(c => c.TransportSecurityName) ? TransportSecurityName : (InputObject.TransportSecurity?.CertificateAuthority != null ? InputObject.TransportSecurity.CertificateAuthority.Name : null);
                this.TransportSecurityKeyVaultSecretId = this.IsParameterBound(c => c.TransportSecurityKeyVaultSecretId) ? TransportSecurityKeyVaultSecretId : (InputObject.TransportSecurity?.CertificateAuthority != null ? InputObject.TransportSecurity.CertificateAuthority.KeyVaultSecretId : null);
                this.Identity = this.IsParameterBound(c => c.Identity) ? Identity : (InputObject.Identity != null ? InputObject.Identity : null);
                this.UserAssignedIdentityId = this.IsParameterBound(c => c.UserAssignedIdentityId) ? UserAssignedIdentityId : (InputObject.Identity?.UserAssignedIdentities != null ? InputObject.Identity.UserAssignedIdentities?.First().Key : null);
                this.SkuTier = this.IsParameterBound(c => c.SkuTier) ? SkuTier : (InputObject.Sku?.Tier != null ? InputObject.Sku.Tier : null);

                var firewallPolicy = new PSAzureFirewallPolicy()
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = this.Location,
                    ThreatIntelMode = this.ThreatIntelMode ?? MNM.AzureFirewallThreatIntelMode.Alert,
                    ThreatIntelWhitelist = this.ThreatIntelWhitelist,
                    BasePolicy = this.BasePolicy != null ? new Microsoft.Azure.Management.Network.Models.SubResource(this.BasePolicy) : null,
                    DnsSettings = this.DnsSetting
                };

                AddPremiumProperties(firewallPolicy);

                var azureFirewallPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.FirewallPolicy>(firewallPolicy);

                // Execute the PUT AzureFirewall Policy call
                this.AzureFirewallPolicyClient.CreateOrUpdate(ResourceGroupName, Name, azureFirewallPolicyModel);
                var getAzureFirewall = this.GetAzureFirewallPolicy(ResourceGroupName, Name);
                WriteObject(getAzureFirewall);
            }
            else
            {
                var firewallPolicy = new PSAzureFirewallPolicy()
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = this.Location,
                    ThreatIntelMode = this.ThreatIntelMode ?? MNM.AzureFirewallThreatIntelMode.Alert,
                    ThreatIntelWhitelist = this.ThreatIntelWhitelist,
                    BasePolicy = BasePolicy != null ? new Microsoft.Azure.Management.Network.Models.SubResource(BasePolicy) : null,
                    DnsSettings = this.DnsSetting
                };

                AddPremiumProperties(firewallPolicy);

                // Map to the sdk object
                var azureFirewallPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.FirewallPolicy>(firewallPolicy);
                azureFirewallPolicyModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

                // Execute the Create AzureFirewall call
                this.AzureFirewallPolicyClient.CreateOrUpdate(this.ResourceGroupName, this.Name, azureFirewallPolicyModel);
                var getAzureFirewallPolicy = this.GetAzureFirewallPolicy(ResourceGroupName, Name);
                WriteObject(getAzureFirewallPolicy);
            }

        }
    }
}
