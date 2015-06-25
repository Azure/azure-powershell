﻿// ----------------------------------------------------------------------------------
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
using System.Net;
using Hyak.Common;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ServerUpgrade.Model;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ServerUpgrade.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the server upgrade REST endpoints
    /// </summary>
    public class AzureSqlServerUpgradeCommunicator
    {
        /// <summary>
        /// The target version to upgrade server to
        /// </summary>
        private const string targetUpgradeVersion = "12.0";

        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }
        
        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static AzureSubscription Subscription {get ; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Databases
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="subscription"></param>
        public AzureSqlServerUpgradeCommunicator(AzureProfile profile, AzureSubscription subscription)
        {
            Profile = profile;
            if (subscription != Subscription)
            {
                Subscription = subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Start an Azure Sql Database Server Upgrade
        /// </summary>
        public void Start(string resourceGroupName, string serverName, ServerUpgradeStartParameters parameters, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).ServerUpgrades.Start(resourceGroupName, serverName, parameters);
        }

        /// <summary>
        /// Cancel an Azure Sql Database Server Upgrade
        /// </summary>
        public void Cancel(string resourceGroupName, string serverName, string clientRequestId)
        {
            GetCurrentSqlClient(clientRequestId).ServerUpgrades.Cancel(resourceGroupName, serverName);
        }

        /// <summary>
        /// Gets the Azure Sql Database Server Upgrade status
        /// </summary>
        public ServerUpgradeStatus GetStatus(string resourceGroupName, string serverName, string clientRequestId)
        {
            try
            {
                var status = GetCurrentSqlClient(clientRequestId).ServerUpgrades.Get(resourceGroupName, serverName).Status;
                if (status == null)
                {
                    // This upgrade is either completed or not started. Check server version to be sure
                    var server = GetCurrentSqlClient(clientRequestId).Servers.Get(resourceGroupName, serverName).Server;
                    if (server.Properties.Version.Equals(targetUpgradeVersion, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return ServerUpgradeStatus.Completed;
                    }

                    return ServerUpgradeStatus.NotStarted;
                }
                
                ServerUpgradeStatus result;
                if (Enum.TryParse(status, out result))
                {
                    return result;
                }
                
                return ServerUpgradeStatus.Unknown;
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.BadRequest)
                {
                    // if bad request, the migration is aborted or cancelled
                    return ServerUpgradeStatus.Stopped;
                }
                
                throw;
            }
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
                SqlClient = AzureSession.ClientFactory.CreateClient<SqlManagementClient>(Profile, Subscription, AzureEnvironment.Endpoint.ResourceManager);
            }
            SqlClient.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            SqlClient.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
            return SqlClient;
        }
    }
}
