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
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Resources.Models;
using MNM = Microsoft.Azure.Management.Network.Models;
using System.Collections;
using Microsoft.Azure.Commands.Tags.Model;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmVpnClientPackage"), OutputType(typeof(string))]
    public class GetAzureVpnClientPackage : VirtualNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "ResourceGroup name")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "VirtualNetworkGateway name")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "ProcessorArchitecture")]
        [ValidateSet(
        MNM.ProcessorArchitecture.Amd64,
        MNM.ProcessorArchitecture.X86,
        IgnoreCase = true)]
        public string ProcessorArchitecture { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.IsVirtualNetworkGatewayPresent(ResourceGroupName, VirtualNetworkGatewayName))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            PSVpnClientParameters vpnClientParams = new PSVpnClientParameters();
            vpnClientParams.ProcessorArchitecture = this.ProcessorArchitecture;
            var vnetVpnClientParametersModel = Mapper.Map<MNM.VpnClientParameters>(vpnClientParams);

            string packageUrl = this.VirtualNetworkGatewayClient.Generatevpnclientpackage(ResourceGroupName, VirtualNetworkGatewayName, vnetVpnClientParametersModel);

            WriteObject(packageUrl);
        }
    }
}

