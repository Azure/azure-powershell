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

using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Gallery;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.WebApp.Test.ScenarioTests
{
    public class WebsitesController
    {

        private CSMTestEnvironmentFactory csmTestFactory;
        private EnvironmentSetupHelper helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }

        public WebSiteManagementClient WebsitesManagementClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }

        public GalleryClient GalleryClient { get; private set; }

        public string UserDomain { get; private set; }

        public static WebsitesController NewInstance
        {
            get
            {
                return new WebsitesController();
            }
        }


        public WebsitesController()
        {
            helper = new EnvironmentSetupHelper();
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
            d.Add("Microsoft.Authorization", "2014-07-01-preview");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(false, d);

            using (UndoContext context = UndoContext.Current)
            {
                context.Start(callingClassType, mockName);

                this.csmTestFactory = new CSMTestEnvironmentFactory();

                if (initialize != null)
                {
                    initialize(this.csmTestFactory);
                }

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);

                var callingClassName = callingClassType
                                        .Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                        .Last();
                helper.SetupModules(AzureModule.AzureResourceManager, 
                    "ScenarioTests\\Common.ps1", 
                    "ScenarioTests\\" + callingClassName + ".ps1", 
                    helper.RMProfileModule, 
                    helper.RMResourceModule, 
                    helper.GetRMModulePath(@"AzureRM.WebSites.psd1"));

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

        private void SetupManagementClients()
        {
            ResourceManagementClient = GetResourceManagementClient();
            SubscriptionClient = GetSubscriptionClient();
            WebsitesManagementClient = GetWebsitesManagementClient();
            AuthorizationManagementClient = GetAuthorizationManagementClient();
            GalleryClient = GetGalleryClient();

            helper.SetupManagementClients(ResourceManagementClient,
                SubscriptionClient,
                WebsitesManagementClient,
                AuthorizationManagementClient,
                GalleryClient
                );
        }


        private AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(this.csmTestFactory);
        }

        private ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(this.csmTestFactory);
        }

        private WebSiteManagementClient GetWebsitesManagementClient()
        {
            return TestBase.GetServiceClient<WebSiteManagementClient>(this.csmTestFactory);
        }
        private SubscriptionClient GetSubscriptionClient()
        {
            return TestBase.GetServiceClient<SubscriptionClient>(this.csmTestFactory);
        }

        private GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(this.csmTestFactory);
        }
    
    }
}
