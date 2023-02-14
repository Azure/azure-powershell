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

using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyRuleCollectionGroup", SupportsShouldProcess = true, DefaultParameterSetName = RemoveByNameParameterSet), OutputType(typeof(bool))]
    public class RemoveAzureFirewallPolicyRuleGroupCommand : AzureFirewallPolicyRuleCollectionGroupBaseCmdlet
    {
        private const string RemoveByNameParameterSet = "RemoveByNameParameterSet";
        private const string RemoveByParentInputObjectParameterSet = "RemoveByParentInputObjectParameterSet";
        private const string RemoveByInputObjectParameterSet = "RemoveByInputObjectParameterSet";
        private const string RemoveByResourceIdParameterSet = "RemoveByResourceIdParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.", ParameterSetName = RemoveByNameParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = RemoveByParentInputObjectParameterSet)]
        [ResourceNameCompleter("ruleGroups", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = RemoveByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
                   Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Firewall Policy.", ParameterSetName = RemoveByParentInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicy FirewallPolicyObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the firewall policy", ParameterSetName = RemoveByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string AzureFirewallPolicyName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = "Firewall Policy Rule collection group object", ParameterSetName = RemoveByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicyRuleCollectionGroupWrapper InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource Id of the Rule collection groupy", ParameterSetName = RemoveByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/FirewallPolicies")]
        public virtual string ResourceId { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (this.IsParameterBound(c => c.FirewallPolicyObject))
            {
                this.AzureFirewallPolicyName = FirewallPolicyObject.Name;
                this.ResourceGroupName = FirewallPolicyObject.ResourceGroupName;
            }
            else if (this.IsParameterBound(c => c.InputObject))
            {
                this.Name = InputObject.Name;
                var resourceId = InputObject.Properties.Id;

                var resourceInfo = new ResourceIdentifier(resourceId);
                this.AzureFirewallPolicyName = resourceInfo.ParentResource.Split('/')[1];
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
            }
            else if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                this.Name = resourceInfo.ResourceName;
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.AzureFirewallPolicyName = resourceInfo.ParentResource.Split('/')[1];
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    this.AzureFirewallPolicyRuleGroupClient.Delete(this.ResourceGroupName, this.AzureFirewallPolicyName, this.Name);
                    {
                        if (this.PassThru.IsPresent)
                        {
                            WriteObject(true);
                        }

                    }
                });
        }
    }
}
