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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ServerDnsAlias.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlServerDnsAliasCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Server DNS Aliases
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerDnsAliasCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Get the Azure Sql Server Dns Alias
        /// </summary>
        public Management.Sql.Models.ServerDnsAlias Get(string resourceGroupName, string serverName, string serverDnsAliasName)
        {
            return GetCurrentSqlClient().ServerDnsAliases.Get(resourceGroupName, serverName, serverDnsAliasName);
        }

        /// <summary>
        /// Lists the Azure Sql Server Dns Aliases
        /// </summary>
        public IList<Management.Sql.Models.ServerDnsAlias> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().ServerDnsAliases.ListByServer(resourceGroupName, serverName).ToList();
        }

        /// <summary>
        /// Creates or updates an Azure Sql Server Dns Alias
        /// </summary>
        public Management.Sql.Models.ServerDnsAlias CreateOrUpdate(string resourceGroupName, string serverName, string serverDnsAliasName)
        {
            return GetCurrentSqlClient().ServerDnsAliases.CreateOrUpdate(resourceGroupName, serverName, serverDnsAliasName);
        }

        /// <summary>
        /// Deletes an Azure Sql Server Dns Alias
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string serverDnsAliasName)
        {
            GetCurrentSqlClient().ServerDnsAliases.Delete(resourceGroupName, serverName, serverDnsAliasName);
        }

        /// <summary>
        /// Acquires an Azure Sql Server Dns Alias from one server and assign it to another
        /// </summary>
        public void Acquire(string resourceGroupName, string serverName, string serverDnsAliasName, ServerDnsAliasAcquisition parameters)
        {
            GetCurrentSqlClient().ServerDnsAliases.Acquire(resourceGroupName, serverName, serverDnsAliasName, parameters);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            //
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
}
