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

        [Parameter(Mandatory = false, HelpMessage = Constants.SourceBackupLocationHelpMessage)]
        public string SourceBackupLocation { get; set; }

        public override void ExecuteCmdlet()
        {
            System.IO.File.WriteAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 1");
            DateTime utcRestoreDateTime;
            if (RestoreTimestampInUtc.Kind == DateTimeKind.Unspecified)
            {
                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 1-1");
                utcRestoreDateTime = RestoreTimestampInUtc;
            }
            else
            {
                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 1-2");
                utcRestoreDateTime = RestoreTimestampInUtc.ToUniversalTime();
            }
            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 2");

            // Fail if provided restoretimesamp is greater than current timestamp
            if (utcRestoreDateTime > DateTime.UtcNow)
            {
                WriteWarning($"Restore timestamp {utcRestoreDateTime} should be less than current timestamp {DateTime.UtcNow}");
                return;
            }
            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 3");

            bool isSourceRestorableAccountDeleted = false;
            List<RestorableDatabaseAccountGetResult> restorableDatabaseAccounts = CosmosDBManagementClient.RestorableDatabaseAccounts.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.ToList();

            RestorableDatabaseAccountGetResult sourceAccountToRestore = null;
            List<RestorableDatabaseAccountGetResult> accountsWithMatchingName = restorableDatabaseAccounts.Where(databaseAccount => databaseAccount.AccountName.Equals(SourceDatabaseAccountName, StringComparison.OrdinalIgnoreCase)).ToList();
            if (accountsWithMatchingName.Count > 0)
            {
                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 4");
                foreach (RestorableDatabaseAccountGetResult restorableAccount in accountsWithMatchingName)
                {
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 5");
                    if (restorableAccount.CreationTime.HasValue &&
                        restorableAccount.CreationTime < utcRestoreDateTime)
                    {
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 6");
                        if (restorableAccount.DeletionTime.HasValue)
                        {
                            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 7");
                            if (restorableAccount.DeletionTime >= utcRestoreDateTime)
                            {
                                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 8");
                                sourceAccountToRestore = restorableAccount;
                                isSourceRestorableAccountDeleted = true;
                                break;
                            }
                            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 9");
                        }
                        else
                        {
                            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 10");
                            sourceAccountToRestore = restorableAccount;
                            isSourceRestorableAccountDeleted = false;
                            break;
                        }
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 11");
                    }
                }
            }

            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 12");

            if (sourceAccountToRestore == null)
            {
                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 13");
                WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} that was alive at given utc-timestamp {utcRestoreDateTime}");
                return;
            }
            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 14");

            // Validate if source account is empty if the source account is a live account.
            if (!isSourceRestorableAccountDeleted)
            {
                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 15");
                string sourceLocation = Location;
                if (!string.IsNullOrEmpty(SourceBackupLocation))
                {
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 16");
                    sourceLocation = SourceBackupLocation;
                }
                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 17");

                bool restorableResourcesNotFound = false;
                if (sourceAccountToRestore.ApiType.Equals("Sql", StringComparison.OrdinalIgnoreCase))
                {
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 18");
                    try
                    {
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 19");
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 19: Location = " + sourceAccountToRestore.Location);
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 19: Name = " + sourceAccountToRestore.Name);
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 19: Location = " + sourceAccountToRestore.Location);
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 19: utcRestoreDateTime = " + utcRestoreDateTime.ToString());
                        IEnumerable<RestorableSqlResourcesGetResult> restorableResources = CosmosDBManagementClient.RestorableSqlResources.ListWithHttpMessagesAsync(
                            sourceAccountToRestore.Location,
                            sourceAccountToRestore.Name,
                            sourceLocation,
                            utcRestoreDateTime.ToString()).GetAwaiter().GetResult().Body;

                        restorableResourcesNotFound = restorableResources == null || !restorableResources.Any();
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 20");
                    }
                    catch (Exception)
                    {
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 21");
                        WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} that was alive at given utc-timestamp {utcRestoreDateTime} in location {sourceLocation}");
                        return;
                    }
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 22");
                }
                else if (sourceAccountToRestore.ApiType.Equals("MongoDB", StringComparison.OrdinalIgnoreCase))
                {
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 23");
                    try
                    {
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 24");
                        IEnumerable<RestorableMongodbResourcesGetResult> restorableResources = CosmosDBManagementClient.RestorableMongodbResources.ListWithHttpMessagesAsync(
                        sourceAccountToRestore.Location,
                        sourceAccountToRestore.Name,
                        sourceLocation,
                        utcRestoreDateTime.ToString()).GetAwaiter().GetResult().Body;

                        restorableResourcesNotFound = restorableResources == null || !restorableResources.Any();
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 25");
                    }
                    catch (Exception)
                    {
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 26");
                        WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} that was alive at given utc-timestamp {utcRestoreDateTime} in location {sourceLocation}");
                        return;
                    }
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 27");
                }
                else if (sourceAccountToRestore.ApiType.Equals("Gremlin, Sql", StringComparison.OrdinalIgnoreCase))
                {
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 28");
                    try
                    {
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 29");
                        IEnumerable<RestorableGremlinResourcesGetResult> restorableResources = CosmosDBManagementClient.RestorableGremlinResources.ListWithHttpMessagesAsync(
                        sourceAccountToRestore.Location,
                        sourceAccountToRestore.Name,
                        sourceLocation,
                        utcRestoreDateTime.ToString()).GetAwaiter().GetResult().Body;

                        restorableResourcesNotFound = restorableResources == null || !restorableResources.Any();
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 30");
                    }
                    catch (Exception)
                    {
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 31");
                        WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} that was alive at given utc-timestamp {utcRestoreDateTime} in location {sourceLocation}");
                        return;
                    }
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 32");
                }
                else if (sourceAccountToRestore.ApiType.Equals("Table, Sql", StringComparison.OrdinalIgnoreCase))
                {
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 33");
                    try
                    {
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 34");
                        IEnumerable<RestorableTableResourcesGetResult> restorableResources = CosmosDBManagementClient.RestorableTableResources.ListWithHttpMessagesAsync(
                        sourceAccountToRestore.Location,
                        sourceAccountToRestore.Name,
                        sourceLocation,
                        utcRestoreDateTime.ToString()).GetAwaiter().GetResult().Body;

                        restorableResourcesNotFound = restorableResources == null || !restorableResources.Any();
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 35");
                    }
                    catch (Exception)
                    {
                        System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 36");
                        WriteWarning($"No database accounts found with matching account name {SourceDatabaseAccountName} that was alive at given utc-timestamp {utcRestoreDateTime} in location {sourceLocation}");
                        return;
                    }
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 37");
                }
                else
                {
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 38");
                    WriteWarning($"Provided API Type {sourceAccountToRestore.ApiType} is not supported");
                    return;
                }

                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 39");

                if (restorableResourcesNotFound)
                {
                    System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 40");
                    WriteWarning($"Database account {SourceDatabaseAccountName} contains no restorable resources in location {sourceLocation} at given restore timestamp {utcRestoreDateTime} in location {sourceLocation}");
                    return;
                }
                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 41");
            }

            // Trigger restore
            PSRestoreParameters restoreParameters = new PSRestoreParameters()
            {
                RestoreSource = sourceAccountToRestore.Id,
                RestoreTimestampInUtc = utcRestoreDateTime,
                DisableTtl = DisableTtl,
                DatabasesToRestore = DatabasesToRestore,
                TablesToRestore = TablesToRestore,
                GremlinDatabasesToRestore = GremlinDatabasesToRestore,
                SourceBackupLocation = SourceBackupLocation
            };
            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 41");

            Collection<Location> LocationCollection = new Collection<Location>();
            Location loc = new Location(locationName: Location, failoverPriority: 0);
            LocationCollection.Add(loc);
            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 42");

            string apiKind = "GlobalDocumentDB";
            if (sourceAccountToRestore.ApiType.Equals("MongoDB", StringComparison.OrdinalIgnoreCase))
            {
                apiKind = "MongoDB";
            }

            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 43");
            DatabaseAccountCreateUpdateParameters databaseAccountCreateUpdateParameters = new DatabaseAccountCreateUpdateParameters(locations: LocationCollection, location: sourceAccountToRestore.Location, name: TargetDatabaseAccountName)
            {
                Kind = apiKind,
                CreateMode = CreateMode.Restore,
                RestoreParameters = restoreParameters.ToSDKModel(),
                PublicNetworkAccess = PublicNetworkAccess
            };
            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 44");

            if (ShouldProcess(TargetDatabaseAccountName,
                string.Format(
                    "Creating Database Account by restoring Database Account with Name {0} and restorable database account Id {1} to the timestamp {2}",
                    SourceDatabaseAccountName,
                    sourceAccountToRestore.Id,
                    RestoreTimestampInUtc)))
            {
                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 45");
                DatabaseAccountGetResults cosmosDBAccount = CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(TargetResourceGroupName, TargetDatabaseAccountName, databaseAccountCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountGetResults(cosmosDBAccount));
                System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 46");
            }
            System.IO.File.AppendAllText("RestoreAzCosmosDBAccount.log", "\nin ExecuteCmdlet ---- step 47");

            return;
        }
    }
}
