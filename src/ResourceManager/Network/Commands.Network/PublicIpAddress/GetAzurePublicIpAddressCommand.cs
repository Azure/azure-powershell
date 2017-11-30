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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmPublicIpAddress", DefaultParameterSetName = "NoExpandStandAloneIp"), OutputType(typeof(PSPublicIpAddress))]
    public class GetAzurePublicIpAddressCommand : PublicIpAddressBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpandStandAloneIp")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "ExpandStandAloneIp")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpandScaleSetIp")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "ExpandScaleSetIp")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpandStandAloneIp")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "ExpandStandAloneIp")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpandScaleSetIp")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "ExpandScaleSetIp")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine Scale Set Name.",
            ParameterSetName = "NoExpandScaleSetIp")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine Scale Set Name.",
            ParameterSetName = "ExpandScaleSetIp")]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineScaleSetName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine Index.",
            ParameterSetName = "NoExpandScaleSetIp")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine Index.",
            ParameterSetName = "ExpandScaleSetIp")]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineIndex { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine Network Interface Name.",
            ParameterSetName = "NoExpandScaleSetIp")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine Network Interface Name.",
            ParameterSetName = "ExpandScaleSetIp")]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Network Interface IP Configuration Name.",
            ParameterSetName = "NoExpandScaleSetIp")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Network Interface IP Configuration Name.",
            ParameterSetName = "ExpandScaleSetIp")]
        [ValidateNotNullOrEmpty]
        public string IpConfigurationName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "ExpandStandAloneIp")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "ExpandScaleSetIp")]
        [ValidateNotNullOrEmpty]
        public string ExpandResource { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!string.IsNullOrEmpty(this.Name))
            {
                PSPublicIpAddress publicIp;
                if (ParameterSetName.Contains("ScaleSetIp"))
                {
                    var publicIpVmss = PublicIpAddressClient.GetVirtualMachineScaleSetPublicIPAddress(
                        this.ResourceGroupName, this.VirtualMachineScaleSetName, this.VirtualMachineIndex, this.NetworkInterfaceName, this.IpConfigurationName, this.Name, this.ExpandResource);
                    publicIp = ToPsPublicIpAddress(publicIpVmss);
                    publicIp.ResourceGroupName = this.ResourceGroupName;
                    publicIp.Tag = TagsConversionHelper.CreateTagHashtable(publicIpVmss.Tags);
                }
                else
                {
                    publicIp = this.GetPublicIpAddress(this.ResourceGroupName, this.Name, this.ExpandResource);
                }

                WriteObject(publicIp);
            }
            else
            {
                IPage<PublicIPAddress> publicipPage;
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    if (ParameterSetName.Contains("ScaleSetIp"))
                    {
                        if (string.IsNullOrEmpty(this.VirtualMachineIndex))
                        {
                            publicipPage =
                                this.PublicIpAddressClient.ListVirtualMachineScaleSetPublicIPAddresses(
                                    this.ResourceGroupName,
                                    this.VirtualMachineScaleSetName);
                        }
                        else
                        {
                            publicipPage =
                                this.PublicIpAddressClient.ListVirtualMachineScaleSetVMPublicIPAddresses(
                                    this.ResourceGroupName,
                                    this.VirtualMachineScaleSetName,
                                    this.VirtualMachineIndex,
                                    this.NetworkInterfaceName,
                                    this.IpConfigurationName);
                        }
                    }
                    else
                    {
                        publicipPage = this.PublicIpAddressClient.List(this.ResourceGroupName);
                    }
                }
                else
                {
                    publicipPage = this.PublicIpAddressClient.ListAll();
                }

                // Get all resources by polling on next page link
                List<PublicIPAddress> publicIPList;
                if (ParameterSetName.Contains("ScaleSetIp"))
                {
                    if (string.IsNullOrEmpty(this.VirtualMachineIndex))
                    {
                        publicIPList = ListNextLink<PublicIPAddress>.GetAllResourcesByPollingNextLink(publicipPage, this.PublicIpAddressClient.ListVirtualMachineScaleSetPublicIPAddressesNext);
                    }
                    else
                    {
                        publicIPList = ListNextLink<PublicIPAddress>.GetAllResourcesByPollingNextLink(publicipPage, this.PublicIpAddressClient.ListVirtualMachineScaleSetVMPublicIPAddressesNext);
                    }
                }
                else
                {
                    publicIPList = ListNextLink<PublicIPAddress>.GetAllResourcesByPollingNextLink(publicipPage, this.PublicIpAddressClient.ListNext);
                }

                var psPublicIps = new List<PSPublicIpAddress>();

                // populate the publicIpAddresses with the ResourceGroupName
                foreach (var publicIp in publicIPList)
                {
                    var psPublicIp = this.ToPsPublicIpAddress(publicIp);
                    psPublicIp.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(publicIp.Id);
                    psPublicIps.Add(psPublicIp);
                }

                WriteObject(psPublicIps, true);
            }
        }
    }
}
