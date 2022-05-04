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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.ElasticPool.Services;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Database.Services
{
    /// <summary>
    /// Adapter for database operations
    /// </summary>
    public class AzureSqlDatabaseAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlDatabaseCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the AzureSqlElasticPoolCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlElasticPoolCommunicator ElasticPoolCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private IAzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        /// <param name="context">The current context</param>
        public AzureSqlDatabaseAdapter(IAzureContext context)
        {
            Context = context;
            _subscription = context?.Subscription;
            Communicator = new AzureSqlDatabaseCommunicator(Context);
            ElasticPoolCommunicator = new AzureSqlElasticPoolCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Database by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database</param>
        /// <returns>The Azure Sql Database object</returns>
        internal AzureSqlDatabaseModel GetDatabase(string resourceGroupName, string serverName, string databaseName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, databaseName);
            return CreateDatabaseModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets an Azure Sql Database by name with additional information.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database</param>
        /// <returns>The Azure Sql Database object</returns>
        internal AzureSqlDatabaseModelExpanded GetDatabaseExpanded(string resourceGroupName, string serverName, string databaseName)
        {
            var resp = Communicator.GetExpanded(resourceGroupName, serverName, databaseName);
            return CreateExpandedDatabaseModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlDatabaseModel> ListDatabases(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName);

            return resp.Select((db) =>
            {
                return CreateDatabaseModelFromResponse(resourceGroupName, serverName, db);
            }).ToList();
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases with additional information.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlDatabaseModelExpanded> ListDatabasesExpanded(string resourceGroupName, string serverName)
        {
            var resp = Communicator.ListExpanded(resourceGroupName, serverName);

            return resp.Select((db) =>
            {
                return CreateExpandedDatabaseModelFromResponse(resourceGroupName, serverName, db);
            }).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database with new AutoRest SDK.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database from AutoRest SDK</returns>
        internal AzureSqlDatabaseModel UpsertDatabaseWithNewSdk(string resourceGroup, string serverName, AzureSqlDatabaseCreateOrUpdateModel model)
        {
            // Construct the ARM resource Id of the pool
            string elasticPoolId = string.IsNullOrWhiteSpace(model.Database.ElasticPoolName) ? null : AzureSqlDatabaseModel.PoolIdTemplate.FormatInvariant(
                        _subscription.Id,
                        resourceGroup,
                        serverName,
                        model.Database.ElasticPoolName);

            // Use AutoRest SDK
            var resp = Communicator.CreateOrUpdate(resourceGroup, serverName, model.Database.DatabaseName, new Management.Sql.Models.Database
            {
                Location = model.Database.Location,
                Tags = model.Database.Tags,
                Collation = model.Database.CollationName,
                Sku = string.IsNullOrWhiteSpace(model.Database.SkuName) ? null : new Sku()
                {
                    Name = model.Database.SkuName,
                    Tier = model.Database.Edition,
                    Family = model.Database.Family,
                    Capacity = model.Database.Capacity
                },
                MaxSizeBytes = model.Database.MaxSizeBytes,
                ReadScale =  model.Database.ReadScale.ToString(),
                SampleName = model.SampleName,
                ZoneRedundant = model.Database.ZoneRedundant,
                ElasticPoolId = elasticPoolId,
                LicenseType = model.Database.LicenseType,
                AutoPauseDelay = model.Database.AutoPauseDelayInMinutes,
                MinCapacity = model.Database.MinimumCapacity,
                HighAvailabilityReplicaCount = model.Database.HighAvailabilityReplicaCount,
                RequestedBackupStorageRedundancy = model.Database.RequestedBackupStorageRedundancy,
                SecondaryType = model.Database.SecondaryType,
                MaintenanceConfigurationId = MaintenanceConfigurationHelper.ConvertMaintenanceConfigurationIdArgument(model.Database.MaintenanceConfigurationId, _subscription.Id),
                IsLedgerOn = model.Database.EnableLedger,
            });

            return CreateDatabaseModelFromResponse(resourceGroup, serverName, resp);
        }

        /// <summary>
        /// Deletes a database
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database to delete</param>
        public void RemoveDatabase(string resourceGroupName, string serverName, string databaseName)
        {
            Communicator.Remove(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Gets the Location of the server.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns></returns>
        public string GetServerLocation(string resourceGroupName, string serverName)
        {
            AzureSqlServerAdapter serverAdapter = new AzureSqlServerAdapter(Context);
            var server = serverAdapter.GetServer(resourceGroupName, serverName);
            return server.Location;
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="database">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlDatabaseModel CreateDatabaseModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.Database database)
        {
            return new AzureSqlDatabaseModel(resourceGroup, serverName, database);
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="database">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlDatabaseModel CreateDatabaseModelFromResponse(string resourceGroup, string serverName, Management.Sql.LegacySdk.Models.Database database)
        {
            return new AzureSqlDatabaseModel(resourceGroup, serverName, database);
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="database">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlDatabaseModelExpanded CreateExpandedDatabaseModelFromResponse(string resourceGroup, string serverName, Management.Sql.LegacySdk.Models.Database database)
        {
            return new AzureSqlDatabaseModelExpanded(resourceGroup, serverName, database);
        }

        /// <summary>
        /// Failovers a database
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database to failover</param>
        /// <param name="replicaType">Whether to failover primary replica or readable secondary replica</param>
        public void FailoverDatabase(string resourceGroupName, string serverName, string databaseName, string replicaType)
        {
            Communicator.Failover(resourceGroupName, serverName, databaseName, replicaType);
        }

        internal IEnumerable<AzureSqlDatabaseActivityModel> ListDatabaseActivity(string resourceGroupName, string serverName, string elasticPoolName, string databaseName, Guid? operationId)
        {
            if (!string.IsNullOrEmpty(elasticPoolName))
            {
                var response = ElasticPoolCommunicator.ListDatabaseActivity(resourceGroupName, serverName, elasticPoolName);
                IEnumerable<AzureSqlDatabaseActivityModel> list = response.Select((r) =>
                   {
                       return new AzureSqlDatabaseActivityModel()
                       {
                           DatabaseName = r.DatabaseName,
                           EndTime = r.EndTime,
                           ErrorCode = r.ErrorCode,
                           ErrorMessage = r.ErrorMessage,
                           ErrorSeverity = r.ErrorSeverity,
                           Operation = r.Operation,
                           OperationId = r.OperationId,
                           PercentComplete = r.PercentComplete,
                           ServerName = r.ServerName,
                           StartTime = r.StartTime,
                           State = r.State,
                           Properties = new AzureSqlDatabaseActivityModel.DatabaseState()
                           {
                               Current = new Dictionary<string, string>()
                               {
                                    {"CurrentElasticPoolName", r.CurrentElasticPoolName},
                                    {"CurrentServiceObjectiveName", r.CurrentServiceObjective},
                               },
                               Requested = new Dictionary<string, string>()
                               {
                                    {"RequestedElasticPoolName", r.RequestedElasticPoolName},
                                    {"RequestedServiceObjectiveName", r.RequestedServiceObjective},
                               }
                           }
                       };
                   });

                // Check if we have a database name constraint
                if (!string.IsNullOrEmpty(databaseName))
                {
                    list = list.Where(pl => string.Equals(pl.DatabaseName, databaseName, StringComparison.OrdinalIgnoreCase));
                }

                return list.ToList();
            }
            else
            {
                var response = Communicator.ListOperations(resourceGroupName, serverName, databaseName);
                IEnumerable<AzureSqlDatabaseActivityModel> list = response.Select((r) =>
                {
                    return new AzureSqlDatabaseActivityModel()
                    {
                        DatabaseName = r.DatabaseName,
                        ErrorCode = r.ErrorCode,
                        ErrorMessage = r.ErrorDescription,
                        ErrorSeverity = r.ErrorSeverity,
                        Operation = r.Operation,
                        OperationId = Guid.Parse(r.Name),
                        PercentComplete = r.PercentComplete,
                        ServerName = r.ServerName,
                        StartTime = r.StartTime,
                        State = r.State,
                        Properties = new AzureSqlDatabaseActivityModel.DatabaseState()
                        {
                            Current = new Dictionary<string, string>(),
                            Requested = new Dictionary<string, string>()
                        },
                        EstimatedCompletionTime = r.EstimatedCompletionTime,
                        Description = r.Description,
                        IsCancellable = r.IsCancellable
                    };
                });

                // Check if we have a operation id constraint
                if (operationId.HasValue)
                {
                    list = list.Where(pl => Guid.Equals(pl.OperationId, operationId));
                }

                return list.ToList();
            }
        }

        internal IEnumerable<AzureSqlDatabaseActivityModel> CancelDatabaseActivity(string resourceGroupName, string serverName, string elasticPoolName, string databaseName, Guid? operationId)
        {
            if (!string.IsNullOrEmpty(elasticPoolName))
            {
                throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.ElasticPoolDatabaseActivityCancelNotSupported));
            }

            if (!operationId.HasValue)
            {
                throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.OperationIdRequired));
            }

            Communicator.CancelOperation(resourceGroupName, serverName, databaseName, operationId.Value);

            // After Cancel event is fired, state will be in 'CancelInProgress' for a while but should expect to finish in a minute

            return ListDatabaseActivity(resourceGroupName, serverName, elasticPoolName, databaseName, operationId);
        }

        public void RenameDatabase(string resourceGroupName, string serverName, string databaseName, string newName)
        {
            Communicator.Rename(resourceGroupName, serverName, databaseName, newName);
        }

        /// <summary>
        /// Get database sku name based on edition
        ///    Edition              | SkuName
        ///    GeneralPurpose       | GP
        ///    BusinessCritical     | BC
        ///    Hyperscale           | HS
        ///    Standard             | Standard
        ///    Basic                | Basic
        ///    Premium              | Premium
        ///    
        /// Also adds _S in the end of SkuName in case if it is Serverless
        /// </summary>
        /// <param name="tier">Azure Sql database edition</param>
        /// <param name="isServerless">If sku should be serverless type</param>
        /// <returns>The sku name</returns>
        public static string GetDatabaseSkuName(string tier, bool isServerless = false)
        {
            if (string.IsNullOrWhiteSpace(tier))
            {
                return null;
            }

            return (SqlSkuUtils.GetVcoreSkuPrefix(tier) ?? tier) + (isServerless ? "_S" : "");
        }

        /// <summary>
        /// Gets the Sku for the Dtu database.
        /// </summary>
        /// <param name="requestedServiceObjectiveName">Requested service objective name of the Azure Sql database</param>
        /// <param name="edition">Edition of the Azure Sql database</param>
        /// <returns></returns>
        public static Sku GetDtuDatabaseSku(string requestedServiceObjectiveName, string edition)
        {
            Sku sku = null;
            if (!string.IsNullOrWhiteSpace(requestedServiceObjectiveName) || !string.IsNullOrWhiteSpace(edition))
            {
                sku = new Sku()
                {
                    Name = string.IsNullOrWhiteSpace(requestedServiceObjectiveName) ? GetDatabaseSkuName(edition) : requestedServiceObjectiveName,
                    Tier = edition
                };
            }

            return sku;
        }

        /// <summary>
        /// Map external BackupStorageRedundancy value (GeoZone/Geo/Local/Zone) to internal (GZRS/GRS/LRS/ZRS)
        /// </summary>
        /// <param name="backupStorageRedundancy">Backup storage redundancy</param>
        /// <returns>internal backupStorageRedundancy</returns>
        private static string MapExternalBackupStorageRedundancyToInternal(string backupStorageRedundancy)
        {

            if (string.IsNullOrWhiteSpace(backupStorageRedundancy))
            {
                return null;
            }

            switch (backupStorageRedundancy.ToLower())
            {
                case "geozone":
                    return "GZRS";
                case "geo":
                    return "GRS";
                case "local":
                    return "LRS";
                case "zone":
                    return "ZRS";
                default:
                    return null;
            }
        }
    }
}
