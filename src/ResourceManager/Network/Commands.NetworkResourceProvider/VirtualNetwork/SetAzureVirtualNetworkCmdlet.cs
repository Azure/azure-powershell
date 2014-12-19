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
using Microsoft.Azure.Commands.NetworkResourceProvider.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Set, "AzureVirtualNetwork"), OutputType(typeof(PSVirtualNetwork))]
    public class SetAzureVirtualNetworkCmdlet : VirtualNetworkBaseClient
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.IsVirtualNetworkPresent(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name))
            {
                throw new ArgumentException(Resources.ResourceNotFound);
            }
            
            // Map to the sdk object
            var vnetModel = Mapper.Map<MNM.VirtualNetworkCreateOrUpdateParameters>(this.VirtualNetwork);
            vnetModel.Tags = TagsConversionHelper.CreateTagDictionary(this.VirtualNetwork.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkClient.CreateOrUpdate(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name, vnetModel);

            var getVirtualNetwork = this.GetVirtualNetwork(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name);
            WriteObject(getVirtualNetwork);
        }
    }
}
