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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IpAllocation"), OutputType(typeof(PSIpAllocation))]
    public class GetAzureIpAllocationCommand : IpAllocationBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "Expand")]
        [ResourceNameCompleter("Microsoft.Network/ipAllocation", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "NoExpand")]
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "Expand")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource reference to be expanded.",
            ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public string ExpandResource { get; set; }

        public override void Execute()
        {

            base.Execute();
            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var allocation = this.GetIpAllocation(this.ResourceGroupName, this.Name, this.ExpandResource);

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
