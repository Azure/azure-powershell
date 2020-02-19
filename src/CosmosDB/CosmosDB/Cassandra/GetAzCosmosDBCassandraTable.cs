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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBCassandraTable", DefaultParameterSetName = NameParameterSet), OutputType(typeof(PSCassandraTableGetResults), typeof(PSThroughputSettingsGetResults))]
    public class GetAzCosmosDBCassandraTable : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.KeyspaceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string KeyspaceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.CassandraTableNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.CassandraKeyspaceObjectHelpMessage)]
        [ValidateNotNull]
        public PSCassandraKeyspaceGetResults InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.CassandraTableDetailedParamHelpMessage)]
        public SwitchParameter Detailed { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                KeyspaceName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            if (!string.IsNullOrEmpty(Name))
            {
                CassandraTableGetResults cassandraTableGetResults = CosmosDBManagementClient.CassandraResources.GetCassandraTableWithHttpMessagesAsync(ResourceGroupName, AccountName, KeyspaceName, Name).GetAwaiter().GetResult().Body;
                WriteObject(new PSCassandraTableGetResults(cassandraTableGetResults));

                if (Detailed)
                {
                    ThroughputSettingsGetResults throughputSettingsGetResults = CosmosDBManagementClient.CassandraResources.GetCassandraTableThroughputWithHttpMessagesAsync(ResourceGroupName, AccountName, KeyspaceName, Name).GetAwaiter().GetResult().Body;
                    WriteObject(throughputSettingsGetResults);
                }
            }
            else
            {
                IEnumerable<CassandraTableGetResults> cassandraTables = CosmosDBManagementClient.CassandraResources.ListCassandraTablesWithHttpMessagesAsync(ResourceGroupName, AccountName, KeyspaceName).GetAwaiter().GetResult().Body;
                
                foreach(CassandraTableGetResults cassandraTable in cassandraTables)
                    WriteObject(new PSCassandraTableGetResults(cassandraTable));
            }

            return;
        }
    }
}
