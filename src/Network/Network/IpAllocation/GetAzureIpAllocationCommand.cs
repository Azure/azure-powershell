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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Rest.Azure;
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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IpAllocation"), OutputType(typeof(PSIpAllocation))]
    public class GetAzureIpAllocationCommand : IpAllocationBaseCmdlet
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = GetByNameParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource group name.",
            ParameterSetName = ListParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
           HelpMessage = "The resource name.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/ipAllocation", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "IpAllocation Id",
            ParameterSetName = GetByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

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
                var allocation = this.GetIpAllocation(this.ResourceGroupName, this.Name);

                WriteObject(allocation);
            }
            else
            {
                IPage<Microsoft.Azure.Management.Network.Models.IpAllocation> allocationPage;
                if (ShouldListByResourceGroup(ResourceGroupName, Name))
                {
                    allocationPage = this.IpAllocationClient.ListByResourceGroup(this.ResourceGroupName);
                }
                else
                {
                    allocationPage = this.IpAllocationClient.List();
                }

                // Get all resources by polling on next page link
                var allocationList = ListNextLink<Microsoft.Azure.Management.Network.Models.IpAllocation>.GetAllResourcesByPollingNextLink(allocationPage, this.IpAllocationClient.ListNext);

                var psAllocations = new List<PSIpAllocation>();
                foreach (var allocation in allocationList)
                {
                    var psAllocation = this.ToPsIpAllocation(allocation);
                    psAllocation.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(psAllocation.Id);
                    psAllocations.Add(psAllocation);
                }

                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, psAllocations), true);
            }
        }
    }
}
