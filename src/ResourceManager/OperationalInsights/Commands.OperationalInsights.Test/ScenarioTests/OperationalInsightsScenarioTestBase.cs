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
using Microsoft.Azure.Management.OperationalInsights;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.OperationalInsights;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.OperationalInsights.Test
{
    public abstract class OperationalInsightsScenarioTestBase : RMTestBase
    {
        private EnvironmentSetupHelper helper;

        protected OperationalInsightsScenarioTestBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var operationalInsightsManagementClient = GetOperationalInsightsManagementClient(context);
            var resourceManagementClient = GetResourceManagementClient();
            var subscriptionsClient = GetSubscriptionClient();
            var galleryClient = GetGalleryClient();
            var authorizationManagementClient = GetAuthorizationManagementClient();

            helper.SetupManagementClients(
                operationalInsightsManagementClient,
                resourceManagementClient,
                subscriptionsClient,
                galleryClient,
                authorizationManagementClient);
        }

        protected void SetupDataClient(RestTestFramework.MockContext context)
        {
            var credentials = new ApiKeyClientCredentials("DEMO_KEY");
            var operationalInsightsDataClient = new OperationalInsightsDataClient(credentials, HttpMockServer.CreateInstance());

            helper.SetupManagementClients(operationalInsightsDataClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            RunPowerShellTest(true, false, scripts);
        }

        protected void RunDataPowerShellTest(params string[] scripts)
        {
            RunPowerShellTest(false, true, scripts);
        }

        protected void RunPowerShellTest(bool setupManagementClients, bool setupDataClient, params string[] scripts)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (RestTestFramework.MockContext context = RestTestFramework.MockContext.Start(TestUtilities.GetCallingClass(3), TestUtilities.GetCurrentMethodName(3)))
            {
                if (setupManagementClients)
                {
                    SetupManagementClients(context);
                    helper.SetupEnvironment(AzureModule.AzureResourceManager);
                }
                if (setupDataClient)
                {
                    SetupDataClient(context);
                }

                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\Common.ps1",
                    "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    helper.RMProfileModule,
                    helper.RMResourceModule,
                    helper.GetRMModulePath(@"AzureRM.OperationalInsights.psd1"),
                    "AzureRM.Resources.ps1");

                helper.RunPowerShellTest(scripts);
            }
        }

        protected OperationalInsightsManagementClient GetOperationalInsightsManagementClient(RestTestFramework.MockContext context)
        {
            return context.GetServiceClient<OperationalInsightsManagementClient>(RestTestFramework.TestEnvironmentFactory.GetTestEnvironment());
        }

        protected ResourceManagementClient GetResourceManagementClient()
        {
            return TestBase.GetServiceClient<ResourceManagementClient>(new CSMTestEnvironmentFactory());
        }

        protected SubscriptionClient GetSubscriptionClient()
        {
            return TestBase.GetServiceClient<SubscriptionClient>(new CSMTestEnvironmentFactory());
        }

        protected GalleryClient GetGalleryClient()
        {
            return TestBase.GetServiceClient<GalleryClient>(new CSMTestEnvironmentFactory());
        }

        protected AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return TestBase.GetServiceClient<AuthorizationManagementClient>(new CSMTestEnvironmentFactory());
        }
    }
}
