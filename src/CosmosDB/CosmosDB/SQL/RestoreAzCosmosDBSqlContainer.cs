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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlContainer", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlDatabaseGetResults), typeof(ConflictingResourceException))]
    public class RestoreAzCosmosDBSqlContainer : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.ContainerNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ResourceRestoreTimestampHelpMessage)]
        public DateTime RestoreTimestampInUtc { get; set; }

        public (DateTime, DateTime, string) ProcessRestorableDatabases(IEnumerable restorableDatabases)
        {
            DateTime latestDatabaseDeleteTime = DateTime.MinValue;
            DateTime latestDatabaseCreateOrRecreateTime = DateTime.MinValue;
            string databaseRid = null;

            foreach (RestorableSqlDatabaseGetResult restorableDatabase in restorableDatabases)
            {
                RestorableSqlDatabasePropertiesResource resource = restorableDatabase.Resource;

                if (resource != null && resource.OwnerId.Equals(this.DatabaseName))
                {
                    databaseRid = resource.OwnerResourceId;
                    var eventTimestamp = DateTime.Parse(resource.EventTimestamp);
                    if (resource.OperationType == "Delete" && latestDatabaseDeleteTime < eventTimestamp)
                    {
                        latestDatabaseDeleteTime = eventTimestamp;
                    }

                    if ((resource.OperationType == "Create" || resource.OperationType == "Recreate") && latestDatabaseCreateOrRecreateTime < eventTimestamp)
                    {
                        latestDatabaseCreateOrRecreateTime = eventTimestamp;
                    }
                }
            }

            if (databaseRid == null)
            {
                this.WriteWarning($"No restorable database found with name: {this.DatabaseName}");
                return (latestDatabaseDeleteTime, latestDatabaseCreateOrRecreateTime, databaseRid);
            }

            // Database never deleted then reset it to max time
            if (latestDatabaseDeleteTime == DateTime.MinValue)
            {
                latestDatabaseDeleteTime = DateTime.MaxValue;
            }

            this.WriteDebug($"ProcessRestorableDatabases: latestDatabaseDeleteTime {latestDatabaseDeleteTime}," +
                $" latestDatabaseCreateOrRecreateTime {latestDatabaseCreateOrRecreateTime}, databaseName {this.DatabaseName}, databaseRid {databaseRid}");

            return (latestDatabaseDeleteTime, latestDatabaseCreateOrRecreateTime, databaseRid);
        }

        public (DateTime, DateTime, string) ProcessRestorableCollections(IEnumerable restorableCollections)
        {
            DateTime latestCollectionDeleteTime = DateTime.MinValue;
            DateTime latestCollectionCreateOrRecreateTime = DateTime.MinValue;
            string collectionRid = null;

            foreach (RestorableSqlContainerGetResult restorableCollection in restorableCollections)
            {
                RestorableSqlContainerPropertiesResource resource = restorableCollection.Resource;

                if (resource != null && resource.OwnerId.Equals(this.Name))
                {
                    collectionRid = resource.OwnerResourceId;
                    var eventTimestamp = DateTime.Parse(resource.EventTimestamp);
                    if (resource.OperationType == "Delete" && latestCollectionDeleteTime < eventTimestamp)
                    {
                        latestCollectionDeleteTime = eventTimestamp;
                    }

                    if ((resource.OperationType == "Create" || resource.OperationType == "Recreate") && latestCollectionCreateOrRecreateTime < eventTimestamp)
                    {
                        latestCollectionCreateOrRecreateTime = eventTimestamp;
                    }
                }
            }

            if (collectionRid == null)
            {
                this.WriteWarning($"No restorable collection found with name: {this.Name} in database with name: {this.DatabaseName}");
                return (latestCollectionDeleteTime, latestCollectionCreateOrRecreateTime, collectionRid);
            }

            // Collection never deleted then reset it to max time
            latestCollectionDeleteTime = latestCollectionDeleteTime == DateTime.MinValue ? DateTime.MaxValue : latestCollectionDeleteTime;

            this.WriteDebug($"ProcessRestorableCollections: latestCollectionDeleteTime {latestCollectionDeleteTime}," +
                $" latestCollectionCreateOrRecreateTime {latestCollectionCreateOrRecreateTime}, databaseName {this.DatabaseName}, collectionName {this.Name}");

            return (latestCollectionDeleteTime, latestCollectionCreateOrRecreateTime, collectionRid);
        }

        public override void ExecuteCmdlet()
        {
          DateTime utcRestoreDateTime;
            RestorableDatabaseAccountGetResult databaseAccount = null;
            List<RestorableDatabaseAccountGetResult> restorableDatabaseAccounts = this.CosmosDBManagementClient.RestorableDatabaseAccounts.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.ToList();
            List<RestorableDatabaseAccountGetResult> accountsWithMatchingName = restorableDatabaseAccounts.Where(account => account.AccountName.Equals(this.AccountName, StringComparison.OrdinalIgnoreCase)).ToList();

            if (this.RestoreTimestampInUtc!= null && this.RestoreTimestampInUtc != default(DateTime))
            {
                if (this.RestoreTimestampInUtc.Kind == DateTimeKind.Unspecified)
                {
                    utcRestoreDateTime = this.RestoreTimestampInUtc;
                }
                else
                {
                    utcRestoreDateTime = this.RestoreTimestampInUtc.ToUniversalTime();
                }

                // Fail if provided restoretimesamp is greater than current timestamp
                if (utcRestoreDateTime > DateTime.UtcNow)
                {
                    this.WriteWarning($"Restore timestamp {utcRestoreDateTime} should be less than current timestamp {DateTime.UtcNow}");
                    return;
                }

                if (accountsWithMatchingName.Count > 0)
                {
                    foreach (RestorableDatabaseAccountGetResult restorableAccount in accountsWithMatchingName)
                    {
                        if (restorableAccount.CreationTime.HasValue &&
                            restorableAccount.CreationTime < utcRestoreDateTime)
                        {
                            if (!restorableAccount.DeletionTime.HasValue)
                            {
                                databaseAccount = restorableAccount;
                                break;
                            }
                        }
                    }
                }

                if (databaseAccount == null)
                {
                    this.WriteWarning($"No database accounts found with matching account name {this.AccountName} that was alive at given utc-timestamp {utcRestoreDateTime}");
                    return;
                }
            }
            else
            {
                if (accountsWithMatchingName.Count > 0)
                {
                    RestorableDatabaseAccountGetResult lastestAccountToRestore = null;
                    foreach (RestorableDatabaseAccountGetResult restorableAccount in accountsWithMatchingName)
                    {
                        if (lastestAccountToRestore == null || (restorableAccount.CreationTime.HasValue &&
                            restorableAccount.CreationTime > lastestAccountToRestore.CreationTime))
                        {
                            if (!restorableAccount.DeletionTime.HasValue)
                            {
                                lastestAccountToRestore = restorableAccount;
                            }
                        }
                    }

                    databaseAccount = lastestAccountToRestore;
                }

                if (databaseAccount == null)
                {
                    this.WriteWarning($"No database accounts found with matching account name {this.AccountName} that was alive");
                    return;
                }

                string accountInstanceId = databaseAccount.Name;

                IEnumerable restorableSqlDatabases = CosmosDBManagementClient.RestorableSqlDatabases.ListWithHttpMessagesAsync(databaseAccount.Location, accountInstanceId).GetAwaiter().GetResult().Body;
                (DateTime latestDatabaseDeleteTime, DateTime latestDatabaseCreateOrRecreateTime, string databaseRid) = ProcessRestorableDatabases(restorableSqlDatabases);

                if (databaseRid == null)
                {
                    return;
                }

                // Database is alive if create or recreate timestamp is later than latest delete timestamp
                bool isDatabaseAlive = latestDatabaseCreateOrRecreateTime > latestDatabaseDeleteTime || latestDatabaseDeleteTime == DateTime.MaxValue;

                if (!isDatabaseAlive)
                {
                    this.WriteWarning($"No active database with name {this.DatabaseName} found that contains the collection {this.Name} in location {databaseAccount.Location}");
                    return;
                }

                IEnumerable restorableSqlContainers = CosmosDBManagementClient.RestorableSqlContainers.ListWithHttpMessagesAsync(
                    databaseAccount.Location,
                    accountInstanceId,
                    databaseRid).GetAwaiter().GetResult().Body;

                (DateTime latestCollectionDeleteTime, DateTime latestCollectionCreateOrRecreateTime, string collectionRid) = ProcessRestorableCollections(restorableSqlContainers);

                if (collectionRid == null)
                {
                    return;
                }

                // Collection is alive if create or recreate timestamp is later than latest delete timestamp
                bool isCollectionAlive = latestCollectionCreateOrRecreateTime > latestCollectionDeleteTime || latestCollectionDeleteTime == DateTime.MaxValue;

                if (isCollectionAlive)
                {
                    this.WriteWarning($"The collection {this.Name} in database {this.DatabaseName} is currently online. " +
                        $"Please delete the collection and provide a restore timestamp for restoring different instance of the collection. in location {databaseAccount.Location}");
                    return;
                }

                //Subtracting 1 second from delete timestamp to restore till end of logchain in no timestamp restore.
                utcRestoreDateTime = latestCollectionDeleteTime.AddSeconds(-1);
            }
            SqlContainerResource sqlContainerResource = new SqlContainerResource
            {
                Id = Name,
                CreateMode = CreateMode.Restore,
                RestoreParameters = new ResourceRestoreParameters()
                {
                    RestoreSource = databaseAccount.Id,
                    RestoreTimestampInUtc = utcRestoreDateTime
                }
            };
            SqlContainerCreateUpdateParameters sqlContainerCreateUpdateParameters = new SqlContainerCreateUpdateParameters
            {
                Resource = sqlContainerResource,
                Options = new CreateUpdateOptions()
            };

            if (this.ShouldProcess(this.Name, "Restoring a CosmosDB Sql Container"))
            {
                SqlContainerGetResults sqlContainerGetResults = this.CosmosDBManagementClient.SqlResources.CreateUpdateSqlContainerWithHttpMessagesAsync(this.ResourceGroupName, this.AccountName, this.DatabaseName, this.Name, sqlContainerCreateUpdateParameters).GetAwaiter().GetResult().Body;
                this.WriteObject(new PSSqlContainerGetResults(sqlContainerGetResults));
            }

            return;
        }
    }
}