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
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.WebSites;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class WebsitesController
    {
        private EnvironmentSetupHelper helper;
        private const string TenantIdKey = "TenantId";
        private const string DomainKey = "Domain";
        private const string AuthorizationApiVersion = "2014-07-01-preview";

        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public SubscriptionClient SubscriptionClient { get; private set; }

        public WebSiteManagementClient WebsitesManagementClient { get; private set; }

        public AuthorizationManagementClient AuthorizationManagementClient { get; private set; }
        
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

        public void RunPsTest(string callingClass, string currentMethod, params string[] scripts)
        {
            RunPsTestWorkflow(
                () => scripts,
                // no custom initializer
                null,
                // no custom cleanup 
                null,
                callingClass,
                currentMethod);
        }
        
        public void RunPsTestWorkflow(
            Func<string[]> scriptBuilder,
            Action<TestEnvironment> initialize,
            Action cleanup,
            string callingClassType,
            string mockName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Authorization", AuthorizationApiVersion);
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(false, d);

            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                if (initialize != null)
                {
                    initialize(TestEnvironmentFactory.GetTestEnvironment());
                }
                SetupManagementClients(context);
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

        private void SetupManagementClients(MockContext context)
        {
            ResourceManagementClient = GetResourceManagementClient(context);
            SubscriptionClient = GetSubscriptionClient(context);
            WebsitesManagementClient = GetWebsitesManagementClient(context);
            AuthorizationManagementClient = GetAuthorizationManagementClient(context);
            helper.SetupManagementClients(ResourceManagementClient,
                SubscriptionClient,
                WebsitesManagementClient,
                AuthorizationManagementClient
                );
        }
        
        private AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        private WebSiteManagementClient GetWebsitesManagementClient(MockContext context)
        {
            return context.GetServiceClient<WebSiteManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
        private SubscriptionClient GetSubscriptionClient(MockContext context)
        {
            return context.GetServiceClient<SubscriptionClient>(TestEnvironmentFactory.GetTestEnvironment());
        }
    }
}
