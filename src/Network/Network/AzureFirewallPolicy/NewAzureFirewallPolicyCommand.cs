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
using System.Collections.Generic;
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicy", SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallPolicy))]
    public class NewAzureFirewallPolicyCommand : AzureFirewallPolicyBaseCmdlet
    {

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "location.")]
        [LocationCompleter("Microsoft.Network/FirewallPolicies")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

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
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

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

        public override void Execute()
        {

            base.Execute();

            var present = NetworkBaseCmdlet.IsResourcePresent(() => GetAzureFirewallPolicy(this.ResourceGroupName, this.Name));  
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () => WriteObject(this.CreateAzureFirewallPolicy()),
                () => present);
        }

        private PSAzureFirewallPolicy CreateAzureFirewallPolicy()
        {

            var firewallPolicy = new PSAzureFirewallPolicy()
            {
                Name = this.Name,
                ResourceGroupName = this.ResourceGroupName,
                Location = this.Location,
                ThreatIntelMode = this.ThreatIntelMode ?? MNM.AzureFirewallThreatIntelMode.Alert,
                ThreatIntelWhitelist = this.ThreatIntelWhitelist,
                BasePolicy = BasePolicy != null ? new Microsoft.Azure.Management.Network.Models.SubResource(BasePolicy) : null,
                DnsSettings = this.DnsSetting,
                Sku = new PSAzureFirewallPolicySku {
                    Tier = this.SkuTier ?? MNM.FirewallPolicySkuTier.Standard
                },
                IntrusionDetection = this.IntrusionDetection
            };

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

            // Map to the sdk object
            var azureFirewallPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.FirewallPolicy>(firewallPolicy);
            azureFirewallPolicyModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create AzureFirewall call
            this.AzureFirewallPolicyClient.CreateOrUpdate(this.ResourceGroupName, this.Name, azureFirewallPolicyModel);
            return this.GetAzureFirewallPolicy(this.ResourceGroupName, this.Name);
        }
    }
}
