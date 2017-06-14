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
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public sealed class ComputeTestController : RMTestBase
    {
        bool testViaCsm = true; // Currently set to true, we will get this from Environment varialbe.

        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";

        public GraphRbacManagementClient GraphClient { get; private set; }

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        //public EventsClient EventsClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }


        public StorageManagementClient StorageClient { get; private set; }

        public NetworkManagementClient NetworkManagementClient { get; private set; }

        public ComputeManagementClient ComputeManagementClient { get; private set; }

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
            helper = new EnvironmentSetupHelper();
        }

        public void RunPsTest(ServiceManagemenet.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);

            helper.TracingInterceptor = logger;
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
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
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

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\ComputeTestCommon.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.RMStorageDataPlaneModule,
                    helper.RMStorageModule,
                    helper.GetRMModulePath("AzureRM.Compute.psd1"),
                    helper.GetRMModulePath("AzureRM.Network.psd1"),
                    "AzureRM.Storage.ps1",
                    "AzureRM.Resources.ps1");

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

        private void SetupManagementClients(RestTestFramework.MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient();
            SubscriptionClient = GetSubscriptionClient();
            StorageClient = GetStorageManagementClient(context);
            GalleryClient = GetGalleryClient();
            //var eventsClient = GetEventsClient();
            NetworkManagementClient = this.GetNetworkManagementClientClient(context);
            ComputeManagementClient = GetComputeManagementClient(context);
            AuthorizationManagementClient = GetAuthorizationManagementClient();
            // GraphClient = GetGraphClient();

            helper.SetupManagementClients(
                ResourceManagementClient,
                SubscriptionClient,
                StorageClient,
                GalleryClient,
                //eventsClient,
                NetworkManagementClient,
                ComputeManagementClient,
                AuthorizationManagementClient);
            // GraphClient);
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

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        private SubscriptionClient GetSubscriptionClient()
        {
            return TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
        }

        private StorageManagementClient GetStorageManagementClient(RestTestFramework.MockContext context)
        {
            return testViaCsm
                ? context.GetServiceClient<StorageManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment())
                : TestBase.GetServiceClient<StorageManagementClient>(new RDFETestEnvironmentFactory());
        }

        private GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }

        //private EventsClient GetEventsClient()
        //{
        //    return TestBase.GetServiceClient<EventsClient>(this.csmTestFactory);
        //}

        private NetworkManagementClient GetNetworkManagementClientClient(RestTestFramework.MockContext context)
        {
            return testViaCsm
                ? context.GetServiceClient<NetworkManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment())
                : TestBase.GetServiceClient<NetworkManagementClient>(new RDFETestEnvironmentFactory());
        }

        private ComputeManagementClient GetComputeManagementClient(RestTestFramework.MockContext context)
        {
            return testViaCsm
                ? context.GetServiceClient<ComputeManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment())
                : TestBase.GetServiceClient<ComputeManagementClient>(new RDFETestEnvironmentFactory());
        }
    }
}
