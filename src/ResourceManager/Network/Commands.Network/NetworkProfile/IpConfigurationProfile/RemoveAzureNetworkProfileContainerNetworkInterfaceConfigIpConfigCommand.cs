﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkProfileContainerNicConfigIpConfig", SupportsShouldProcess = true), OutputType(typeof(PSContainerNetworkInterfaceConfiguration))]
    public partial class RemoveAzureNetworkProfileContainerNetworkInterfaceConfigIpConfigCommand : NetworkBaseCmdlet 
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the Containter network interface configuration resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSContainerNetworkInterfaceConfiguration ContainerNetworkInterfaceConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the container network interface configuration ip configuration")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            // ContainerNetworkInterfaceConfigurations
            if (this.ContainerNetworkInterfaceConfiguration.IpConfigurations == null)
            {
                WriteObject(this.ContainerNetworkInterfaceConfiguration);
                return;
            }
            var vContainerNetworkInterfaceConfigurations = this.ContainerNetworkInterfaceConfiguration.IpConfigurations.First
                (e =>
                    (this.Name != null && e.Name == this.Name)
                );

            if (vContainerNetworkInterfaceConfigurations != null)
            {
                this.ContainerNetworkInterfaceConfiguration.IpConfigurations.Remove(vContainerNetworkInterfaceConfigurations);
            }

            if (this.ContainerNetworkInterfaceConfiguration.IpConfigurations.Count == 0)
            {
                this.ContainerNetworkInterfaceConfiguration.IpConfigurations = null;
            }
            WriteObject(this.ContainerNetworkInterfaceConfiguration, true);
        }
    }
}
