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
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Replication.Model
{
    /// <summary>
    /// Represents an Azure SQL Database Replication Link
    /// </summary>
    public class AzureReplicationLinkModel : AzureSqlDatabaseReplicationModelBase
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string PartnerResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure SQL Server
        /// </summary>
        public string PartnerServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the secondary
        /// </summary>
        public string PartnerDatabaseName { get; set; }

        /// <summary>
        /// Get or sets the AllowConnections setting for the Replication Link
        /// </summary>
        public AllowConnections AllowConnections { get; set; }

        /// <summary>
        /// Gets or sets the requested service objective name for the partner
        /// </summary>
        public string SecondaryServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Elastic Pool the partner is in
        /// </summary>
        public string SecondaryElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the id of the replication link
        /// </summary>
        public Guid LinkId { get; set; }

        /// <summary>
        /// Gets or sets the ReplicationState of the link
        /// </summary>
        public string ReplicationState { get; set; }

        /// <summary>
        /// Gets or sets the Percent seeding complete
        /// </summary>
        public string PercentComplete { get; set; }

        /// <summary>
        /// Gets or sets the Role from the partner context
        /// </summary>
        public string PartnerRole { get; set; }

        /// <summary>
        /// Gets or sets the Role from the context
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the Role from the partner context
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// Gets or sets the location of the partner database
        /// </summary>
        public string PartnerLocation { get; set; }

        /// <summary>
        /// Gets or sets the SkuName of the database
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// Gets or sets the edition of the database
        /// </summary>
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the Family of the database
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the Capacity of the database
        /// </summary>
        public int? Capacity { get; set; }

        /// <summary>
        /// Gets or sets the license type of the database
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
        /// Gets or sets the current backup storage redundancy for the database
        /// </summary>
        public string CurrentBackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the requested backup storage redundancy for the database
        /// </summary>
        public string RequestedBackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the secondary type for the database if it is a secondary
        /// </summary>
        public string SecondaryType { get; set; }

        /// <summary>
        /// Gets or sets the number of high availability replicas for the database
        /// </summary>
        public int? HighAvailabilityReplicaCount { get; set; }

        /// <summary>
        /// Gets or sets the zone redundant option of the database.
        /// </summary>
        public bool? ZoneRedundant { get; set; }

        /// <summary>
        /// Gets or sets the link type of the replication link.
        /// </summary>
        public string LinkType { get; set; }
    }
}
