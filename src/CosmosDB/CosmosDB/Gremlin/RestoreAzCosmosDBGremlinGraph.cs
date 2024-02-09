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
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB;
using System.Linq;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGremlinGraph", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSGremlinGraphGetResults), typeof(Exception))]
    public class RestoreAzCosmosDBGremlinGraph : AzureCosmosDBCmdletBase
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

        [Parameter(Mandatory = true, HelpMessage = Constants.GraphNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.RestoreTimestampHelpMessage)]
        [ValidateNotNullOrEmpty]
        public DateTime RestoreTimestampInUtc { get; set; }

        public override void ExecuteCmdlet()
        {
            DateTime utcRestoreDateTime;
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

            RestorableDatabaseAccountGetResult databaseAccount = null;
            List<RestorableDatabaseAccountGetResult> restorableDatabaseAccounts = this.CosmosDBManagementClient.RestorableDatabaseAccounts.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.ToList();
            List<RestorableDatabaseAccountGetResult> accountsWithMatchingName = restorableDatabaseAccounts.Where(account => account.AccountName.Equals(this.AccountName, StringComparison.OrdinalIgnoreCase)).ToList();
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

            GremlinGraphGetResults readGremlinGraphGetResults = null;
            try
            {
                readGremlinGraphGetResults = CosmosDBManagementClient.GremlinResources.GetGremlinGraph(ResourceGroupName, AccountName, DatabaseName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw;
                }
            }

            if (readGremlinGraphGetResults != null)
            {
                throw new ConflictingResourceException(message: string.Format(ExceptionMessage.Conflict, Name));
            }

            GremlinGraphResource gremlinGraphResource = new GremlinGraphResource
            {
                Id = Name,
                CreateMode = CreateMode.Restore,
                RestoreParameters = new ResourceRestoreParameters()
                {
                    RestoreTimestampInUtc = utcRestoreDateTime,
                    RestoreSource = databaseAccount.Id
                }
            };

            GremlinGraphCreateUpdateParameters gremlinGraphCreateUpdateParameters = new GremlinGraphCreateUpdateParameters
            {
                Resource = gremlinGraphResource,
                Options = new CreateUpdateOptions()
            };

            if (ShouldProcess(Name, "Restoring the deleted CosmosDB Gremlin Graph"))
            {
                GremlinGraphGetResults gremlinGraphGetResults = CosmosDBManagementClient.GremlinResources.CreateUpdateGremlinGraphWithHttpMessagesAsync(ResourceGroupName, AccountName, DatabaseName, Name, gremlinGraphCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSGremlinGraphGetResults(gremlinGraphGetResults));
            }

            return;
        }
    }
}
