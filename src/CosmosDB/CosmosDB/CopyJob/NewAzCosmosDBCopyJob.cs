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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.CosmosDB.Helpers;
using Microsoft.Azure.Commands.CosmosDB.Models;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.CosmosDB
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CosmosDBCopyJob", DefaultParameterSetName = SqlParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSCopyJobGetResults))]
    public class NewAzCosmosDBCopyJob : AzureCosmosDBCmdletBase
    {
        private const string SqlParameterSet = "SqlParameterSet";
        private const string CassandraParameterSet = "CassandraParameterSet";
        private const string MongoParameterSet = "MongoParameterSet";

        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.ResourceGroupNameHelpMessage)]
        public string ResourceGroupName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, HelpMessage = Constants.CopyJobSourceAccountNameHelpMessage)]
        public string SourceAccountName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.CopyJobDestinationAccountNameHelpMessage)]
        public string DestinationAccountName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, HelpMessage = Constants.CopyJobNameHelpMessage)]
        public string JobName { get; set; }

        // NoSQL parameters
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = SqlParameterSet, HelpMessage = Constants.CopyJobSourceDatabaseNameHelpMessage)]
        public string SourceSqlDatabaseName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = SqlParameterSet, HelpMessage = Constants.CopyJobSourceContainerNameHelpMessage)]
        public string SourceSqlContainerName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = SqlParameterSet, HelpMessage = Constants.CopyJobDestinationDatabaseNameHelpMessage)]
        public string DestinationSqlDatabaseName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = SqlParameterSet, HelpMessage = Constants.CopyJobDestinationContainerNameHelpMessage)]
        public string DestinationSqlContainerName { get; set; }

        // Cassandra parameters
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = CassandraParameterSet, HelpMessage = Constants.CopyJobSourceKeyspaceNameHelpMessage)]
        public string SourceKeyspaceName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = CassandraParameterSet, HelpMessage = Constants.CopyJobSourceTableNameHelpMessage)]
        public string SourceTableName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = CassandraParameterSet, HelpMessage = Constants.CopyJobDestinationKeyspaceNameHelpMessage)]
        public string DestinationKeyspaceName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = CassandraParameterSet, HelpMessage = Constants.CopyJobDestinationTableNameHelpMessage)]
        public string DestinationTableName { get; set; }

        // MongoDB parameters
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = MongoParameterSet, HelpMessage = Constants.CopyJobSourceMongoDatabaseNameHelpMessage)]
        public string SourceMongoDatabaseName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = MongoParameterSet, HelpMessage = Constants.CopyJobSourceCollectionNameHelpMessage)]
        public string SourceCollectionName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = MongoParameterSet, HelpMessage = Constants.CopyJobDestinationMongoDatabaseNameHelpMessage)]
        public string DestinationMongoDatabaseName { get; set; }

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ParameterSetName = MongoParameterSet, HelpMessage = Constants.CopyJobDestinationCollectionNameHelpMessage)]
        public string DestinationCollectionName { get; set; }

        [ValidateSet("Online", "Offline")]
        [Parameter(Mandatory = false, HelpMessage = Constants.CopyJobModeHelpMessage)]
        public string Mode { get; set; } = "Offline";

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(DestinationAccountName))
            {
                DestinationAccountName = SourceAccountName;
            }

            if (string.IsNullOrEmpty(JobName))
            {
                JobName = Guid.NewGuid().ToString();
            }

            bool isCrossAccount = !string.Equals(SourceAccountName, DestinationAccountName, StringComparison.OrdinalIgnoreCase);
            string hostAccountName = DestinationAccountName;

            CopyJobDataSource source;
            CopyJobDataSource destination;
            string jobType;

            switch (ParameterSetName)
            {
                case CassandraParameterSet:
                    jobType = "CassandraRUToCassandraRU";
                    source = new CopyJobDataSource
                    {
                        KeyspaceName = SourceKeyspaceName,
                        TableName = SourceTableName
                    };
                    destination = new CopyJobDataSource
                    {
                        KeyspaceName = DestinationKeyspaceName,
                        TableName = DestinationTableName
                    };
                    break;

                case MongoParameterSet:
                    jobType = "MongoRUToMongoRU";
                    source = new CopyJobDataSource
                    {
                        DatabaseName = SourceMongoDatabaseName,
                        CollectionName = SourceCollectionName
                    };
                    destination = new CopyJobDataSource
                    {
                        DatabaseName = DestinationMongoDatabaseName,
                        CollectionName = DestinationCollectionName
                    };
                    break;

                default: // SqlParameterSet
                    jobType = "NoSqlRUToNoSqlRU";
                    source = new CopyJobDataSource
                    {
                        DatabaseName = SourceSqlDatabaseName,
                        ContainerName = SourceSqlContainerName
                    };
                    destination = new CopyJobDataSource
                    {
                        DatabaseName = DestinationSqlDatabaseName,
                        ContainerName = DestinationSqlContainerName
                    };
                    break;
            }

            var jobProperties = new CopyJobJobProperties
            {
                JobType = jobType,
                Tasks = new System.Collections.Generic.List<CopyJobTask>
                {
                    new CopyJobTask { Source = source, Destination = destination }
                }
            };

            if (isCrossAccount)
            {
                jobProperties.SourceDetails = new CosmosDBSourceSinkDetails
                {
                    RemoteAccountName = SourceAccountName
                };
            }

            if (ShouldProcess(JobName, "Creating CosmosDB Copy Job"))
            {
                CopyJobCreateUpdateParameters parameters = new CopyJobCreateUpdateParameters
                {
                    Properties = new CopyJobCreateUpdateProperties
                    {
                        JobProperties = jobProperties,
                        Mode = Mode
                    }
                };

                CopyJobGetResults result = CosmosDBManagementClient.CopyJobs.CreateWithHttpMessagesAsync(
                    ResourceGroupName, hostAccountName, JobName, parameters).GetAwaiter().GetResult().Body;

                WriteObject(new PSCopyJobGetResults(result));
            }
        }
    }
}

