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
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using ResourceManagementClientInternal = Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public sealed class ComputeTestController : RMTestBase
    {
        bool testViaCsm = true; // Currently set to true, we will get this from Environment variable.

        private CSMTestEnvironmentFactory csmTestFactory;
		    private readonly EnvironmentSetupHelper _helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";

        public GraphRbacManagementClient GraphClient { get; private set; }
        public Azure.Management.ResourceManager.ResourceManagementClient ResourceManagementClient { get; private set; }

        public Subscriptions.SubscriptionClient SubscriptionClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }
        
        public ResourceManagementClientInternal InternalResourceManagementClient { get; private set; }

        public StorageManagementClient StorageClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }

        public Microsoft.Azure.Management.Internal.Network.Version2017_10_01.NetworkManagementClient InternalNetworkManagementClient { get; private set; }

        public string UserDomain { get; private set; }

        public static ComputeTestController NewInstance
        {
            get
            {
                return new ComputeTestController();
            }
        }

        public ComputeTestController()
        {
            _helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(ServiceManagemenet.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            _helper.TracingInterceptor = logger;
            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup
                null,
                callingClassType,
                mockName);
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
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            d.Add("Microsoft.Compute", null);
            d.Add("Microsoft.Network", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.ResourceManager.ResourceManagementClient", "2018-05-01");
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2018-05-01");
            providersToIgnore.Add("Microsoft.Azure.Management.Storage.StorageManagementClient", "2016-01-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            using (RestTestFramework.MockContext context = RestTestFramework.MockContext.Start(callingClassType, mockName))
            {
                this.csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);
                
                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                _helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\ComputeTestCommon.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    _helper.StackRMProfileModule,
                    _helper.StackRMResourceModule,
                    _helper.StackRMStorageDataPlaneModule,
                    _helper.StackRMStorageModule,
                    _helper.GetStackRMModulePath("AzureRM.Compute"),
                    _helper.GetStackRMModulePath("AzureRM.Network"));

                try
                {
                    if (scriptBuilder != null)
                    {
                        var psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            _helper.RunPowerShellTest(psScripts);
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

        private void SetupManagementClients(RestTestFramework.MockContext context)
        {

            ResourceManagementClient = GetResourceManagementClient(context);
            SubscriptionClient = GetSubscriptionClient();
            StorageClient = GetStorageManagementClient(context);
            GalleryClient = GetGalleryClient();
            NetworkManagementClient = this.GetNetworkManagementClientClient(context);
            ComputeManagementClient = GetComputeManagementClient(context);
            AuthorizationManagementClient = GetAuthorizationManagementClient();
            InternalNetworkManagementClient = this.GetNetworkManagementClientInternal(context);
            InternalResourceManagementClient = GetResourceManagementClientInternal(context);

            _helper.SetupManagementClients(
                ResourceManagementClient,
                SubscriptionClient,
                StorageClient,
                GalleryClient,
                NetworkManagementClient,
                ComputeManagementClient,
                AuthorizationManagementClient,
                InternalNetworkManagementClient,
                InternalResourceManagementClient);
        }

        private GraphRbacManagementClient GetGraphClient()
        {
            var environment = this.csmTestFactory.GetTestEnvironment();
            string tenantId = null;

            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                tenantId = environment.AuthorizationContext.TenantId;
                UserDomain = environment.AuthorizationContext.UserDomain;

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
            }

            return TestBase.GetGraphServiceClient<GraphRbacManagementClient>(this.csmTestFactory, tenantId);
        }

        private Microsoft.Azure.Management.Authorization.AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }

        private Azure.Management.ResourceManager.ResourceManagementClient GetResourceManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<Azure.Management.ResourceManager.ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private static ResourceManagementClientInternal GetResourceManagementClientInternal(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClientInternal>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private Subscriptions.SubscriptionClient GetSubscriptionClient()
        {
            return TestBase.GetServiceClient<Subscriptions.SubscriptionClient>(this.csmTestFactory);
        }

        private StorageManagementClient GetStorageManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }

        private NetworkManagementClient GetNetworkManagementClientClient(RestTestFramework.MockContext context)
        {
            return testViaCsm
                ? context.GetServiceClient<NetworkManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment())
                : TestBase.GetServiceClient<NetworkManagementClient>(new RDFETestEnvironmentFactory());
        }

        private Microsoft.Azure.Management.Internal.Network.Version2017_10_01.NetworkManagementClient GetNetworkManagementClientInternal(RestTestFramework.MockContext context)
        {
            return testViaCsm
                ? context.GetServiceClient<Microsoft.Azure.Management.Internal.Network.Version2017_10_01.NetworkManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment())
                : TestBase.GetServiceClient<Microsoft.Azure.Management.Internal.Network.Version2017_10_01.NetworkManagementClient>(new RDFETestEnvironmentFactory());
        }

        private ComputeManagementClient GetComputeManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<ComputeManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
