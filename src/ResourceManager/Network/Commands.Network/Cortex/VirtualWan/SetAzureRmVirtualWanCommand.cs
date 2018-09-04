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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.Network.VirtualNetworkGateway;
using Microsoft.WindowsAzure.Commands.Common;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Linq;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set,
        "AzureRmVirtualWan",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualWan))]
    public class SetAzureRmVirtualWanCommand : VirtualWanBaseCmdlet
    {
        [Alias("ResourceName", "VirtualWanName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            HelpMessage = "The virtual wan name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual wan object to be modified")]
        [ValidateNotNullOrEmpty]
        public PSVirtualWan VirtualWan { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the VirtualWan to be modified.")]
        [ValidateNotNullOrEmpty]
        public string VirtualWanId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of PSP2SVpnServerConfigurations that are associated with this VirtualWan.")]
        public List<PSP2SVpnServerConfiguration> P2SVpnServerConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanObject))
            {
                Name = VirtualWan.Name;
                ResourceGroupName = VirtualWan.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(VirtualWanId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            //// Let's get the existing VirtualWan - this will throw not found if the VirtualWan does not exist
            var existingVirtualWan = this.GetVirtualWan(this.ResourceGroupName, this.Name);

            if (existingVirtualWan == null)
            {
                throw new PSArgumentException("The VirtualWan to modify could not be found");
            }

            // Modify the P2SVpnServerConfigurations
            existingVirtualWan.P2SVpnServerConfigurations = this.P2SVpnServerConfiguration;

            ConfirmAction(
                                this.Force.IsPresent,
                                string.Format(Properties.Resources.SettingResourceMessage, this.Name),
                                Properties.Resources.SettingResourceMessage,
                                this.Name,
                                () =>
                                {
                                    WriteObject(this.CreateOrUpdateVirtualWan(this.ResourceGroupName, this.Name, existingVirtualWan, this.Tag));
                                });
        }
    }
}