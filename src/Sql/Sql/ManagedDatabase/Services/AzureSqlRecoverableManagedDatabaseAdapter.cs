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

namespace Microsoft.Azure.Commands.Sql.ManagedDatabase.Services
{
    /// <summary>
    /// Adapter for managed database geo-backup operations
    /// </summary>
    public class AzureSqlRecoverableManagedDatabaseAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlRecoverableManagedDatabaseAdapter which has all the needed management clients
        /// </summary>
        private AzureSqlRecoverableManagedDatabaseCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private IAzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a recoverable managed database adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlRecoverableManagedDatabaseAdapter(IAzureContext context)
        {
            Context = context;
            _subscription = context.Subscription;
            Communicator = new AzureSqlRecoverableManagedDatabaseCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Managed Database Geo backup by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="databaseName">The name of the Azure Sql Managed Database</param>
        /// <returns>The Azure Sql Database object</returns>
        internal AzureSqlRecoverableManagedDatabaseModel GetRecoverableManagedDatabase(string resourceGroupName, string managedInstanceName, string databaseName)
        {
            var resp = Communicator.Get(resourceGroupName, managedInstanceName, databaseName);
            return CreateRecoverableManagedDatabaseModelFromResponse(resourceGroupName, managedInstanceName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Managed Databases geo-backups.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <returns>A list of database objects</returns>
        internal ICollection<AzureSqlRecoverableManagedDatabaseModel> ListRecoverableManagedDatabases(string resourceGroupName, string managedInstanceName)
        {
            var resp = Communicator.List(resourceGroupName, managedInstanceName);

            return resp.Select((db) => CreateRecoverableManagedDatabaseModelFromResponse(resourceGroupName, managedInstanceName, db)).ToList();
        }

        /// <summary>
        /// Converts the response from the service to a powershell managed database object
        /// </summary>
        /// <param name="resourceGroup">The resource group the managed instance is in</param>
        /// <param name="managedInstanceName">The name of the Azure Sql Database Managed Instance</param>
        /// <param name="managedDatabase">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlRecoverableManagedDatabaseModel CreateRecoverableManagedDatabaseModelFromResponse(string resourceGroup, string managedInstanceName, Management.Sql.Models.RecoverableManagedDatabase managedDatabase)
        {
            return new AzureSqlRecoverableManagedDatabaseModel(resourceGroup, managedInstanceName, managedDatabase);
        }
    }
}
