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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSoftDeletedAccount", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSSoftDeletedDatabaseAccountGetResult))]
    public class GetAzCosmosDBSoftDeletedAccount : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, HelpMessage = Constants.SoftDeletedLocationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SoftDeletedAccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(ResourceGroupName))
            {
                SoftDeletedDatabaseAccountGetResult softDeletedAccount = CosmosDBManagementClient.SoftDeletedDatabaseAccounts.GetWithHttpMessagesAsync(ResourceGroupName, Location, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSSoftDeletedDatabaseAccountGetResult(softDeletedAccount));
            }
            else
            {
                IEnumerable softDeletedAccounts = CosmosDBManagementClient.SoftDeletedDatabaseAccounts.ListByLocationWithHttpMessagesAsync(Location).GetAwaiter().GetResult().Body;
                foreach (SoftDeletedDatabaseAccountGetResult softDeletedAccount in softDeletedAccounts)
                {
                    WriteObject(new PSSoftDeletedDatabaseAccountGetResult(softDeletedAccount));
                }
            }
        }
    }
}
