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
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBCassandraSchema"), OutputType(typeof(PSCassandraSchema))]
    public class NewAzCosmosDBCassandraSchema : AzureCosmosDBCmdletBase
    {
        [Parameter(Mandatory = false, HelpMessage = Constants.CassandraSchemaColumnHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSColumn[] Column { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.CassandraSchemaPartitionKeyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string[] PartitionKey { get; set; }

        [Parameter(Mandatory = false, HelpMessage = Constants.CassandraSchemaClusterKeyHelpMessage)]
        [ValidateNotNullOrEmpty]
        public PSClusterKey[] ClusterKey { get; set; }

        public override void ExecuteCmdlet()
        {
            PSCassandraSchema psCassandraSchema = new PSCassandraSchema();

            if(Column != null && Column.Length > 0)
            {
                psCassandraSchema.Columns = Column;
            }

            if(PartitionKey != null && PartitionKey.Length > 0)
            {
                List<PSCassandraPartitionKey> PSPartitionKeys = new List<PSCassandraPartitionKey>();

                foreach(string partitionKey in PartitionKey)
                {
                    PSPartitionKeys.Add(new PSCassandraPartitionKey { Name = partitionKey });
                }
                psCassandraSchema.PartitionKeys = PSPartitionKeys;
            }

            if (ClusterKey != null && ClusterKey.Length > 0)
            {
                psCassandraSchema.ClusterKeys = ClusterKey;
            }

            WriteObject(psCassandraSchema);
            return;
        }
    }
}
