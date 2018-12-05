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
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Microsoft.Azure.Commands.StorageSync.Test.ScenarioTests
{
    public class TestController : IDisposable
    {
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";
        private const string SubscriptionIdKey = "SubscriptionId";

        private readonly EnvironmentSetupHelper _helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient InternalResourceManagementClient { get; private set; }

        public GraphRbacManagementClient GraphRbacManagementClient { get; private set; }
        //public ActiveDirectoryClient ActiveDirectoryClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public StorageSyncManagementClient StorageSyncClient { get; private set; }

        public Internal.Subscriptions.SubscriptionClient SubscriptionClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public string UserDomain { get; private set; }

        public static TestController NewInstance => new TestController();

        public TestEnvironment TestEnvironment { get; set; }

        public TestController()
        {
            _helper = new EnvironmentSetupHelper();
            TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            _helper.TracingInterceptor = logger;

            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            RunPsTestWorkflow(
                () => scripts,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            var d = new Dictionary<string, string>
            {
                {"Microsoft.Resources", null},
                {"Microsoft.Features", null},
                {"Microsoft.Authorization", null},
                {"Microsoft.Storage", null},
                {"Microsoft.StorageSync", null}
            };

            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
            };
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
#if !NETSTANDARD
                    _helper.RMStorageDataPlaneModule,
#endif
                    _helper.RMStorageModule,
                    _helper.GetRMModulePath("Az.StorageSync.psd1"),
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "AzureRM.Resources.ps1");

                try
                {
                    if (scriptBuilder == null) return;

                    var psScripts = scriptBuilder();
                    if (psScripts != null)
                    {
                        _helper.RunPowerShellTest(psScripts);
                    }
                }
                finally
                {
                    cleanup?.Invoke();
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            InternalResourceManagementClient = GetInternalResourceManagementClient(context);
            SubscriptionClient = GetSubscriptionClient(context);
            AuthorizationManagementClient = GetAuthorizationManagementClient(context);
            StorageClient = GetStorageManagementClient(context);
            StorageSyncClient = GetStorageSyncManagementClient(context);
            GraphRbacManagementClient = GetGraphRbacManagementClient(context);

            _helper.SetupManagementClients(
                ResourceManagementClient,
                InternalResourceManagementClient,
                SubscriptionClient,
                AuthorizationManagementClient,
                StorageClient,
                StorageSyncClient,
                GraphRbacManagementClient
                );
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context) => context.GetServiceClient<ResourceManagementClient>(TestEnvironment)/*(TestEnvironmentFactory.GetTestEnvironment())*/;

        private Internal.Subscriptions.SubscriptionClient GetSubscriptionClient(MockContext context)
        {
            return context.GetServiceClient<Internal.Subscriptions.SubscriptionClient>(TestEnvironment)/*(TestEnvironmentFactory.GetTestEnvironment())*/;
        }

        private GraphRbacManagementClient GetGraphRbacManagementClient(MockContext context)
        {
            var environment = TestEnvironment;// TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = environment.Tenant;
                UserDomain = String.IsNullOrEmpty(environment.UserName) ? String.Empty : environment.UserName.Split(new[] { "@" }, StringSplitOptions.RemoveEmptyEntries).Last();

                HttpMockServer.Variables[TenantIdKey] = tenantId;
                HttpMockServer.Variables[DomainKey] = UserDomain;
            }
            else if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                if (HttpMockServer.Variables.ContainsKey(TenantIdKey))
                {
                    tenantId = HttpMockServer.Variables[TenantIdKey];
                }
                if (HttpMockServer.Variables.ContainsKey(DomainKey))
                {
                    UserDomain = HttpMockServer.Variables[DomainKey];
                }
                if (HttpMockServer.Variables.ContainsKey(SubscriptionIdKey))
                {
                    AzureRmProfileProvider.Instance.Profile.DefaultContext.Subscription.Id = HttpMockServer.Variables[SubscriptionIdKey];
                }
            }

            var client = context.GetGraphServiceClient<GraphRbacManagementClient>(environment);
            client.TenantID = tenantId;

            if (AzureRmProfileProvider.Instance != null &&
                AzureRmProfileProvider.Instance.Profile != null &&
                AzureRmProfileProvider.Instance.Profile.DefaultContext != null &&
                AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant != null)
            {
                AzureRmProfileProvider.Instance.Profile.DefaultContext.Tenant.Id = client.TenantID;
            }
            return client;
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>(TestEnvironment)/*(TestEnvironmentFactory.GetTestEnvironment())*/;
        }

        private StorageManagementClient GetStorageManagementClient(MockContext context) => context.GetServiceClient<StorageManagementClient>(TestEnvironment)/*(TestEnvironmentFactory.GetTestEnvironment())*/;

        private StorageSyncManagementClient GetStorageSyncManagementClient(MockContext context) => context.GetServiceClient<StorageSyncManagementClient>(TestEnvironment)/*(TestEnvironmentFactory.GetTestEnvironment())*/;

        private Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient GetInternalResourceManagementClient(MockContext context) => context.GetServiceClient<Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient>();

        public void Dispose()
        {
            ResourceManagementClient?.Dispose();
            InternalResourceManagementClient?.Dispose();
            SubscriptionClient?.Dispose();
            AuthorizationManagementClient?.Dispose();
            StorageSyncClient?.Dispose();
        }
    }
}