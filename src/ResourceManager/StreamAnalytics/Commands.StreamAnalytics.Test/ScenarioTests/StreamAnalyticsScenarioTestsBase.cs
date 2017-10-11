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
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Subscriptions;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using LegacyRMClient = Microsoft.Azure.Management.Resources;
using LegacyRMSubscription = Microsoft.Azure.Subscriptions;
using LegacyTest = Microsoft.Azure.Test;
using TestEnvironmentFactory = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestEnvironmentFactory;
using TestUtilities = Microsoft.Rest.ClientRuntime.Azure.TestFramework.TestUtilities;

namespace Microsoft.Azure.Commands.StreamAnalytics.Test
{
    public abstract class StreamAnalyticsScenarioTestsBase : RMTestBase
    {
        private EnvironmentSetupHelper helper;

        protected StreamAnalyticsScenarioTestsBase()
        {
            helper = new EnvironmentSetupHelper();
        }

        protected void SetupManagementClients(MockContext context)
        {
            var streamAnalyticsManagementClient = GetStreamAnalyticsManagementClient(context);
            var resourceManagementClient = GetResourceManagementClient();
            var subscriptionsClient = GetSubscriptionClient();
            var galleryClient = GetGalleryClient();
            var authorizationManagementClient = GetAuthorizationManagementClient();

            helper.SetupManagementClients(streamAnalyticsManagementClient,
                resourceManagementClient,
                subscriptionsClient,
                galleryClient,
                authorizationManagementClient);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            var callingClassType = TestUtilities.GetCallingClass(2);
            var mockName = TestUtilities.GetCurrentMethodName(2);
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("Microsoft.Resources", null);
            d.Add("Microsoft.Features", null);
            d.Add("Microsoft.Authorization", null);
            var providersToIgnore = new Dictionary<string, string>();
            providersToIgnore.Add("Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01");
            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, d, providersToIgnore);
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");

            using (MockContext context = MockContext.Start(callingClassType, mockName))
            {
                SetupManagementClients(context);
                var whatisthis = this.GetType().Name;

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager,
                    "ScenarioTests\\" + this.GetType().Name + ".ps1",
                    helper.RMProfileModule,
                    helper.GetRMModulePath(@"AzureRM.StreamAnalytics.psd1"));

                helper.RunPowerShellTest(scripts);
            }
        }

        protected StreamAnalyticsManagementClient GetStreamAnalyticsManagementClient(MockContext context)
        {
            return context.GetServiceClient<StreamAnalyticsManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
        }

        protected LegacyRMClient.ResourceManagementClient GetResourceManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<ResourceManagementClient>(new LegacyTest.CSMTestEnvironmentFactory());
        }

        protected LegacyRMSubscription.SubscriptionClient GetSubscriptionClient()
        {
            return LegacyTest.TestBase.GetServiceClient<SubscriptionClient>(new LegacyTest.CSMTestEnvironmentFactory());
        }

        protected GalleryClient GetGalleryClient()
        {
            return LegacyTest.TestBase.GetServiceClient<GalleryClient>(new LegacyTest.CSMTestEnvironmentFactory());
        }

        protected AuthorizationManagementClient GetAuthorizationManagementClient()
        {
            return LegacyTest.TestBase.GetServiceClient<AuthorizationManagementClient>(new LegacyTest.CSMTestEnvironmentFactory());
        }
    }
}
