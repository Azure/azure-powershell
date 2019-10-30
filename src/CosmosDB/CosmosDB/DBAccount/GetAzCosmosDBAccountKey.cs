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
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccountKey", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSDatabaseAccountListConnectionStrings), typeof(PSDatabaseAccountListKeysResult), typeof(PSDatabaseAccountListReadOnlyKeysResult))]
    public class GetAzCosmosDBAccountKey : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Value from: {ConnectionStrings, Keys, ReadOnlyKeys}. Default is Keys. ")]
        [PSArgumentCompleter("ConnectionStrings", "Keys", "ReadOnlyKeys")]
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
                var response = CosmosClient.DatabaseAccounts.ListConnectionStringsWithHttpMessagesAsync(ResourceGroupName, Name).Result;
                WriteObject(response);
            }
            else if (Type.Equals("ReadOnlyKeys"))
            {
                var response = CosmosClient.DatabaseAccounts.ListReadOnlyKeysWithHttpMessagesAsync(ResourceGroupName, Name).Result;
                WriteObject(response);
            }
            else
            {
                var response = CosmosClient.DatabaseAccounts.ListKeysWithHttpMessagesAsync(ResourceGroupName, Name).Result;
                WriteObject(response);
            }
        }
    }
}
