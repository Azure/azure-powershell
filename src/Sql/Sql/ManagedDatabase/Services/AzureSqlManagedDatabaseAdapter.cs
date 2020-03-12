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
using Microsoft.Azure.Commands.Sql.ManagedDatabase.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Adapter;
using Microsoft.Azure.Commands.Sql.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Services;

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
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
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
        /// Converts the response from the service to a powershell managed database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="database">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlManagedDatabaseModel CreateManagedDatabaseModelFromResponse(string resourceGroup, string managedInstanceName, Management.Sql.Models.ManagedDatabase managedDatabase)
        {
            return new AzureSqlManagedDatabaseModel(resourceGroup, managedInstanceName, managedDatabase);
        }
    }
}
