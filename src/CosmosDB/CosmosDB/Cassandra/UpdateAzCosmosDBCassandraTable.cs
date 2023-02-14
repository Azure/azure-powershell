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
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Exceptions;
using Microsoft.Rest.Azure;
using Microsoft.Azure.PowerShell.Cmdlets.CosmosDB.Exceptions;
using Microsoft.Azure.Management.CosmosDB;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBCassandraTable", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSCassandraTableGetResults), typeof(ResourceNotFoundException))]
    public class UpdateAzCosmosDBCassandraTable : AzureCosmosDBCmdletBase
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

        [Parameter(Mandatory = false, HelpMessage = Constants.CassandraTableNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.CassandraTableThroughputHelpMessage)]
        public int? Throughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AutoscaleMaxThroughputHelpMessage)]
        public int? AutoscaleMaxThroughput { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.TtlInSecondsHelpMessage)]
        public int? TtlInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.AnalyticalStorageTtlHelpMessage)]
        public int? AnalyticalStorageTtl { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = Constants.CassandraSchemaHelpMessage)]
        [ValidateNotNull]
        public PSCassandraSchema Schema { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParentObjectParameterSet, HelpMessage = Constants.CassandraKeyspaceObjectHelpMessage)]
        [ValidateNotNull]
        public PSCassandraKeyspaceGetResults ParentObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ObjectParameterSet, HelpMessage = Constants.CassandraTableObjectHelpMessage)]
        [ValidateNotNull]
        public PSCassandraTableGetResults InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            if(ParameterSetName.Equals(ParentObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(ParentObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                KeyspaceName = resourceIdentifier.ResourceName;
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }
            else if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.Ordinal))
            {
                ResourceIdentifier resourceIdentifier = new ResourceIdentifier(InputObject.Id);
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
                Name = resourceIdentifier.ResourceName;
                KeyspaceName = ResourceIdentifierExtensions.GetCassandraKeyspaceName(resourceIdentifier);
                AccountName = ResourceIdentifierExtensions.GetDatabaseAccountName(resourceIdentifier);
            }

            CassandraTableGetResults readCassandraTableGetResults = null;
            try
            {
                readCassandraTableGetResults = CosmosDBManagementClient.CassandraResources.GetCassandraTable(ResourceGroupName, AccountName, KeyspaceName, Name);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(message: string.Format(ExceptionMessage.NotFound, Name), innerException: e);
                }
            }

            CassandraTableResource cassandraTableResource = PopulateCassandraTableResource(readCassandraTableGetResults.Resource);

            if(TtlInSeconds != null)
            {
                cassandraTableResource.DefaultTtl = TtlInSeconds;
            }

            if (Schema != null)
            {
                cassandraTableResource.Schema = PSCassandraSchema.ToSDKModel(Schema);
            }

            if(AnalyticalStorageTtl != null)
            {
                cassandraTableResource.AnalyticalStorageTtl = AnalyticalStorageTtl;
            }

            CreateUpdateOptions options = ThroughputHelper.PopulateCreateUpdateOptions(Throughput, AutoscaleMaxThroughput);

            CassandraTableCreateUpdateParameters cassandraTableCreateUpdateParameters = new CassandraTableCreateUpdateParameters
            {
                Resource = cassandraTableResource,
                Options = options,
            };

            if (ShouldProcess(Name, "Updating an existing CosmosDB Cassandra Table"))
            {
                CassandraTableGetResults cassandraTableGetResults = CosmosDBManagementClient.CassandraResources.CreateUpdateCassandraTableWithHttpMessagesAsync(ResourceGroupName, AccountName, KeyspaceName, Name, cassandraTableCreateUpdateParameters).GetAwaiter().GetResult().Body;
                WriteObject(new PSCassandraTableGetResults(cassandraTableGetResults));
            }

            return;
        }

        private CassandraTableResource PopulateCassandraTableResource(CassandraTableGetPropertiesResource resource)
        {
            return new CassandraTableResource
            {
                DefaultTtl = resource.DefaultTtl,
                Id = resource.Id,
                Schema = resource.Schema,
                AnalyticalStorageTtl = resource.AnalyticalStorageTtl
            };
        }
    }
}
