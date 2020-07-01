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
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccountRegion", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDatabaseAccountGetResults))]
    public class UpdateAzCosmosDBAccountRegion : AzureCosmosDBCmdletBase
    { 
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AccountUpdateLocationHelpMessage)]
        public string[] Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.LocationObjectHelpMessage)]
        public PSLocation[] LocationObject { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccountGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!ParameterSetName.Equals(NameParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = null;
                if (ParameterSetName.Equals(ResourceIdParameterSet, StringComparison.Ordinal))
                {
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                }
                else if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
                {
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                }

                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
            }

            List<Location> locations = new List<Location>();
            if (Location != null || LocationObject != null)
            {
                if (Location != null && Location.Length > 0)
                {
                    int failoverPriority = 0;
                    foreach (string location in Location)
                    {
                        locations.Add(new Location(locationName: location, failoverPriority: failoverPriority));
                        failoverPriority++;
                    }
                }
                if (LocationObject != null && LocationObject.Length > 0)
                {
                    foreach (PSLocation psLocation in LocationObject)
                    {
                        locations.Add(PSLocation.ToSDKModel(psLocation));
                    }
                }
            }
            else
            {
                WriteWarning("Cannot Add Region if no location is provided.");
                return;
            }

            DatabaseAccountUpdateParameters createUpdateParameters = new DatabaseAccountUpdateParameters(locations:locations);
            
            if (ShouldProcess(Name, "Updating Database Account Region"))
            {
                CosmosDBManagementClient.DatabaseAccounts.UpdateWithHttpMessagesAsync(ResourceGroupName, Name, createUpdateParameters).GetAwaiter().GetResult();

                DatabaseAccountGetResults databaseAccount = CosmosDBManagementClient.DatabaseAccounts.GetWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountGetResults(databaseAccount));
            }

            return;
        }
    }
}
