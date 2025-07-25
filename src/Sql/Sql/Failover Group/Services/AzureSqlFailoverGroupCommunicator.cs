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
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;

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
        private static Management.Sql.LegacySdk.SqlManagementClient LegacySqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure SQL Database Failover Group
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlFailoverGroupCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                LegacySqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database Failover Group
        /// </summary>
        public Management.Sql.LegacySdk.Models.FailoverGroup Get(string resourceGroupName, string serverName, string FailoverGroupName)
        {
            return GetLegacySqlClient().FailoverGroups.Get(resourceGroupName, serverName, FailoverGroupName).FailoverGroup;
        }

                /// <summary>
        /// Gets the Azure Sql Database Failover Group
        /// </summary>
        public Management.Sql.Models.FailoverGroup GetV2(string resourceGroupName, string serverName, string FailoverGroupName)
        {
            return GetCurrentSqlClient().FailoverGroups.Get(resourceGroupName, serverName, FailoverGroupName);
        }

        /// <summary>
        /// Lists Azure Sql Database Failover Groups
        /// </summary>
        public IList<Management.Sql.Models.FailoverGroup> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().FailoverGroups.ListByServer(resourceGroupName, serverName).ToList();
        }

        /// <summary>
        /// Creates or updates an Failover Group
        /// </summary>
        public Management.Sql.LegacySdk.Models.FailoverGroup CreateOrUpdate(string resourceGroupName, string serverName, string FailoverGroupName, FailoverGroupCreateOrUpdateParameters parameters)
        {
            var resp = GetLegacySqlClient().FailoverGroups.CreateOrUpdate(resourceGroupName, serverName, FailoverGroupName, parameters);
            return resp.FailoverGroup;
        }

        /// <summary>
        /// Creates or updates an Failover Group
        /// </summary>
        public Management.Sql.Models.FailoverGroup CreateOrUpdateV2(string resourceGroupName, string serverName, string FailoverGroupName, Management.Sql.Models.FailoverGroup parameters)
        {
            var resp = GetCurrentSqlClient().FailoverGroups.CreateOrUpdate(resourceGroupName, serverName, FailoverGroupName, parameters);
            return resp;
        }

        /// <summary>
        /// Deletes an Failover Group
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string FailoverGroupName)
        {
            GetLegacySqlClient().FailoverGroups.Delete(resourceGroupName, serverName, FailoverGroupName);
        }

        /// <summary>
        /// Fail over an Failover Group without data loss
        /// </summary>
        public void Failover(string resourceGroupName, string serverName, string FailoverGroupName)
        {
            GetLegacySqlClient().FailoverGroups.Failover(resourceGroupName, serverName, FailoverGroupName);
        }

        /// <summary>
        /// Fail over an Failover Group with data loss
        /// </summary>
        public void ForceFailoverAllowDataLoss(string resourceGroupName, string serverName, string FailoverGroupName)
        {
            GetLegacySqlClient().FailoverGroups.ForceFailoverAllowDataLoss(resourceGroupName, serverName, FailoverGroupName);
        }

        /// <summary>
        /// Fail over an Failover Group with try planned before forced failover
        /// </summary>
        public void TryPlannedBeforeForcedFailover(string resourceGroupName, string serverName, string FailoverGroupName)
        {
            GetCurrentSqlClient().FailoverGroups.TryPlannedBeforeForcedFailover(resourceGroupName, serverName, FailoverGroupName);
        }

        /// <summary>
        /// Patch-updates an Failover Group
        /// </summary>
        public Management.Sql.LegacySdk.Models.FailoverGroup PatchUpdate(string resourceGroupName, string serverName, string FailoverGroupName, FailoverGroupPatchUpdateParameters parameters)
        {
            var resp = GetLegacySqlClient().FailoverGroups.PatchUpdate(resourceGroupName, serverName, FailoverGroupName, parameters);
            return resp.FailoverGroup;
        }

        /// <summary>
        /// Patch-updates an Failover Group
        /// </summary>
        public Management.Sql.Models.FailoverGroup PatchUpdateV2(string resourceGroupName, string serverName, string FailoverGroupName, FailoverGroupUpdate parameters)
        {
            var resp = GetCurrentSqlClient().FailoverGroups.Update(resourceGroupName, serverName, FailoverGroupName, parameters);
            return resp;
        }


        /// <summary>
        /// Lists Azure Sql Databases on the Server
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.Database> ListDatabasesOnServer(string resourceGroupName, string serverName)
        {
            return GetLegacySqlClient().Databases.List(resourceGroupName, serverName).Databases;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.LegacySdk.SqlManagementClient GetLegacySqlClient()
        {
            // Get the SQL management client for the current subscription
            if (LegacySqlClient == null)
            {
                LegacySqlClient = AzureSession.Instance.ClientFactory.CreateClient<Management.Sql.LegacySdk.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return LegacySqlClient;
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            // Note: client is not cached in static field because that causes ObjectDisposedException in functional tests
            var sqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
       
            return sqlClient;
        }

    }
}
