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
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using CNM = Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AvailablePrivateEndpointType"), OutputType(typeof(PSAvailablePrivateEndpointType))]
    public class GetAzureAvailablePrivateEndpointTypeCommand : PrivateEndpointBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/locations/availablePrivateEndpointTypes")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();

            IPage<AvailablePrivateEndpointType> availablePrivateEndpointList = null;
            if (!string.IsNullOrEmpty(ResourceGroupName))
            {
                availablePrivateEndpointList = this.NetworkClient.NetworkManagementClient.AvailablePrivateEndpointTypes.ListByResourceGroup(this.Location, this.ResourceGroupName);
            }
            else
            {
                availablePrivateEndpointList = this.NetworkClient.NetworkManagementClient.AvailablePrivateEndpointTypes.List(Location);
            }

            List<PSAvailablePrivateEndpointType> psPrivateEndpoints = new List<PSAvailablePrivateEndpointType>();
            foreach (var availablePrivateEndpoint in availablePrivateEndpointList)
            {
                psPrivateEndpoints.Add(NetworkResourceManagerProfile.Mapper.Map<CNM.PSAvailablePrivateEndpointType>(availablePrivateEndpoint));
            }

            WriteObject(psPrivateEndpoints, true);
        }
    }
}
