﻿

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
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmNetworkInterface", DefaultParameterSetName = "NoExpandStandAloneNic"), OutputType(typeof(PSNetworkInterface))]
    public class GetAzureNetworkInterfaceCommand : NetworkInterfaceBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpandStandAloneNic")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "ExpandStandAloneNic")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpandScaleSetNic")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "ExpandScaleSetNic")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpandStandAloneNic")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "ExpandStandAloneNic")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpandScaleSetNic")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "ExpandScaleSetNic")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine Scale Set Name.",
            ParameterSetName = "NoExpandScaleSetNic")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine Scale Set Name.",
            ParameterSetName = "ExpandScaleSetNic")]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineScaleSetName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine Index.",
            ParameterSetName = "NoExpandScaleSetNic")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual Machine Index.",
            ParameterSetName = "ExpandScaleSetNic")]
        [ValidateNotNullOrEmpty]
        public string VirtualMachineIndex { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "ExpandStandAloneNic")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "ExpandScaleSetNic")]
        [ValidateNotNullOrEmpty]
        public string ExpandResource { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!string.IsNullOrEmpty(this.Name))
            {
                PSNetworkInterface networkInterface;

                if (ParameterSetName.Contains("ScaleSetNic"))
                {
                    networkInterface = this.GetScaleSetNetworkInterface(this.ResourceGroupName, this.VirtualMachineScaleSetName, this.VirtualMachineIndex, this.Name, this.ExpandResource);
                }
                else
                {
                    networkInterface = this.GetNetworkInterface(this.ResourceGroupName, this.Name, this.ExpandResource);
                }

                WriteObject(networkInterface);
            }
            else
            {
                IPage<MNM.NetworkInterface> nicPage;
                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    if (ParameterSetName.Contains("ScaleSetNic"))
                    {
                        if (string.IsNullOrEmpty(this.VirtualMachineIndex))
                        {
                            nicPage =
                                this.NetworkInterfaceClient.ListVirtualMachineScaleSetNetworkInterfaces(
                                    this.ResourceGroupName,
                                    this.VirtualMachineScaleSetName);
                        }
                        else
                        {
                            nicPage =
                                this.NetworkInterfaceClient.ListVirtualMachineScaleSetVMNetworkInterfaces(
                                    this.ResourceGroupName,
                                    this.VirtualMachineScaleSetName,
                                    this.VirtualMachineIndex);
                        }
                    }
                    else
                    {
                        nicPage = this.NetworkInterfaceClient.List(this.ResourceGroupName);
                    }                    
                }

                else
                {
                    nicPage = this.NetworkInterfaceClient.ListAll();
                }

                // Get all resources by polling on next page link
                var nicList = ListNextLink<NetworkInterface>.GetAllResourcesByPollingNextLink(nicPage, this.NetworkInterfaceClient.ListNext);

                var psNetworkInterfaces = new List<PSNetworkInterface>();

                foreach (var nic in nicList)
                {
                    var psNic = this.ToPsNetworkInterface(nic);
                    psNic.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(psNic.Id);
                    psNetworkInterfaces.Add(psNic);
                }

                WriteObject(psNetworkInterfaces, true);
            }
        }
    }
}

