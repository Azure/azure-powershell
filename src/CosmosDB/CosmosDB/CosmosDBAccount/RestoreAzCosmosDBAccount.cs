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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Extensions.Azure;
using Newtonsoft.Json.Converters;
using SDKModel = Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccount", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSDatabaseAccountGetResults))]
    public class RestoreAzCosmosDBAccount : AzureCosmosDBCmdletBase
    {
        [Newtonsoft.Json.JsonConverter(typeof(IsoDateTimeConverter))]
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

        [Parameter(Mandatory = false, HelpMessage = Constants.GremlinDatabasesToRestoreHelpMessage)]
        public PSGremlinDatabaseToRestore[] GremlinDatabasesToRestore { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TablesToRestoreHelpMessage)]
        public PSTablesToRestore TablesToRestore { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.PublicNetworkAccessHelpMessage)]
        [PSArgumentCompleter(SDKModel.PublicNetworkAccess.Disabled, SDKModel.PublicNetworkAccess.Enabled)]
        public string PublicNetworkAccess { get; set; }
        
        [Parameter(Mandatory = false, HelpMessage = Constants.DisableTtlHelpMessage)]
        public bool? DisableTtl { get; set; }

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

            bool isSourceRestorableAccountDeleted = false;
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
                        if (restorableAccount.DeletionTime.HasValue)
                        {
                            if (restorableAccount.DeletionTime >= utcRestoreDateTime)
                            {
                                sourceAccountToRestore = restorableAccount;
                                isSourceRestorableAccountDeleted = true;
                                break;
                            }
                        }
                        else
                        {
                            sourceAccountToRestore = restorableAccount;
                            isSourceRestorableAccountDeleted = false;
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

            // Validate if source account is empty if the source account is a live account.
            if (!isSourceRestorableAccountDeleted)
            {
                bool restorableResourcesNotFound = false;
                if (sourceAccountToRestore.ApiType.Equals("Sql", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        IEnumerable<RestorableSqlResourcesGetResult> restorableResources = CosmosDBManagementClient.RestorableSqlResources.ListWithHttpMessagesAsync(
                            sourceAccountToRestore.Location,
                            sourceAccountToRestore.Name,
                            Location,
                            utcRestoreDateTime.ToString()).GetAwaiter().GetResult().Body;

                        restorableResourcesNotFound = restorableResources == null || !restorableResources.Any();
                    }
                    catch (Exception)
                    {
                        WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} that was alive at given utc-timestamp {utcRestoreDateTime} in location {Location}");
                        return;
                    }
                }
                else if (sourceAccountToRestore.ApiType.Equals("MongoDB", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        IEnumerable<RestorableMongodbResourcesGetResult> restorableResources = CosmosDBManagementClient.RestorableMongodbResources.ListWithHttpMessagesAsync(
                        sourceAccountToRestore.Location,
                        sourceAccountToRestore.Name,
                        Location,
                        utcRestoreDateTime.ToString()).GetAwaiter().GetResult().Body;

                        restorableResourcesNotFound = restorableResources == null || !restorableResources.Any();
                    }
                    catch (Exception)
                    {
                        WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} that was alive at given utc-timestamp {utcRestoreDateTime} in location {Location}");
                        return;
                    }
                }
                else if (sourceAccountToRestore.ApiType.Equals("Gremlin, Sql", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        IEnumerable<RestorableGremlinResourcesGetResult> restorableResources = CosmosDBManagementClient.RestorableGremlinResources.ListWithHttpMessagesAsync(
                        sourceAccountToRestore.Location,
                        sourceAccountToRestore.Name,
                        Location,
                        utcRestoreDateTime.ToString()).GetAwaiter().GetResult().Body;

                        restorableResourcesNotFound = restorableResources == null || !restorableResources.Any();
                    }
                    catch (Exception)
                    {
                        WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} that was alive at given utc-timestamp {utcRestoreDateTime} in location {Location}");
                        return;
                    }
                }
                else if (sourceAccountToRestore.ApiType.Equals("Table, Sql", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        IEnumerable<RestorableTableResourcesGetResult> restorableResources = CosmosDBManagementClient.RestorableTableResources.ListWithHttpMessagesAsync(
                        sourceAccountToRestore.Location,
                        sourceAccountToRestore.Name,
                        Location,
                        utcRestoreDateTime.ToString()).GetAwaiter().GetResult().Body;

                        restorableResourcesNotFound = restorableResources == null || !restorableResources.Any();
                    }
                    catch (Exception)
                    {
                        WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} that was alive at given utc-timestamp {utcRestoreDateTime} in location {Location}");
                        return;
                    }
                }
                else
                {
                    WriteWarning($"Provided API Type {sourceAccountToRestore.ApiType} is not supported");
                    return;
                }

                if (restorableResourcesNotFound)
                {
                    WriteWarning($"Database account {SourceDatabaseAccountName} contains no restorable resources in location {Location} at given restore timestamp {utcRestoreDateTime} in location {Location}");
                    return;
                }
            }

            // Trigger restore
            PSRestoreParameters restoreParameters = new PSRestoreParameters()
            {
                RestoreSource = sourceAccountToRestore.Id,
                RestoreTimestampInUtc = utcRestoreDateTime,
                DatabasesToRestore = DatabasesToRestore,
                TablesToRestore = TablesToRestore,
                GremlinDatabasesToRestore = GremlinDatabasesToRestore,
                DisableTtl = DisableTtl
            };

            Collection<Location> LocationCollection = new Collection<Location>();
            Location loc = new Location(locationName: Location, failoverPriority: 0);
            LocationCollection.Add(loc);

            string apiKind = "GlobalDocumentDB";
            if (sourceAccountToRestore.ApiType.Equals("MongoDB", StringComparison.OrdinalIgnoreCase))
            {
                apiKind = "MongoDB";
            }

            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations: LocationCollection, location: sourceAccountToRestore.Location, name: TargetDatabaseAccountName)
            {
                Kind = apiKind,
                CreateMode = CreateMode.Restore,
                RestoreParameters = restoreParameters.ToSDKModel(),
                PublicNetworkAccess = PublicNetworkAccess
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
