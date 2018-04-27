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

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using TestUtilities = Microsoft.Azure.Test.TestUtilities;
using TestBase = Microsoft.Azure.Test.TestBase;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using System.Linq;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.SignalR;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Management.Internal.Resources;

namespace Microsoft.Azure.Commands.SignalR.Test
{
    class TestController : RMTestBase
    {
        public static TestController NewInstance => new TestController();

        private CSMTestEnvironmentFactory _csmTestFactory;

        private readonly EnvironmentSetupHelper _helper 
            = new EnvironmentSetupHelper();

        public Management.Resources.ResourceManagementClient ResourceManagementClient { get; private set; }

        public Management.Internal.Resources.ResourceManagementClient InternalResourceManagementClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public SignalRManagementClient SignalRManagementClient { get; private set; }

        public void RunPowerShellTest(ServiceManagemenet.Common.Models.XunitTracingInterceptor logger, params string[] scripts)
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

        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<CSMTestEnvironmentFactory> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {

            var providers = new Dictionary<string, string>();
            providers.Add("Microsoft.Resources", null);
            providers.Add("Microsoft.Features", null);
            providers.Add("Microsoft.Authorization", null);
            providers.Add("Microsoft.Compute", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providers, providersToIgnore);

            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (var context = MockContext.Start(callingClassType, mockName))
            {

                _csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize(_csmTestFactory);
                }

                SetupManagementClients(context);

                _helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();

                _helper.SetupModules(
                    AzureModule.AzureResourceManager,
                    _helper.RMProfileModule,
                    "AzureRM.SignalR.psd1",
                    "ScenarioTests\\" + callingClassName + ".ps1");
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

        protected void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient();
            InternalResourceManagementClient = GetResourceManagementClientInternal(context);
            //SubscriptionClient = GetSubscriptionClient();
            //GalleryClient = GetGalleryClient();
            //AuthorizationManagementClient = GetAuthorizationManagementClient();
            SignalRManagementClient = GetSignalRManagementClient(context);

            _helper.SetupManagementClients(
                ResourceManagementClient,
                InternalResourceManagementClient,
                //SubscriptionClient,
                //GalleryClient,
                //AuthorizationManagementClient,
                SignalRManagementClient);
        }

        bool testViaCsm = true; // Currently set to true, we will get this from Environment varialbe.

        private Management.Internal.Resources.ResourceManagementClient GetResourceManagementClientInternal(MockContext context)
            => testViaCsm
                ? context.GetServiceClient<Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment())
                : TestBase.GetServiceClient<Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient>(new RDFETestEnvironmentFactory());

        protected Management.Resources.ResourceManagementClient GetResourceManagementClient()
            => TestBase.GetServiceClient<Management.Resources.ResourceManagementClient>(_csmTestFactory);

        private SubscriptionClient GetSubscriptionClient()
            => TestBase.GetServiceClient<SubscriptionClient>(_csmTestFactory);

        private GalleryClient GetGalleryClient()
            => TestBase.GetServiceClient<GalleryClient>(_csmTestFactory);

        private AuthorizationManagementClient GetAuthorizationManagementClient()
            => TestBase.GetServiceClient<AuthorizationManagementClient>(_csmTestFactory);

        private SignalRManagementClient GetSignalRManagementClient(MockContext context)
            => context.GetServiceClient<SignalRManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
    }
}
