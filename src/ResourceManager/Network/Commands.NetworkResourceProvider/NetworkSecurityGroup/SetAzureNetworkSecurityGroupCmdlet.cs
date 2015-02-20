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
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.Azure.Commands.NetworkResourceProvider.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.Set, "AzureNetworkSecurityGroup"), OutputType(typeof(PSNetworkSecurityGroup))]
    public class SetAzureNetworkSecurityGroupCmdlet : NetworkSecurityGroupBaseClient
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The NetworkSecurityGroup")]
        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (!this.IsNetworkSecurityGroupPresent(this.NetworkSecurityGroup.ResourceGroupName, this.NetworkSecurityGroup.Name))
            {
                throw new ArgumentException(Resources.ResourceNotFound);
            }
            
            // Map to the sdk object
            var nsgModel = Mapper.Map<MNM.NetworkSecurityGroupCreateOrUpdateParameters>(this.NetworkSecurityGroup);
            nsgModel.Tags = TagsConversionHelper.CreateTagDictionary(this.NetworkSecurityGroup.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.NetworkSecurityGroupClient.CreateOrUpdate(this.NetworkSecurityGroup.ResourceGroupName, this.NetworkSecurityGroup.Name, nsgModel);

            var getNetworkSecurityGroup = this.GetNetworkSecurityGroup(this.NetworkSecurityGroup.ResourceGroupName, this.NetworkSecurityGroup.Name);
            WriteObject(getNetworkSecurityGroup);
        }
    }
}
