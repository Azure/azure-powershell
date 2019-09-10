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
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkTap", SupportsShouldProcess = true, DefaultParameterSetName = "ListParameterSet"), OutputType(typeof(PSVirtualNetworkTap))]
    public partial class GetAzureRmVirtualNetworkTap : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = "ListParameterSet",
            HelpMessage = "The resource group name of the virtual network tap.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "ListParameterSet",
            HelpMessage = "The name of the tap.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Network/virtualNetworkTaps", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
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

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var vVirtualNetworkTap = this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.Get(ResourceGroupName, Name);
                var vVirtualNetworkTapModel = NetworkResourceManagerProfile.Mapper.Map<CNM.PSVirtualNetworkTap>(vVirtualNetworkTap);
                vVirtualNetworkTapModel.ResourceGroupName = this.ResourceGroupName;
                vVirtualNetworkTapModel.Tag = TagsConversionHelper.CreateTagHashtable(vVirtualNetworkTap.Tags);
                WriteObject(vVirtualNetworkTapModel, true);
            }
            else
            {
                IPage<VirtualNetworkTap> vtapPage;
                if (ShouldListByResourceGroup(ResourceGroupName, Name))
                {
                    vtapPage = this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.ListByResourceGroup(this.ResourceGroupName);
                }
                else
                {
                    vtapPage = this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.ListAll();
                }

                // Get all resources by polling on next page link
                var vtapList = ListNextLink<VirtualNetworkTap>.GetAllResourcesByPollingNextLink(vtapPage, this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.ListByResourceGroupNext);

                var psVtaps = new List<PSVirtualNetworkTap>();
                foreach (var vtap in vtapList)
                {
                    var psVtap = this.ToPsVirtualNetworkTap(vtap);
                    psVtap.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(vtap.Id);
                    psVtaps.Add(psVtap);
                }

                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psVtaps), true);
            }
        }

        public PSVirtualNetworkTap ToPsVirtualNetworkTap(VirtualNetworkTap vtap)
        {
            var psVtap = NetworkResourceManagerProfile.Mapper.Map<PSVirtualNetworkTap>(vtap);

            psVtap.Tag = TagsConversionHelper.CreateTagHashtable(vtap.Tags);

            return psVtap;
        }
    }
}
