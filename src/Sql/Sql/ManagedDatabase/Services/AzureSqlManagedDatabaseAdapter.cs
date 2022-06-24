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
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Services;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Adapter;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Services
{
    /// <summary>
    /// Adapter for managed database operations
    /// </summary>
    public class AzureSqlManagedDatabaseAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlManagedDatabaseCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlManagedDatabaseCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private IAzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a managed database adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlManagedDatabaseAdapter(IAzureContext context)
        {
            Context = context;
            _subscription = context?.Subscription;
            Communicator = new AzureSqlManagedDatabaseCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Managed Database by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="databaseName">The name of the Azure Sql Managed Database</param>
        /// <returns>The Azure Sql Database object</returns>
        internal AzureSqlManagedDatabaseModel GetManagedDatabase(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            var resp = Communicator.Get(resourceGroupName, managedInstanceName, databaseName);
            return CreateManagedDatabaseModelFromResponse(resourceGroupName, managedInstanceName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Managed Databases.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlManagedDatabaseModel> ListManagedDatabases(string resourceGroupName, string managedInstanceName)
        {
            var resp = Communicator.List(resourceGroupName, managedInstanceName);

            return resp.Select((db) => CreateManagedDatabaseModelFromResponse(resourceGroupName, managedInstanceName, db)).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure Sql Managed Database.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>The upserted Azure Sql Database from AutoRest SDK</returns>
        internal AzureSqlManagedDatabaseModel UpsertManagedDatabase(string resourceGroup, string managedInstanceName, AzureSqlManagedDatabaseModel model)
        {
            var resp = Communicator.CreateOrUpdate(resourceGroup, managedInstanceName, model.Name, new Management.Sql.Models.ManagedDatabase
            {
                Location = model.Location,
                Tags = model.Tags,
                Collation = model.Collation,
            });

            return CreateManagedDatabaseModelFromResponse(resourceGroup, managedInstanceName, resp);
        }

        /// <summary>
        /// Deletes a managed database
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="databaseName">The name of the Azure Sql Managed Database to delete</param>
        public void RemoveManagedDatabase(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            Communicator.Remove(resourceGroupName, managedInstanceName, databaseName);
        }

        /// <summary>
        /// Restore a given Sql Azure Managed Database
        /// </summary>
        /// <param name="model">An object modeling the database to create via restore</param>
        /// <returns>Restored database object</returns>
        internal AzureSqlManagedDatabaseModel RestoreManagedDatabase(AzureSqlManagedDatabaseModel model)
        {
            var dbModel = new Management.Sql.Models.ManagedDatabase()
            {
                Location = model.Location,
                CreateMode = model.CreateMode,
                RestorePointInTime = model.RestorePointInTime,
                RecoverableDatabaseId = model.RecoverableDatabaseId,
                RestorableDroppedDatabaseId = model.RestorableDroppedDatabaseId,
                SourceDatabaseId = model.SourceDatabaseId,
                LongTermRetentionBackupResourceId = model.LongTermRetentionBackupResourceId
            };

            Management.Sql.Models.ManagedDatabase database = Communicator.RestoreDatabase(model.ResourceGroupName, model.ManagedInstanceName, model.Name, dbModel);

            return new AzureSqlManagedDatabaseModel(model.ResourceGroupName, model.ManagedInstanceName, database);
        }

        /// <summary>
        /// Gets the Location of the managed instance.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the managed instance</param>
        /// <returns></returns>
        public string GetManagedInstanceLocation(string resourceGroupName, string managedInstanceName)
        {
            AzureSqlManagedInstanceAdapter managedInstanceAdapter = new AzureSqlManagedInstanceAdapter(Context);
            var managedInstance = managedInstanceAdapter.GetManagedInstance(resourceGroupName, managedInstanceName);
            return managedInstance.Location;
        }

        /// <summary>
        /// Gets the Resource id of the managed instance.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the managed instance</param>
        /// <param name="managedDatabaseName">The name of the managed databse</param>
        /// <returns></returns>
        public string GetManagedDatabaseResourceId(string resourceGroupName, string managedInstanceName, string managedDatabaseName)
        {
            AzureSqlManagedDatabaseAdapter managedInstanceAdapter = new AzureSqlManagedDatabaseAdapter(Context);
            var managedInstance = managedInstanceAdapter.GetManagedDatabase(resourceGroupName, managedInstanceName, managedDatabaseName);
            return managedInstance.Id;
        }

        /// <summary>
        /// Gets the Resource id of the managed instance.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the managed instance</param>
        /// <param name="managedDatabaseName">The name of the managed databse</param>
        /// <returns></returns>
        public string GetDeletedManagedDatabaseResourceId(string resourceGroupName, string managedInstanceName, string managedDatabaseName)
        {
            AzureSqlManagedDatabaseBackupAdapter managedInstanceAdapter = new AzureSqlManagedDatabaseBackupAdapter(Context);
            var managedInstance = managedInstanceAdapter.GetDeletedDatabaseBackup(resourceGroupName, managedInstanceName, managedDatabaseName);
            return managedInstance.Id;
        }

        /// <summary>
        /// Start the managed database log replay
        /// </summary>
        /// <param name="parameters">The parameters for log replay</param>
        public AzureSqlManagedDatabaseModel StartManagedDatabaseLogReplay(AzureSqlManagedDatabaseModel parameters)
        {
            var model = new Management.Sql.Models.ManagedDatabase()
            {
                Location = parameters.Location,
                Collation = parameters.Collation,
                AutoCompleteRestore = parameters.AutoCompleteRestore,
                LastBackupName = parameters.LastBackupName,
                CreateMode = CreateMode.RestoreExternalBackup,
                StorageContainerUri = parameters.StorageContainerUri,
                StorageContainerSasToken = parameters.StorageContainerSasToken
            };
            var response = Communicator.StartLogReplay(parameters.ResourceGroupName, parameters.ManagedInstanceName, parameters.Name, model);
            return CreateManagedDatabaseModelFromResponse(parameters.ResourceGroupName, parameters.ManagedInstanceName, response);
        }

        /// <summary>
        /// Get managed database log replay restore status details
        /// </summary>
        /// <param name="resourceGroupName">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the managed instance</param>
        /// <param name="managedDatabaseName">The name of the managed database</param>
        /// <returns></returns>
        public AzureSqlManagedDatabaseRestoreDetailsResultModel GetManagedDatabaseLogReplay(string resourceGroupName, string managedInstanceName, string managedDatabaseName)
        {
            var result = Communicator.GetLogReplayStatus(
                resourceGroupName,
                managedInstanceName,
                managedDatabaseName);

            return CreateManagedDatabaseRestoreStatusModel(
                resourceGroupName, 
                managedInstanceName,
                managedDatabaseName, result);
        }

        /// <summary>
        /// Completes managed database log replay restore.
        /// </summary>
        /// <param name="parameters">The parameters for log replay complete action</param>
        public void CompleteManagedDatabaseLogReplay(AzureSqlManagedDatabaseModel parameters)
        {
            Communicator.CompleteLogReplay(
                parameters.ResourceGroupName,
                parameters.ManagedInstanceName,
                parameters.Name,
                parameters.LastBackupName);
        }

        private bool isLRSRestore(ManagedDatabaseRestoreDetailsResult restoreDetails)
        {
            var restoreType = restoreDetails.GetType().GetProperty("ManagedDatabaseRestoreDetailsResultType");
            // 1) no property => old api => it's log replay as the API only works for such dbs
            // 2) property is there => new api => property value will tell us if its LRS
            return (restoreType == null) || ((string)restoreType.GetValue(restoreDetails)).Equals("lrsrestore", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Removes managed database in order to stop log replay service
        /// </summary>
        /// <param name="parameters">The parameters for log replay cancel action</param>
        public void StopManagedDatabaseLogReplay(AzureSqlManagedDatabaseModel parameters)
        {
            // Check if the database provided by the caller is indeed created by Log Replay migration
            var dbRestoreDetails = Communicator.GetLogReplayStatus(parameters.ResourceGroupName, parameters.ManagedInstanceName, parameters.Name);
            if (isLRSRestore(dbRestoreDetails))
            {
                Communicator.Remove(parameters.ResourceGroupName, parameters.ManagedInstanceName, parameters.Name);
            }
            else
            {
                throw new PSArgumentException(string.Format(Properties.Resources.StopLogReplayErrorDatabaseOrigin, parameters.Name, parameters.ManagedInstanceName, parameters.ResourceGroupName), "InstanceDatabaseName");
            }
        }

        /// <summary>
        /// Converts the response from the service to a powershell managed database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="managedDatabase">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlManagedDatabaseModel CreateManagedDatabaseModelFromResponse(string resourceGroup, string managedInstanceName, Management.Sql.Models.ManagedDatabase managedDatabase)
        {
            return new AzureSqlManagedDatabaseModel(resourceGroup, managedInstanceName, managedDatabase);
        }

        private AzureSqlManagedDatabaseRestoreDetailsResultModel CreateManagedDatabaseRestoreStatusModel(string resourceGroupName, string managedInstanceName, string managedDatabaseName, ManagedDatabaseRestoreDetailsResult result)
        {
            return new AzureSqlManagedDatabaseRestoreDetailsResultModel(result)
            {
                ResourceGroupName = resourceGroupName,
                ManagedInstanceName = managedInstanceName,
                Name = managedDatabaseName
            };
        }

    }
}
