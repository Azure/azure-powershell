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
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB;
using System.Linq;
using System.Collections;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBTable", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSTableGetResults), typeof(ConflictingResourceException))]
    public class RestoreAzCosmosDBTable : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.TableNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ResourceRestoreTimestampHelpMessage)]
        public DateTime RestoreTimestampInUtc { get; set; }

        public (DateTime, DateTime, string) ProcessRestorableDatabases(IEnumerable restorableDatabases)
        {
            DateTime latestDatabaseDeleteTime = DateTime.MinValue;
            DateTime latestDatabaseCreateOrRecreateTime = DateTime.MinValue;
            string databaseRid = null;
            string databaseName = this.Name;

            foreach (RestorableTableGetResult restorableDatabase in restorableDatabases)
            {
                RestorableTablePropertiesResource resource = restorableDatabase.Resource;

                if (resource != null && resource.OwnerId.Equals(databaseName))
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
                this.WriteWarning($"No restorable database found with name: {databaseName}");
                return (latestDatabaseDeleteTime, latestDatabaseCreateOrRecreateTime, databaseRid);
            }

            // Database never deleted then reset it to max time
            if (latestDatabaseDeleteTime == DateTime.MinValue)
            {
                latestDatabaseDeleteTime = DateTime.MaxValue;
            }

            this.WriteDebug($"ProcessRestorableDatabases: latestDatabaseDeleteTime {latestDatabaseDeleteTime}," +
                $" latestDatabaseCreateOrRecreateTime {latestDatabaseCreateOrRecreateTime}, databaseName {databaseName}, databaseRid {databaseRid}");

            return (latestDatabaseDeleteTime, latestDatabaseCreateOrRecreateTime, databaseRid);
        }

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

                string accountInstanceId = databaseAccount.Name;

                IEnumerable restorableTables = CosmosDBManagementClient.RestorableTables.ListWithHttpMessagesAsync(databaseAccount.Location, accountInstanceId, databaseAccount.CreationTime.ToString(), DateTime.MaxValue.ToString()).GetAwaiter().GetResult().Body;
                (DateTime latestDatabaseDeleteTime, DateTime latestDatabaseCreateOrRecreateTime, string databaseRid) = ProcessRestorableDatabases(restorableTables);

                if (databaseRid == null)
                {
                    return;
                }
                // Database is alive if create or recreate timestamp is later than latest delete timestamp
                bool isDatabaseAlive = latestDatabaseCreateOrRecreateTime > latestDatabaseDeleteTime || latestDatabaseDeleteTime == DateTime.MaxValue;

                if (isDatabaseAlive)
                {
                    this.WriteWarning($"Database with name {this.Name} already exists in this account with name {this.AccountName} in location {databaseAccount.Location}");
                    return;
                }

                //Subtracting 1 second from delete timestamp to restore till end of logchain in no timestamp restore.
                utcRestoreDateTime = latestDatabaseDeleteTime.AddSeconds(-1);
            }
            

            TableGetResults readTableGetResults = null;
            try
            {
                readTableGetResults = CosmosDBManagementClient.TableResources.GetTable(ResourceGroupName, AccountName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (readTableGetResults != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, Name));
            }

            TableCreateUpdateParameters tableCreateUpdateParameters = new TableCreateUpdateParameters
            {
                Resource = new TableResource
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

            if (ShouldProcess(Name, "Restoring the deleted CosmosDB Table"))
            {
                TableGetResults tableGetResults = CosmosDBManagementClient.TableResources.CreateUpdateTableWithHttpMessagesAsync(ResourceGroupName, AccountName, Name, tableCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSTableGetResults(tableGetResults));
            }

            return;
        }
    }
}