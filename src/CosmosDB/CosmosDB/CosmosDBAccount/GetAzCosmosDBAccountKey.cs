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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccountKey", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSDatabaseAccountListKeys))]
    public class GetAzCosmosDBAccountKey : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AccountKeyTypeHelpMessage)]
        public string Type { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ResourceId);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
            }

            if (Type == null)
                Type = "Keys";

            if (Type.Equals("ConnectionStrings"))
            {
                DatabaseAccountListConnectionStringsResultInner response = CosmosDBManagementClient.DatabaseAccounts.ListConnectionStringsWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountListKeys(response));
            }
            else if (Type.Equals("ReadOnlyKeys"))
            {
                DatabaseAccountListReadOnlyKeysResultInner response = CosmosDBManagementClient.DatabaseAccounts.ListReadOnlyKeysWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountListKeys(response));
            }
            else
            {
                DatabaseAccountListKeysResultInner response = CosmosDBManagementClient.DatabaseAccounts.ListKeysWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountListKeys(response));
            }
            return;
        }
    }
}
