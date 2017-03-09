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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.WindowsAzure.Management.Storage;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.Database.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlDatabaseCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static AzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Expand string used for getting additional database information
        /// </summary>
        public const string ExpandDatabase = "serviceTierAdvisors";

        /// <summary>
        /// Creates a communicator for Azure Sql Databases
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public AzureSqlDatabaseCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database
        /// </summary>
        public Management.Sql.Models.Database Get(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).Databases.Get(resourceGroupName, serverName, databaseName).Database;
        }

        /// <summary>
        /// Gets the Azure Sql Database expanded additional details.
        /// </summary>
        public Management.Sql.Models.Database GetExpanded(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).Databases.GetExpanded(resourceGroupName, serverName, databaseName, ExpandDatabase).Database;
        }

        /// <summary>
        /// Lists Azure Sql Databases
        /// </summary>
        public IList<Management.Sql.Models.Database> List(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).Databases.List(resourceGroupName, serverName).Databases;
        }

        /// <summary>
        /// Lists Azure Sql Databases expanded with additional details.
        /// </summary>
        public IList<Management.Sql.Models.Database> ListExpanded(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).Databases.ListExpanded(resourceGroupName, serverName, ExpandDatabase).Databases;
        }

        /// <summary>
        /// Creates or updates a database
        /// </summary>
        public Management.Sql.Models.Database CreateOrUpdate(string resourceGroupName, string serverName, string databaseName, string clientRequestId, DatabaseCreateOrUpdateParameters parameters)
        {
            return GetCurrentSqlClient(clientRequestId).Databases.CreateOrUpdate(resourceGroupName, serverName, databaseName, parameters).Database;
        }

        /// <summary>
        /// Deletes a database
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).Databases.Delete(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient(String clientRequestId)
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}