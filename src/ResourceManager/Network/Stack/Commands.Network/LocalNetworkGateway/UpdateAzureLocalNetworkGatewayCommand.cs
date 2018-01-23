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

using MNM = Microsoft.Azure.Management.Network.Models;
using System.Collections;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmLocalNetworkGateway"), OutputType(typeof(PSLocalNetworkGateway))]
    public class SetAzureLocalNetworkGatewayCommand : LocalNetworkGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The LocalNetworkGateway")]
        public PSLocalNetworkGateway LocalNetworkGateway { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The address prefixes of the local network to be changed.")]
        [ValidateNotNullOrEmpty]
        public List<string> AddressPrefix { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.IsLocalNetworkGatewayPresent(this.LocalNetworkGateway.ResourceGroupName, this.LocalNetworkGateway.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            this.LocalNetworkGateway.LocalNetworkAddressSpace.AddressPrefixes = this.AddressPrefix;

            // Map to the sdk object
            var localnetGatewayModel = Mapper.Map<MNM.LocalNetworkGateway>(this.LocalNetworkGateway);
            localnetGatewayModel.Tags = TagsConversionHelper.CreateTagDictionary(this.LocalNetworkGateway.Tag, validate: true);

            this.LocalNetworkGatewayClient.CreateOrUpdate(this.LocalNetworkGateway.ResourceGroupName, this.LocalNetworkGateway.Name, localnetGatewayModel);

            var getlocalnetGateway = this.GetLocalNetworkGateway(this.LocalNetworkGateway.ResourceGroupName, this.LocalNetworkGateway.Name);

            WriteObject(getlocalnetGateway);
        }
    }
}
