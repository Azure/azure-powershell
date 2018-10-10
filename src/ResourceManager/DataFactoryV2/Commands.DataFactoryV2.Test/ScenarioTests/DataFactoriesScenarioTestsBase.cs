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

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Resources.Models.Authorization;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure.Authentication;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.Azure.Commands.DataFactoryV2.Test
{
    public abstract class DataFactoriesScenarioTestsBase : RMTestBase
    {
        private const string TenantIdKey = "TenantId";

        private EnvironmentSetupHelper helper;

        protected DataFactoriesScenarioTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            var resourceManagementClient = GetResourceManagementClient(context);
            var dataPipelineManagementClient = GetDataPipelineManagementClient(context);
            var subscriptionsClient = GetSubscriptionClient(context);
            var authorizationManagementClient = GetAuthorizationManagementClient(context);
            var graphClient = GetGraphClient(context);

            helper.SetupManagementClients(dataPipelineManagementClient,
                resourceManagementClient,
                subscriptionsClient,
                graphClient,
                authorizationManagementClient);
        }

        protected void RunPowerShellTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            helper.TracingInterceptor = logger;
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2016-07-01");
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (MockContext context = MockContext.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2)))
            {
                SetupManagementClients(context);

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                UpdateDefaultContextForPlayback();

                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath("AzureRM.DataFactoryV2.psd1"),
                    "AzureRM.Resources.ps1");

                helper.RunPowerShellTest(scripts);
            }
        }

        protected DataFactoryManagementClient GetDataPipelineManagementClient(MockContext context)
        {
            return context.GetServiceClient<DataFactoryManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected Internal.Subscriptions.SubscriptionClient GetSubscriptionClient(MockContext context)
        {
            return context.GetServiceClient<Internal.Subscriptions.SubscriptionClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private GraphRbacManagementClient GetGraphClient(MockContext context)
        {
            var environment = TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = environment.Tenant;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                HttpMockServer.Variables[TenantIdKey] = tenantId;

                string password;
                string spnClientId;
                string spnSecret;
                var connStr = environment.ConnectionString;
                connStr.KeyValuePairs.TryGetValue(ConnectionStringKeys.PasswordKey, out password);
                connStr.KeyValuePairs.TryGetValue(ConnectionStringKeys.ServicePrincipalKey, out spnClientId);
                connStr.KeyValuePairs.TryGetValue(ConnectionStringKeys.ServicePrincipalSecretKey, out spnSecret);

                var graphAadServiceSettings = new ActiveDirectoryServiceSettings()
                {
                    AuthenticationEndpoint = new Uri(environment.Endpoints.AADAuthUri + environment.Tenant),
                    TokenAudience = environment.Endpoints.GraphTokenAudienceUri
                };

                var accessToken = ApplicationTokenProvider
                    .LoginSilentAsync(environment.Tenant, spnClientId, spnSecret, graphAadServiceSettings)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
                environment.TokenInfo[TokenAudience.Graph] = accessToken as TokenCredentials;
            }

            var client = context.GetGraphServiceClient<GraphRbacManagementClient>(environment);
            client.TenantID = tenantId;

            return client;
        }

        private void UpdateDefaultContextForPlayback()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Playback
                && HttpMockServer.Variables.ContainsKey(TenantIdKey))
            {
                if (AzureRmProfileProvider.Instance?.Profile?.DefaultContext?.Tenant != null)
                {
                    AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id = HttpMockServer.Variables[TenantIdKey];
                }
            }
        }
    }
}

