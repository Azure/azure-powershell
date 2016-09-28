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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmVirtualNetwork"), OutputType(typeof(PSVirtualNetwork))]
    public class SetAzureVirtualNetworkCommand : VirtualNetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsVirtualNetworkPresent(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vnetModel = Mapper.Map<MNM.VirtualNetwork>(this.VirtualNetwork);
            vnetModel.Tags = TagsConversionHelper.CreateTagDictionary(this.VirtualNetwork.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkClient.CreateOrUpdate(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name, vnetModel);

            var getVirtualNetwork = this.GetVirtualNetwork(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name);
            WriteObject(getVirtualNetwork);
        }
    }
}
