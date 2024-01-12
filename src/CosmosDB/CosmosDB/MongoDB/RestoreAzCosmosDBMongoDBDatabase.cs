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

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBMongoDBDatabase", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSMongoDBDatabaseGetResults), typeof(ConflictingResourceException))]
    public class RestoreAzCosmosDBMongoDBDatabase : AzureCosmosDBCmdletBase
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
            RestorableDatabaseAccountGetResult databaseAccount = null;
            List<RestorableDatabaseAccountGetResult> restorableDatabaseAccounts = this.CosmosDBManagementClient.RestorableDatabaseAccounts.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.ToList();
            List<RestorableDatabaseAccountGetResult> accountsWithMatchingName = restorableDatabaseAccounts.Where(account => account.AccountName.Equals(this.AccountName, StringComparison.OrdinalIgnoreCase)).ToList();

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
                        if (lastestAccountToRestore == null)
                        {
                            lastestAccountToRestore = restorableAccount;
                        }

                        if (restorableAccount.CreationTime.HasValue &&
                            restorableAccount.CreationTime > lastestAccountToRestore.CreationTime)
                        {
                            if (!restorableAccount.DeletionTime.HasValue)
                            {
                                lastestAccountToRestore = restorableAccount;
                            }
                        }
                    }

                    databaseAccount = lastestAccountToRestore;
                }
                else
                {
                    this.WriteWarning($"No database accounts found with matching account name {this.AccountName} that was alive");
                    return;
                }

                Regex regex = new Regex(@"[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}");
                var matches = regex.Matches(databaseAccount.Id);

                string accountInstanceId = string.Empty;
                if (matches.Count > 1)
                {
                    accountInstanceId = matches[1].Value;
                }


                DateTime latestDeleteTime = DateTime.MinValue;
                IEnumerable restorableMongoDBDatabases = CosmosDBManagementClient.RestorableMongodbDatabases.ListWithHttpMessagesAsync(databaseAccount.Location, accountInstanceId).GetAwaiter().GetResult().Body;
                foreach (RestorableMongodbDatabaseGetResult restorableMongoDBDatabase in restorableMongoDBDatabases)
                {
                    DateTime eventDateTime = DateTime.Parse(restorableMongoDBDatabase.Resource.EventTimestamp);
                    if (restorableMongoDBDatabase.Resource.OperationType.Equals(OperationType.Delete) && latestDeleteTime < eventDateTime)
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
            

            MongoDBDatabaseCreateUpdateParameters mongoDBDatabaseCreateUpdateParameters = new MongoDBDatabaseCreateUpdateParameters
            {
                Resource = new MongoDBDatabaseResource
                {
                    Id = Name,
                    CreateMode = CreateMode.Restore,
                    RestoreParameters = new ResourceRestoreParameters()
                    {
                        RestoreTimestampInUtc = utcRestoreDateTime,
                        RestoreSource = databaseAccount.Id
                    }
                },
                Options = new CreateUpdateOptions()
            };

            if (this.ShouldProcess(this.Name, "Restoring CosmosDB MongoDB Database"))
            {
                MongoDBDatabaseGetResults mongoDBDatabaseGetResults = CosmosDBManagementClient.MongoDbResources.CreateUpdateMongoDBDatabaseWithHttpMessagesAsync(this.ResourceGroupName, this.AccountName, this.Name, mongoDBDatabaseCreateUpdateParameters).GetAwaiter().GetResult().Body;
                this.WriteObject(new PSMongoDBDatabaseGetResults(mongoDBDatabaseGetResults));
            }

            return;
        }
    }
}