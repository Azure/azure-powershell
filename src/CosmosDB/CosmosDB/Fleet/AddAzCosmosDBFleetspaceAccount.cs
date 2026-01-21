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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBFleetspaceAccount", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSFleetspaceAccountGetResults))]
    public class AddAzCosmosDBFleetspaceAccount : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.FleetNameHelpMessage)]
        public string FleetName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.FleetspaceNameHelpMessage)]
        public string FleetspaceName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.FleetspaceAccountNameHelpMessage)]
        public string Name { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.GlobalDatabaseAccountResourceIdHelpMessage)]
        public string GlobalDatabaseAccountResourceId { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.GlobalDatabaseAccountLocationHelpMessage)]
        public string GlobalDatabaseAccountLocation { get; set; }

        [ValidateNotNull]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.FleetspaceObjectHelpMessage)]
        public PSFleetspaceGetResults ParentObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                FleetName = ExtractFleetNameFromResourceId(ParentObject.Id);
                FleetspaceName = ParentObject.Name;
            }

            FleetspaceAccountResource fleetspaceAccountResource = new FleetspaceAccountResource
            {
                GlobalDatabaseAccountProperties = new FleetspaceAccountPropertiesGlobalDatabaseAccountProperties
                {
                    ResourceId = GlobalDatabaseAccountResourceId,
                    ArmLocation = GlobalDatabaseAccountLocation
                }
            };

            FleetspaceAccountResource fleetspaceAccountResults = CosmosDBManagementClient.FleetspaceAccount.CreateWithHttpMessagesAsync(
                ResourceGroupName,
                FleetName,
                FleetspaceName,
                Name,
                fleetspaceAccountResource).GetAwaiter().GetResult().Body;
            WriteObject(new PSFleetspaceAccountGetResults(fleetspaceAccountResults));

            return;
        }

        private string ExtractFleetNameFromResourceId(string resourceId)
        {
            // Extract fleet name from resource ID
            // Format: /subscriptions/{subscription}/resourceGroups/{rg}/providers/Microsoft.DocumentDB/fleets/{fleet}/fleetspaces/{fleetspace}
            string[] parts = resourceId.Split('/');
            for (int i = 0; i < parts.Length - 1; i++)
            {
                if (parts[i].Equals("fleets", StringComparison.OrdinalIgnoreCase))
                {
                    return parts[i + 1];
                }
            }
            throw new ArgumentException("Invalid resource ID format");
        }
    }
}
