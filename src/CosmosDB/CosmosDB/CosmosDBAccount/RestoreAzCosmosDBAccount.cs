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
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccount", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDatabaseAccountGetResults))]
    public class RestoreAzCosmosDBAccount : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = Constants.RestoreTimestampHelpMessage)]
        public DateTime RestoreTimestampInUtc { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.RestoreSourceDatabaseAccountNameHelpMessage)]
        public string SourceDatabaseAccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.RestoreLocationNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string TargetResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string TargetDatabaseAccountName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DatabasesToRestoreHelpMessage)]
        public PSDatabaseToRestore[] DatabasesToRestore { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            DateTime utcRestoreDateTime;
            if (RestoreTimestampInUtc.Kind == DateTimeKind.Unspecified)
            {
                utcRestoreDateTime = RestoreTimestampInUtc;
            }
            else
            {
                utcRestoreDateTime = RestoreTimestampInUtc.ToUniversalTime();
            }

            // Fail if provided restoretimesamp is greater than current timestamp
            if (utcRestoreDateTime > DateTime.UtcNow)
            {
                WriteWarning($"Restore timestamp {utcRestoreDateTime} should be less than current timestamp {DateTime.UtcNow}");
                return;
            }

            List<RestorableDatabaseAccountGetResult> restorableDatabaseAccounts = CosmosDBManagementClient.RestorableDatabaseAccounts.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.ToList();

            RestorableDatabaseAccountGetResult sourceAccountToRestore = null;
            List<RestorableDatabaseAccountGetResult> accountsWithMatchingName = restorableDatabaseAccounts.Where(databaseAccount => databaseAccount.AccountName.Equals(SourceDatabaseAccountName, StringComparison.OrdinalIgnoreCase)).ToList();
            if (accountsWithMatchingName.Count > 0)
            {
                foreach (RestorableDatabaseAccountGetResult restorableAccount in accountsWithMatchingName)
                {
                    if (restorableAccount.CreationTime.HasValue &&
                        restorableAccount.CreationTime < utcRestoreDateTime)
                    {
                        if (!restorableAccount.DeletionTime.HasValue || restorableAccount.DeletionTime > utcRestoreDateTime)
                        {
                            sourceAccountToRestore = restorableAccount;
                            break;
                        }
                    }
                }
            }

            if (sourceAccountToRestore == null)
            {
                WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} that was alive at given utc-timestamp {utcRestoreDateTime}");
                return;
            }

            // Validate if regional database accounts exists as of restore timestamp
            RestorableLocationResource restorableLocationResource = null;
            foreach (RestorableLocationResource restorableResource in sourceAccountToRestore.RestorableLocations)
            {
                if (restorableResource.LocationName.Equals(Location, StringComparison.OrdinalIgnoreCase) &&
                    (restorableResource.CreationTime.HasValue && restorableResource.CreationTime < utcRestoreDateTime) &&
                    (!restorableResource.DeletionTime.HasValue || restorableResource.DeletionTime > utcRestoreDateTime))
                {
                    restorableLocationResource = restorableResource;
                    break;
                }
            }

            if (restorableLocationResource == null)
            {
                WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} in location {Location} that was alive at given utc-timestamp {utcRestoreDateTime}");
                return;
            }

            // Validate if source account is empty
            IEnumerable<DatabaseRestoreResource> restorableResources;
            if (sourceAccountToRestore.ApiType.Equals("Sql", StringComparison.OrdinalIgnoreCase))
            {
                restorableResources = CosmosDBManagementClient.RestorableSqlResources.ListWithHttpMessagesAsync(
                    sourceAccountToRestore.Location,
                    sourceAccountToRestore.Name,
                    Location,
                    utcRestoreDateTime.ToString()).GetAwaiter().GetResult().Body;
            }
            else if (sourceAccountToRestore.ApiType.Equals("MongoDB", StringComparison.OrdinalIgnoreCase))
            {
                restorableResources = CosmosDBManagementClient.RestorableMongodbResources.ListWithHttpMessagesAsync(
                    sourceAccountToRestore.Location,
                    restorableLocationResource.RegionalDatabaseAccountInstanceId,
                    Location,
                    utcRestoreDateTime.ToString()).GetAwaiter().GetResult().Body;
            }
            else
            {
                WriteWarning($"Provided API Type {sourceAccountToRestore.ApiType} is not supported");
                return;
            }

            if (!restorableResources.Any())
            {
                WriteWarning($"Database account {SourceDatabaseAccountName} contains no restorable resources in location {Location} at given restore timestamp {utcRestoreDateTime}");
                return;
            }

            // Trigger restore
            DatabaseAccountCreateUpdateProperties databaseAccountCreateUpdateProperties = null;
            PSRestoreParameters restoreParameters = new PSRestoreParameters()
            {
                RestoreSource = sourceAccountToRestore.Id,
                RestoreTimestampInUtc = utcRestoreDateTime,
                DatabasesToRestore = DatabasesToRestore
            };

            Collection<Location> LocationCollection = new Collection<Location>();
            Location loc = new Location(locationName: Location, failoverPriority: 0);
            LocationCollection.Add(loc);

            databaseAccountCreateUpdateProperties = new RestoreReqeustDatabaseAccountCreateUpdateProperties()
            {
                RestoreParameters = restoreParameters.ToSDKModel(),
                Locations = LocationCollection
            };

            string apiKind = "GlobalDocumentDB";
            if (sourceAccountToRestore.ApiType.Equals("MongoDB", StringComparison.OrdinalIgnoreCase))
            {
                apiKind = "MongoDB";
            }

            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters(location: sourceAccountToRestore.Location, name: TargetDatabaseAccountName, properties: databaseAccountCreateUpdateProperties)
            {
                Kind = apiKind
            };

            if (ShouldProcess(TargetDatabaseAccountName,
                string.Format(
                    "Creating Database Account by restoring Database Account with Name {0} and restorable database account Id {1} to the timestamp {2}",
                    SourceDatabaseAccountName,
                    sourceAccountToRestore.Id,
                    RestoreTimestampInUtc)))
            {
                DatabaseAccountGetResults cosmosDBAccount = CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(TargetResourceGroupName, TargetDatabaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountGetResults(cosmosDBAccount));
            }

            return;
        }
    }
}
