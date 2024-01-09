﻿// ----------------------------------------------------------------------------------
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
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlDatabase", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSSqlDatabaseGetResults), typeof(ConflictingResourceException))]
    public class RestoreAzCosmosDBSqlDatabase : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ResourceRestoreTimestampHelpMessage)]
        public DateTime RestoreTimestampInUtc { get; set; }

        public override void ExecuteCmdlet()
        {
            DateTime utcRestoreDateTime;
            RestorableDatabaseAccountGetResult sourceAccountToRestore = null;
            List<RestorableDatabaseAccountGetResult> restorableDatabaseAccounts = this.CosmosDBManagementClient.RestorableDatabaseAccounts.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.ToList();
            List<RestorableDatabaseAccountGetResult> accountsWithMatchingName = restorableDatabaseAccounts.Where(databaseAccount => databaseAccount.AccountName.Equals(this.AccountName, StringComparison.OrdinalIgnoreCase)).ToList();

            if (this.RestoreTimestampInUtc != null && this.RestoreTimestampInUtc != default(DateTime))
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
                            restorableAccount.CreationTime < utcRestoreDateTime )
                        {
                            if (!restorableAccount.DeletionTime.HasValue)
                            {
                                sourceAccountToRestore = restorableAccount;
                                break;
                            }
                        }
                    }
                }

                if (sourceAccountToRestore == null)
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

                    sourceAccountToRestore = lastestAccountToRestore;
                }

                if (sourceAccountToRestore == null)
                {
                    this.WriteWarning($"No database accounts found with matching account name {this.AccountName} that was alive");
                    return;
                }

                string accountInstanceId = sourceAccountToRestore.Name;
                IEnumerable restorableSqlDatabases = CosmosDBManagementClient.RestorableSqlDatabases.ListWithHttpMessagesAsync(sourceAccountToRestore.Location, accountInstanceId).GetAwaiter().GetResult().Body;
                DateTime latestDeleteTime = DateTime.MinValue;
                foreach (RestorableSqlDatabaseGetResult restorableSqlDatabase in restorableSqlDatabases)
                {
                    DateTime eventDateTime = DateTime.Parse(restorableSqlDatabase.Resource.EventTimestamp);
                    if (restorableSqlDatabase.Resource.OperationType.Equals(OperationType.Delete) && latestDeleteTime < eventDateTime && restorableSqlDatabase.Resource.OwnerId.Equals(Name))
                    {
                        latestDeleteTime = eventDateTime;
                    }
                }

                if (latestDeleteTime == DateTime.MinValue)
                {
                    this.WriteWarning($"No deleted database with name {this.Name} found in the account name {this.AccountName}");
                }

                //Subtracting 1 second from delete timestamp to restore till end of logchain in no timestamp restore.
                utcRestoreDateTime = latestDeleteTime.AddSeconds(-1);
            }

            SqlDatabaseCreateUpdateParameters sqlDatabaseCreateUpdateParameters = new SqlDatabaseCreateUpdateParameters
            {
                Resource = new SqlDatabaseResource
                {
                    Id = Name,
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new ResourceRestoreParameters()
                    {
                        RestoreTimestampInUtc = utcRestoreDateTime,
                        RestoreSource = sourceAccountToRestore.Id
                    }
                },
                Options = new CreateUpdateOptions()
            };

            if (this.ShouldProcess(this.Name, "Restoring a CosmosDB Sql Database"))
            {
                SqlDatabaseGetResults sqlDatabaseGetResults = this.CosmosDBManagementClient.SqlResources.CreateUpdateSqlDatabaseWithHttpMessagesAsync(this.ResourceGroupName, this.AccountName, this.Name, sqlDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                this.WriteObject(new PSSqlDatabaseGetResults(sqlDatabaseGetResults));
            }

            return;
        }
    }
}