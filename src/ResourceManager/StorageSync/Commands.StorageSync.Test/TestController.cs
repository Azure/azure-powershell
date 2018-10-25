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
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Internal.Subscriptions;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.ResourceManager;
//using Microsoft.Azure.Management.ResourceManager;
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
using LegacyTest = Microsoft.Azure.Test;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestUtilities = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities;

namespace Microsoft.Azure.Commands.StorageSync.Test.ScenarioTests
{
    public class TestController : IDisposable
    {
        private LegacyTest.CSMTestEnvironmentFactory csmTestFactory;

        private EnvironmentSetupHelper environmentSetupHelper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient InternalResourceManagementClient { get; private set; }

        public GraphRbacManagementClient GraphRbacManagementClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public StorageSyncManagementClient StorageSyncClient { get; private set; }

        public Internal.Subscriptions.SubscriptionClient SubscriptionClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public string UserDomain { get; private set; }

        public static TestController NewInstance => new TestController();

        public TestController()
        {
            environmentSetupHelper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            RunPsTestWorkflow(
                () => scripts,
                initializeEnvironment: null,// no custom initializer
                cleanupAction: null,// no custom cleanup 
                callingClassType: TestUtilities.GetCallingClass(2),
                mockName: TestUtilities.GetCurrentMethodName(2));

        }

        public void RunPsTest(XunitTracingInterceptor logger, params string[] scripts)
        {
            StackFrame stackFrame = new StackTrace().GetFrame(1);

            environmentSetupHelper.TracingInterceptor = logger;

            RunPsTestWorkflow(
                scriptBuilder: () => scripts,
               // no custom cleanup
               initializeEnvironment: null,// no custom initializer
                cleanupAction: null,// no custom cleanup 
                callingClassType: stackFrame.GetMethod().ReflectedType?.ToString(),
                mockName: stackFrame.GetMethod().Name);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<LegacyTest.CSMTestEnvironmentFactory> initializeEnvironment,
            Action cleanupAction,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> providers = new Dictionary<string, string>
            {
                { "Microsoft.Resources", null },
                { "Microsoft.Features", null },
                { "Microsoft.Authorization", null },
                { "Microsoft.Storage", null }
            };

            var providersToIgnore = new Dictionary<string, string>
            {
                { "Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01" }
            };

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {

                this.csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();

                initializeEnvironment?.Invoke(csmTestFactory);

                InitializeComponent(context);

                environmentSetupHelper.SetupEnvironment(AzureModule.AzureResourceManager);
                //environmentSetupHelper.SetupAzureEnvironmentFromEnvironmentVariables(AzureModule.AzureResourceManager);

                string callingClassName = callingClassType.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries).Last();

                environmentSetupHelper.SetupModules(AzureModule.AzureResourceManager,
                    environmentSetupHelper.RMProfileModule,
                    environmentSetupHelper.RMStorageModule,
                    environmentSetupHelper.GetRMModulePath("AzureRm.StorageSync.psd1"),
                    "ScenarioTests\\Common.ps1",
                    $"ScenarioTests\\{callingClassName}.ps1",
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1");

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            environmentSetupHelper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    cleanupAction?.Invoke();
                }
            }
        }

        private void InitializeComponent(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            InternalResourceManagementClient = GetInternalResourceManagementClient(context);
            SubscriptionClient = GetSubscriptionClient(context);
            GalleryClient = GetGalleryClient();
            AuthorizationManagementClient = GetAuthorizationManagementClient(context);
            StorageClient = GetStorageManagementClient(context);
            StorageSyncClient = GetStorageSyncManagementClient(context);
            GraphRbacManagementClient = GetGraphRbacManagementClient(context);

            environmentSetupHelper.SetupManagementClients(
                ResourceManagementClient,
                InternalResourceManagementClient,
                SubscriptionClient,
                GalleryClient,
                AuthorizationManagementClient,
                StorageClient,
                StorageSyncClient, 
                GraphRbacManagementClient);
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context) =>context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

        private Internal.Subscriptions.SubscriptionClient GetSubscriptionClient(MockContext context)
        {
            return context.GetServiceClient<Internal.Subscriptions.SubscriptionClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private GraphRbacManagementClient GetGraphRbacManagementClient(MockContext context)
        {
            return context.GetGraphServiceClient<GraphRbacManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }


        private AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
        private GalleryClient GetGalleryClient()
        {
            return LegacyTest.TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }
        private StorageManagementClient GetStorageManagementClient(MockContext context) => context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

        private StorageSyncManagementClient GetStorageSyncManagementClient(MockContext context) => context.GetServiceClient<StorageSyncManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

        private Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient GetInternalResourceManagementClient(MockContext context) => context.GetServiceClient<Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient>();

        public void Dispose()
        {
            ResourceManagementClient?.Dispose();
            InternalResourceManagementClient?.Dispose();
            SubscriptionClient?.Dispose();
            GalleryClient?.Dispose();
            AuthorizationManagementClient?.Dispose();
            StorageSyncClient?.Dispose();
        }
    }
  
}
