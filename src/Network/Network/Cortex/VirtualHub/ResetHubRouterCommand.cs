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

namespace Microsoft.Azure.Commands.Network
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Text;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet(VerbsCommon.Reset,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "HubRouter",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualHub))]
    public class ResetHubRouterCommand : VirtualHubBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VirtualHubName", "HubName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The virtual hub name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VirtualHubId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId,
            HelpMessage = "The resource id of the Virtual hub.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("VirtualHub")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The Virtual hub object.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualHub InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            PSVirtualHub virtualHub = null;

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                var inputVirtualHub = this.InputObject;
                this.ResourceGroupName = inputVirtualHub.ResourceGroupName;
                this.Name = inputVirtualHub.Name;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    this.Name = parsedResourceId.ResourceName;
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                }
            }

            // always do an explicit Get and use this object to trigger a Put if needed.
            virtualHub = this.GetVirtualHub(this.ResourceGroupName, this.Name);
            if (virtualHub == null)
            {
                throw new PSArgumentException(Properties.Resources.VirtualHubToUpdateNotFound);
            }

            if (string.Equals(virtualHub.RoutingState, MNM.RoutingState.Provisioned.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                WriteVerbose($"The virtual hub routing state is already Provisioned. Nothing to do.");
                WriteObject(virtualHub);
                return;
            }

            // trigger the Put on the VirtualHub
            ConfirmAction(
                Properties.Resources.SettingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateOrUpdateVirtualHub(
                        this.ResourceGroupName,
                        this.Name,
                        virtualHub,
                        null));
                });
        }
    }
}
