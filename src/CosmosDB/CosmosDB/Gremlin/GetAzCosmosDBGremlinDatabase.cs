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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBGremlinDatabase", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSGremlinDatabaseGetResults), typeof(PSThroughputSettingsGetResults))]
    public class GetAzCosmosDBGremlinDatabase : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.DatabaseNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.AccountObjectHelpMessage)]
        [ValidateNotNull]
        public PSDatabaseAccount InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.GremlinDatabaseDetailedParamHelpMessage)]
        public SwitchParameter Detailed { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                AccountName = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (!string.IsNullOrEmpty(Name))
            {
                GremlinDatabaseGetResults gremlinDatabaseGetResults = CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseWithHttpMessagesAsync(ResourceGroupName, AccountName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSGremlinDatabaseGetResults(gremlinDatabaseGetResults));

                if (Detailed)
                {
                    ThroughputSettingsGetResults throughputSettingsGetResults = CosmosDBManagementClient.GremlinResources.GetGremlinDatabaseThroughputWithHttpMessagesAsync(ResourceGroupName, AccountName, Name).GetAwaiter().GetResult().Body;
                    WriteObject(throughputSettingsGetResults);
                }
            }
            else
            {
                IEnumerable<GremlinDatabaseGetResults> gremlinDatabases = CosmosDBManagementClient.GremlinResources.ListGremlinDatabasesWithHttpMessagesAsync(ResourceGroupName, AccountName).GetAwaiter().GetResult().Body;
                
                foreach (GremlinDatabaseGetResults gremlinDatabase in gremlinDatabases)
                    WriteObject(new PSGremlinDatabaseGetResults(gremlinDatabase));
            }

            return;
        }
    }
}
