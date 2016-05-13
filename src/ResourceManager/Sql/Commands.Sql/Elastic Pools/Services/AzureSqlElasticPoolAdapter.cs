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
        public AzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlElasticPoolAdapter(AzureContext context)
        {
            _subscription = context.Subscription;
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
            var resp = Communicator.Get(resourceGroupName, serverName, poolName, Util.GenerateTracingId());
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
            var resp = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());

            return resp.Select((db) =>
            {
                return CreateElasticPoolModelFromResponse(resourceGroupName, serverName, db);
            }).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database ElasticPool.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database ElasticPool</returns>
        internal AzureSqlElasticPoolModel UpsertElasticPool(AzureSqlElasticPoolModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.ElasticPoolName, Util.GenerateTracingId(), new ElasticPoolCreateOrUpdateParameters()
            {
                Location = model.Location,
                Properties = new ElasticPoolCreateOrUpdateProperties()
                {
                    DatabaseDtuMax = model.DatabaseDtuMax,
                    DatabaseDtuMin = model.DatabaseDtuMin,
                    Edition = model.Edition.ToString(),
                    Dtu = model.Dtu,
                    StorageMB = model.StorageMB
                }
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
            Communicator.Remove(resourceGroupName, serverName, databaseName, Util.GenerateTracingId());
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
            var resp = Communicator.GetDatabase(resourceGroupName, serverName, poolName, databaseName, Util.GenerateTracingId());
            return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroupName, serverName, resp);
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
            var resp = Communicator.ListDatabases(resourceGroupName, serverName, poolName, Util.GenerateTracingId());

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
            var resp = Communicator.ListActivity(resourceGroupName, serverName, poolName, Util.GenerateTracingId());

            return resp.Select((activity) =>
            {
                return CreateActivityModelFromResponse(activity);
            }).ToList();
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
            var resp = Communicator.ListDatabaseActivity(resourceGroupName, serverName, poolName, Util.GenerateTracingId());

            return resp.Select((activity) =>
            {
                return CreateDatabaseActivityModelFromResponse(activity);
            }).ToList();
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
            AzureSqlElasticPoolActivityModel activity = new AzureSqlElasticPoolActivityModel();

            activity.ElasticPoolName = model.Properties.ElasticPoolName;
            activity.EndTime = model.Properties.EndTime;
            activity.ErrorCode = model.Properties.ErrorCode;
            activity.ErrorMessage = model.Properties.ErrorMessage;
            activity.ErrorSeverity = model.Properties.ErrorSeverity;
            activity.Operation = model.Properties.Operation;
            activity.OperationId = model.Properties.OperationId;
            activity.PercentComplete = model.Properties.PercentComplete;
            activity.RequestedDatabaseDtuMax = model.Properties.RequestedDatabaseDtuMax;
            activity.RequestedDatabaseDtuMin = model.Properties.RequestedDatabaseDtuMin;
            activity.RequestedDtu = model.Properties.RequestedDtu;
            activity.RequestedElasticPoolName = model.Properties.RequestedElasticPoolName;
            activity.RequestedStorageLimitInGB = model.Properties.RequestedStorageLimitInGB;
            activity.ServerName = model.Properties.ServerName;
            activity.StartTime = model.Properties.StartTime;
            activity.State = model.Properties.State;

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
            AzureSqlElasticPoolModel model = new AzureSqlElasticPoolModel();

            model.ResourceId = pool.Id;
            model.ResourceGroupName = resourceGroup;
            model.ServerName = serverName;
            model.ElasticPoolName = pool.Name;
            model.CreationDate = pool.Properties.CreationDate ?? DateTime.MinValue;
            model.DatabaseDtuMax = (int)pool.Properties.DatabaseDtuMax;
            model.DatabaseDtuMin = (int)pool.Properties.DatabaseDtuMin;
            model.Dtu = (int)pool.Properties.Dtu;
            model.State = pool.Properties.State;
            model.StorageMB = pool.Properties.StorageMB;
            model.Tags = pool.Tags as Dictionary<string, string>;
            model.Location = pool.Location;

            DatabaseEdition edition = DatabaseEdition.None;
            Enum.TryParse<DatabaseEdition>(pool.Properties.Edition, out edition);
            model.Edition = edition;

            return model;
        }
    }
}
