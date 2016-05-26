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
using Microsoft.Azure.Test.HttpRecorder;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.TrafficManager.Test.ScenarioTests
{
    using Microsoft.Azure.Gallery;
    using Microsoft.Azure.Management.Authorization;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.TrafficManager;
    using Microsoft.Azure.Subscriptions;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using System;
    using System.Linq;
    using WindowsAzure.Commands.Test.Utilities.Common;

    public class TestController : RMTestBase
    {
        private CSMTestEnvironmentFactory csmTestFactory;

        private EnvironmentSetupHelper helper;

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public TrafficManagerManagementClient TrafficManagerManagementClient { get; private set; }

        public static TestController NewInstance
        {
            get
            {
                return new TestController();
            }
        }

        protected TestController()
        {
            this.helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients()
        {
            this.ResourceManagementClient = this.GetResourceManagementClient();
            this.SubscriptionClient = this.GetSubscriptionClient();
            this.GalleryClient = this.GetGalleryClient();
            this.AuthorizationManagementClient = this.GetAuthorizationManagementClient();
            this.TrafficManagerManagementClient = this.GetFeatureClient();

            this.helper.SetupManagementClients(
                this.ResourceManagementClient,
                this.SubscriptionClient,
                this.GalleryClient,
                this.AuthorizationManagementClient,
                this.TrafficManagerManagementClient);
        }

        public void RunPowerShellTest(params string[] scripts)
        {
            string callingClassType = TestUtilities.GetCallingClass(2);
            string mockName = TestUtilities.GetCurrentMethodName(2);

            this.RunPsTestWorkflow(
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
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);

            using (UndoContext context = UndoContext.Current)
            {
                context.Start(callingClassType, mockName);

                this.csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                this.helper.SetupEnvironment(AzureModule.AzureResourceManager);

                this.SetupManagementClients();

                string callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();

                this.helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + callingClassName + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath(@"AzureRM.TrafficManager.psd1"),
                    "AzureRM.Resources.ps1");

                try
                {
                    if (scriptBuilder != null)
                    {
                        string[] psScripts = scriptBuilder();

                        if (psScripts != null)
                        {
                            this.helper.RunPowerShellTest(psScripts);
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

        protected ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }

        private SubscriptionClient GetSubscriptionClient()
        {
            return TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
        }

        private GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }

        private TrafficManagerManagementClient GetFeatureClient()
        {
            return TestBase.GetServiceClient<TrafficManagerManagementClient>(this.csmTestFactory);
        }
    }
}
