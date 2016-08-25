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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Get, ProfileNouns.RemoteDesktopFile)]
    public class GetAzureRemoteDesktopFileCommand : VirtualMachineRemoteDesktopBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VMName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path and name of the output RDP file.",
            ParameterSetName = "Download")]
        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path and name of the output RDP file.",
            ParameterSetName = "Launch")]
        [ValidateNotNullOrEmpty]
        public string LocalPath { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 3,
            HelpMessage = "Start a remote desktop session to the specified role instance.",
            ParameterSetName = "Launch")]
        public SwitchParameter Launch
        {
            get;
            set;
        }

        const string PublicIPAddressResource = "publicIPAddresses";
        const string NetworkInterfaceResouce = "networkInterfaces";
        const string LoadBalancerResouce = "loadBalancers";

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                const string fullAddressPrefix = "full address:s:";
                const string promptCredentials = "prompt for credentials:i:1";
                const int defaultPort = 3389;

                string address = string.Empty;
                int port = defaultPort;

                // Get Azure VM
                var vmResponse = this.VirtualMachineClient.Get(this.ResourceGroupName, this.Name);

                var nicId = vmResponse.NetworkProfile.NetworkInterfaces.First().Id;

                // Get the NIC
                var nicResourceGroupName = this.GetResourceGroupName(nicId);

                var nicName = this.GetResourceName(nicId, NetworkInterfaceResouce);

                var nic = this.NetworkClient.NetworkManagementClient.NetworkInterfaces.Get(nicResourceGroupName, nicName);

                if (nic.IpConfigurations.First().PublicIPAddress != null && !string.IsNullOrEmpty(nic.IpConfigurations.First().PublicIPAddress.Id))
                {
                    // Get PublicIPAddress resource if present
                    address = this.GetAddressFromPublicIPResource(nic.IpConfigurations.First().PublicIPAddress.Id);
                }
                else if (nic.IpConfigurations.First().LoadBalancerInboundNatRules.Any())
                {
                    address = string.Empty;

                    // Get ipaddress and port from loadbalancer
                    foreach (var nicRuleRef in nic.IpConfigurations.First().LoadBalancerInboundNatRules)
                    {
                        var lbName = this.GetResourceName(nicRuleRef.Id, LoadBalancerResouce);
                        var lbResourceGroupName = this.GetResourceGroupName(nicRuleRef.Id);

                        var loadbalancer =
                            this.NetworkClient.NetworkManagementClient.LoadBalancers.Get(lbResourceGroupName, lbName);

                        // Iterate over the InboundNatRules where Backendport = 3389
                        var inboundRule =
                            loadbalancer.InboundNatRules.Where(
                                rule =>
                                rule.BackendPort == defaultPort
                                && string.Equals(
                                    rule.Id,
                                    nicRuleRef.Id,
                                    StringComparison.OrdinalIgnoreCase));

                        if (inboundRule.Any())
                        {
                            port = inboundRule.First().FrontendPort.Value;

                            // Get the corresponding frontendIPConfig -> publicIPAddress
                            var frontendIPConfig =
                                loadbalancer.FrontendIPConfigurations.First(
                                    frontend =>
                                    string.Equals(
                                        inboundRule.First().FrontendIPConfiguration.Id,
                                        frontend.Id,
                                        StringComparison.OrdinalIgnoreCase));

                            if (frontendIPConfig.PublicIPAddress != null)
                            {
                                address = this.GetAddressFromPublicIPResource(frontendIPConfig.PublicIPAddress.Id);
                                break;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(address))
                    {
                        throw new ArgumentException(Microsoft.Azure.Commands.Compute.Properties.Resources.VirtualMachineNotAssociatedWithPublicLoadBalancer);
                    }
                }
                else
                {
                    throw new ArgumentException(Microsoft.Azure.Commands.Compute.Properties.Resources.VirtualMachineNotAssociatedWithPublicIPOrPublicLoadBalancer);
                }

                // Write to file
                string rdpFilePath = this.LocalPath ?? Path.GetTempFileName();

                using (var file = new StreamWriter(rdpFilePath))
                {
                    file.WriteLine(fullAddressPrefix + address + ":" + port);
                    file.WriteLine(promptCredentials);
                }

                if (Launch.IsPresent)
                {
                    var startInfo = new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    if (this.LocalPath == null)
                    {
                        string scriptGuid = Guid.NewGuid().ToString();

                        string launchRDPScript = Path.GetTempPath() + scriptGuid + ".bat";
                        using (var scriptStream = File.OpenWrite(launchRDPScript))
                        {
                            var writer = new StreamWriter(scriptStream);
                            writer.WriteLine("start /wait mstsc.exe " + rdpFilePath);
                            writer.Flush();
                        }

                        startInfo.FileName = launchRDPScript;
                    }
                    else
                    {
                        startInfo.FileName = "mstsc.exe";
                        startInfo.Arguments = rdpFilePath;
                    }

                    Process.Start(startInfo);
                }
            });
        }

        private string GetAddressFromPublicIPResource(string resourceId)
        {
            string address = string.Empty;

            // Get IpAddress from public IPAddress resource
            var publicIPResourceGroupName = this.GetResourceGroupName(resourceId);
            var publicIPName = this.GetResourceName(resourceId, PublicIPAddressResource);

            var publicIp =
                this.NetworkClient.NetworkManagementClient.PublicIPAddresses.Get(
                    publicIPResourceGroupName,
                    publicIPName);


            // Use the FQDN if present
            if (publicIp.DnsSettings != null && !string.IsNullOrEmpty(publicIp.DnsSettings.Fqdn))
            {
                address = publicIp.DnsSettings.Fqdn;
            }
            else
            {
                address = publicIp.IpAddress;
            }

            return address;
        }
        private string GetResourceGroupName(string resourceId)
        {
            return resourceId.Split('/')[4];
        }

        private string GetResourceName(string resourceId, string resource)
        {
            int resourceTypeLocation = resourceId.IndexOf(resource, StringComparison.OrdinalIgnoreCase);

            var resourceName = resourceId.Substring(resourceTypeLocation + resource.Length + 1);
            if (resourceName.Contains("/"))
            {
                int resourceNameEnd = resourceName.IndexOf("/");
                resourceName = resourceName.Substring(0, resourceNameEnd);
            }

            return resourceName;
        }
    }
}
