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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "P2SVpnServerConfiguration",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanName),
        OutputType(typeof(PSP2SVpnServerConfiguration))]
    public class GetAzureRmVirtualWanP2SVpnServerConfigCommand : VirtualWanBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("ParentVirtualWanName", "VirtualWanName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            HelpMessage = "The name of the parent VirtualWan this P2SVpnServerConfiguration is associated with.")]
        public string ParentResourceName { get; set; }

        [Alias("ParentVirtualWan", "VirtualWan")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
            HelpMessage = "The VirtualWan this P2SVpnServerConfiguration is associated with.")]
        public PSVirtualWan ParentObject { get; set; }

        [Alias("ParentVirtualWanId", "VirtualWanId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId,
            HelpMessage = "The Id of the parent VirtualWan this P2SVpnServerConfiguration is associated with.")]
        [ResourceIdCompleter("Microsoft.Network/virtualWans")]
        [ValidateNotNullOrEmpty]
        public string ParentResourceId { get; set; }

        [Alias("ResourceName", "P2SVpnServerConfigurationName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the P2SVpnServerConfiguration")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            //// Verify the parent virtual wan exists
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ParentObject.ResourceGroupName;
                this.ParentResourceName = this.ParentObject.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ParentResourceName = parsedResourceId.ResourceName;
            }

            //// At this point, we should have the virtual Wan name resolved. Fail this operation if it is not.
            if (string.IsNullOrWhiteSpace(this.ParentResourceName))
            {
                throw new PSArgumentException(Properties.Resources.ParentVirtualWanRequiredForP2SVpnServerConfig);
            }

            if (!string.IsNullOrWhiteSpace(this.Name))
            {
                WriteObject(this.GetVirtualWanP2SVpnServerConfiguration(this.ResourceGroupName, this.ParentResourceName, this.Name));
            }
            else
            {
                WriteObject(this.ListVirtualWanP2SVpnServerConfigurations(this.ResourceGroupName, this.ParentResourceName), true);
            }
        }
    }
}
