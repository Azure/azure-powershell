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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    public class RestoreRequestDynamicParameters
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.RestoreSourceIdHelpMessage)]
        public string SourceRestorableDatabaseAccountId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.RestoreSourceDatabaseAccountNameHelpMessage)]
        public string SourceDatabaseAccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.RestoreTimestampHelpMessage)]
        public DateTimeOffset RestoreTimestampInUtc { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DatabasesToRestoreHelpMessage)]
        public PSDatabaseToRestore[] DatabasesToRestore { get; set; }

        public PSRestoreParameters GetRestoreParameters(CosmosDBManagementClient cosmosDBManagementClient)
        {
            if (string.IsNullOrEmpty(SourceRestorableDatabaseAccountId) && !string.IsNullOrEmpty(SourceDatabaseAccountName))
            {
                List<RestorableDatabaseAccountGetResult> restorableDatabaseAccounts = cosmosDBManagementClient.RestorableDatabaseAccounts.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body.ToList();
                List<RestorableDatabaseAccountGetResult> accountsWithMatchingName = restorableDatabaseAccounts.Where(databaseAccount => databaseAccount.AccountName.Equals(SourceDatabaseAccountName, StringComparison.OrdinalIgnoreCase)).ToList();
                if (accountsWithMatchingName.Count > 0)
                {
                    foreach (RestorableDatabaseAccountGetResult restorableAccount in accountsWithMatchingName)
                    {
                        if (restorableAccount.CreationTime.HasValue &&
                            restorableAccount.CreationTime < RestoreTimestampInUtc)
                        {
                            if (!restorableAccount.DeletionTime.HasValue || restorableAccount.DeletionTime < RestoreTimestampInUtc)
                            {
                                SourceRestorableDatabaseAccountId = restorableAccount.Id;
                                break;
                            }
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(SourceRestorableDatabaseAccountId))
            {
                return null;
            }

            PSRestoreParameters restoreParameters = new PSRestoreParameters()
            {
                RestoreSource = SourceRestorableDatabaseAccountId,
                RestoreTimestampInUtc = RestoreTimestampInUtc.DateTime,
                DatabasesToRestore = DatabasesToRestore
            };

            return restoreParameters;
        }
    }
}
