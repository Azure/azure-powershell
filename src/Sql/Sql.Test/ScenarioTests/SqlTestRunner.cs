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

using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Sql;
using CommonStorage = Microsoft.Azure.Management.Storage.Version2017_10_01;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit.Abstractions;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Management.OperationalInsights;
using SDKMonitor = Microsoft.Azure.Management.Monitor;
using CommonMonitor = Microsoft.Azure.Management.Monitor.Version2018_09_01;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.TestFx;

namespace Microsoft.Azure.Commands.ScenarioTest.SqlTests
{
    public class SqlTestRunner
    {
        protected string[] resourceTypesToIgnoreApiVersion = new string[] {
            "Microsoft.Sql/managedInstances",
            "Microsoft.Sql/managedInstances/databases",
            "Microsoft.Sql/managedInstances/managedDatabases",
            "Microsoft.Sql/servers",
            "Microsoft.Sql/servers/databases",
            "Microsoft.Sql/servers/elasticPools"
        };
        private const string TenantIdKey = "TenantId";

        protected readonly ITestRunner TestRunner;

        protected SqlTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Storage.ps1",
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Sql.psd1"),
                    helper.RMNetworkModule,
                    helper.RMOperationalInsightsModule,
                    helper.RMEventHubModule,
                    helper.RMMonitorModule,
                    helper.RMKeyVaultModule
                })
                .WithRecordMatcher(
                    (bool ignoreResourcesClient, Dictionary<string, string> providers, Dictionary<string, string> userAgents) =>
                        new PermissiveRecordMatcherWithResourceApiExclusion(ignoreResourcesClient, providers, userAgents, resourceTypesToIgnoreApiVersion)
                )
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Graph.RBAC.Version1_6.GraphRbacManagementClient", "1.42-previewInternal"},
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Network", null},
                        {"Microsoft.KeyVault", null},
                        {"Microsoft.EventHub", null},
                        {"Microsoft.Insights", null},
                        {"Microsoft.OperationalInsights", null}
                    }
                ).WithManagementClients(
                    GetSqlClient,
                    GetMonitorManagementClient,
                    GetCommonMonitorManagementClient,
                    GetEventHubManagementClient,
                    GetOperationalInsightsManagementClient,
                    GetResourcesClient,
                    GetGraphClient,
                    GetGraphClientVersion1_6,
                    GetKeyVaultClient,
                    GetNetworkClient,
                    GetStorageManagementClient
                )
                .Build();
        }

        protected SqlManagementClient GetSqlClient(MockContext context)
        {
            return context.GetServiceClient<SqlManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected SDKMonitor.IMonitorManagementClient GetMonitorManagementClient(MockContext context)
        {
            return context.GetServiceClient<SDKMonitor.MonitorManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected CommonMonitor.IMonitorManagementClient GetCommonMonitorManagementClient(MockContext context)
        {
            return context.GetServiceClient<CommonMonitor.MonitorManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected IEventHubManagementClient GetEventHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<EventHubManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected IOperationalInsightsManagementClient GetOperationalInsightsManagementClient(MockContext context)
        {
            return context.GetServiceClient<OperationalInsightsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected ResourceManagementClient GetResourcesClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected GraphRbacManagementClient GetGraphClient(MockContext context)
        {
            GraphRbacManagementClient graphClient = context.GetServiceClient<GraphRbacManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            graphClient.BaseUri = TestEnvironmentFactory.GetTestEnvironment().Endpoints.GraphUri;
            graphClient.TenantID = TestEnvironmentFactory.GetTestEnvironment().Tenant;
            return graphClient;
        }

        protected Microsoft.Azure.Graph.RBAC.Version1_6.GraphRbacManagementClient GetGraphClientVersion1_6(MockContext context)
        {
            Microsoft.Azure.Graph.RBAC.Version1_6.GraphRbacManagementClient graphClient = context.GetServiceClient<Microsoft.Azure.Graph.RBAC.Version1_6.GraphRbacManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            graphClient.BaseUri = TestEnvironmentFactory.GetTestEnvironment().Endpoints.GraphUri;
            string tenantId = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = TestEnvironmentFactory.GetTestEnvironment().Tenant;
                HttpMockServer.Variables[TenantIdKey] = tenantId;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                if (HttpMockServer.Variables.ContainsKey(TenantIdKey))
                {
                    tenantId = HttpMockServer.Variables[TenantIdKey];
                }
            }
            graphClient.TenantID = tenantId;
            if (AzureRmProfileProvider.Instance != null &&
                AzureRmProfileProvider.Instance.Profile != null &&
                AzureRmProfileProvider.Instance.Profile.DefaultContext != null &&
                AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant != null)
            {
                AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id = tenantId;
            }
            return graphClient;
        }

        protected KeyVaultManagementClient GetKeyVaultClient(MockContext context)
        {
            return context.GetServiceClient<KeyVaultManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected NetworkManagementClient GetNetworkClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static CommonStorage.StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<CommonStorage.StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
