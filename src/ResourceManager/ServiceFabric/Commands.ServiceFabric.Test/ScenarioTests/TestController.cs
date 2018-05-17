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
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Graph.RBAC.Version1_6;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.ServiceFabric;
using LegacyTest = Microsoft.Azure.Test;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestUtilities = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Network;

namespace Microsoft.Azure.Commands.ServiceFabric.Test.ScenarioTests
{
    public class TestController
    {
        private LegacyTest.CSMTestEnvironmentFactory csmTestFactory;
        private ServceFabricSetupHelper helper;

        public ResourceManagementClient ResourcesResourceManagementClient { get; private set; }
        public Azure.Management.ResourceManager.ResourceManagementClient ResourceManagerResourceManagementClient
        {
            get;
            private set;
        }

        public Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient NewResourceManagementClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public ServiceFabricManagementClient ServiceFabricClient { get; private set; }

        public GraphRbacManagementClient GraphRbacManagementClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }

        public KeyVaultManagementClient KeyVaultManagementClient { get; private set; }

        public StorageManagementClient StorageManagementClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public string UserDomain { get; private set; }

        public static TestController NewInstance
        {
            get
            {
                return new TestController();
            }
        }

        public TestController()
        {
            helper = new ServceFabricSetupHelper();
        }

        public void RunPsTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClassType,
                mockName);
        }

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<LegacyTest.CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            d.Add("Microsoft.KeyVault", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new LegacyTest.CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                SetupManagementClients(context);

                helper.SetupEnvironment();

              
                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();

                helper.SetupModules(AzureModule.AzureResourceManager,
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    "AzureRM.Resources.ps1",
                    "AzureRM.ServiceFabric.psd1");

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            helper.RunPowerShellTest(psScripts);
                        }
                    }
                }
                finally
                {
                    if (cleanup != null)
                    {
                        cleanup();
                    }
                }
            }
        }

        private void SetupManagementClients(MockContext context)
        {
            ResourcesResourceManagementClient = GetResourceManagementClient();
            SubscriptionClient = GetSubscriptionClient();
            ServiceFabricClient = GetServiceFabricManagementClient(context);
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                ServiceFabricClient.LongRunningOperationRetryTimeout = 20;
            }

            GalleryClient = GetGalleryClient();
            AuthorizationManagementClient = GetAuthorizationManagementClient();
            GraphRbacManagementClient = GetGraphRbacManagementClient(context);
            ComputeManagementClient = GetComputeManagementClient(context);
            ResourceManagerResourceManagementClient = 
                GetResourceManagerResourceManagementClient(context);
            KeyVaultManagementClient = GetKeyVaultManagementClient(context);
            StorageManagementClient = GetStorageManagementClient(context);
            NetworkManagementClient = GetNetworkManagementClient(context);
            NewResourceManagementClient = GetNewResourceManagementClient(context);

            helper.SetupManagementClients(
                ResourcesResourceManagementClient,
                SubscriptionClient,
                ServiceFabricClient,
                GalleryClient,
                AuthorizationManagementClient,
                GraphRbacManagementClient,
                ComputeManagementClient,
                ResourceManagerResourceManagementClient,
                KeyVaultManagementClient,
                StorageManagementClient,
                NetworkManagementClient,
                NewResourceManagementClient);
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        private SubscriptionClient GetSubscriptionClient()
        {
            return LegacyTest.TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }

        private GalleryClient GetGalleryClient()
        {
            return LegacyTest.TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }

        private ServiceFabricManagementClient GetServiceFabricManagementClient(MockContext context)
        {
            return context.GetServiceClient<ServiceFabricManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private GraphRbacManagementClient GetGraphRbacManagementClient(MockContext context)
        {
            return context.GetGraphServiceClient<GraphRbacManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private ComputeManagementClient GetComputeManagementClient(MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private Azure.Management.ResourceManager.ResourceManagementClient GetResourceManagerResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Azure.Management.ResourceManager.ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private KeyVaultManagementClient GetKeyVaultManagementClient(MockContext context)
        {
            return context.GetServiceClient<KeyVaultManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private StorageManagementClient GetStorageManagementClient(MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private NetworkManagementClient GetNetworkManagementClient(MockContext context)
        {
            return context.GetServiceClient<NetworkManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient GetNewResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
        
    }
}