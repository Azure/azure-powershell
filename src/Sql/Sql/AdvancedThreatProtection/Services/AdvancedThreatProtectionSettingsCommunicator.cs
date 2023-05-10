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
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the AdvancedThreatProtectionSettings REST endpoints
    /// </summary>
    public class AdvancedThreatProtectionSettingsCommunicator
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

        public AdvancedThreatProtectionSettingsCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the server Advanced Threat Protection settings for the given server in the given resource group.
        /// </summary>
        /// <param name="resourceGroupName">The given resource group.</param>
        /// <param name="serverName">The given server.</param>
        /// <returns>A ServerAdvancedThreatProtection instance with the Advanced Threat Protection settings for the given server.</returns>
        public ServerAdvancedThreatProtection GetServerAdvancedThreatProtection(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().ServerAdvancedThreatProtectionSettings.Get(resourceGroupName, serverName);
        }

        /// <summary>
        /// Gets the database Advanced Threat Protection settings for the given server and database in the given resource group.
        /// </summary>
        /// <param name="resourceGroupName">The given resource group.</param>
        /// <param name="serverName">The given server.</param>
        /// <param name="databaseName">The given database.</param>
        /// <returns>A DatabaseAdvancedThreatProtection instance with the Advanced Threat Protection settings for the given server and database.</returns>
        public DatabaseAdvancedThreatProtection GetDatabaseAdvancedThreatProtection(string resourceGroupName, string serverName, string databaseName)
        {
            return GetCurrentSqlClient().DatabaseAdvancedThreatProtectionSettings.Get(resourceGroupName, serverName, databaseName);
        }

        /// <summary>
        /// Gets the managed instance Advanced Threat Protection settings for the given managed instance in the given resource group.
        /// </summary>
        /// <param name="resourceGroupName">The given resource group.</param>
        /// <param name="instanceName">The given managed instance.</param>
        /// <returns>A ManagedInstanceAdvancedThreatProtection instance with the Advanced Threat Protection settings for the given managed instance.</returns>
        public ManagedInstanceAdvancedThreatProtection GetManagedInstanceAdvancedThreatProtection(string resourceGroupName, string instanceName)
        {
            return GetCurrentSqlClient().ManagedInstanceAdvancedThreatProtectionSettings.Get(resourceGroupName, instanceName);
        }

        /// <summary>
        /// Gets the managed database Advanced Threat Protection settings for the given managed instance and database in the given resource group.
        /// </summary>
        /// <param name="resourceGroupName">The given resource group.</param>
        /// <param name="instanceName">The given managed instance.</param>
        /// <param name="databaseName">The given managed database.</param>
        /// <returns>A ManagedDatabaseAdvancedThreatProtection instance with the Advanced Threat Protection settings for the given managed database.</returns>
        public ManagedDatabaseAdvancedThreatProtection GetManagedDatabaseAdvancedThreatProtection(string resourceGroupName, string instanceName, string databaseName)
        {
            return GetCurrentSqlClient().ManagedDatabaseAdvancedThreatProtectionSettings.Get(resourceGroupName, instanceName, databaseName);
        }

        /// <summary>
        /// Creates or updates the Advanced Threat Protection settings for the given server in the given resource group.
        /// </summary>
        /// <param name="resourceGroupName">The given resource group.</param>
        /// <param name="serverName">The given server.</param>
        /// <param name="settingsToSet">The Advanced Threat Protection settings to set.</param>
        public void SetServerAdvancedThreatProtection(string resourceGroupName, string serverName, ServerAdvancedThreatProtection settingsToSet)
        {
            GetCurrentSqlClient().ServerAdvancedThreatProtectionSettings.CreateOrUpdate(resourceGroupName, serverName, settingsToSet);
        }

        /// <summary>
        /// Creates or updates the Advanced Threat Protection settings for the given server and database in the given resource group.
        /// </summary>
        /// <param name="resourceGroupName">The given resource group.</param>
        /// <param name="serverName">The given server.</param>
        /// <param name="databaseName">The given database.</param>
        /// <param name="settingsToSet">The Advanced Threat Protection settings to set.</param>
        public void SetDatabaseAdvancedThreatProtection(string resourceGroupName, string serverName, string databaseName,
            DatabaseAdvancedThreatProtection settingsToSet)
        {
            GetCurrentSqlClient().DatabaseAdvancedThreatProtectionSettings.CreateOrUpdate(resourceGroupName, serverName, databaseName, settingsToSet);
        }

        /// <summary>
        /// Creates or updates the Advanced Threat Protection settings for the given managed instance in the given resource group.
        /// </summary>
        /// <param name="resourceGroupName">The given resource group.</param>
        /// <param name="instanceName">The given managed instance.</param>
        /// <param name="settingsToSet">The Advanced Threat Protection settings to set.</param>
        public void SetManagedInstanceAdvancedThreatProtection(string resourceGroupName, string instanceName, ManagedInstanceAdvancedThreatProtection settingsToSet)
        {
            GetCurrentSqlClient().ManagedInstanceAdvancedThreatProtectionSettings.CreateOrUpdate(resourceGroupName, instanceName, settingsToSet);
        }

        /// <summary>
        /// Creates or updates the Advanced Threat Protection settings for the given managed instance and database in the given resource group.
        /// </summary>
        /// <param name="resourceGroupName">The given resource group.</param>
        /// <param name="instanceName">The given managed instance.</param>
        /// <param name="databaseName">The given managed database.</param>
        /// <param name="settingsToSet">The Advanced Threat Protection settings to set.</param>
        public void SetManagedDatabaseAdvancedThreatProtection(string resourceGroupName, string instanceName, string databaseName, 
            ManagedDatabaseAdvancedThreatProtection settingsToSet)
        {
            GetCurrentSqlClient().ManagedDatabaseAdvancedThreatProtectionSettings.CreateOrUpdate(resourceGroupName, instanceName, databaseName, settingsToSet);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
}
