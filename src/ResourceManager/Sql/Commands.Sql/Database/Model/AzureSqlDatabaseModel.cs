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

namespace Microsoft.Azure.Commands.Sql.Database.Model
{
    /// <summary>
    /// Represents an Azure Sql Database
    /// </summary>
    public class AzureSqlDatabaseModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the location of the database
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the database
        /// </summary>
        public Guid DatabaseId { get; set; }

        /// <summary>
        /// Gets or sets the edition of the database
        /// </summary>
        public DatabaseEdition Edition { get; set; }

        /// <summary>
        /// Gets or sets the database collation
        /// </summary>
        public string CollationName { get; set; }

        /// <summary>
        /// Gets or sets the database collation
        /// </summary>
        public string CatalogCollation { get; set; }

        /// <summary>
        /// Gets or sets the max size of the database in bytes
        /// </summary>
        public long MaxSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the status of the databse
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the database
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the current service objective ID
        /// </summary>
        public Guid CurrentServiceObjectiveId { get; set; }

        /// <summary>
        /// Gets or sets the current service objective name
        /// </summary>
        public string CurrentServiceObjectiveName { get; set; }

        /// <summary>
        /// gets or sets the requested service objective ID
        /// </summary>
        public Guid? RequestedServiceObjectiveId { get; set; }

        /// <summary>
        /// Gets or sets the requested service objective name
        /// </summary>
        public string RequestedServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Elastic Pool the database is in
        /// </summary>
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the earliest restore date
        /// </summary>
        public DateTime? EarliestRestoreDate { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the server.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the resource ID of the database.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the create mode of the database.
        /// </summary>
        public string CreateMode { get; set; }

        /// <summary>
        /// Construct AzureSqlDatabaseModel
        /// </summary>
        public AzureSqlDatabaseModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlDatabaseModel from Management.Sql.Models.Database object
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="database">Database object</param>
        public AzureSqlDatabaseModel(string resourceGroup, string serverName, Management.Sql.Models.Database database)
        {
            Guid id = Guid.Empty;
            DatabaseEdition edition = DatabaseEdition.None;

            ResourceGroupName = resourceGroup;
            ServerName = serverName;
            CollationName = database.Properties.Collation;
            CreationDate = database.Properties.CreationDate;
            CurrentServiceObjectiveName = database.Properties.ServiceObjective;
            MaxSizeBytes = database.Properties.MaxSizeBytes;
            DatabaseName = database.Name;
            Status = database.Properties.Status;
            Tags = database.Tags as Dictionary<string, string>;
            ElasticPoolName = database.Properties.ElasticPoolName;
            Location = database.Location;
            ResourceId = database.Id;
            CreateMode = database.Properties.CreateMode;
            EarliestRestoreDate = database.Properties.EarliestRestoreDate;

            Guid.TryParse(database.Properties.CurrentServiceObjectiveId, out id);
            CurrentServiceObjectiveId = id;

            Guid.TryParse(database.Properties.DatabaseId, out id);
            DatabaseId = id;

            Enum.TryParse<DatabaseEdition>(database.Properties.Edition, true, out edition);
            Edition = edition;

            Guid.TryParse(database.Properties.RequestedServiceObjectiveId, out id);
            RequestedServiceObjectiveId = id;
        }
    }
}
