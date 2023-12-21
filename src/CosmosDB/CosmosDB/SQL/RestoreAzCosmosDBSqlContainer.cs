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
using System.Text.RegularExpressions;
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
                DateTime latestDatabaseDeleteTime = DateTime.MinValue;
                DateTime latestDatabaseCreateOrRecreateTime = DateTime.MinValue;
                DateTime latestCollectionDeleteTime = DateTime.MinValue;
                DateTime latestCollectionCreateOrRecreateTime = DateTime.MinValue;
                string databaseRid = string.Empty;
                string collectionRid = string.Empty;
                foreach (RestorableSqlDatabaseGetResult restorableSqlDatabase in restorableSqlDatabases)
                {
                    if (restorableSqlDatabase.Resource.Database.Id.Equals(DatabaseName))
                    {
                        databaseRid = restorableSqlDatabase.Resource.Database.Rid;
                        DateTime eventDateTime = DateTime.Parse(restorableSqlDatabase.Resource.EventTimestamp);
                        if (restorableSqlDatabase.Resource.OperationType.Equals(OperationType.Delete) && latestDatabaseDeleteTime < eventDateTime)
                        {
                            latestDatabaseDeleteTime = eventDateTime;
                        }

                        if ((restorableSqlDatabase.Resource.OperationType.Equals(OperationType.Create) || restorableSqlDatabase.Resource.OperationType.Equals(OperationType.Recreate)) && latestDatabaseCreateOrRecreateTime < eventDateTime)
                        {
                            latestDatabaseCreateOrRecreateTime = eventDateTime;
                        }
                    }
                }

                latestDatabaseDeleteTime = latestDatabaseDeleteTime == default(DateTime) ? DateTime.MaxValue : latestDatabaseDeleteTime;
                IEnumerable restorableSqlContainers = CosmosDBManagementClient.RestorableSqlContainers.ListWithHttpMessagesAsync(
                    databaseAccount.Location,
                    accountInstanceId,
                    databaseRid,
                    latestDatabaseCreateOrRecreateTime.ToString(),
                    (latestDatabaseCreateOrRecreateTime < latestDatabaseDeleteTime) ? latestDatabaseDeleteTime.ToString() : DateTime.MaxValue.ToString()).GetAwaiter().GetResult().Body;
                 
                foreach (RestorableSqlContainerGetResult restorableSqlContainer in restorableSqlContainers)
                {
                    if (restorableSqlContainer.Resource.Container.Id.Equals(Name))
                    {
                        collectionRid = restorableSqlContainer.Resource.Rid;
                        DateTime eventDateTime = DateTime.Parse(restorableSqlContainer.Resource.EventTimestamp);
                        if (restorableSqlContainer.Resource.OperationType.Equals(OperationType.Delete) && latestCollectionDeleteTime < eventDateTime && eventDateTime <= latestDatabaseDeleteTime)
                        {
                            latestCollectionDeleteTime = eventDateTime;
                        }

                        if ((restorableSqlContainer.Resource.OperationType.Equals(OperationType.Create) || restorableSqlContainer.Resource.OperationType.Equals(OperationType.Recreate)) && latestCollectionDeleteTime < eventDateTime)
                        {
                            latestCollectionCreateOrRecreateTime = eventDateTime;
                        }
                    }
                }

                //Subtracting 1 second from delete timestamp to restore till end of logchain in no timestamp restore.
                if (latestCollectionDeleteTime < latestCollectionCreateOrRecreateTime && latestCollectionCreateOrRecreateTime <= latestDatabaseDeleteTime)
                {
                    utcRestoreDateTime = latestDatabaseDeleteTime.AddSeconds(-1);
                }
                else if (latestCollectionDeleteTime > latestCollectionCreateOrRecreateTime && latestCollectionDeleteTime < latestDatabaseDeleteTime)
                {
                    utcRestoreDateTime = latestCollectionDeleteTime.AddSeconds(-1);
                }
                else
                {
                    this.WriteWarning($"No container with name {Name} existed in the current version of database. Please provide a restore timestamp for restoring the collection from different instance of the database");
                    return;
                }
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