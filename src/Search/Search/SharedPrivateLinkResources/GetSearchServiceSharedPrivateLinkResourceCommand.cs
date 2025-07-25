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
    ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchSharedPrivateLinkResource",
    DefaultParameterSetName = ResourceNameParameterSetName,
    SupportsShouldProcess = true),
    OutputType(typeof(PSSharedPrivateLinkResource))]
    public class GetSearchServiceSharedPrivateLinkResourceCommand : SharedPrivateLinkResourceBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = ParentObjectParameterSetName,
            HelpMessage = InputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSSearchService ParentObject { get; set; }

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
        public string ServiceName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = false,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = SharedPrivateLinkResourceNameHelpMessage)]
        [Parameter(
            Position = 1,
            Mandatory = false,
            ParameterSetName = ParentObjectParameterSetName,
            HelpMessage = SharedPrivateLinkResourceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = SharedPrivateLinkResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ResourceNameParameterSetName, StringComparison.InvariantCulture))
            {
                // LIST
                if (Name == null)
                {
                    ListSharedPrivateLinkResources(ResourceGroupName, ServiceName);
                }
                // GET
                else
                {
                    GetSharedPrivateLinkResource(ResourceGroupName, ServiceName, Name);
                }
            }
            else if (ParameterSetName.Equals(ParentObjectParameterSetName, StringComparison.InvariantCulture))
            {
                ResourceGroupName = ParentObject.ResourceGroupName;
                ServiceName = ParentObject.Name;

                // LIST
                if (Name == null)
                {
                    ListSharedPrivateLinkResources(ResourceGroupName, ServiceName);
                }
                // GET
                else
                {
                    GetSharedPrivateLinkResource(ResourceGroupName, ServiceName, Name);
                }
            }
            else if (ParameterSetName.Equals(ResourceIdParameterSetName, StringComparison.InvariantCulture))
            {
                var resourceId = new ResourceIdentifier(ResourceId);

                var resourceGroupName = resourceId.ResourceGroupName;
                var serviceName = GetServiceNameFromParentResource(resourceId.ParentResource);
                var resourceName = resourceId.ResourceName;

                GetSharedPrivateLinkResource(resourceGroupName, serviceName, resourceName);
            }
            else
            {
                throw new InvalidOperationException("Invalid set of parameters specified.");
            }
        }

        private void GetSharedPrivateLinkResource(
            string resourceGroupName,
            string serviceName,
            string sharedPrivateLinkResourceName)
        {
            try
            {
                var resource =
                    SearchClient.SharedPrivateLinkResources.GetWithHttpMessagesAsync(
                        resourceGroupName,
                        serviceName,
                        sharedPrivateLinkResourceName).Result;

                WriteSharedPrivateLinkResource(resource.Body);
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

        private void ListSharedPrivateLinkResources(
            string resourceGroupName,
            string serviceName)
        {
            try
            {
                var resources =
                    SearchClient.SharedPrivateLinkResources.ListByServiceWithHttpMessagesAsync(
                        resourceGroupName,
                        serviceName).Result;

                WriteSharedPrivateLinkResourceList(resources.Body);
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
