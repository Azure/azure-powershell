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
<<<<<<< HEAD
=======
using Microsoft.Azure.Commands.Sql.Common;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using Microsoft.Azure.Management.Monitor.Version2018_09_01;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
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
<<<<<<< HEAD
            IDatabaseBlobAuditingPoliciesOperations operations = GetCurrentSqlClient().DatabaseBlobAuditingPolicies;
            return operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName,
                serverName, databaseName, policy).Result.Response.IsSuccessStatusCode;
=======
            return SetAuditingPolicyInternal(() =>
            {
                IDatabaseBlobAuditingPoliciesOperations operations = GetCurrentSqlClient().DatabaseBlobAuditingPolicies;
                return operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName,
                    serverName, databaseName, policy).Result.Response.IsSuccessStatusCode;
            });
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        public bool SetAuditingPolicy(string resourceGroupName, string serverName,
            ServerBlobAuditingPolicy policy)
        {
<<<<<<< HEAD
            SqlManagementClient client = GetCurrentSqlClient();
            AzureOperationResponse<ServerBlobAuditingPolicy> response =
                client.ServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName, serverName, policy).Result;
            return client.GetLongRunningOperationResultAsync(response, null, CancellationToken.None).Result.Response.IsSuccessStatusCode;
=======
            return SetAuditingPolicyInternal(() =>
            {
                SqlManagementClient client = GetCurrentSqlClient();
                AzureOperationResponse<ServerBlobAuditingPolicy> response =
                    client.ServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                        resourceGroupName, serverName, policy).Result;
                return client.GetLongRunningOperationResultAsync(response, null, CancellationToken.None).Result.Response.IsSuccessStatusCode;
            });
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
            IExtendedDatabaseBlobAuditingPoliciesOperations operations = GetCurrentSqlClient().ExtendedDatabaseBlobAuditingPolicies;
            return operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName,
                serverName, databaseName, policy).Result.Response.IsSuccessStatusCode;
=======
            return SetAuditingPolicyInternal(() =>
            {
                IExtendedDatabaseBlobAuditingPoliciesOperations operations = GetCurrentSqlClient().ExtendedDatabaseBlobAuditingPolicies;
                return operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName,
                    serverName, databaseName, policy).Result.Response.IsSuccessStatusCode;
            });
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        public bool SetExtendedAuditingPolicy(string resourceGroupName, string serverName,
            ExtendedServerBlobAuditingPolicy policy)
        {
<<<<<<< HEAD
            SqlManagementClient client = GetCurrentSqlClient();
            AzureOperationResponse<ExtendedServerBlobAuditingPolicy> response =
                client.ExtendedServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName, serverName, policy).Result;
            return client.GetLongRunningOperationResultAsync(response, null,
                CancellationToken.None).Result.Response.IsSuccessStatusCode;
