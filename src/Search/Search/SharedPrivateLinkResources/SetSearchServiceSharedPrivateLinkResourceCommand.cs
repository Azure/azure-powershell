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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Search.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    [Cmdlet(
        "Set",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchSharedPrivateLinkResource",
        SupportsShouldProcess = true),
        OutputType(typeof(PSSharedPrivateLinkResource))]
    public class SetSearchServiceSharedPrivateLinkResourceCommand : SharedPrivateLinkResourceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceGroupHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter()]
        public string ServiceName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = SharedPrivateLinkResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSetName,
            HelpMessage = SharedPrivateLinkResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = RequestMessageHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string RequestMessage { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ResourceIdParameterSetName, StringComparison.InvariantCulture))
            {
                var resourceId = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceId.ResourceGroupName;
                ServiceName = GetServiceNameFromParentResource(resourceId.ParentResource);
                Name = resourceId.ResourceName;
            }

            if (ShouldProcess(Name, Resources.UpdateSharedPrivateLinkResource))
            {
                CatchThrowInnerException(() =>
                {
                    SharedPrivateLinkResource resource =
                    SearchClient.SharedPrivateLinkResources.GetWithHttpMessagesAsync(
                        ResourceGroupName,
                        ServiceName,
                        Name).Result.Body;

                    // only allowed to update this
                    resource.Properties.RequestMessage = RequestMessage;

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
