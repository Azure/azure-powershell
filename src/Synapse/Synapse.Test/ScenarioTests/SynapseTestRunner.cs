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


using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using NewResourceManagementClient = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;
using Microsoft.Azure.Management.Synapse;
using Microsoft.Azure.Synapse;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using NewStorageManagementClient = Microsoft.Azure.Management.Storage.Version2017_10_01.StorageManagementClient;
using Microsoft.Azure.Management.Storage;
using SDKMonitor = Microsoft.Azure.Management.Monitor;
using CommonMonitor = Microsoft.Azure.Management.Monitor.Version2018_09_01;
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.EventHub;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Synapse.Test.ScenarioTests
{
    public class SynapseTestRunner
    {
        internal string ResourceGroupName { get; set; }
        internal const string ResourceGroupLocation = "northeurope";

        protected static string TestResourceGroupName;

        protected static string TestWorkspaceName;

        protected static string TestSparkPoolName;

        protected readonly ITestRunner TestRunner;

        protected SynapseTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithCommonPsScripts(new[]
                {
                    @"Common.ps1",
                    @"../AzureRM.Resources.ps1"
                })
                .WithNewRmModules(helper => new[]
                {
                    helper.RMProfileModule,
                    helper.GetRMModulePath("Az.Synapse.psd1"),
                    helper.GetRMModulePath("Az.Storage.psd1"),
                    helper.RMOperationalInsightsModule,
                    helper.RMEventHubModule,
                    helper.RMMonitorModule
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"},
                        {"Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2017-05-10"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.EventHub", null},
                        {"Microsoft.Insights", null},
                        {"Microsoft.OperationalInsights", null}
                    }
                ).WithManagementClients(
                    GetResourceManagementClient,
                    GetStorageManagementClient,
                    GetNewSynapseManagementClient,
                    GetSynapseManagementClient,
                    GetSynapseSqlV3ManagementClient,
                    GetCommonMonitorManagementClient,
                    GetMonitorManagementClient,
                    GetOperationalInsightsManagementClient,
                    GetEventHubManagementClient,
                    GetSynapseClient
                )
                .Build();
        }

        #region client creation helpers
        protected static NewResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<NewResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static NewStorageManagementClient GetNewSynapseManagementClient(MockContext context)
        {
            return context.GetServiceClient<NewStorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static SynapseManagementClient GetSynapseManagementClient(MockContext context)
        {
            return context.GetServiceClient<SynapseManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static SynapseSqlV3ManagementClient GetSynapseSqlV3ManagementClient(MockContext context)
        {
            return context.GetServiceClient<SynapseSqlV3ManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static CommonMonitor.MonitorManagementClient GetCommonMonitorManagementClient(MockContext context)
        {
            return context.GetServiceClient<CommonMonitor.MonitorManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static SDKMonitor.MonitorManagementClient GetMonitorManagementClient(MockContext context)
        {
            return context.GetServiceClient<SDKMonitor.MonitorManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static OperationalInsightsManagementClient GetOperationalInsightsManagementClient(MockContext context)
        {
            return context.GetServiceClient<OperationalInsightsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static EventHubManagementClient GetEventHubManagementClient(MockContext context)
        {
            return context.GetServiceClient<EventHubManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected static SynapseClient GetSynapseClient(MockContext context)
        {
            string environmentConnectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION");
            string accessToken = "fakefakefake";

            // When recording, we should have a connection string passed into the code from the environment
            if (!string.IsNullOrEmpty(environmentConnectionString))
            {
                // Gather test client credential information from the environment
                var connectionInfo = new ConnectionString(Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION"));
                string servicePrincipal = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalKey);
                string servicePrincipalSecret = connectionInfo.GetValue<string>(ConnectionStringKeys.ServicePrincipalSecretKey);
                string aadTenant = connectionInfo.GetValue<string>(ConnectionStringKeys.AADTenantKey);

                // Create credentials
                var clientCredentials = new ClientCredential(servicePrincipal, servicePrincipalSecret);
                var authContext = new AuthenticationContext($"https://login.windows.net/{aadTenant}", TokenCache.DefaultShared);
                accessToken = authContext.AcquireTokenAsync("https://dev.azuresynapse.net", clientCredentials).Result.AccessToken;
            }

            return new SynapseClient(new TokenCredentials(accessToken), HttpMockServer.CreateInstance());
        }
        #endregion
    }
}
