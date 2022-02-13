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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchPrivateEndpointConnection", 
        SupportsShouldProcess = true, 
        DefaultParameterSetName = ResourceNameParameterSetName), 
        OutputType(typeof(PSPrivateEndpointConnection))]
    public class SetSearchServicePrivateEndpointConnectionCommand : PrivateEndpointConnectionBaseCmdlet
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
            Mandatory = true,
            ParameterSetName = ResourceNameParameterSetName,
            HelpMessage = PrivateEndpointConnectionNameHelpMessage)]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ParentObjectParameterSetName,
            HelpMessage = PrivateEndpointConnectionNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSetName,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = PrivateEndpointConnectionResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = PrivateEndpointConnectionStatusHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSPrivateLinkServiceConnectionStatus Status { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = PrivateEndpointConnectionDescriptionHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = InputObjectParameterSetName,
            HelpMessage = PrivateEndpointInputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSPrivateEndpointConnection InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ResourceIdParameterSetName, StringComparison.InvariantCulture))
            {
                SetParameters(ResourceId);
            }
            else if (ParameterSetName.Equals(InputObjectParameterSetName, StringComparison.InvariantCulture))
            {
                SetParameters(InputObject.Id);
            }
            else if (ParameterSetName.Equals(ParentObjectParameterSetName, StringComparison.InvariantCulture))
            {
                ResourceGroupName = ParentObject.ResourceGroupName;
                ServiceName = ParentObject.Name;
            }

            if (ShouldProcess(Name, Resources.UpdatePrivateEndpointConnection))
            {
                CatchThrowInnerException(() =>
                {
                    // GET
                    var privateEndpointConnection =
                        SearchClient.PrivateEndpointConnections.GetWithHttpMessagesAsync(
                            ResourceGroupName,
                            ServiceName,
                            Name).Result.Body;

                    var update = new PrivateEndpointConnection(
                        id: privateEndpointConnection.Id,
                        name: Name,
                        type: privateEndpointConnection.Type,
                        properties: new PrivateEndpointConnectionProperties
                        {
                            PrivateEndpoint = privateEndpointConnection.Properties.PrivateEndpoint,
                            PrivateLinkServiceConnectionState = new PrivateEndpointConnectionPropertiesPrivateLinkServiceConnectionState
                            {
                                ActionsRequired = privateEndpointConnection.Properties.PrivateLinkServiceConnectionState.ActionsRequired,
                                
                                // Update if not null
                                Description = Description ?? privateEndpointConnection.Properties.PrivateLinkServiceConnectionState.Description,

                                // Update
                                Status = (PrivateLinkServiceConnectionStatus)Status
                            }
                        });

                    var connection = SearchClient.PrivateEndpointConnections.UpdateWithHttpMessagesAsync(
                        ResourceGroupName,
                        ServiceName,
                        Name,
                        update).Result.Body;

                    // OUTPUT
                    WritePrivateEndpointConnection(connection);
                });
            }
        }

        private void SetParameters(string resourceIdentifier)
        {
            var resourceId = new ResourceIdentifier(resourceIdentifier);
            ResourceGroupName = resourceId.ResourceGroupName;
            ServiceName = GetServiceNameFromParentResource(resourceId.ParentResource);
            Name = resourceId.ResourceName;
        }
    }
}
