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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Set, "AzureNetworkInterface"), OutputType(typeof(PSNetworkInterface))]
    public class SetAzureNetworkInterfaceCmdlet : NetworkInterfaceBaseClient
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The NetworkInterface")]
        public PSNetworkInterface NetworkInterface { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.IsNetworkInterfacePresent(this.NetworkInterface.ResourceGroupName, this.NetworkInterface.Name))
            {
                throw new ArgumentException(ResourceNotFound);
            }

            // Map to the sdk object
            var networkInterfaceModel = Mapper.Map<MNM.NetworkInterfaceCreateOrUpdateParameters>(this.NetworkInterface);
            networkInterfaceModel.Tags = TagsConversionHelper.CreateTagDictionary(this.NetworkInterface.Tag, validate: true);

            this.NetworkInterfaceClient.CreateOrUpdate(this.NetworkInterface.ResourceGroupName, this.NetworkInterface.Name, networkInterfaceModel);

            var getNetworkInterface = this.GetNetworkInterface(this.NetworkInterface.ResourceGroupName, this.NetworkInterface.Name);
            WriteObject(getNetworkInterface);
        }
    }
}
