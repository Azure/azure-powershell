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
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.CosmosDB.Models;
using System.Reflection;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBCassandraTable", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSCassandraTableGetResults))]
    public class SetAzCosmosDBCassandraTable : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.AccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NameParameterSet, HelpMessage = Constants.KeyspaceNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string KeyspaceName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = Constants.CassandraTableNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.CassandraTableThroughputHelpMessage)]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TtlInSecondsHelpMessage)]
        public int? TtlInSeconds { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = Constants.CassandraSchemaHelpMessage)]
        [ValidateNotNull]
        public PSCassandraSchema Schema { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.CassandraKeyspaceObjectHelpMessage)]
        [ValidateNotNull]
        public PSCassandraKeyspaceGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                KeyspaceName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            IDictionary<string, string> options = new Dictionary<string, string>();
            if (Throughput != null)
            {
                options.Add("Throughput", Throughput.ToString());
            }

            CassandraTableResource cassandraTableResource = new CassandraTableResource
            {
                Id = Name,
                DefaultTtl = TtlInSeconds
            };
            cassandraTableResource.Schema = PSCassandraSchema.ConvertPSCassandraSchemaToCassandraSchema(Schema);

            CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters = new CassandraTableCreateUpdateParameters
            {
                Resource = cassandraTableResource,
                Options = options
            };

            if (ShouldProcess(Name, "Setting CosmosDB Cassandra Table"))
            {
                CassandraTableGetResults cassandraTableGetResults = CosmosDBManagementClient.CassandraResources.CreateUpdateCassandraTableWithHttpMessagesAsync(ResourceGroupName, AccountName, KeyspaceName, Name, cassandraTableCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSCassandraTableGetResults(cassandraTableGetResults));
            }

            return;
        }
    }
}
