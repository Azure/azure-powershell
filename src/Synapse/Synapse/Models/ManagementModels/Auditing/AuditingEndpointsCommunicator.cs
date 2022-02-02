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
using Microsoft.Azure.Management.Monitor.Version2018_09_01;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using Microsoft.Azure.Management.Synapse;
using Microsoft.Azure.Management.Synapse.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ErrorResponseException = Microsoft.Azure.Management.Monitor.Version2018_09_01.Models.ErrorResponseException;

namespace Microsoft.Azure.Commands.Synapse.Models.Auditing
{
    /// <summary>
    /// This class is responsible for all the REST communication.
    /// </summary>
    public class AuditingEndpointsCommunicator
    {
        private static SynapseManagementClient SynapseManagementClient { get; set; }

        private static IMonitorManagementClient MonitorClient { get; set; }

        private static IAzureSubscription Subscription { get; set; }

        public IAzureContext Context { get; set; }

        public AuditingEndpointsCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SynapseManagementClient = null;
                MonitorClient = null;
            }
        }

        public bool SetAuditingPolicy(string resourceGroupName, string workspaceName,
            string sqlPoolName, SqlPoolBlobAuditingPolicy policy)
        {
            return SetAuditingPolicyInternal(() =>
            {
                ISqlPoolBlobAuditingPoliciesOperations operations = GetCurrentSynapseManagementClient().SqlPoolBlobAuditingPolicies;
                return operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName,
                    workspaceName, sqlPoolName, policy).Result.Response.IsSuccessStatusCode;
            });
        }

        public bool SetAuditingPolicy(string resourceGroupName, string workspaceName,
            ServerBlobAuditingPolicy policy)
        {
            return SetAuditingPolicyInternal(() =>
            {
                SynapseManagementClient client = GetCurrentSynapseManagementClient();
                AzureOperationResponse<ServerBlobAuditingPolicy> response =
                    client.WorkspaceManagedSqlServerBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                        resourceGroupName, workspaceName, policy).Result;
                return client.GetLongRunningOperationResultAsync(response, null, CancellationToken.None).Result.Response.IsSuccessStatusCode;
            });
        }

        public ExtendedSqlPoolBlobAuditingPolicy GetAuditingPolicy(string resourceGroupName,
            string workspaceName, string sqlPoolName)
        {
            return GetCurrentSynapseManagementClient().ExtendedSqlPoolBlobAuditingPolicies.Get(
                resourceGroupName, workspaceName, sqlPoolName);
        }

        public ExtendedServerBlobAuditingPolicy GetAuditingPolicy(string resourceGroupName,
            string workspaceName)
        {
            return GetCurrentSynapseManagementClient().WorkspaceManagedSqlServerExtendedBlobAuditingPolicies.Get(
                resourceGroupName, workspaceName);
        }

        public bool SetExtendedAuditingPolicy(string resourceGroupName, string workspaceName,
            string sqlPoolName, ExtendedSqlPoolBlobAuditingPolicy policy)
        {
            return SetAuditingPolicyInternal(() =>
            {
                IExtendedSqlPoolBlobAuditingPoliciesOperations operations = GetCurrentSynapseManagementClient().ExtendedSqlPoolBlobAuditingPolicies;
                return operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName,
                    workspaceName, sqlPoolName, policy).Result.Response.IsSuccessStatusCode;
            });
        }

        public bool SetExtendedAuditingPolicy(string resourceGroupName, string workspaceName,
            ExtendedServerBlobAuditingPolicy policy)
        {
            return SetAuditingPolicyInternal(() =>
            {
                SynapseManagementClient client = GetCurrentSynapseManagementClient();
                AzureOperationResponse<ExtendedServerBlobAuditingPolicy> response =
                    client.WorkspaceManagedSqlServerExtendedBlobAuditingPolicies.BeginCreateOrUpdateWithHttpMessagesAsync(
                    resourceGroupName, workspaceName, policy).Result;
                return client.GetLongRunningOperationResultAsync(response, null,
                    CancellationToken.None).Result.Response.IsSuccessStatusCode;
            });
        }

        public IList<DiagnosticSettingsResource> GetDiagnosticsEnablingAuditCategory(
            out string nextDiagnosticSettingsName,
            string categoryName, string settingsNamePrefix,
            string resourceGroupName, string workspaceName, string sqlPoolName = null)
        {
            string resourceUri = GetResourceUri(resourceGroupName, workspaceName, sqlPoolName);
            IList<DiagnosticSettingsResource> settings =
                GetMonitorManagementClient().DiagnosticSettings.ListAsync(resourceUri).Result.Value;
            nextDiagnosticSettingsName = GetNextDiagnosticSettingsName(settings, settingsNamePrefix);
            return settings?.Where(s => IsAuditCategoryEnabled(s, categoryName))?.OrderBy(s => s.Name)?.ToList();
        }

        public bool RemoveDiagnosticSettings(string settingsName, string resourceGroupName,
            string workspaceName, string sqlPoolName = null)
        {
            string resourceUri = GetResourceUri(resourceGroupName, workspaceName, sqlPoolName);
            return GetMonitorManagementClient().DiagnosticSettings.DeleteWithHttpMessagesAsync(
                resourceUri, settingsName).Result.Response.IsSuccessStatusCode;
        }

        public DiagnosticSettingsResource CreateDiagnosticSettings(
            string categoryName, string settingsName, 
            string eventHubName, string eventHubAuthorizationRuleId, string workspaceId,
            string resourceGroupName, string workspaceName, string sqlPoolName = null)
        {
            string resoureUri = GetResourceUri(resourceGroupName, workspaceName, sqlPoolName);
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
                                    string.Equals(category.Name, categoryName),
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

            if (!settings.Logs.Any(l => string.Equals(l.Category, categoryName)))
            {
                settings.Logs.Add(new LogSettings(true, categoryName));
            }

            return client.DiagnosticSettings.CreateOrUpdateAsync(
                resoureUri, settings, settingsName).Result;
        }

        public DiagnosticSettingsResource UpdateDiagnosticSettings(DiagnosticSettingsResource settings,
            string resourceGroupName, string workspaceName, string sqlPoolName = null)
        {
            return GetMonitorManagementClient().DiagnosticSettings.CreateOrUpdateAsync(
                GetResourceUri(resourceGroupName, workspaceName, sqlPoolName), settings, settings.Name).Result;
        }

        public Guid? AssignWorkspaceIdentityIfNotAssigned(string resourceGroupName, string workspaceName)
        {
            var workspace = GetCurrentSynapseManagementClient().Workspaces.Get(resourceGroupName, workspaceName);
            if (workspace.Identity == null ||
                workspace.Identity.Type != ResourceIdentityType.SystemAssigned)
            {
                workspace.Identity = new ManagedIdentity
                {
                    Type = ResourceIdentityType.SystemAssigned
                };
                workspace = GetCurrentSynapseManagementClient().Workspaces.CreateOrUpdate(resourceGroupName, workspaceName, workspace);
            }

            try
            {
                return new Guid(workspace.Identity.PrincipalId);
            }
            catch (Exception)
            {
                return null;
            }
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
        }

        private static string GetResourceUri(string resourceGroupName, string workspaceName, string sqlPoolName)
        {
            string resourceUri = $"/subscriptions/{Subscription.Id}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}";
            if (sqlPoolName == null)
            {
                return resourceUri;
            }
            else
            {
                return resourceUri + $"/sqlPools/{sqlPoolName}";
            }
        }

        private SynapseManagementClient GetCurrentSynapseManagementClient()
        {
            // Get the SQL management client for the current subscription
            if (SynapseManagementClient == null)
            {
                SynapseManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<SynapseManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }

            return SynapseManagementClient;
        }

        private IMonitorManagementClient GetMonitorManagementClient()
        {
            if (MonitorClient == null)
            {
                MonitorClient = AzureSession.Instance.ClientFactory.CreateArmClient<MonitorManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }

            return MonitorClient;
        }

        private bool SetAuditingPolicyInternal(Func<bool> setAuditingPolicy)
        {
            SynapseManagementClient client = GetCurrentSynapseManagementClient();

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
    }
}
