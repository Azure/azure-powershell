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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using System;
using System.Management.Automation;
using System.Net;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    [Cmdlet(
    "Get",
    ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchPrivateLinkResource",
    DefaultParameterSetName = ResourceNameParameterSetName,
    SupportsShouldProcess = true),
    OutputType(typeof(PSSharedPrivateLinkResource))]
    public class GetSearchPrivateLinkResourceCommand : PrivateLinkResourcesBaseCmdlet
    {
        [Parameter(
           Position = 0,
           Mandatory = true,
           ParameterSetName = ResourceNameParameterSetName,
           HelpMessage = ResourceGroupHelpMessage)]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = ResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSetName,
            HelpMessage = ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectParameterSetName,
            HelpMessage = InputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSSearchService InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ResourceIdParameterSetName, StringComparison.InvariantCulture))
            {
                var resourceId = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceId.ResourceGroupName;
                Name = resourceId.ResourceName;
            }
            else if (ParameterSetName.Equals(InputObjectParameterSetName, StringComparison.InvariantCulture))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Name = InputObject.Name;
            }

            try
            {
                var resources = SearchClient.PrivateLinkResources.ListSupportedWithHttpMessagesAsync(ResourceGroupName, Name).Result;
                WritePrivateLinkResourcesList(resources.Body);
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException is CloudException
                    && ((CloudException)ae.InnerException).Response?.StatusCode == HttpStatusCode.NotFound)
                {
                    // the method throws an exception when the service does not exist.
                    return;
                }

                throw ae.InnerException;
            }
        }
    }
}