=======
            return SetAuditingPolicyInternal(() =>
            {
                SqlManagementClient client = GetCurrentSqlClient();
                AzureOperationResponse<ExtendedServerBlobAuditingPolicy> response =
                    client.ExtendedServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                    resourceGroupName, serverName, policy).Result;
                return client.GetLongRunningOperationResultAsync(response, null,
                    CancellationToken.None).Result.Response.IsSuccessStatusCode;
            });
        }

        public ServerDevOpsAuditingSettings GetDevOpsAuditingPolicy(string resourceGroupName,
            string serverName)
        {
            IServerDevOpsAuditSettingsOperations serverDevOpsAuditPolicies = GetCurrentSqlClient().ServerDevOpsAuditSettings;

            return serverDevOpsAuditPolicies.Get(resourceGroupName, serverName, "default");
        }

        public bool SetDevOpsAuditingPolicy(string resourceGroupName, string serverName,
            ServerDevOpsAuditingSettings policy)
        {
            return SetAuditingPolicyInternal(() =>
            {
                SqlManagementClient client = GetCurrentSqlClient();
                IServerDevOpsAuditSettingsOperations serverDevOpsAuditSettings = client.ServerDevOpsAuditSettings;

                AzureOperationResponse<ServerDevOpsAuditingSettings> response =
                    serverDevOpsAuditSettings.BeginCreateOrUpdateWithHttpMessagesAsync(
                        resourceGroupName, serverName, "default", policy).Result;
                return client.GetLongRunningOperationResultAsync(response, null, CancellationToken.None).Result.Response.IsSuccessStatusCode;
            });
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        public IList<DiagnosticSettingsResource> GetDiagnosticsEnablingAuditCategory(
            out string nextDiagnosticSettingsName,
<<<<<<< HEAD
=======
            string categoryName, string settingsNamePrefix,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            string resourceGroupName, string serverName, string databaseName = "master")
        {
            string resourceUri = GetResourceUri(resourceGroupName, serverName, databaseName);
            IList<DiagnosticSettingsResource> settings =
                GetMonitorManagementClient().DiagnosticSettings.ListAsync(resourceUri).Result.Value;
<<<<<<< HEAD
            nextDiagnosticSettingsName = GetNextDiagnosticSettingsName(settings);
            return settings?.Where(s => IsAuditCategoryEnabled(s))?.OrderBy(s => s.Name)?.ToList();
=======
            nextDiagnosticSettingsName = GetNextDiagnosticSettingsName(settings, settingsNamePrefix);
            return settings?.Where(s => IsAuditCategoryEnabled(s, categoryName))?.OrderBy(s => s.Name)?.ToList();
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        public bool RemoveDiagnosticSettings(string settingsName, string resourceGroupName,
            string serverName, string databaseName = "master")
        {
            string resourceUri = GetResourceUri(resourceGroupName, serverName, databaseName);
            return GetMonitorManagementClient().DiagnosticSettings.DeleteWithHttpMessagesAsync(
                resourceUri, settingsName).Result.Response.IsSuccessStatusCode;
        }

        public DiagnosticSettingsResource CreateDiagnosticSettings(
<<<<<<< HEAD
            string settingsName, string eventHubName, string eventHubAuthorizationRuleId, string workspaceId,
=======
            string categoryName, string settingsName, 
            string eventHubName, string eventHubAuthorizationRuleId, string workspaceId,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
                                    string.Equals(category.Name, DefinitionsCommon.SQLSecurityAuditCategory),
=======
                                    string.Equals(category.Name, categoryName),
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
            if (!settings.Logs.Any(l => string.Equals(l.Category, DefinitionsCommon.SQLSecurityAuditCategory)))
            {
                settings.Logs.Add(new LogSettings(true, DefinitionsCommon.SQLSecurityAuditCategory));
=======
            if (!settings.Logs.Any(l => string.Equals(l.Category, categoryName)))
            {
                settings.Logs.Add(new LogSettings(true, categoryName));
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
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
=======
        public Guid? AssignServerIdentityIfNotAssigned(string resourceGroupName, string serverName)
        {
            var server = GetCurrentSqlClient().Servers.Get(resourceGroupName, serverName);
            if (server.Identity == null ||
                server.Identity.Type != ResourceIdentityType.SystemAssigned.ToString())
            {
                server.Identity = ResourceIdentityHelper.GetIdentityObjectFromType(true);
                server = GetCurrentSqlClient().Servers.CreateOrUpdate(resourceGroupName, serverName, server);
            }

            return server.Identity.PrincipalId;
        }

        private static string GetNextDiagnosticSettingsName(IList<DiagnosticSettingsResource> settings, 
            string settingsNamePrefix)
        {
            int nextIndex = (settings?.Where(
                s => s.Name.StartsWith(settingsNamePrefix)).Select(
                s => s.Name).Select(
                name => name.Replace(settingsNamePrefix, string.Empty)).Select(
                number => Int32.TryParse(number, out Int32 index) ? index : 0).DefaultIfEmpty().Max() ?? 0) + 1;

            return $"{settingsNamePrefix}{nextIndex}";
        }

        internal static bool IsAuditCategoryEnabled(DiagnosticSettingsResource settings, string categoryName)
        {
            return settings?.Logs?.FirstOrDefault(
                l => l.Enabled &&
                string.Equals(l.Category, categoryName)) != null;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
=======

        private bool SetAuditingPolicyInternal(Func<bool> setAuditingPolicy)
        {
            SqlManagementClient client = GetCurrentSqlClient();

            const int SecondsToSleepBetweenTries = 5;
            int numberOfTries = 3;
            bool isARetry = false;
            do
            {
                if (isARetry)
                {
                    Thread.Sleep(SecondsToSleepBetweenTries);
                }

                try
                {
                    return setAuditingPolicy();
                }
                catch (Exception e)
                {
                    if (!(e.InnerException is CloudException cloudException) ||
                        cloudException.Body.Code != "BlobAuditingInsufficientStorageAccountPermissions")
                    {
                        throw;
                    }
                }

                numberOfTries--;
                isARetry = true;
            } while (numberOfTries > 0);

            return false;
        }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
