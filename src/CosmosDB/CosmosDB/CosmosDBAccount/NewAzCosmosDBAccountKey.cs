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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBAccountKey", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(string))]
    public class NewAzCosmosDBAccountKey : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AccountKeyKindHelpMessage)]
        [PSArgumentCompleter("primary", "primaryReadonly", "secondary", "secondaryReadonly")]
        public string KeyKind { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = Constants.ResourceIdHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSDatabaseAccountGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!ParameterSetName.Equals(NameParameterSet))
            {
                ResourceIdentifier resourceIdentifier = null;
                if (ParameterSetName.Equals(ResourceIdParameterSet, StringComparison.Ordinal))
                {
                    resourceIdentifier = new ResourceIdentifier(ResourceId);
                }
                else if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
                {
                    resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                }

                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
            }

            if (ShouldProcess(KeyKind, string.Format("Regenerating key for Database Account:", Name)))
            {
                CosmosDBManagementClient.DatabaseAccounts.RegenerateKeyWithHttpMessagesAsync(ResourceGroupName, Name, new DatabaseAccountRegenerateKeyParameters{ KeyKind = KeyKind }).GetAwaiter().GetResult();

                DatabaseAccountListKeysResult response = CosmosDBManagementClient.DatabaseAccounts.ListKeysWithHttpMessagesAsync(ResourceGroupName, Name).GetAwaiter().GetResult().Body;
                PSDatabaseAccountListKeys databaseAccountListKeys = new PSDatabaseAccountListKeys(response);

                switch (KeyKind)
                {
                    case "primary":
                        WriteObject(databaseAccountListKeys.Keys["PrimaryMasterKey"]);
                        break;

                    case "primaryReadonly":
                        WriteObject(databaseAccountListKeys.Keys["PrimaryReadonlyMasterKey"]);
                        break;

                    case "secondary":
                        WriteObject(databaseAccountListKeys.Keys["SecondaryMasterKey"]);
                        break;

                    case "secondaryReadonly":
                        WriteObject(databaseAccountListKeys.Keys["SecondaryReadonlyMasterKey"]);
                        break;

                    default:
                        WriteWarning("Invalid value for KeyKind.");
                        break;
                }

                return;
            }
        }
    }
}
