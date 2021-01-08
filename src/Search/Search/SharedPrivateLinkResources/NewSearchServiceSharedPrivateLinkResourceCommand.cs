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

using Microsoft.Azure.Commands.Management.Search.Models;
using Microsoft.Azure.Commands.Management.Search.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Search.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    [Cmdlet(
        "New", 
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchSharedPrivateLinkResource", 
        SupportsShouldProcess = true), 
        OutputType(typeof(PSSharedPrivateLinkResource))]
    public class NewSearchServiceSharedPrivateLinkResourceCommand : SharedPrivateLinkResourceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            HelpMessage = ResourceGroupHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            HelpMessage = ResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ServiceName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = SharedPrivateLinkResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = PrivateLinkResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string PrivateLinkResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = GroupIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string GroupId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = RequestMessageHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string RequestMessage { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = ResourceRegionHelpMessage)]
        public string ResourceRegion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = AsJobMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            SharedPrivateLinkResource resource =
                new SharedPrivateLinkResource(
                    name: Name,
                    properties: new SharedPrivateLinkResourceProperties
                    {
                        GroupId = GroupId,
                        PrivateLinkResourceId = PrivateLinkResourceId,
                        RequestMessage = RequestMessage,
                        ResourceRegion = ResourceRegion
                    });

            if (ShouldProcess(Name, Resources.CreateSharedPrivateLinkResource))
            {
                CatchThrowInnerException(() =>
                {
                    var response = 
                        SearchClient.SharedPrivateLinkResources.CreateOrUpdateWithHttpMessagesAsync(
                            ResourceGroupName, 
                            ServiceName,
                            Name, 
                            resource).Result;

                    WriteSharedPrivateLinkResource(response.Body);
                });
            }
        }
    }
}
