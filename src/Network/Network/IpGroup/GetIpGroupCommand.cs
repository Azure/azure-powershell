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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IpGroup", DefaultParameterSetName = IpGroupParameterSetNames.ByName), OutputType(typeof(PSIpGroup), typeof(IEnumerable<PSIpGroup>))]
    public class GetIpGroupsCommand : IpGroupBaseCmdlet
    {
        [Parameter(
            ParameterSetName = IpGroupParameterSetNames.ByName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        [ResourceGroupCompleter]
        public virtual string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            ParameterSetName = IpGroupParameterSetNames.ByName,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/ipGroups", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = IpGroupParameterSetNames.ByResourceId,
            Mandatory = true,
            HelpMessage = "ResourceId of the ipGroup.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/ipGroups")]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {

            base.ExecuteCmdlet();

            if (string.Equals(this.ParameterSetName, IpGroupParameterSetNames.ByResourceId, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName; 
            }

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var ipGroups = this.GetIpGroup(this.ResourceGroupName, this.Name);

                WriteObject(ipGroups);
            }
            else
            {
               var ipGroupsPage = ShouldListBySubscription(ResourceGroupName, Name)
                    ? this.IpGroupsClient.List()
                    : this.IpGroupsClient.ListByResourceGroup(this.ResourceGroupName);

                    // Get all resources by polling on next page link
                    var ipGroupsResponseList = ListNextLink<IpGroup>.GetAllResourcesByPollingNextLink(ipGroupsPage, this.IpGroupsClient.ListNext);

                var PSIpGroups = ipGroupsResponseList.Select(ipGroups =>
                {
                    var PSIpGroup = this.ToPSIpGroup(ipGroups);
                    PSIpGroup.ResourceGroupName = NetworkBaseCmdlet.GetResourceGroup(ipGroups.Id);
                    return PSIpGroup;
                }).ToList();

                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, PSIpGroups), true);
            }
        }
    }
}
