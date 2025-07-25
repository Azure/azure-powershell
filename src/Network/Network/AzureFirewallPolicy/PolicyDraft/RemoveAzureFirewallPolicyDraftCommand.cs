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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyDraft", SupportsShouldProcess = true, DefaultParameterSetName = RemoveByNameParameterSet), OutputType(typeof(bool))]
    public class RemoveAzureFirewallPolicyDraftCommand : AzureFirewallPolicyDraftCmdlet
    {
        private const string RemoveByNameParameterSet = "RemoveByNameParameterSet";
        private const string RemoveByParentInputObjectParameterSet = "RemoveByParentInputObjectParameterSet";
        private const string RemoveByInputObjectParameterSet = "RemoveByInputObjectParameterSet";
        private const string RemoveByResourceIdParameterSet = "RemoveByResourceIdParameterSet";

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the firewallPolicy.", ParameterSetName = RemoveByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string AzureFirewallPolicyName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = RemoveByNameParameterSet)]
        [ValidateNotNullOrEmpty]
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
            HelpMessage = "The resource Id.", ParameterSetName = RemoveByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The AzureFirewall Policy draft", ParameterSetName = RemoveByInputObjectParameterSet)]
        public PSAzureFirewallPolicyDraft InputObject { get; set; }

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
            if (this.IsParameterBound(c => c.FirewallPolicyObject))
            {
                this.AzureFirewallPolicyName = FirewallPolicyObject.Name;
                this.ResourceGroupName = FirewallPolicyObject.ResourceGroupName;
            }

            else if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                AzureFirewallPolicyName = ExtractFirewallPolicyNameFromDraftResourceId(resourceInfo.ParentResource);
            }

            else if (this.IsParameterBound(c => c.InputObject))
            {
                var resourceId = InputObject.Id;
                var resourceInfo = new ResourceIdentifier(resourceId);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.AzureFirewallPolicyName = ExtractFirewallPolicyNameFromDraftResourceId(resourceInfo.ParentResource);
            }

            base.Execute();
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, AzureFirewallPolicyName + " draft"),
                Properties.Resources.RemoveResourceMessage,
                AzureFirewallPolicyName,
                () =>
                {
                    this.AzureFirewallPolicyDraftClient.Delete(this.ResourceGroupName, this.AzureFirewallPolicyName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
