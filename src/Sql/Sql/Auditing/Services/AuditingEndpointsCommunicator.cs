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
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Microsoft.Azure.Commands.Sql.Auditing.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication.
    /// </summary>
    public class AuditingEndpointsCommunicator
    {
        private static SqlManagementClient SqlClient { get; set; }

        private static IMonitorManagementClient MonitorClient { get; set; }

        private static IAzureSubscription Subscription { get; set; }

        public IAzureContext Context { get; set; }

        public AuditingEndpointsCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
                MonitorClient = null;
            }
        }

        public bool SetAuditingPolicy(string resourceGroupName, string serverName,
            string databaseName, DatabaseBlobAuditingPolicy policy)
        {
            IDatabaseBlobAuditingPoliciesOperations operations = GetCurrentSqlClient().DatabaseBlobAuditingPolicies;
            return operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName,
                serverName, databaseName, policy).Result.Response.IsSuccessStatusCode;
        }

        public bool SetAuditingPolicy(string resourceGroupName, string serverName,
            ServerBlobAuditingPolicy policy)
        {
            SqlManagementClient client = GetCurrentSqlClient();
            AzureOperationResponse<ServerBlobAuditingPolicy> response =
                client.ServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName, serverName, policy).Result;
            return client.GetLongRunningOperationResultAsync(response, null, CancellationToken.None).Result.Response.IsSuccessStatusCode;
        }

        public ExtendedDatabaseBlobAuditingPolicy GetAuditingPolicy(string resourceGroupName,
            string serverName, string databaseName)
        {
            return GetCurrentSqlClient().ExtendedDatabaseBlobAuditingPolicies.Get(
                resourceGroupName, serverName, databaseName);
        }

        public ExtendedServerBlobAuditingPolicy GetAuditingPolicy(string resourceGroupName,
            string serverName)
        {
            return GetCurrentSqlClient().ExtendedServerBlobAuditingPolicies.Get(
                resourceGroupName, serverName);
        }

        public bool SetExtendedAuditingPolicy(string resourceGroupName, string serverName,
            string databaseName, ExtendedDatabaseBlobAuditingPolicy policy)
        {
            IExtendedDatabaseBlobAuditingPoliciesOperations operations = GetCurrentSqlClient().ExtendedDatabaseBlobAuditingPolicies;
            return operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName,
                serverName, databaseName, policy).Result.Response.IsSuccessStatusCode;
        }

        public bool SetAuditingPolicy(string resourceGroupName, string serverName,
            ExtendedServerBlobAuditingPolicy policy)
        {
            SqlManagementClient client = GetCurrentSqlClient();
            AzureOperationResponse<ExtendedServerBlobAuditingPolicy> response =
                client.ExtendedServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName, serverName, policy).Result;
            return client.GetLongRunningOperationResultAsync(response, null,
                CancellationToken.None).Result.Response.IsSuccessStatusCode;
        }

        public IList<DiagnosticSettingsResource> GetDiagnosticsEnablingAuditCategory(
            out string nextDiagnosticSettingsName,
            string resourceGroupName, string serverName, string databaseName = "master")
        {
            string resourceUri = GetResourceUri(resourceGroupName, serverName, databaseName);
            IList<DiagnosticSettingsResource> settings =
                GetMonitorManagementClient().DiagnosticSettings.ListAsync(resourceUri).Result.Value;
            nextDiagnosticSettingsName = GetNextDiagnosticSettingsName(settings);
            return settings?.Where(s => IsAuditCategoryEnabled(s))?.OrderBy(s => s.Name)?.ToList();
        }

        public bool RemoveDiagnosticSettings(string settingsName, string resourceGroupName,
            string serverName, string databaseName = "master")
        {
            string resourceUri = GetResourceUri(resourceGroupName, serverName, databaseName);
            return GetMonitorManagementClient().DiagnosticSettings.DeleteWithHttpMessagesAsync(
                resourceUri, settingsName).Result.Response.IsSuccessStatusCode;
        }

        public DiagnosticSettingsResource CreateDiagnosticSettings(
            string settingsName, string eventHubName, string eventHubAuthorizationRuleId, string workspaceId,
            string resourceGroupName, string serverName, string databaseName = "master")
        {
            string resoureUri = GetResourceUri(resourceGroupName, serverName, databaseName);
            IMonitorManagementClient client = GetMonitorManagementClient();
            DiagnosticSettingsResource settings = new DiagnosticSettingsResource
            {
                Logs = new List<LogSettings>(),
                Metrics = new List<MetricSettings>(),
                EventHubName = eventHubName,
                EventHubAuthorizationRuleId = eventHubAuthorizationRuleId,
                WorkspaceId = workspaceId
            };

            try
            {
                IList<DiagnosticSettingsCategoryResource> supportedCategories =
                    client.DiagnosticSettingsCategory.ListAsync(resoureUri).Result.Value;
                if (supportedCategories != null)
                {
                    foreach (DiagnosticSettingsCategoryResource category in supportedCategories)
                    {
                        if (category.CategoryType == CategoryType.Metrics)
                        {
                            settings.Metrics.Add(new MetricSettings(false, null, category.Name));
                        }
                        else
                        {
                            settings.Logs.Add(
                                new LogSettings(
                                    string.Equals(category.Name, DefinitionsCommon.SQLSecurityAuditCategory),
                                    category.Name));
                        }
                    }
                }
            }
            catch (AggregateException ex)
            {
                if (!(ex.InnerException is ErrorResponseException ex1) ||
                    ex1.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    throw ex.InnerException ?? ex;
                }
            }

            return client.DiagnosticSettings.CreateOrUpdateAsync(
                resoureUri, settings, settingsName).Result;
        }

        public DiagnosticSettingsResource UpdateDiagnosticSettings(DiagnosticSettingsResource settings,
            string resourceGroupName, string serverName, string databaseName = "master")
        {
            return GetMonitorManagementClient().DiagnosticSettings.CreateOrUpdateAsync(
                GetResourceUri(resourceGroupName, serverName, databaseName), settings, settings.Name).Result;
        }

        private static string GetNextDiagnosticSettingsName(IList<DiagnosticSettingsResource> settings)
        {
            int nextIndex = (settings?.Where(
                s => s.Name.StartsWith(DefinitionsCommon.DiagnosticSettingsNamePrefix)).Select(
                s => s.Name).Select(
                name => name.Replace(DefinitionsCommon.DiagnosticSettingsNamePrefix, string.Empty)).Select(
                number => Int32.TryParse(number, out Int32 index) ? index : 0).DefaultIfEmpty().Max() ?? 0) + 1;
            return $"{DefinitionsCommon.DiagnosticSettingsNamePrefix}{nextIndex}";
        }

        internal static bool IsAuditCategoryEnabled(DiagnosticSettingsResource settings)
        {
            return settings?.Logs?.FirstOrDefault(
                l => l.Enabled &&
                string.Equals(l.Category, DefinitionsCommon.SQLSecurityAuditCategory)) != null;
        }

        private static string GetResourceUri(string resourceGroupName, string serverName, string databaseName)
        {
            return $"/subscriptions/{Subscription.Id}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}";
        }

        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateArmClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }

            return SqlClient;
        }

        private IMonitorManagementClient GetMonitorManagementClient()
        {
            if (MonitorClient == null)
            {
                MonitorClient = AzureSession.Instance.ClientFactory.CreateArmClient<MonitorManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }

            return MonitorClient;
        }
    }
}
