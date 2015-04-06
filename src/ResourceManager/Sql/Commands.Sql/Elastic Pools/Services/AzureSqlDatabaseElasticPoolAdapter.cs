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
using System.Linq;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using Microsoft.Azure.Commands.Sql.ElasticPool.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ElasticPool.Services
{
    /// <summary>
    /// Adapter for ElasticPool operations
    /// </summary>
    public class AzureSqlDatabaseElasticPoolAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseElasticPoolCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseElasticPoolAdapter(AzureProfile Profile, AzureSubscription subscription)
        {
            this.Profile = Profile;
            Communicator = new AzureSqlDatabaseElasticPoolCommunicator(Profile, subscription);
        }

        /// <summary>
        /// Gets an Azure Sql Database ElasticPool by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="poolName">The name of the Azure Sql Database ElasticPool</param>
        /// <returns>The Azure Sql Database ElasticPool object</returns>
        internal AzureSqlDatabaseElasticPoolModel GetElasticPool(string resourceGroupName, string serverName, string poolName)
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
        internal ICollection<AzureSqlDatabaseElasticPoolModel> ListElasticPools(string resourceGroupName, string serverName)
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
        internal AzureSqlDatabaseElasticPoolModel UpsertElasticPool(AzureSqlDatabaseElasticPoolModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.ElasticPoolName, Util.GenerateTracingId(), new ElasticPoolCreateOrUpdateParameters()
            {
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
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="pool">The service response</param>
        /// <returns>The converted model</returns>
        private AzureSqlDatabaseElasticPoolModel CreateElasticPoolModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.ElasticPool pool)
        {
            AzureSqlDatabaseElasticPoolModel model = new AzureSqlDatabaseElasticPoolModel();

            model.ResourceGroupName = resourceGroup;
            model.ServerName = serverName;
            model.ElasticPoolName = pool.Name;
            model.CreationDate = pool.Properties.CreationDate?? DateTime.MinValue;
            model.DatabaseDtuMax = (int)pool.Properties.DatabaseDtuMax;
            model.DatabaseDtuMin = (int)pool.Properties.DatabaseDtuMin;
            model.Dtu = (int)pool.Properties.Dtu;
            model.State = pool.Properties.State;
            model.StorageMB = pool.Properties.StorageMB;
            model.Tags = pool.Tags as Dictionary<string,string>;

            DatabaseEdition edition = DatabaseEdition.None;
            Enum.TryParse<DatabaseEdition>(pool.Properties.Edition, out edition);
            model.Edition = edition;

            return model;
        }
    }
}
