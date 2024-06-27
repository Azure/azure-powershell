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
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyDraft", DefaultParameterSetName = SetByNameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSAzureFirewallPolicyDraft))]
    public class NewAzureFirewallPolicyDraftCommand : AzureFirewallPolicyDraftCmdlet
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentInputObjectParameterSet = "SetByParentInputObjectParameterSet";

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string AzureFirewallPolicyName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Firewall Policy.", ParameterSetName = SetByParentInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy FirewallPolicyObject { get; set; }

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
            HelpMessage = "The SQL related setting")]
        public PSAzureFirewallPolicySqlSetting SqlSetting { get; set; }

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
            HelpMessage = "The private IP ranges to which traffic won't be SNAT'ed"
        )]
        public string[] PrivateRange { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Explicit Proxy Settings in Firewall Policy.")]
        public PSAzureFirewallPolicyExplicitProxy ExplicitProxy { get; set; }

        [Parameter(
          Mandatory = false,
          HelpMessage = "The private IP addresses/IP ranges to which traffic will not be SNAT in Firewall Policy.")]
        public PSAzureFirewallPolicySNAT Snat { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (this.IsParameterBound(c => c.FirewallPolicyObject))
            {
                this.AzureFirewallPolicyName = FirewallPolicyObject.Name;
                this.ResourceGroupName = FirewallPolicyObject.ResourceGroupName;
            }
            var present = NetworkBaseCmdlet.IsResourcePresent(() => GetAzureFirewallPolicyDraft(this.ResourceGroupName, this.AzureFirewallPolicyName));
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, AzureFirewallPolicyName + " draft"),
                Properties.Resources.CreatingResourceMessage,
                AzureFirewallPolicyName,
                () => WriteObject(this.CreateAzureFirewallPolicyDraft()),
                () => present);
        }

        private PSAzureFirewallPolicyDraft CreateAzureFirewallPolicyDraft()
        {
            if (this.Snat != null && this.PrivateRange != null && this.PrivateRange.Length > 0)
            {
                throw new ArgumentException("Please use Snat parameter to set PrivateRange. Private ranges can not be provided on both Snat and PrivateRange parameters at the same time.");
            }

            // Copy draft properties from base policy
            var firewallPolicyParams = NetworkResourceManagerProfile.Mapper.Map<PSAzureFirewallPolicy>(NetworkClient.NetworkManagementClient.FirewallPolicies.Get(this.ResourceGroupName, this.AzureFirewallPolicyName));
            var firewallPolicyDraft = new PSAzureFirewallPolicyDraft()
            {
                Name = this.AzureFirewallPolicyName,
                ThreatIntelMode = this.ThreatIntelMode ?? firewallPolicyParams.ThreatIntelMode,
                ThreatIntelWhitelist = this.ThreatIntelWhitelist ?? firewallPolicyParams.ThreatIntelWhitelist,
                BasePolicy = this.BasePolicy != null ? new SubResource(BasePolicy) : firewallPolicyParams.BasePolicy,
                DnsSettings = this.DnsSetting ?? firewallPolicyParams.DnsSettings,
                SqlSetting = this.SqlSetting ?? firewallPolicyParams.SqlSetting,
                IntrusionDetection = this.IntrusionDetection ?? firewallPolicyParams.IntrusionDetection,
                PrivateRange = this.PrivateRange ?? firewallPolicyParams.PrivateRange,
                ExplicitProxy = this.ExplicitProxy ?? firewallPolicyParams.ExplicitProxy,
                Snat = this.Snat ?? firewallPolicyParams.Snat,
            };

            // Map to the sdk object
            var azureFirewallPolicyDraftModel = NetworkResourceManagerProfile.Mapper.Map<MNM.FirewallPolicyDraft>(firewallPolicyDraft);
            azureFirewallPolicyDraftModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create AzureFirewall call
            this.AzureFirewallPolicyDraftClient.CreateOrUpdate(this.ResourceGroupName, this.AzureFirewallPolicyName , azureFirewallPolicyDraftModel);
            return this.GetAzureFirewallPolicyDraft(this.ResourceGroupName, this.AzureFirewallPolicyName );
        }
    }
}
