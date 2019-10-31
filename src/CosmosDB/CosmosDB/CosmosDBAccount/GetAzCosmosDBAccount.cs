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
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccount", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSDatabaseAccountList))]
    public class GetAzCosmosDBAccount : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.AccountNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            DatabaseAccountInner databaseAccount = new DatabaseAccountInner();
            if (ParameterSetName.Equals(NameParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                if (Name != null)
                {
                    databaseAccount = CosmosDBManagementClient.DatabaseAccounts.GetWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body; 
                    WriteObject(databaseAccount);
                }
                else
                {
                    IEnumerable<DatabaseAccountInner> databaseAccounts = null;
                    databaseAccounts = CosmosDBManagementClient.DatabaseAccounts.ListByResourceGroupWithHttpMessagesAsync(ResourceGroupName).GetAwaiter().GetResult().Body;
                    WriteObject(new PSDatabaseAccountList(databaseAccounts));
                    return;
                }
            }
            else if (ParameterSetName.Equals(ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ResourceId);
                Name = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                databaseAccount = CosmosDBManagementClient.DatabaseAccounts.GetWithHttpMessagesAsync(Name, ResourceGroupName).GetAwaiter().GetResult().Body;
            }

            WriteObject(new PSDatabaseAccountList(databaseAccount));
            return;
        }
    }
}
