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
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.WindowsAzure.Management.Storage;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.FailoverGroup.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlFailoverGroupCommunicator
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
        /// Creates a communicator for Azure SQL Database Failover Group
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public AzureSqlFailoverGroupCommunicator(AzureContext context)
        {
            Context = context;
            if (context.Subscription != Subscription)
            {
                Subscription = context.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database Failover Group
        /// </summary>
        public Management.Sql.LegacySdk.Models.FailoverGroup Get(string resourceGroupName, string serverName, string FailoverGroupName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).FailoverGroups.Get(resourceGroupName, serverName, FailoverGroupName).FailoverGroup;
        }

        /// <summary>
        /// Lists Azure Sql Database Failover Groups
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.FailoverGroup> List(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).FailoverGroups.List(resourceGroupName, serverName).FailoverGroups;
        }

        /// <summary>
        /// Creates or updates an Failover Group
        /// </summary>
        public Management.Sql.LegacySdk.Models.FailoverGroup CreateOrUpdate(string resourceGroupName, string serverName, string FailoverGroupName, string clientRequestId, FailoverGroupCreateOrUpdateParameters parameters)
        {
            var resp = GetCurrentSqlClient(clientRequestId).FailoverGroups.CreateOrUpdate(resourceGroupName, serverName, FailoverGroupName, parameters);
            return resp.FailoverGroup;
        }

        /// <summary>
        /// Deletes an Failover Group
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string FailoverGroupName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).FailoverGroups.Delete(resourceGroupName, serverName, FailoverGroupName);
        }

        /// <summary>
        /// Fail over an Failover Group without data loss
        /// </summary>
        public void Failover(string resourceGroupName, string serverName, string FailoverGroupName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).FailoverGroups.Failover(resourceGroupName, serverName, FailoverGroupName);
        }

        /// <summary>
        /// Fail over an Failover Group with data loss
        /// </summary>
        public void ForceFailoverAllowDataLoss(string resourceGroupName, string serverName, string FailoverGroupName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).FailoverGroups.ForceFailoverAllowDataLoss(resourceGroupName, serverName, FailoverGroupName);
        }

        /// <summary>
        /// Patch-updates an Failover Group
        /// </summary>
        public Management.Sql.LegacySdk.Models.FailoverGroup PatchUpdate(string resourceGroupName, string serverName, string FailoverGroupName, string clientRequestId, FailoverGroupPatchUpdateParameters parameters)
        {
            var resp = GetCurrentSqlClient(clientRequestId).FailoverGroups.PatchUpdate(resourceGroupName, serverName, FailoverGroupName, parameters);
            return resp.FailoverGroup;
        }


        /// <summary>
        /// Lists Azure Sql Databases on the Server
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.Database> ListDatabasesOnServer(string resourceGroupName, string serverName, string clientRequestId)
        {
            return GetCurrentSqlClient(clientRequestId).Databases.List(resourceGroupName, serverName).Databases;
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
