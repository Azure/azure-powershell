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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The base policy to inherit from")]
        public string BasePolicy { get; set; }

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
                this.BasePolicy = this.IsParameterBound(c => c.BasePolicy) ? BasePolicy : (InputObject.BasePolicy != null ? InputObject.BasePolicy.Id : null);

                var firewallPolicy = new PSAzureFirewallPolicy()
                {
                    Name = this.Name,
                    ResourceGroupName = this.ResourceGroupName,
                    Location = this.Location,
                    ThreatIntelMode = this.ThreatIntelMode ?? MNM.AzureFirewallThreatIntelMode.Alert,
                    BasePolicy = this.BasePolicy != null ? new Microsoft.Azure.Management.Network.Models.SubResource(this.BasePolicy) : null
                };


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
                    BasePolicy = BasePolicy != null ? new Microsoft.Azure.Management.Network.Models.SubResource(BasePolicy) : null
                };

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
