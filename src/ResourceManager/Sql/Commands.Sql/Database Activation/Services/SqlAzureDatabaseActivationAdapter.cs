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
using Microsoft.Azure.Commands.Sql.Services;

namespace Microsoft.Azure.Commands.Sql.DatabaseActivation.Services
{
    /// <summary>
    /// Adapter for database activation operations
    /// </summary>
    public class AzureSqlDatabaseActivationAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlDatabaseActivationCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlDatabaseActivationCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a database activation adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseActivationAdapter(AzureContext context)
        {
            Context = context;
            _subscription = context.Subscription;
            Communicator = new AzureSqlDatabaseActivationCommunicator(Context);
        }

        /// <summary>
        /// Pauses a Azure SQL Data Warehouse database.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Data Warehouse database</param>
        /// <returns>The paused Azure SQL Data Warehouse database object</returns>
        internal AzureSqlDatabaseModel PauseDatabase(string resourceGroup, string serverName, string databaseName)
        {
            var resp = Communicator.Pause(resourceGroup, serverName, databaseName, Util.GenerateTracingId());
            return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroup, serverName, resp);
        }

        /// <summary>
        /// Resumes a Azure Sql Data Warehouse database.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure SQL Server</param>
        /// <param name="databaseName">The name of the Azure SQL Data Warehouse database</param>
        /// <returns>The resumed Azure SQL Data Warehouse database object</returns>
        internal AzureSqlDatabaseModel ResumeDatabase(string resourceGroup, string serverName, string databaseName)
        {
            var resp = Communicator.Resume(resourceGroup, serverName, databaseName, Util.GenerateTracingId());
            return AzureSqlDatabaseAdapter.CreateDatabaseModelFromResponse(resourceGroup, serverName, resp);
        }
    }
}
