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

using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.CosmosDB.Models;
using System.Collections;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBRestorableDatabaseAccount", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSRestorableDatabaseAccountGetResult))]
    public class GetAzCosmosDBRestorableDatabaseAccount : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.LocationNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string LocationName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AccountInstanceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseAccountInstanceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(DatabaseAccountInstanceId))
            {
                RestorableDatabaseAccountGetResult restorableDatabaseAccount = CosmosDBManagementClient.RestorableDatabaseAccounts.GetByLocationWithHttpMessagesAsync(
                    LocationName,
                    DatabaseAccountInstanceId).GetAwaiter().GetResult().Body;

                WriteObject(new PSRestorableDatabaseAccountGetResult(restorableDatabaseAccount));
            }
            else if (!string.IsNullOrEmpty(LocationName))
            {
                IEnumerable restorableDatabaseAccounts = CosmosDBManagementClient.RestorableDatabaseAccounts.ListByLocationWithHttpMessagesAsync(LocationName).GetAwaiter().GetResult().Body;
                foreach (RestorableDatabaseAccountGetResult restorableDatabaseAccount in restorableDatabaseAccounts)
                    WriteObject(new PSRestorableDatabaseAccountGetResult(restorableDatabaseAccount));
            }
            else
            {
                IEnumerable restorableDatabaseAccounts = CosmosDBManagementClient.RestorableDatabaseAccounts.ListWithHttpMessagesAsync().GetAwaiter().GetResult().Body;
                foreach (RestorableDatabaseAccountGetResult restorableDatabaseAccount in restorableDatabaseAccounts)
                    WriteObject(new PSRestorableDatabaseAccountGetResult(restorableDatabaseAccount));
            }
        }
    }
}
