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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;

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

                // Get the NIC
                var nicResourceGroupName =
                    this.GetResourceGroupName(vmResponse.VirtualMachine.NetworkProfile.NetworkInterfaces.First().ReferenceUri);

                var nicName =
                    this.GetResourceName(
                        vmResponse.VirtualMachine.NetworkProfile.NetworkInterfaces.First().ReferenceUri, "networkInterfaces");

                var nicResponse =
                    this.NetworkClient.NetworkResourceProviderClient.NetworkInterfaces.Get(nicResourceGroupName, nicName);

                if (nicResponse.NetworkInterface.IpConfigurations.First().PublicIpAddress != null && !string.IsNullOrEmpty(nicResponse.NetworkInterface.IpConfigurations.First().PublicIpAddress.Id))
                {
                    // Get PublicIPAddress resource if present
                    address = this.GetAddressFromPublicIPResource(nicResponse.NetworkInterface.IpConfigurations.First().PublicIpAddress.Id);
                }
                else if (nicResponse.NetworkInterface.IpConfigurations.First().LoadBalancerInboundNatRules.Any())
                {
                    address = string.Empty;

                    // Get ipaddress and port from loadbalancer
                    foreach (var nicRuleRef in nicResponse.NetworkInterface.IpConfigurations.First().LoadBalancerInboundNatRules)
                    {
                        var lbName = this.GetResourceName(nicRuleRef.Id, "loadBalancers");
                        var lbResourceGroupName = this.GetResourceGroupName(nicRuleRef.Id);

                        var loadbalancer =
                            this.NetworkClient.NetworkResourceProviderClient.LoadBalancers.Get(lbResourceGroupName, lbName).LoadBalancer;

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
                            port = inboundRule.First().FrontendPort;

                            // Get the corresponding frontendIPConfig -> publicIPAddress
                            var frontendIPConfig =
                                loadbalancer.FrontendIpConfigurations.First(
                                    frontend =>
                                    string.Equals(
                                        inboundRule.First().FrontendIPConfiguration.Id,
                                        frontend.Id,
                                        StringComparison.OrdinalIgnoreCase));

                            if (frontendIPConfig.PublicIpAddress != null)
                            {
                                address = this.GetAddressFromPublicIPResource(frontendIPConfig.PublicIpAddress.Id);
                                break;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(address))
                    {
                        throw new ArgumentException(Properties.Resources.VirtualMachineNotAssociatedWithPublicLoadBalancer);
                    }
                }
                else
                {
                    throw new ArgumentException(Properties.Resources.VirtualMachineNotAssociatedWithPublicIPOrPublicLoadBalancer);
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
                            writer.WriteLine("del " + rdpFilePath);
                            writer.WriteLine("del " + launchRDPScript);
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
            var publicIPName = this.GetResourceName(resourceId, "publicIPAddresses");

            var publicIpResponse =
                this.NetworkClient.NetworkResourceProviderClient.PublicIpAddresses.Get(
                    publicIPResourceGroupName,
                    publicIPName);


            // Use the FQDN if present
            if (publicIpResponse.PublicIpAddress.DnsSettings != null
                && !string.IsNullOrEmpty(publicIpResponse.PublicIpAddress.DnsSettings.Fqdn))
            {
                address = publicIpResponse.PublicIpAddress.DnsSettings.Fqdn;
            }
            else
            {
                address = publicIpResponse.PublicIpAddress.IpAddress;
            }

            return address;
        }
        private string GetResourceGroupName(string resourceId)
        {
            return resourceId.Split('/')[4];
        }

        private string GetResourceName(string resourceId, string resource)
        {
            return resourceId.Split('/')[8];
        }
    }
}
