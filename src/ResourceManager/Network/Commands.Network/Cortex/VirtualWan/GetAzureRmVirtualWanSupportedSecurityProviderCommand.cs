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

namespace Microsoft.Azure.Commands.Network
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network;

    [Cmdlet(
        VerbsCommon.Get, 
        "AzureRmVirtualWanSupportedSecurityProvider", 
        SupportsShouldProcess = true,
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanName),
        OutputType(typeof(PSVirtualWanSecurityProvider))]
    public class GetAzureRmVirtualWanSupportedSecurityProviderCommand : VirtualWanBaseCmdlet
    {
        [Alias("ResourceName", "VirtualWanName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Alias("VirtualWan")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The vpn site object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSVirtualWan InputObject { get; set; }

        [Alias("VirtualWanId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId,
            Mandatory = true,
            HelpMessage = "The Azure resource ID for the virtual wan.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            //// Resolve the virtual wan
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.Name = parsedResourceId.ResourceName;
            }

            var supportedSecurityProviders = NetworkClient.NetworkManagementClient.SupportedSecurityProviders(this.ResourceGroupName, this.Name);
            WriteObject(supportedSecurityProviders.SupportedProviders);
        }
    }
}
