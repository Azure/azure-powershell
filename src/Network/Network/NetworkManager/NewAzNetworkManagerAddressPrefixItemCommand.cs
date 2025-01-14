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
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerAddressPrefixItem"), OutputType(typeof(PSNetworkManagerAddressPrefixItem))]
    public class NewAzNetworkManagerAddressPrefixItemCommand: NetworkManagerBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "AddressPrefix")]
        public string AddressPrefix { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "AddressPrefix Type. Valid values include 'IPPrefix', 'NetworkGroup' and 'ServiceTag'.")]
        [ValidateSet("IPPrefix", "ServiceTag", "NetworkGroup", IgnoreCase = true)]
        public string AddressPrefixType { get; set; }

        public override void Execute()
        {
            base.Execute();
            var pSNetworkManagerAddressPrefixItem = new PSNetworkManagerAddressPrefixItem();
            pSNetworkManagerAddressPrefixItem.AddressPrefix = this.AddressPrefix;
            pSNetworkManagerAddressPrefixItem.AddressPrefixType = this.AddressPrefixType;
            WriteObject(pSNetworkManagerAddressPrefixItem);
        }
    }
}
