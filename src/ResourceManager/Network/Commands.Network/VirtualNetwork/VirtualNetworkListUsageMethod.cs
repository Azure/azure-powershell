﻿// 
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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkUsageList"), OutputType(typeof(PSVirtualNetworkUsage))]
    public partial class GetAzureRmVirtualNetworkUsageList : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Virtual network name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            var vVirtualNetworkList = this.NetworkClient.NetworkManagementClient.VirtualNetworks.ListUsage(ResourceGroupName, Name);
            var vnetUsageList = new List<PSVirtualNetworkUsage>();
            foreach (var vVirtualNetwork in vVirtualNetworkList)
            {
                var vVirtualNetworkModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualNetworkUsage>(vVirtualNetwork);
                vnetUsageList.Add(vVirtualNetworkModel);
            }
            WriteObject(vnetUsageList, true);
        }
    }
}
