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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LoadBalancerBackendAddressPoolTunnelInterfaceConfig", SupportsShouldProcess = true), OutputType(typeof(PSTunnelInterface))]
    public partial class NewAzureRmLoadBalancerBackendAddressPoolTunnelInterfaceConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Protocol of the backend address pool TunnelInterface.")]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Type of the backend address pool TunnelInterface.")]
        public string Type { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Identifier of the backend address pool TunnelInterface.")]
        public int Identifier { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Port of the backend address pool TunnelInterface.")]
        public int Port { get; set; }

        public override void Execute()
        {
            // Validation will be on server side
            var vTunnelInterface = new PSTunnelInterface();

            vTunnelInterface.Protocol = this.Protocol;
            vTunnelInterface.Type = this.Type;
            vTunnelInterface.Identifier = this.Identifier;
            vTunnelInterface.Port = this.Port;

            WriteObject(vTunnelInterface, true);
        }
    }
}