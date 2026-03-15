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

using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.WindowsAzure.Commands.Common.Attributes;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{
    public class PSCopyJobGetResults
    {
        public PSCopyJobGetResults()
        {
        }

        public PSCopyJobGetResults(CopyJobGetResults copyJobGetResults)
        {
            if (copyJobGetResults == null)
            {
                return;
            }

            Id = copyJobGetResults.Id;
            Name = copyJobGetResults.Name;
            Type = copyJobGetResults.Type;

            // If Name is not set, extract from Id (e.g., .../copyJobs/jobName)
            if (string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Id))
            {
                var trimmedId = Id.TrimEnd('/');
                if (!string.IsNullOrEmpty(trimmedId))
                {
                    var parts = trimmedId.Split('/');
                    Name = parts[parts.Length - 1];
                }
            }

            if (copyJobGetResults.Properties != null)
            {
                Status = copyJobGetResults.Properties.Status;
                Mode = copyJobGetResults.Properties.Mode;
                ProcessedCount = copyJobGetResults.Properties.ProcessedCount;
                TotalCount = copyJobGetResults.Properties.TotalCount;
                Duration = copyJobGetResults.Properties.Duration;

                ExtractJobDetails(copyJobGetResults.Properties.JobProperties);
            }
        }

        private void ExtractJobDetails(BaseCopyJobProperties jobProperties)
        {
            if (jobProperties == null)
            {
                return;
            }

            if (jobProperties is NoSqlRUToNoSqlRUCopyJobProperties noSqlProps)
            {
                JobType = "NoSqlRUToNoSqlRU";
                if (noSqlProps.Tasks != null && noSqlProps.Tasks.Count > 0)
                {
                    var task = noSqlProps.Tasks[0];
                    SourceDatabaseName = task.Source?.DatabaseName;
                    SourceContainerName = task.Source?.ContainerName;
                    DestinationDatabaseName = task.Destination?.DatabaseName;
                    DestinationContainerName = task.Destination?.ContainerName;
                }
            }
            else if (jobProperties is CassandraRUToCassandraRUCopyJobProperties cassandraProps)
            {
                JobType = "CassandraRUToCassandraRU";
                if (cassandraProps.Tasks != null && cassandraProps.Tasks.Count > 0)
                {
                    var task = cassandraProps.Tasks[0];
                    SourceKeyspaceName = task.Source?.KeyspaceName;
                    SourceTableName = task.Source?.TableName;
                    DestinationKeyspaceName = task.Destination?.KeyspaceName;
                    DestinationTableName = task.Destination?.TableName;
                }
            }
            else if (jobProperties is MongoRUToMongoRUCopyJobProperties mongoProps)
            {
                JobType = "MongoRUToMongoRU";
                if (mongoProps.Tasks != null && mongoProps.Tasks.Count > 0)
                {
                    var task = mongoProps.Tasks[0];
                    SourceDatabaseName = task.Source?.DatabaseName;
                    SourceCollectionName = task.Source?.CollectionName;
                    DestinationDatabaseName = task.Destination?.DatabaseName;
                    DestinationCollectionName = task.Destination?.CollectionName;
                }
            }
        }

        /// <summary>
        /// Gets or sets Id of the Copy Job
        /// </summary>
        [Ps1Xml(Label = "Id", Target = ViewControl.List)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Name of the Copy Job
        /// </summary>
        [Ps1Xml(Label = "Name", Target = ViewControl.List)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Type of the resource
        /// </summary>
        [Ps1Xml(Label = "Type", Target = ViewControl.List)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Status of the Copy Job
        /// </summary>
        [Ps1Xml(Label = "Status", Target = ViewControl.List)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets Mode of the Copy Job
        /// </summary>
        [Ps1Xml(Label = "Mode", Target = ViewControl.List)]
        public string Mode { get; set; }

        /// <summary>
        /// Gets or sets Source Database Name (used for both NoSQL and MongoDB copy jobs, disambiguated by JobType)
        /// </summary>
        [Ps1Xml(Label = "SourceDatabaseName", Target = ViewControl.List)]
        public string SourceDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets Source Container Name (NoSQL copy jobs)
        /// </summary>
        [Ps1Xml(Label = "SourceContainerName", Target = ViewControl.List)]
        public string SourceContainerName { get; set; }

        /// <summary>
        /// Gets or sets Destination Database Name (used for both NoSQL and MongoDB copy jobs, disambiguated by JobType)
        /// </summary>
        [Ps1Xml(Label = "DestinationDatabaseName", Target = ViewControl.List)]
        public string DestinationDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets Destination Container Name (NoSQL copy jobs)
        /// </summary>
        [Ps1Xml(Label = "DestinationContainerName", Target = ViewControl.List)]
        public string DestinationContainerName { get; set; }

        /// <summary>
        /// Gets or sets Source Keyspace Name (Cassandra)
        /// </summary>
        [Ps1Xml(Label = "SourceKeyspaceName", Target = ViewControl.List)]
        public string SourceKeyspaceName { get; set; }

        /// <summary>
        /// Gets or sets Source Table Name (Cassandra)
        /// </summary>
        [Ps1Xml(Label = "SourceTableName", Target = ViewControl.List)]
        public string SourceTableName { get; set; }

        /// <summary>
        /// Gets or sets Destination Keyspace Name (Cassandra)
        /// </summary>
        [Ps1Xml(Label = "DestinationKeyspaceName", Target = ViewControl.List)]
        public string DestinationKeyspaceName { get; set; }

        /// <summary>
        /// Gets or sets Destination Table Name (Cassandra)
        /// </summary>
        [Ps1Xml(Label = "DestinationTableName", Target = ViewControl.List)]
        public string DestinationTableName { get; set; }

        /// <summary>
        /// Gets or sets Source Collection Name (MongoDB)
        /// </summary>
        [Ps1Xml(Label = "SourceCollectionName", Target = ViewControl.List)]
        public string SourceCollectionName { get; set; }

        /// <summary>
        /// Gets or sets Destination Collection Name (MongoDB)
        /// </summary>
        [Ps1Xml(Label = "DestinationCollectionName", Target = ViewControl.List)]
        public string DestinationCollectionName { get; set; }

        /// <summary>
        /// Gets or sets Job Type
        /// </summary>
        [Ps1Xml(Label = "JobType", Target = ViewControl.List)]
        public string JobType { get; set; }

        /// <summary>
        /// Gets or sets Processed Count
        /// </summary>
        [Ps1Xml(Label = "ProcessedCount", Target = ViewControl.List)]
        public long? ProcessedCount { get; set; }

        /// <summary>
        /// Gets or sets Total Count
        /// </summary>
        [Ps1Xml(Label = "TotalCount", Target = ViewControl.List)]
        public long? TotalCount { get; set; }

        /// <summary>
        /// Gets or sets Duration
        /// </summary>
        [Ps1Xml(Label = "Duration", Target = ViewControl.List)]
        public string Duration { get; set; }
    }
}
