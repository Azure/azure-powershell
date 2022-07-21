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
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Database.Model
{
    /// <summary>
    /// Represents an Azure Sql Database
    /// </summary>
    public class AzureSqlDatabaseModel
    {
        /// <summary>
        /// Template to generate database id
        /// </summary>
        public const string IdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/databases/{3}";

        /// <summary>
        /// Template to generate elastic pool id for the database
        /// </summary>
        public const string PoolIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Sql/servers/{2}/elasticPools/{3}";

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
        public string Edition { get; set; }

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
        /// Gets or sets the requested service objective name
        /// </summary>
        public string RequestedServiceObjectiveName { get; set; }

        /// <summary>
        /// gets or sets the requested service objective ID
        /// </summary>
        public Guid? RequestedServiceObjectiveId { get; set; }

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
        /// Gets or sets the read scale option of the database (Disabled/Enabled).
        /// </summary>
        public DatabaseReadScale? ReadScale { get; set; }

        /// <summary>
        /// Gets or sets the zone redundant option of the database.
        /// </summary>
        public bool? ZoneRedundant { get; set; }

        /// <summary>
        /// Gets or sets the capacity of the database.
        ///    The capacity is Dtu number if the database is dtu based database; capacity is Vcore number if the database is vcore based database.
        /// </summary>
        public int? Capacity { get; set; }

        /// <summary>
        /// Gets or sets the Family of the database.
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the SkuName of the database.
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// Gets or sets the LicenseType of the database
        /// </summary>
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the Auto pause delay of the database
        /// </summary>
        public int? AutoPauseDelayInMinutes { get; set; }

        /// <summary>
        /// Minimal capacity that database will always have allocated, if not paused
        /// </summary>
        public double? MinimumCapacity { get; set; }

        /// <summary>
        /// Gets or sets the number of readonly secondary replicas for the database that are used to provide high availability
        /// </summary>
        public int? ReadReplicaCount { get; set; }

        /// <summary>
        /// Gets or sets the number of readonly secondary replicas for the database that are used to provide high availability
        /// </summary>
        public int? HighAvailabilityReplicaCount { get; set; }

        /// <summary>
        /// Gets or sets the current backup storage redundancy for the database
        /// </summary>
        public string CurrentBackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the requested backup storage redundancy for the database
        /// </summary>
        public string RequestedBackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the secondary type for the database if it is a secondary.
        /// </summary>
        public string SecondaryType { get; set; }

        /// <summary>
        /// Gets or sets the maintenance configuration id for the database
        /// </summary>
        public string MaintenanceConfigurationId { get; set; }

        /// <summary>
        /// Gets or sets the ledger property for the database
        /// </summary>
        public bool? EnableLedger { get; set; }

        /// <summary>
        /// Construct AzureSqlDatabaseModel
        /// </summary>
        public AzureSqlDatabaseModel()
        {
        }

        /// <summary>
        /// Construct AzureSqlDatabaseModel from Management.Sql.LegacySdk.Models.Database object
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="database">Database object</param>
        public AzureSqlDatabaseModel(string resourceGroup, string serverName, Management.Sql.LegacySdk.Models.Database database)
        {
            Guid id = Guid.Empty;

            ResourceGroupName = resourceGroup;
            ServerName = serverName;
            CollationName = database.Properties.Collation;
            CreationDate = database.Properties.CreationDate;
            CurrentServiceObjectiveName = database.Properties.ServiceObjective;
            MaxSizeBytes = database.Properties.MaxSizeBytes;
            DatabaseName = database.Name;
            Status = database.Properties.Status;
            Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(database.Tags), false);
            ElasticPoolName = database.Properties.ElasticPoolName;
            Location = database.Location;
            ResourceId = database.Id;
            CreateMode = database.Properties.CreateMode;
            EarliestRestoreDate = database.Properties.EarliestRestoreDate;

            Guid.TryParse(database.Properties.CurrentServiceObjectiveId, out id);
            CurrentServiceObjectiveId = id;

            Guid.TryParse(database.Properties.DatabaseId, out id);
            DatabaseId = id;

            Edition = database.Properties.Edition;

            Guid.TryParse(database.Properties.RequestedServiceObjectiveId, out id);
            RequestedServiceObjectiveId = id;
            
            DatabaseReadScale readScale;
            if (Enum.TryParse<DatabaseReadScale>(database.Properties.ReadScale, true, out readScale))
            {
                ReadScale = readScale;
            }

            ZoneRedundant = false;
            AutoPauseDelayInMinutes = null;
            MinimumCapacity = null;
            ReadReplicaCount = null;
            HighAvailabilityReplicaCount = null;
            CurrentBackupStorageRedundancy = null;
            RequestedBackupStorageRedundancy = null;
            SecondaryType = null;
            MaintenanceConfigurationId = null;
            EnableLedger = false;
        }

        /// <summary>
        /// Construct AzureSqlDatabaseModel from Management.Sql.Database object
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="serverName">Server name</param>
        /// <param name="database">Database object</param>
        public AzureSqlDatabaseModel(string resourceGroup, string serverName, Management.Sql.Models.Database database)
        {
            ResourceGroupName = resourceGroup;
            ServerName = serverName;
            CollationName = database.Collation;
            CreationDate = database.CreationDate.Value;
            MaxSizeBytes = (long)database.MaxSizeBytes;
            DatabaseName = database.Name;
            Status = database.Status;
            Tags = TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(database.Tags), false);
            ElasticPoolName = database.ElasticPoolName;
            Location = database.Location;
            ResourceId = database.Id;
            CreateMode = database.CreateMode;
            EarliestRestoreDate = database.EarliestRestoreDate;

            CurrentServiceObjectiveName = database.CurrentServiceObjectiveName;

            DatabaseId = database.DatabaseId.Value;

            Edition = database.Edition;

            RequestedServiceObjectiveName = database.RequestedServiceObjectiveName;

            DatabaseReadScale readScale;
            if (Enum.TryParse<DatabaseReadScale>(database.ReadScale.ToString(), true, out readScale))
            {
                ReadScale = readScale;
            }

            ZoneRedundant = database.ZoneRedundant;

            Capacity = database.Sku == null ? (int?)null : database.Sku.Capacity;

            Family = database.Sku == null ? null : database.Sku.Family;

            SkuName = database.Sku == null ? null : database.Sku.Name;

            LicenseType = database.LicenseType;

            AutoPauseDelayInMinutes = database.AutoPauseDelay;
            MinimumCapacity = database.MinCapacity;
            HighAvailabilityReplicaCount = database.HighAvailabilityReplicaCount;
            CurrentBackupStorageRedundancy = database.CurrentBackupStorageRedundancy;
            RequestedBackupStorageRedundancy = database.RequestedBackupStorageRedundancy;
            SecondaryType = database.SecondaryType;
            MaintenanceConfigurationId = database.MaintenanceConfigurationId;
            EnableLedger = database.IsLedgerOn;
        }

        /// <summary>
        /// Map internal BackupStorageRedundancy value (GZRS/GRS/LRS/ZRS) to external (GeoZone/Geo/Local/Zone)
        /// </summary>
        /// <param name="backupStorageRedundancy">Backup storage redundancy</param>
        /// <returns>internal backupStorageRedundancy</returns>
        private static string MapInternalBackupStorageRedundancyToExternal(string backupStorageRedundancy)
        {
            switch (backupStorageRedundancy)
            {
                case "GZRS":
                    return "GeoZone";
                case "GRS":
                    return "Geo";
                case "LRS":
                    return "Local";
                case "ZRS":
                    return "Zone";
                default:
                    return null;
            }
        }
    }
}
