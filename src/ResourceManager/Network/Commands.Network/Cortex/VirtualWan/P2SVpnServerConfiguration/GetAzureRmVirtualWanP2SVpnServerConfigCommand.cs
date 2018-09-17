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
    [Cmdlet(VerbsCommon.Get, "AzureRmP2SVpnServerConfiguration"), OutputType(typeof(PSP2SVpnServerConfiguration))]
    public class GetAzureRmVirtualWanP2SVpnServerConfigCommand : VirtualWanBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            HelpMessage = "The name of the parent VirtualWan this P2SVpnServerConfiguration is associated with.")]
        public string VirtualWanName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("VirtualWan")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
            HelpMessage = "The VirtualWan this P2SVpnServerConfiguration is associated with.")]
        public PSVirtualWan InputObject { get; set; }

        [Alias("VirtualWanId")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId,
            HelpMessage = "The Id of the parent VirtualWan this P2SVpnServerConfiguration is associated with.")]
        [ResourceIdCompleter("Microsoft.Network/virtualWans")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the p2sVpnServerConfiguration")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            //// Verify the parent virtual wan exists
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanObject, StringComparison.OrdinalIgnoreCase))
            {
                this.VirtualWanName = this.InputObject.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.VirtualWanName = parsedResourceId.ResourceName;
            }

            //// At this point, we should have the virtual Wan name resolved. Fail this operation if it is not.
            if (string.IsNullOrWhiteSpace(this.VirtualWanName))
            {
                throw new PSArgumentException("A valid Parent VirtualWan reference is required to get the associated P2SVpnServerConfiguration.");
            }

            var parentVirtualWan = new VirtualWanBaseCmdlet().GetVirtualWan(this.ResourceGroupName, this.VirtualWanName);

            if (!string.IsNullOrEmpty(this.Name))
            {
                var p2sVpnServerConfig = this.GetVirtualWanP2SVpnServerConfiguration(parentVirtualWan.ResourceGroupName, parentVirtualWan.Name, this.Name);

                WriteObject(p2sVpnServerConfig);
            }
            else
            {
                // Get the list of all P2SVpnserverConfigurations associated with Virtual Wan
                var psP2SVpnServerConfigurations = new List<PSP2SVpnServerConfiguration>();
                psP2SVpnServerConfigurations = this.ListVirtualWanP2SVpnServerConfigurations(parentVirtualWan.ResourceGroupName, parentVirtualWan.Name);

                WriteObject(psP2SVpnServerConfigurations, true);
            }
        }
    }
}
