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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network.Automation
{
    [Cmdlet(VerbsCommon.Get, "AzureRmVirtualNetworkAvailableEndpointService"), OutputType(typeof(List<PSEndpointServiceResult>))]
    public partial class GetAzureRMVirtualNetworkAvailableEndpointServiceCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The location.",
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Network/locations/virtualNetworkAvailableEndpointServices")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public override void Execute()
        {
            base.Execute();

            var vAvailableEndpointServiceList = this.NetworkClient.NetworkManagementClient.AvailableEndpointServices.List(Location);
            List<PSEndpointServiceResult> psAvailableServiceEndpoints = new List<PSEndpointServiceResult>();
            foreach (var vAvailableEndpointService in vAvailableEndpointServiceList)
            {
                psAvailableServiceEndpoints.Add(NetworkResourceManagerProfile.Mapper.Map<CNM.PSEndpointServiceResult>(vAvailableEndpointService));
            }
            WriteObject(psAvailableServiceEndpoints, true);
        }
    }
}
