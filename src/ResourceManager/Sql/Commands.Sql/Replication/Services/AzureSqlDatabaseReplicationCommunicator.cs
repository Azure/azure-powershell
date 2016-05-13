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

namespace Microsoft.Azure.Commands.Sql.ReplicationLink.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlDatabaseReplicationCommunicator
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
        /// Creates a communicator for Azure SQL Databases
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public AzureSqlDatabaseReplicationCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure SQL Database
        /// </summary>
        public Management.Sql.Models.ReplicationLink GetLink(string resourceGroupName, string serverName, string databaseName, Guid linkId, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DatabaseReplicationLinks.Get(resourceGroupName, serverName, databaseName, linkId.ToString()).ReplicationLink;
        }

        /// <summary>
        /// Lists Azure SQL Databases
        /// </summary>
        public IList<Management.Sql.Models.ReplicationLink> ListLinks(string resourceGroupName, string serverName, string databaseName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).DatabaseReplicationLinks.List(resourceGroupName, serverName, databaseName).ReplicationLinks;
        }

        /// <summary>
        /// Creates a copy of a Azure SQL Database
        /// </summary>
        public Management.Sql.Models.DatabaseCreateOrUpdateResponse CreateCopy(string resourceGroupName, string serverName, string databaseName, string clientRequestId, DatabaseCreateOrUpdateParameters parameters)
        {
            return GetCurrentSqlClient(clientRequestId).Databases.CreateOrUpdate(resourceGroupName, serverName, databaseName, parameters);
        }

        /// <summary>
        /// Deletes a Replication Link
        /// </summary>
        public void RemoveLink(string resourceGroupName, string serverName, string databaseName, Guid linkId, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).DatabaseReplicationLinks.Delete(resourceGroupName, serverName, databaseName, linkId.ToString());
        }

        /// <summary>
        /// Fails over a Replication Link without data loss
        /// </summary>
        public void FailoverLink(string resourceGroupName, string serverName, string databaseName, Guid linkId, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).DatabaseReplicationLinks.Failover(resourceGroupName, serverName, databaseName, linkId.ToString());
        }

        /// <summary>
        /// Fails over a Replication Link with data loss
        /// </summary>
        public void FailoverLinkAllowDataLoss(string resourceGroupName, string serverName, string databaseName, Guid linkId, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).DatabaseReplicationLinks.FailoverAllowDataLoss(resourceGroupName, serverName, databaseName, linkId.ToString());
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