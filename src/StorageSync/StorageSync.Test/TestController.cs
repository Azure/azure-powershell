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
using Microsoft.Azure.Commands.StorageSync.Common;
using Microsoft.Azure.Commands.StorageSync.Interfaces;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Management.Authorization.Version2015_07_01;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.StorageSync;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using StorageSync.Test.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ScenarioTests
{
    /// <summary>
    /// Class TestController.
    /// Implements the <see cref="Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase" />
    /// </summary>
    /// <seealso cref="Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase" />
    public class TestController : RMTestBase
    {
        /// <summary>
        /// The tenant identifier key
        /// </summary>
        private const string TenantIdKey = StorageSyncConstants.TenantId;
        /// <summary>
        /// The domain key
        /// </summary>
        private const string DomainKey = "Domain";
        /// <summary>
        /// The subscription identifier key
        /// </summary>
        private const string SubscriptionIdKey = "SubscriptionId";

        /// <summary>
        /// Gets the user domain.
        /// </summary>
        /// <value>The user domain.</value>
        public string UserDomain { get; private set; }

        /// <summary>
        /// The helper
        /// </summary>
        private readonly EnvironmentSetupHelper _helper;

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <value>The new instance.</value>
        public static TestController NewInstance => new TestController();

        /// <summary>
        /// Initializes a new instance of the <see cref="TestController"/> class.
        /// </summary>
        public TestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        /// <summary>
        /// Runs the ps test.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="scripts">The scripts.</param>
        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            var sf = new StackTrace().GetFrame(1);
            var callingClassType = sf.GetMethod().ReflectedType?.ToString();
            var mockName = sf.GetMethod().Name;

            _helper.TracingInterceptor = logger;

            RunPsTestWorkflow(
                () => scripts,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        /// <summary>
        /// Runs the ps test workflow.
        /// </summary>
        /// <param name="scriptBuilder">The script builder.</param>
        /// <param name="cleanup">The cleanup.</param>
        /// <param name="callingClassType">Type of the calling class.</param>
        /// <param name="testName">Name of the test.</param>
        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action cleanup,
            string callingClassType,
            string testName)
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

            using (var context = MockContext.Start(callingClassType, testName))
            {
                RegisterComponents(context,testName);
                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    _helper.RMStorageModule,
                    _helper.GetRMModulePath("AzureRM.StorageSync.psd1"),
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

        /// <summary>
        /// Registers the components.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="testName">Name of the test.</param>
        private void RegisterComponents(MockContext context, string testName)
        {
            AzureSession.Instance.RegisterComponent<IStorageSyncResourceManager>(StorageSyncConstants.StorageSyncResourceManager, () => new MockStorageSyncResourceManager(testName), overwrite: true);
        }

        /// <summary>
        /// Setups the management clients.
        /// </summary>
        /// <param name="context">The context.</param>
        private void SetupManagementClients(MockContext context)
        {
            var rmClient = context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            var subClient = context.GetServiceClient<SubscriptionClient>(TestEnvironmentFactory.GetTestEnvironment());
            var storageSyncClient = context.GetServiceClient<StorageSyncManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            var storageClient = context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            //var rbacClient = context.GetServiceClient<GraphRbacManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            GraphRbacManagementClient rbacClient = GetGraphClient(context);
            var authClient = context.GetServiceClient<AuthorizationManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            _helper.SetupManagementClients(rmClient, subClient, storageSyncClient, storageClient, rbacClient, authClient);
        }

        /// <summary>
        /// Gets the graph client.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>GraphRbacManagementClient.</returns>
        private GraphRbacManagementClient GetGraphClient(MockContext context)
        {
            var environment = TestEnvironmentFactory.GetTestEnvironment();
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
    }
}