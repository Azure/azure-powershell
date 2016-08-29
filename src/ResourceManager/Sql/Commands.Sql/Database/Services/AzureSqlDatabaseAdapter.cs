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
using Microsoft.Azure.Commands.Sql.ElasticPool.Services;
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
        public AzureSqlDatabaseAdapter(AzureContext context)
        {
            Context = context;
            _subscription = context.Subscription;
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
            var resp = Communicator.Get(resourceGroupName, serverName, databaseName, Util.GenerateTracingId());
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
            var resp = Communicator.GetExpanded(resourceGroupName, serverName, databaseName, Util.GenerateTracingId());
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
            var resp = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());

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
            var resp = Communicator.ListExpanded(resourceGroupName, serverName, Util.GenerateTracingId());

            return resp.Select((db) =>
            {
                return CreateExpandedDatabaseModelFromResponse(resourceGroupName, serverName, db);
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
        public static AzureSqlDatabaseModelExpanded CreateExpandedDatabaseModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.Database database)
        {
            return new AzureSqlDatabaseModelExpanded(resourceGroup, serverName, database);
        }

        internal IEnumerable<AzureSqlDatabaseActivityModel> ListDatabaseActivity(string resourceGroupName, string serverName, string elasticPoolName, string databaseName, Guid? operationId)
        {
            if (!string.IsNullOrEmpty(elasticPoolName))
            {
                var response = ElasticPoolCommunicator.ListDatabaseActivity(resourceGroupName, serverName, elasticPoolName, Util.GenerateTracingId());
                IEnumerable<AzureSqlDatabaseActivityModel> list = response.Select((r) =>
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
                throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.StandaloneDatabaseActivityNotSupported));
            }
        }
    }
}
