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
using Microsoft.Azure.Management.Sql.Models;
using DatabaseEdition = Microsoft.Azure.Commands.Sql.Database.Model.DatabaseEdition;

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
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseAdapter(IAzureContext context)
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
        /// Creates or updates an Azure Sql Database with Hyak SDK.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Database Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database from Hyak SDK</returns>
        internal AzureSqlDatabaseModel UpsertDatabase(string resourceGroup, string serverName, AzureSqlDatabaseCreateOrUpdateModel model)
        {
            // Use Hyak SDK
            var resp = Communicator.CreateOrUpdate(resourceGroup, serverName, model.Database.DatabaseName, new DatabaseCreateOrUpdateParameters
            {
                Location = model.Database.Location,
                Tags = model.Database.Tags,
                Properties = new DatabaseCreateOrUpdateProperties()
                {
                    Collation = model.Database.CollationName,
                    Edition = model.Database.Edition == DatabaseEdition.None ? null : model.Database.Edition.ToString(),
                    MaxSizeBytes = model.Database.MaxSizeBytes,
                    RequestedServiceObjectiveId = model.Database.RequestedServiceObjectiveId,
                    ElasticPoolName = model.Database.ElasticPoolName,
                    RequestedServiceObjectiveName = model.Database.RequestedServiceObjectiveName,
                    ReadScale = model.Database.ReadScale.ToString(),
                }
            });

            return CreateDatabaseModelFromResponse(resourceGroup, serverName, resp);
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
            // Use AutoRest SDK
            var resp = Communicator.CreateOrUpdate(resourceGroup, serverName, model.Database.DatabaseName, new Management.Sql.Models.Database
            {
                Location = model.Database.Location,
                Tags = model.Database.Tags,
                Collation = model.Database.CollationName,
                Edition = model.Database.Edition == DatabaseEdition.None ? null : model.Database.Edition.ToString(),
                MaxSizeBytes = model.Database.MaxSizeBytes.ToString(),
                RequestedServiceObjectiveId = model.Database.RequestedServiceObjectiveId,
                ElasticPoolName = model.Database.ElasticPoolName,
                RequestedServiceObjectiveName = model.Database.RequestedServiceObjectiveName,
                ReadScale = (ReadScale)Enum.Parse(typeof(ReadScale), model.Database.ReadScale.ToString()),
                SampleName = model.SampleName,
                ZoneRedundant = model.Database.ZoneRedundant
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
                        }
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
    }
}
