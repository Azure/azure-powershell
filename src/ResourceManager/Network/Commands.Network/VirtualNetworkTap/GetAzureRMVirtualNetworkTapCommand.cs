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
using System.Collections.Generic;
using System.Management.Automation;
using CNM = Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkTap", SupportsShouldProcess = true, DefaultParameterSetName = "GetByNameParameterSet"), OutputType(typeof(PSVirtualNetworkTap))]
    public partial class GetAzureRmVirtualNetworkTap : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "GetByNameParameterSet",
            HelpMessage = "The resource group name of the virtual network tap.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "GetByNameParameterSet",
            HelpMessage = "The name of the tap.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "GetByResourceIdParameterSet",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (!string.IsNullOrEmpty(this.Name))
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
