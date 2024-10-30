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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyDraft", SupportsShouldProcess = true, DefaultParameterSetName = SetByNameParameterSet), OutputType(typeof(PSAzureFirewallPolicyDraft))]
    public class SetAzureFirewallPolicyDraftCommand : AzureFirewallPolicyDraftCmdlet
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByParentObjectParameterSet = "SetByParentInputObjectParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";
        private const string SetByResourceIdParameterSet = "SetByResourceIdParameterSet";

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string AzureFirewallPolicyName { get; set; }

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
            HelpMessage = "The AzureFirewall Policy Draft", ParameterSetName = SetByInputObjectParameterSet)]
        public PSAzureFirewallPolicyDraft InputObject { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Firewall Policy.", ParameterSetName = SetByParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy FirewallPolicyObject { get; set; }

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
            HelpMessage = "The Intrusion Detection Setting")]
        [ValidateNotNull]
        public PSAzureFirewallPolicyIntrusionDetection IntrusionDetection { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Private IP Range")]
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

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                AzureFirewallPolicyName = ExtractFirewallPolicyNameFromDraftResourceId(resourceInfo.ParentResource);
            }
            else if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceId = InputObject.Id;
                var resourceInfo = new ResourceIdentifier(resourceId);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.AzureFirewallPolicyName = ExtractFirewallPolicyNameFromDraftResourceId(resourceInfo.ParentResource);
            }
            else if (this.IsParameterBound(c => c.FirewallPolicyObject))
            {
                this.ResourceGroupName = FirewallPolicyObject.ResourceGroupName;
                this.AzureFirewallPolicyName = FirewallPolicyObject.Name;
            }

            if (!NetworkBaseCmdlet.IsResourcePresent(() => GetAzureFirewallPolicyDraft(ResourceGroupName, AzureFirewallPolicyName)))
            {
                throw new ArgumentException(Properties.Resources.ResourceNotFound);
            }

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ThreatIntelMode = this.IsParameterBound(c => c.ThreatIntelMode) ? ThreatIntelMode : InputObject.ThreatIntelMode;
                this.ThreatIntelWhitelist = this.IsParameterBound(c => c.ThreatIntelWhitelist) ? ThreatIntelWhitelist : InputObject.ThreatIntelWhitelist;
                this.BasePolicy = this.IsParameterBound(c => c.BasePolicy) ? BasePolicy : (InputObject.BasePolicy != null ? InputObject.BasePolicy.Id : null);
                this.DnsSetting = this.IsParameterBound(c => c.DnsSetting) ? DnsSetting : (InputObject.DnsSettings != null ? InputObject.DnsSettings : null);
                this.SqlSetting = this.IsParameterBound(c => c.SqlSetting) ? SqlSetting : (InputObject.SqlSetting != null ? InputObject.SqlSetting : null);
                this.IntrusionDetection = this.IsParameterBound(c => c.IntrusionDetection) ? IntrusionDetection : (InputObject.IntrusionDetection != null ? InputObject.IntrusionDetection : null);
                this.PrivateRange = this.IsParameterBound(c => c.PrivateRange) ? PrivateRange : InputObject.PrivateRange;
                this.ExplicitProxy = this.IsParameterBound(c => c.ExplicitProxy) ? ExplicitProxy : InputObject.ExplicitProxy;
                this.Snat = this.IsParameterBound(c => c.Snat) ? Snat : InputObject.Snat;

                var firewallPolicyDraft = new PSAzureFirewallPolicyDraft()
                {
                    Name = this.AzureFirewallPolicyName,
                    ThreatIntelMode = this.ThreatIntelMode ?? MNM.AzureFirewallThreatIntelMode.Alert,
                    ThreatIntelWhitelist = this.ThreatIntelWhitelist,
                    BasePolicy = this.BasePolicy != null ? new SubResource(this.BasePolicy) : null,
                    DnsSettings = this.DnsSetting,
                    SqlSetting = this.SqlSetting,
                    PrivateRange = this.PrivateRange,
                    ExplicitProxy = this.ExplicitProxy,
                    IntrusionDetection = this.IntrusionDetection,
                };
                if (this.Snat != null)
                {
                    firewallPolicyDraft.Snat = this.Snat;
                }
                var azureFirewallPolicyDraftModel = NetworkResourceManagerProfile.Mapper.Map<MNM.FirewallPolicyDraft>(firewallPolicyDraft);
                azureFirewallPolicyDraftModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

                // Execute the PUT AzureFirewall Policy call
                this.AzureFirewallPolicyDraftClient.CreateOrUpdate(ResourceGroupName, AzureFirewallPolicyName, azureFirewallPolicyDraftModel);
                var getAzureFirewallPolicyDraft = this.GetAzureFirewallPolicyDraft(ResourceGroupName, AzureFirewallPolicyName);
                WriteObject(getAzureFirewallPolicyDraft);
            }
            else
            {
                if (this.Snat != null && this.PrivateRange != null && this.PrivateRange.Length > 0)
                {
                    throw new ArgumentException("Please use Snat parameter to set PrivateRange. Private ranges can not be provided on both Snat and PrivateRange parameters at the same time.");
                }

                var firewallPolicyDraft = new PSAzureFirewallPolicyDraft()
                {
                    Name = this.AzureFirewallPolicyName,
                    ThreatIntelMode = this.ThreatIntelMode ?? MNM.AzureFirewallThreatIntelMode.Alert,
                    ThreatIntelWhitelist = this.ThreatIntelWhitelist,
                    BasePolicy = BasePolicy != null ? new SubResource(BasePolicy) : null,
                    DnsSettings = this.DnsSetting,
                    SqlSetting = this.SqlSetting,
                    PrivateRange = this.PrivateRange,
                    ExplicitProxy = this.ExplicitProxy,
                    IntrusionDetection = this.IntrusionDetection,
                };

                if (this.Snat != null)
                {
                    firewallPolicyDraft.Snat = this.Snat;
                }

                // Map to the sdk object
                var azureFirewallPolicyDraftModel = NetworkResourceManagerProfile.Mapper.Map<MNM.FirewallPolicyDraft>(firewallPolicyDraft);
                azureFirewallPolicyDraftModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

                // Execute the Create AzureFirewall call
                this.AzureFirewallPolicyDraftClient.CreateOrUpdate(this.ResourceGroupName, this.AzureFirewallPolicyName, azureFirewallPolicyDraftModel);
                var getAzureFirewallPolicyDraft = this.GetAzureFirewallPolicyDraft(ResourceGroupName, AzureFirewallPolicyName);
                WriteObject(getAzureFirewallPolicyDraft);
            }

        }
    }
}
