

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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureNetworkInterface"), OutputType(typeof(PSNetworkInterface))]
    public class GetAzureNetworkInterfaceCommand : NetworkInterfaceBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            
            if (!string.IsNullOrEmpty(this.Name))
            {
                var networkInterface = this.GetNetworkInterface(this.ResourceGroupName, this.Name);
                
                WriteObject(networkInterface);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                var getNetworkInterfaceResponse = this.NetworkInterfaceClient.List(this.ResourceGroupName);

                var psNetworkInterfaces = new List<PSNetworkInterface>();

                foreach (var nic in getNetworkInterfaceResponse.NetworkInterfaces)
                {
                    var psNic = this.ToPsNetworkInterface(nic);
                    psNic.ResourceGroupName = this.ResourceGroupName;
                    psNetworkInterfaces.Add(psNic);
                }

                WriteObject(psNetworkInterfaces, true);
            }

            else
            {
                var getNetworkInterfaceResponse = this.NetworkInterfaceClient.ListAll();

                var psNetworkInterfaces = new List<PSNetworkInterface>();

                foreach (var nic in getNetworkInterfaceResponse.NetworkInterfaces)
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

 