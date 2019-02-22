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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Model
{
    /// <summary>
    /// Represents an Azure Sql Managed Database
    /// </summary>
    public class AzureSqlManagedDatabaseModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed instance
        /// </summary>
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the location of the managed database
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the unique ID of the managed database
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed database
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the managed database.
        /// </summary>
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the managed database collation
        /// </summary>
        public string Collation { get; set; }

        /// <summary>
        /// Gets or sets the status of the managed databse
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the managed database
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the earliest restore date
        /// </summary>
        public DateTime? EarliestRestorePoint { get; set; }

        /// <summary>
        /// Gets or sets the restore point in time
        /// </summary>
        public DateTime? RestorePointInTime { get; set; }

        /// <summary>
        /// Gets or sets the default secondary location
        /// </summary>
        public string DefaultSecondaryLocation { get; set; }

        /// <summary>
        /// Gets or sets the default catalov collation
        /// </summary>
        public string CatalogCollation { get; set; }

        /// <summary>
        /// Gets or sets the create mode
        /// </summary>
        public string CreateMode { get; set; }

        /// <summary>
        /// Gets or sets the storage container Uri
        /// </summary>
        public string StorageContainerUri { get; set; }

        /// <summary>
        /// Gets or sets the storage container Sas token
        /// </summary>
        public string StorageContainerSasToken { get; set; }

        /// <summary>
        /// Gets or sets the source database id
        /// </summary>
        public string SourceDatabaseId { get; set; }

        /// <summary>
        /// Gets or sets the failover group Id
        /// </summary>
        public string FailoverGroupId { get; set; }

        /// <summary>
        /// Gets or sets the failover group Id
        /// </summary>
        public string RecoverableDatabaseId { get; set; }

        /// <summary>
        /// Construct AzureSqlManagedDatabaseModel
        /// </summary>
        public AzureSqlManagedDatabaseModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlManagedDatabaseModel object
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="managedInstanceName">Managed Instance name</param>
        /// <param name="database">Managed Database object</param>
        public AzureSqlManagedDatabaseModel(string resourceGroup, string managedInstanceName, Management.Sql.Models.ManagedDatabase database)
        {
            ResourceGroupName = resourceGroup;
            ManagedInstanceName = managedInstanceName;
            Location = database.Location;
            Id = database.Id;
            Name = database.Name;
            Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(database.Tags), false);
            Collation = database.Collation;
            Status = database.Status;
            CreationDate = database.CreationDate.Value;
            EarliestRestorePoint = database.EarliestRestorePoint;
            RestorePointInTime = database.RestorePointInTime;
            DefaultSecondaryLocation = database.DefaultSecondaryLocation;
            CatalogCollation = database.CatalogCollation;
            CreateMode = database.CreateMode;
            StorageContainerUri = database.StorageContainerUri;
            StorageContainerSasToken = database.StorageContainerSasToken;
            SourceDatabaseId = database.SourceDatabaseId;
            FailoverGroupId = database.FailoverGroupId;
            RecoverableDatabaseId = database.RecoverableDatabaseId;
        }
    }
}
