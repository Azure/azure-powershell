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
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccountKey", DefaultParameterSetName = NameParameterSet), OutputType(typeof(Hashtable))]
    public class GetAzCosmosDBAccountKey : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AccountKeyTypeHelpMessage)]
        public string Type { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccountGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!ParameterSetName.Equals(NameParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = null;
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                   resourceIdentifier = new ResourceIdentifier(ResourceId);
                }
                else if (ParameterSetName.Equals(ObjectParameterSet))
                {
                   resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                }
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
            }

            if (string.IsNullOrEmpty(Type))
                Type = "Keys";

            if (Type.Equals("ConnectionStrings", StringComparison.OrdinalIgnoreCase))
            {
                DatabaseAccountListConnectionStringsResult response = CosmosDBManagementClient.DatabaseAccounts.ListConnectionStringsWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountListKeys(response).Keys);
            }
            else if (Type.Equals("ReadOnlyKeys", StringComparison.OrdinalIgnoreCase))
            {
                DatabaseAccountListReadOnlyKeysResult response = CosmosDBManagementClient.DatabaseAccounts.ListReadOnlyKeysWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountListKeys(response).Keys);
            }
            else
            {
                DatabaseAccountListKeysResult response = CosmosDBManagementClient.DatabaseAccounts.ListKeysWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSDatabaseAccountListKeys(response).Keys);
            }

            return;
        }
    }
}
