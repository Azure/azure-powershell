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
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FirewallPolicyKubeSelectorGroup", SupportsShouldProcess = true, DefaultParameterSetName = RemoveByNameParameterSet), OutputType(typeof(bool))]
    public class RemoveAzureFirewallPolicyKubeSelectorGroupCommand : AzureFirewallPolicyKubeSelectorGroupBaseCmdlet
    {
        private const string RemoveByNameParameterSet = "RemoveByNameParameterSet";
        private const string RemoveByInputObjectParameterSet = "RemoveByInputObjectParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Kube Selector Group", ParameterSetName = RemoveByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.", ParameterSetName = RemoveByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the firewall policy", ParameterSetName = RemoveByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public virtual string FirewallPolicyName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Kube Selector Group object to remove.", ParameterSetName = RemoveByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public PSAzureFirewallPolicyKubeSelectorGroupWrapper InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.Name = InputObject.Name;
                var resourceInfo = new ResourceIdentifier(InputObject.Properties.Id);
                this.ResourceGroupName = resourceInfo.ResourceGroupName;
                this.FirewallPolicyName = resourceInfo.ParentResource.Split('/')[1];
            }

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    this.KubeSelectorGroupClient.Delete(this.ResourceGroupName, this.FirewallPolicyName, this.Name);
                    if (this.PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
