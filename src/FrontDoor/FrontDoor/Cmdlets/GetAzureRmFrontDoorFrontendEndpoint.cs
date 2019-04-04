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

using System;
using System.Collections;
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Helpers;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.FrontDoor.Properties;
using Microsoft.Azure.Management.FrontDoor;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the Get-FrontDoorFrontendEndpoint cmdlet.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorFrontendEndpoint", DefaultParameterSetName = FieldsParameterSet), OutputType(typeof(PSFrontendEndpoint))]
    public class GetAzureRmFrontDoorFrontendEndpoint : AzureFrontDoorCmdletBase
    {
        /// <summary>
        /// The resource group name of the Front Door.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// The Front Door name.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Front Door name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/frontdoors", nameof(ResourceGroupName))]
        public string FrontDoorName { get; set; }

        /// <summary>
        /// Gets or sets the frontend endpoint name.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = FieldsParameterSet, HelpMessage = "Frontend endpoint name.")]
        [Parameter(Mandatory = false, ParameterSetName = ObjectParameterSet, HelpMessage = "Frontend endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///The Front Door object.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ObjectParameterSet, ValueFromPipeline = true, HelpMessage = "The FrontDoor object.")]
        [ValidateNotNullOrEmpty]
        public PSFrontDoor FrontDoorObject { get; set; }

        /// <summary>
        /// Resource Id of the Front Door
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Id of the Front Door frontend endpoint")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName == ObjectParameterSet)
            {
                ResourceIdentifier identifier = new ResourceIdentifier(FrontDoorObject.Id);
                ResourceGroupName = identifier.ResourceGroupName;
                FrontDoorName = identifier.ResourceName;
            }
            else if(ParameterSetName == ResourceIdParameterSet)
            {
                ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                if (!ResourceIdentifierExtensions.IsFrontendEndpointResourceType(identifier))
                {
                    throw new PSArgumentException(string.Format(Resources.Error_InvalidResourceId, ResourceId));
                }
                ResourceGroupName = identifier.ResourceGroupName;
                Name = identifier.ResourceName;
                FrontDoorName = ResourceIdentifierExtensions.GetFrontDoorName(identifier);
            }

            if (Name == null)
            {
                var FrontendEndpoints = FrontDoorManagementClient.FrontendEndpoints.ListByFrontDoor(ResourceGroupName, FrontDoorName).Select(p => p.ToPSFrontendEndpoints());
                WriteObject(FrontendEndpoints, true);
            }
            else
            {
                var FrontendEndpoint = FrontDoorManagementClient.FrontendEndpoints.Get(ResourceGroupName, FrontDoorName, Name);
                WriteObject(FrontendEndpoint.ToPSFrontendEndpoints());
            }
        }
    }
}