// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using CNM = Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network.Automation
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkServiceTag"), OutputType(typeof(PSNetworkServiceTag))]
    public partial class GetAzureNetworkServiceTagCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/locations/serviceTags")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void Execute()
        {
            base.Execute();

            var serviceTagsList = this.NetworkClient.NetworkManagementClient.ServiceTags.List(Location);
            PSNetworkServiceTag psNetworkServiceTag = NetworkResourceManagerProfile.Mapper.Map<CNM.PSNetworkServiceTag>(serviceTagsList);

            WriteObject(psNetworkServiceTag, true);
        }
    }
}
