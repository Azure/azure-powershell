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
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Set, NetworkInterfaceCmdletName)]
    public class SetNetworkInterfaceCmdlet : NetworkInterfaceBaseClient
    {
        [Parameter(
            DontShow = true)]
        public override string Name { get; set; }

        [Parameter(
           DontShow = true)]
        public override string ResourceGroupName { get; set; }

        [Parameter(
                    Mandatory = true,
                    ValueFromPipelineByPropertyName = true,
                    HelpMessage = "The NetworkInterface")]
        public PSNetworkInterface PsNetworkInterface { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.IsNetworkInterfacePresent(this.PsNetworkInterface.ResourceGroupName, this.PsNetworkInterface.Name))
            {
                throw new ArgumentException(ResourceNotFound);
            }

            // Map to the sdk object
            var networkInterfaceModel = Mapper.Map<MNM.NetworkInterfaceCreateOrUpdateParameters>(this.PsNetworkInterface);

            this.NetworkInterfaceClient.CreateOrUpdate(this.PsNetworkInterface.ResourceGroupName, this.PsNetworkInterface.Name, networkInterfaceModel);

            var getNetworkInterface = this.GetNetworkInterface(this.PsNetworkInterface.ResourceGroupName, this.PsNetworkInterface.Name);
            WriteObject(getNetworkInterface);
        }
    }
}
