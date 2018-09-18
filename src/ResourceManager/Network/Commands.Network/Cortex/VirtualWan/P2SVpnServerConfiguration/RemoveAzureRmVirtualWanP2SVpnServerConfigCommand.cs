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
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove,
        "AzureRmP2sVpnServerConfiguration",
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzureRmVirtualWanP2sVpnServerConfigCommand : VirtualWanBaseCmdlet
    {
        [Alias("ResourceName", "P2SVpnServerConfigurationName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("ParentVirtualWanName", "VirtualWanName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationName,
            HelpMessage = "The parent resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ParentResourceName { get; set; }

        [Alias("P2SVpnServerConfigurationId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationResourceId,
            HelpMessage = "The resource id of the P2SVpnServerConfiguration object to delete.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("P2SVpnServerConfiguration")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByP2SVpnServerConfigurationObject,
            HelpMessage = "The P2SVpnServerConfiguration object to update.")]
        public PSP2SVpnServerConfiguration InputObject { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnServerConfigurationName, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ResourceGroupName;
                this.ParentResourceName = this.ParentResourceName;
                this.Name = this.Name;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByP2SVpnServerConfigurationObject, StringComparison.OrdinalIgnoreCase))
                {
                    this.ResourceId = this.InputObject.Id;
                }

                //// At this point, the resource id should not be null. If it is, customer did not specify a valid resource to delete.
                if (string.IsNullOrWhiteSpace(this.ResourceId))
                {
                    throw new PSArgumentException("No P2SVpnServerConfiguration specified. Nothing will be deleted.");
                }

                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }

            //// Get the Parent VirtualWan object - this will throw not found if the object is not found
            PSVirtualWan parentVirtualWan = this.GetVirtualWan(this.ResourceGroupName, this.ParentResourceName);

            if (parentVirtualWan == null ||
                parentVirtualWan.P2sVpnServerConfigurations == null ||
                !parentVirtualWan.P2sVpnServerConfigurations.Any(p2sVpnServerConfiguration => p2sVpnServerConfiguration.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSArgumentException("The P2SVpnServerConfiguration to delete and/or Parent VirtualWan could not be found.");
            }

            base.Execute();

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, this.Name),
                Properties.Resources.RemoveResourceMessage,
                this.Name,
                () =>
                {
                    this.DeleteVirtualWanP2SVpnServerConfiguration(this.ResourceGroupName, this.ParentResourceName, this.Name);
                });

            WriteObject(true);
        }
    }
}
