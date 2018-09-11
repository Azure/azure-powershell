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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
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

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkTap"), OutputType(typeof(PSVirtualNetworkTap))]
    public partial class GetAzureRmVirtualNetworkTap : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource group name of the virtual network tap.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the tap.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if(!string.IsNullOrEmpty(this.Name))
            {
                var vVirtualNetworkTap = this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.Get(ResourceGroupName, Name);
                var vVirtualNetworkTapModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualNetworkTap>(vVirtualNetworkTap);
                vVirtualNetworkTapModel.ResourceGroupName = this.ResourceGroupName;
                vVirtualNetworkTapModel.Tag = TagsConversionHelper.CreateTagHashtable(vVirtualNetworkTap.Tags);
                WriteObject(vVirtualNetworkTapModel, true);
            }
            else
            {
                var vVirtualNetworkTapList = this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.ListAll();
                List<PSVirtualNetworkTap> psVirtualNetworkTapList = new List<PSVirtualNetworkTap>();
                foreach (var vVirtualNetworkTap in vVirtualNetworkTapList)
                {
                    var vVirtualNetworkTapModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualNetworkTap>(vVirtualNetworkTap);
                    vVirtualNetworkTapModel.ResourceGroupName = this.ResourceGroupName;
                    vVirtualNetworkTapModel.Tag = TagsConversionHelper.CreateTagHashtable(vVirtualNetworkTap.Tags);
                    psVirtualNetworkTapList.Add(vVirtualNetworkTapModel);
                }
                WriteObject(psVirtualNetworkTapList, true);
            }
        }
    }
}
