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
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.ElasticPool.Services;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql;
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
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseAdapter(AzureProfile Profile, AzureSubscription subscription)
        {
            this.Profile = Profile;
            this._subscription = subscription;
            Communicator = new AzureSqlDatabaseCommunicator(Profile, subscription);
            ElasticPoolCommunicator = new AzureSqlElasticPoolCommunicator(Profile, subscription);
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
            var resp = Communicator.Get(resourceGroupName, serverName, databaseName, Util.GenerateTracingId());
            return CreateDatabaseModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Databases.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlDatabaseModel> ListDatabases(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());

            return resp.Select((db) =>
            {
                return CreateDatabaseModelFromResponse(resourceGroupName, serverName, db);
            }).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database</returns>
        internal AzureSqlDatabaseModel UpsertDatabase(string resourceGroup, string serverName, AzureSqlDatabaseModel model)
        {
            var resp = Communicator.CreateOrUpdate(resourceGroup, serverName, model.DatabaseName, Util.GenerateTracingId(), new DatabaseCreateOrUpdateParameters()
            {
                Location = model.Location,
                Properties = new DatabaseCreateOrUpdateProperties()
                {
                    Collation = model.CollationName,
                    Edition = model.Edition == DatabaseEdition.None ? null : model.Edition.ToString(),
                    MaxSizeBytes = model.MaxSizeBytes,
                    RequestedServiceObjectiveId = model.RequestedServiceObjectiveId,
                    ElasticPoolName = model.ElasticPoolName,
                    RequestedServiceObjectiveName = model.RequestedServiceObjectiveName,
                }
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
            Communicator.Remove(resourceGroupName, serverName, databaseName, Util.GenerateTracingId());
        }

        /// <summary>
        /// Gets the Location of the server.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns></returns>
        public string GetServerLocation(string resourceGroupName, string serverName)
        {
            AzureSqlServerAdapter serverAdapter = new AzureSqlServerAdapter(Profile, _subscription);
            var server = serverAdapter.GetServer(resourceGroupName, serverName);
            return server.Location;
        }

        /// <summary>
        /// Converts the response from the service to a powershell database object
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="database">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlDatabaseModel CreateDatabaseModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.Database database)
        {
            AzureSqlDatabaseModel model = new AzureSqlDatabaseModel();
            Guid id = Guid.Empty;
            DatabaseEdition edition = DatabaseEdition.None;

            model.ResourceGroupName = resourceGroup;
            model.ServerName = serverName;
            model.CollationName = database.Properties.Collation;
            model.CreationDate = database.Properties.CreationDate;
            model.CurrentServiceLevelObjectiveName = database.Properties.ServiceObjective;
            model.MaxSizeBytes = database.Properties.MaxSizeBytes;
            model.DatabaseName = database.Name;
            model.Status = database.Properties.Status;
            model.Tags = database.Tags as Dictionary<string, string>;
            model.ElasticPoolName = database.Properties.ElasticPoolName;
            model.Location = database.Location;

            Guid.TryParse(database.Properties.CurrentServiceObjectiveId, out id);
            model.CurrentServiceObjectiveId = id;

            Guid.TryParse(database.Properties.DatabaseId, out id);
            model.DatabaseId = id;

            Enum.TryParse<DatabaseEdition>(database.Properties.Edition, true, out edition);
            model.Edition = edition;

            Guid.TryParse(database.Properties.RequestedServiceObjectiveId, out id);
            model.RequestedServiceObjectiveId = id;

            return model;
        }

        internal IEnumerable<AzureSqlDatabaseActivityModel> ListDatabaseActivity(string resourceGroupName, string serverName, string elasticPoolName, string databaseName, Guid? operationId)
        {
            List<AzureSqlDatabaseActivityModel> list = new List<AzureSqlDatabaseActivityModel>();

            if(!string.IsNullOrEmpty(elasticPoolName))
            {
                var response = ElasticPoolCommunicator.ListDatabaseActivity(resourceGroupName, serverName, elasticPoolName, Util.GenerateTracingId());
                list = response.Select((r) =>
                    {
                        return new AzureSqlDatabaseActivityModel()
                        {
                            DatabaseName = r.Properties.DatabaseName,
                            EndTime = r.Properties.EndTime,
                            ErrorCode = r.Properties.ErrorCode,
                            ErrorMessage = r.Properties.ErrorMessage,
                            ErrorSeverity = r.Properties.ErrorSeverity,
                            Operation = r.Properties.Operation,
                            OperationId = r.Properties.OperationId,
                            PercentComplete = r.Properties.PercentComplete,
                            ServerName = r.Properties.ServerName,
                            StartTime = r.Properties.StartTime,
                            State = r.Properties.State,
                            Properties = new AzureSqlDatabaseActivityModel.DatabaseState()
                            {
                                Current = new Dictionary<string, string>()
                                {
                                    {"CurrentElasticPoolName", r.Properties.CurrentElasticPoolName},
                                    {"CurrentServiceObjectiveName", r.Properties.CurrentServiceObjectiveName},
                                },
                                Requested = new Dictionary<string, string>()
                                {
                                    {"RequestedElasticPoolName", r.Properties.RequestedElasticPoolName},
                                    {"RequestedServiceObjectiveName", r.Properties.RequestedServiceObjectiveName},
                                }
                            }
                        };
                    }).ToList();
            }
            else
            {

            }

            return list;
        }
    }
}
