// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Add, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkInterfaceTapConfig", DefaultParameterSetName = "SetByResource", SupportsShouldProcess = true), OutputType(typeof(PSNetworkInterface))]
    public partial class AddAzureRmNetworkInterfaceTapConfigCommand : NetworkInterfaceTapConfigBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the network interface resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSNetworkInterface NetworkInterface { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the tap configuration.")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The reference of the virtual network tap resource.",
            ValueFromPipelineByPropertyName = true)]
        public string VirtualNetworkTapId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResource",
            HelpMessage = "The reference of the virtual network tap resource.",
            ValueFromPipelineByPropertyName = true)]
        public PSVirtualNetworkTap VirtualNetworkTap { get; set; }


        public override void Execute()
        {
            var existingTapConfiguration = this.NetworkInterface.TapConfigurations.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));
            if (existingTapConfiguration != null)
            {
                throw new ArgumentException("TapConfiguration with the specified name already exists");
            }

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.VirtualNetworkTap != null)
                {
                    this.VirtualNetworkTapId = this.VirtualNetworkTap.Id;
                }
            }

            var vTapConfiguration = new PSNetworkInterfaceTapConfiguration();

            vTapConfiguration.Name = this.Name;
            if(!string.IsNullOrEmpty(this.VirtualNetworkTapId))
            {
                // VirtualNetworkTap
                if (vTapConfiguration.VirtualNetworkTap == null)
                {
                    vTapConfiguration.VirtualNetworkTap = new PSVirtualNetworkTap();
                }
                vTapConfiguration.VirtualNetworkTap.Id = this.VirtualNetworkTapId;
            }

            // Map to the sdk object
            var tapConfigurationModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkInterfaceTapConfiguration>(vTapConfiguration);

            this.NetworkInterfaceTapClient.CreateOrUpdate(this.NetworkInterface.ResourceGroupName, this.NetworkInterface.Name, this.Name, tapConfigurationModel);

            var getTapConfiguration = this.GetNetworkInterfaceTapConfiguration(this.NetworkInterface.ResourceGroupName, this.NetworkInterface.Name, this.Name);

            WriteObject(getTapConfiguration);
        }
    }
}
