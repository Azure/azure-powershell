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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyKubeSelectorGroup", SupportsShouldProcess = true, DefaultParameterSetName = SetByNameParameterSet), OutputType(typeof(PSAzureFirewallPolicyKubeSelectorGroupWrapper))]
    public class SetAzureFirewallPolicyKubeSelectorGroupCommand : AzureFirewallPolicyKubeSelectorGroupBaseCmdlet
    {
        private const string SetByNameParameterSet = "SetByNameParameterSet";
        private const string SetByInputObjectParameterSet = "SetByInputObjectParameterSet";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the Kube Selector Group", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The pod selector that matches Kubernetes pods by their labels.")]
        public PSKubeLabelSelector PodSelector { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The namespace selector that matches Kubernetes namespaces by their labels.")]
        public PSKubeLabelSelector NamespaceSelector { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the firewall policy", ParameterSetName = SetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string FirewallPolicyName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Kube Selector Group object to update.", ParameterSetName = SetByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicyKubeSelectorGroupWrapper InputObject { get; set; }

        public override void Execute()
        {
            base.Execute();

            var podSelector = this.PodSelector;
            var namespaceSelector = this.NamespaceSelector;

            if (this.IsParameterBound(c => c.InputObject))
            {
                this.Name = InputObject.Name;
                var resourceInfo = new ResourceIdentifier(InputObject.Properties.Id);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.FirewallPolicyName = resourceInfo.ParentResource.Split('/')[1];

                podSelector = podSelector ?? InputObject.Properties.PodSelector;
                namespaceSelector = namespaceSelector ?? InputObject.Properties.NamespaceSelector;
            }

            var sdkModel = this.BuildSdkModel(podSelector, namespaceSelector);
            var response = this.KubeSelectorGroupClient.CreateOrUpdate(this.ResourceGroupName, this.FirewallPolicyName, this.Name, sdkModel);
            WriteObject(ToPSWrapper(response));
        }
    }
}
