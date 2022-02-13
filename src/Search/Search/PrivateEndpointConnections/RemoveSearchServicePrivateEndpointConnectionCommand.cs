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
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Search.SearchService
{
    [Cmdlet(
        "Remove", 
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SearchPrivateEndpointConnection", 
        DefaultParameterSetName = ResourceNameParameterSetName, 
        SupportsShouldProcess = true), 
        OutputType(typeof(bool))]
    public class RemoveSearchServicePrivateEndpointConnectionCommand : PrivateEndpointConnectionBaseCmdlet
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
            ValueFromPipeline = true,
            ParameterSetName = InputObjectParameterSetName,
            HelpMessage = PrivateEndpointInputObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSPrivateEndpointConnection InputObject { get; set; }

        [Parameter(
           Position = 0,
           Mandatory = true,
           ParameterSetName = ResourceIdParameterSetName,
           HelpMessage = PrivateEndpointConnectionResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = ForceHelpMessage)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = PassThruHelpMessage)]
        public SwitchParameter PassThru { get; set; }

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

            ConfirmAction(Force.IsPresent,
                string.Format(Resources.RemovePrivateEndpointConnectionWarning, Name),
                string.Format(Resources.RemovePrivateEndpointConnection, Name),
                Name,
                () =>
                {
                    CatchThrowInnerException(() =>
                    {
                        SearchClient.PrivateEndpointConnections.DeleteWithHttpMessagesAsync(ResourceGroupName, ServiceName, Name).Wait();
                    });

                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                }
            );
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