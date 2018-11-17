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
using Microsoft.Azure.Management.Network;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, 
        "AzureRmVirtualNetworkGatewayConnectionVpnDeviceConfigScript",
        SupportsShouldProcess = true), 
        OutputType(typeof(string))]
    public class GetAzureRmVirtualNetworkGatewayConnectionVpnDeviceConfigScript : VirtualNetworkGatewayConnectionBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name of the connection for which the configuration is to be generated.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }
        
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the VPN device vendor.")]
        [ValidateNotNullOrEmpty]
        public string DeviceVendor { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the VPN device model/family.")]
        [ValidateNotNullOrEmpty]
        public string DeviceFamily { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Firmware version of the VPN device.")]
        [ValidateNotNullOrEmpty]
        public string FirmwareVersion { get; set; }

        public override void Execute()
        {
            base.Execute();

            MNM.VpnDeviceScriptParameters vpnDeviceScriptParameter = new MNM.VpnDeviceScriptParameters()
            {
                DeviceFamily = this.DeviceFamily,
                FirmwareVersion = this.FirmwareVersion,
                Vendor = this.DeviceVendor
            };

            string vpnDeviceConfigurationScript = NetworkClient.NetworkManagementClient.VirtualNetworkGateways
                .VpnDeviceConfigurationScript(
                    this.ResourceGroupName,
                    this.Name,
                    vpnDeviceScriptParameter);

            WriteObject(vpnDeviceConfigurationScript);
        }
    }
}
