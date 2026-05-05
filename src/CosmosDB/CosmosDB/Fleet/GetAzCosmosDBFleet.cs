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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBFleet", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSFleetGetResults))]
    public class GetAzCosmosDBFleet : AzureCosmosDBCmdletBase
    {
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.FleetNameHelpMessage)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(ResourceGroupName))
            {
                // Get specific fleet
                FleetResource fleetResource = CosmosDBManagementClient.Fleet.GetWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSFleetGetResults(fleetResource));
            }
            else if (!string.IsNullOrEmpty(ResourceGroupName))
            {
                // List fleets by resource group
                IEnumerable<FleetResource> fleetResources = CosmosDBManagementClient.Fleet.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName).GetAwaiter().GetResult().Body;
                foreach (FleetResource fleetResource in fleetResources)
                {
                    WriteObject(new PSFleetGetResults(fleetResource));
                }
            }
            else
            {
                // List all fleets in subscription
                IEnumerable<FleetResource> fleetResources = CosmosDBManagementClient.Fleet.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                foreach (FleetResource fleetResource in fleetResources)
                {
                    WriteObject(new PSFleetGetResults(fleetResource));
                }
            }

            return;
        }
    }
}
