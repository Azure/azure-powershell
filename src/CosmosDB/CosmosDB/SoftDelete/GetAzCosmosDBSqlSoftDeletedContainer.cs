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
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBSqlSoftDeletedContainer", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSSoftDeletedSqlContainerGetResult))]
    public class GetAzCosmosDBSqlSoftDeletedContainer : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.SoftDeletedLocationHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.SoftDeletedContainerNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                SoftDeletedSqlContainerGetResult softDeletedContainer = CosmosDBManagementClient.SoftDeletedSqlContainers.GetWithHttpMessagesAsync(ResourceGroupName, Location, AccountName, DatabaseName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSSoftDeletedSqlContainerGetResult(softDeletedContainer));
            }
            else
            {
                IEnumerable softDeletedContainers = CosmosDBManagementClient.SoftDeletedSqlContainers.ListWithHttpMessagesAsync(ResourceGroupName, Location, AccountName, DatabaseName).GetAwaiter().GetResult().Body;
                foreach (SoftDeletedSqlContainerGetResult softDeletedContainer in softDeletedContainers)
                {
                    WriteObject(new PSSoftDeletedSqlContainerGetResult(softDeletedContainer));
                }
            }
        }
    }
}
