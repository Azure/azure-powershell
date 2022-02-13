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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.ElasticPool.Model;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Globalization;
using Microsoft.Azure.Commands.Sql.Common;

namespace Microsoft.Azure.Commands.Sql.ElasticPool.Services
{
    /// <summary>
    /// Adapter for ElasticPool operations
    /// </summary>
    public class AzureSqlElasticPoolAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlElasticPoolCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlElasticPoolAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlElasticPoolCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Database ElasticPool by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="poolName">The name of the Azure Sql Database ElasticPool</param>
        /// <returns>The Azure Sql Database ElasticPool object</returns>
        internal AzureSqlElasticPoolModel GetElasticPool(string resourceGroupName, string serverName, string poolName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, poolName);
            return CreateElasticPoolModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases ElasticPool.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlElasticPoolModel> ListElasticPools(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName);

            return resp.Select((db) =>
            {
                return CreateElasticPoolModelFromResponse(resourceGroupName, serverName, db);
            }).ToList();
        }

        /// <summary>
        /// Creates an Azure Sql Database ElasticPool.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database ElasticPool</returns>
        internal AzureSqlElasticPoolModel CreateElasticPool(AzureSqlElasticPoolModel model)
        {
            var resp = Communicator.Create(model.ResourceGroupName, model.ServerName, model.ElasticPoolName, new Management.Sql.Models.ElasticPool
            {
                Location = model.Location,
                Tags = model.Tags,
                Sku = string.IsNullOrWhiteSpace(model.SkuName) ? null : new Sku()
                {
                    Name = model.SkuName,
                    Tier = model.Edition,
                    Family = model.Family,
                    Capacity = model.Capacity
                },
                MaxSizeBytes = model.MaxSizeBytes,
                ZoneRedundant = model.ZoneRedundant,
                PerDatabaseSettings = new ElasticPoolPerDatabaseSettings()
                {
                    MinCapacity = model.DatabaseCapacityMin,
                    MaxCapacity = model.DatabaseCapacityMax
                },
                LicenseType = model.LicenseType,
                MaintenanceConfigurationId = MaintenanceConfigurationHelper.ConvertMaintenanceConfigurationIdArgument(model.MaintenanceConfigurationId, Context.Subscription.Id),
            });

            return CreateElasticPoolModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Updates an Azure Sql Database ElasticPool using Patch.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database ElasticPool</returns>
        internal AzureSqlElasticPoolModel UpsertElasticPool(AzureSqlElasticPoolModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.ElasticPoolName, new Management.Sql.Models.ElasticPoolUpdate
            {
                Location = model.Location,
                Tags = model.Tags,
                Sku = string.IsNullOrWhiteSpace(model.SkuName) ? null : new Sku()
                {
                    Name = model.SkuName,
                    Tier = model.Edition,
                    Family = model.Family,
                    Capacity = model.Capacity
                },
                MaxSizeBytes = model.MaxSizeBytes,
                ZoneRedundant = model.ZoneRedundant,
                PerDatabaseSettings = new ElasticPoolPerDatabaseSettings()
                {
                    MinCapacity = model.DatabaseCapacityMin,
                    MaxCapacity = model.DatabaseCapacityMax
                },
                LicenseType = model.LicenseType,
                MaintenanceConfigurationId = MaintenanceConfigurationHelper.ConvertMaintenanceConfigurationIdArgument(model.MaintenanceConfigurationId, Context.Subscription.Id),
            });

            return CreateElasticPoolModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Deletes a database
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database to delete</param>
        public void RemoveElasticPool(string resourceGroupName, string serverName, string databaseName)
        {
            Communicator.Remove(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Gets a database in an elastic pool
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="poolName">The name of the Azure Sql Database ElasticPool</param>
        /// <param name="databaseName">The name of the database</param>
        /// <returns></returns>
        public AzureSqlDatabaseModel GetElasticPoolDatabase(string resourceGroupName, string serverName, string poolName, string databaseName)
        {
            var resp = Communicator.GetDatabase(resourceGroupName, serverName, databaseName);
            return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Failovers an elastic pool
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="databaseName">The name of the Azure Sql Database to failover</param>
        public void FailoverElasticPool(string resourceGroupName, string serverName, string databaseName)
        {
            Communicator.Failover(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases in an ElasticPool.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="poolName">The name of the elastic pool the database are in</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlDatabaseModel> ListElasticPoolDatabases(string resourceGroupName, string serverName, string poolName)
        {
            var resp = Communicator.ListDatabases(resourceGroupName, serverName, poolName);

            return resp.Select((db) =>
            {
                return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroupName, serverName, db);
            }).ToList();
        }

        /// <summary>
        /// Gets a list of Elastic Pool Activity
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="poolName">The name of the elastic pool</param>
        /// <returns>A list of Elastic Pool Activities</returns>
        internal IList<AzureSqlElasticPoolActivityModel> GetElasticPoolActivity(string resourceGroupName, string serverName, string poolName)
        {
            var activityResp = Communicator.ListActivity(resourceGroupName, serverName, poolName);
            var operationResp = Communicator.ListOperation(resourceGroupName, serverName, poolName);

            var resp = from activity in activityResp
                       join operation in operationResp
                       on activity.OperationId equals new Guid(operation.Name)
                       select new {
                           elasticPoolName = activity.ElasticPoolName,
                           endTime = activity.EndTime,
                           rgName = resourceGroupName,
                           errorCode = activity.ErrorCode,
                           errorMessage = activity.ErrorMessage,
                           errorSeverity = activity.ErrorSeverity,
                           operation = activity.Operation,
                           operationId = activity.OperationId,
                           percentComplete = activity.PercentComplete,
                           requestedDatabaseDtuMax = activity.RequestedDatabaseDtuMax,
                           requestedDatabaseDtuMin = activity.RequestedDatabaseDtuMin,
                           requestedDtu = activity.RequestedDtu,
                           requestedElasticPoolName = activity.RequestedElasticPoolName,
                           requestedStorageLimitInGB = activity.RequestedStorageLimitInGB,
                           serverName = activity.ServerName,
                           startTime = activity.StartTime,
                           state = activity.State,
                           estimatedCompletionTime = operation.EstimatedCompletionTime,
                           description = operation.Description,
                           isCancellable = operation.IsCancellable
                       };

            IEnumerable<AzureSqlElasticPoolActivityModel> listResponse = resp.Select((r) =>
            {
                return new AzureSqlElasticPoolActivityModel()
                {
                    ElasticPoolName = r.elasticPoolName,
                    ResourceGroupName = r.rgName,
                    EndTime = r.endTime,
                    ErrorCode = r.errorCode,
                    ErrorMessage = r.errorMessage,
                    ErrorSeverity = r.errorSeverity,
                    Operation = r.operation,
                    OperationId = r.operationId,
                    PercentComplete = r.percentComplete,
                    RequestedDatabaseDtuMax = r.requestedDatabaseDtuMax,
                    RequestedDatabaseDtuMin = r.requestedDatabaseDtuMin,
                    RequestedDtu = r.requestedDtu,
                    RequestedElasticPoolName = r.requestedElasticPoolName,
                    RequestedStorageLimitInGB = r.requestedStorageLimitInGB,
                    ServerName = r.serverName,
                    StartTime = r.startTime,
                    State = r.state,
                    EstimatedCompletionTime = r.estimatedCompletionTime,
                    Description = r.description,
                    IsCancellable = r.isCancellable
                };
            });

            return listResponse.ToList();
        }

        /// <summary>
        /// Gets a list of Elastic Pool Database Activity
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="poolName">The name of the elastic pool</param>
        /// <returns>A list of Elastic Pool Database Activities</returns>
        internal IList<AzureSqlDatabaseActivityModel> ListElasticPoolDatabaseActivity(string resourceGroupName, string serverName, string poolName)
        {
            var resp = Communicator.ListDatabaseActivity(resourceGroupName, serverName, poolName);

            return resp.Select((activity) =>
            {
                return CreateDatabaseActivityModelFromResponse(activity);
            }).ToList();
        }

        /// <summary>
        /// Cancel the elastic pool activity
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database server</param>
        /// <param name="elasticPoolName">The name of the elastic pool</param>
        /// <param name="operationId">The Operation ID</param>
        /// <returns></returns>
        internal IEnumerable<AzureSqlElasticPoolActivityModel> CancelElasticPoolActivity(string resourceGroupName, string serverName, string elasticPoolName, Guid? operationId)
        {
            if (!operationId.HasValue)
            {
                throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.OperationIdRequired));
            }

            Communicator.CancelOperation(resourceGroupName, serverName, elasticPoolName, operationId.Value);

            // After Cancel event is fired, state will be in 'CancelInProgress' for a while but should expect to finish in a minute
            return GetElasticPoolActivity(resourceGroupName, serverName, elasticPoolName);
        }

        /// <summary>
        /// Converts a model received from the server to a powershell model
        /// </summary>
        /// <param name="model">The model to transform</param>
        /// <returns>The transformed model</returns>
        private AzureSqlDatabaseActivityModel CreateDatabaseActivityModelFromResponse(ElasticPoolDatabaseActivity model)
        {
            AzureSqlDatabaseActivityModel activity = new AzureSqlDatabaseActivityModel();

            //activity.CurrentElasticPoolName = model.Properties.CurrentElasticPoolName;
            //activity.CurrentServiceObjectiveName = model.Properties.CurrentServiceObjectiveName;
            //activity.DatabaseName = model.Properties.DatabaseName;
            //activity.EndTime = model.Properties.EndTime;
            //activity.ErrorCode = model.Properties.ErrorCode;
            //activity.ErrorMessage = model.Properties.ErrorMessage;
            //activity.ErrorSeverity = model.Properties.ErrorSeverity;
            //activity.Operation = model.Properties.Operation;
            //activity.OperationId = model.Properties.OperationId;
            //activity.PercentComplete = model.Properties.PercentComplete;
            //activity.RequestedElasticPoolName = model.Properties.RequestedElasticPoolName;
            //activity.RequestedServiceObjectiveName = model.Properties.RequestedServiceObjectiveName;
            //activity.ServerName = model.Properties.ServerName;
            //activity.StartTime = model.Properties.StartTime;
            //activity.State = model.Properties.State;

            return activity;
        }

        /// <summary>
        /// Converts a ElascitPoolAcitivy model to the powershell model.
        /// </summary>
        /// <param name="model">The model from the service</param>
        /// <returns>The converted model</returns>
        private AzureSqlElasticPoolActivityModel CreateActivityModelFromResponse(ElasticPoolActivity model)
        {
            AzureSqlElasticPoolActivityModel activity = new AzureSqlElasticPoolActivityModel
            {
                ElasticPoolName = model.ElasticPoolName,
                EndTime = model.EndTime,
                ErrorCode = model.ErrorCode,
                ErrorMessage = model.ErrorMessage,
                ErrorSeverity = model.ErrorSeverity,
                Operation = model.Operation,
                OperationId = model.OperationId,
                PercentComplete = model.PercentComplete,
                RequestedDatabaseDtuMax = model.RequestedDatabaseDtuMax,
                RequestedDatabaseDtuMin = model.RequestedDatabaseDtuMin,
                RequestedDtu = model.RequestedDtu,
                RequestedElasticPoolName = model.RequestedElasticPoolName,
                RequestedStorageLimitInGB = model.RequestedStorageLimitInGB,
                ServerName = model.ServerName,
                StartTime = model.StartTime,
                State = model.State
            };

            return activity;
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
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="pool">The service response</param>
        /// <returns>The converted model</returns>
        private AzureSqlElasticPoolModel CreateElasticPoolModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.ElasticPool pool)
        {
            AzureSqlElasticPoolModel model = new AzureSqlElasticPoolModel
            {
                ResourceId = pool.Id,
                ResourceGroupName = resourceGroup,
                ServerName = serverName,
                ElasticPoolName = pool.Name,
                CreationDate = pool.CreationDate ?? DateTime.MinValue,
                State = pool.State,
                StorageMB = pool.StorageMB,
                MaxSizeBytes = pool.MaxSizeBytes,
                Tags =
                    TagsConversionHelper.CreateTagDictionary(TagsConversionHelper.CreateTagHashtable(pool.Tags), false),
                Location = pool.Location,
                Edition = pool.Edition,
                ZoneRedundant = pool.ZoneRedundant,
                Capacity = pool.Sku.Capacity,
                SkuName = pool.Sku.Name,
                DatabaseCapacityMin = pool.PerDatabaseSettings.MinCapacity,
                DatabaseCapacityMax = pool.PerDatabaseSettings.MaxCapacity,
                Dtu = pool.Dtu,
                DatabaseDtuMin = pool.DatabaseDtuMin,
                DatabaseDtuMax = pool.DatabaseDtuMax,
                Family = pool.Sku.Family,
                LicenseType = pool.LicenseType,
                MaintenanceConfigurationId = pool.MaintenanceConfigurationId,
            };

            return model;
        }

        /// <summary>
        /// Get elastic pool sku name based on tier
        ///    Edition              | SkuName
        ///    GeneralPurpose       | GP
        ///    BusinessCritical     | BC
        ///    Standard             | StandardPool
        ///    Basic                | BasicPool
        ///    Premium              | PremiumPool
        /// </summary>
        /// <param name="tier">Azure Sql elastic pool edition</param>
        /// <returns>The sku name</returns>
        public static string GetPoolSkuName(string tier)
        {
            if (string.IsNullOrWhiteSpace(tier))
            {
                return null;
            }

            return SqlSkuUtils.GetVcoreSkuPrefix(tier) ?? string.Format("{0}Pool", tier);
        }
    }
}
